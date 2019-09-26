using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;


namespace IRAP.BL.OPCGateway
{
    //MessageInspector Class

    public class MessageInspector : IDispatchMessageInspector
    {
        private ServiceEndpoint _serviceEndpoint;
        private string org = string.Empty;
        public MessageInspector(ServiceEndpoint serviceEndpoint)
        {
            _serviceEndpoint = serviceEndpoint;
        }

        /// <summary>
        /// Called when an inbound message been received
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="channel">The incoming channel.</param>
        /// <param name="instanceContext">The current service instance.</param>
        /// <returns>
        /// The object used to correlate stateMsg. 
        /// This object is passed back in the method.
        /// </returns>
        public object AfterReceiveRequest(ref Message request,
                                              IClientChannel channel,
                                              InstanceContext instanceContext)
        {
            StateMessage stateMsg = null;
            HttpRequestMessageProperty requestProperty = null;
            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
            {
                requestProperty = request.Properties[HttpRequestMessageProperty.Name]
                                  as HttpRequestMessageProperty;
            }

            if (requestProperty != null)
            {
                var origin = requestProperty.Headers["Origin"];
                org = origin;
                if (!string.IsNullOrEmpty(origin))
                {
                    stateMsg = new StateMessage();
                    // if a cors options request (preflight) is detected, 
                    // we create our own reply message and don't invoke any 
                    // operation at all.
                    if (requestProperty.Method == "OPTIONS")
                    {
                        stateMsg.Message = Message.CreateMessage(request.Version, requestProperty.Headers["Origin"]);
                    }

                    request.Properties.Add("CrossOriginResourceSharingState", stateMsg);
                }
            }

            return stateMsg;
        }

        /// <summary>
        /// Called after the operation has returned but before the reply message
        /// is sent.
        /// </summary>
        /// <param name="reply">The reply message. This value is null if the 
        /// operation is one way.</param>
        /// <param name="correlationState">The correlation object returned from
        ///  the method.</param>
        public void BeforeSendReply(ref  Message reply, object correlationState)
        {
            var stateMsg = correlationState as StateMessage;

            if (stateMsg != null)
            {
                if (stateMsg.Message != null)
                {
                    reply = stateMsg.Message;
                }

                HttpResponseMessageProperty responseProperty = null;

                if (reply.Properties.ContainsKey(HttpResponseMessageProperty.Name))
                {
                    responseProperty = reply.Properties[HttpResponseMessageProperty.Name]
                                       as HttpResponseMessageProperty;
                }

                if (responseProperty == null)
                {
                    responseProperty = new HttpResponseMessageProperty();
                    reply.Properties.Add(HttpResponseMessageProperty.Name,
                                         responseProperty);
                }

                // Access-Control-Allow-Origin should be added for all cors responses
                // responseProperty.Headers.Set("Access-Control-Allow-Origin", org);
                
                 responseProperty.Headers.Set("Access-Control-Allow-Origin", "*");

                responseProperty.Headers.Set("Allow", "HEAD,GET,POST,OPTIONS");
               // responseProperty.Headers.Set("Access-Control-Allow-Credentials", "true");
                if (stateMsg.Message != null)
                {
                    // the following headers should only be added for OPTIONS requests
                   
                    responseProperty.Headers.Set("Access-Control-Allow-Methods",
                                                 "DELETE,GET,HEAD,OPTIONS,PATCH,POST,PUT");
                    responseProperty.Headers.Set("Content-Type", "application/json; charset=utf-8");
                    responseProperty.Headers.Set("Access-Control-Allow-Headers",
                              "Content-Type, Accept, Authorization, x-requested-with,X-URL-PATH,x-access-token");
                }
            }
        }
    }

    class StateMessage
    {
        public Message Message;
    }

    public class BehaviorAttribute : Attribute, IEndpointBehavior,
                                   IOperationBehavior
    {
        public void Validate(ServiceEndpoint endpoint) { }

        public void AddBindingParameters(ServiceEndpoint endpoint,
                                 BindingParameterCollection bindingParameters) { }

        /// <summary>
        /// This service modify or extend the service across an endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint that exposes the contract.</param>
        /// <param name="endpointDispatcher">The endpoint dispatcher to be
        /// modified or extended.</param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint,
                                          EndpointDispatcher endpointDispatcher)
        {
            // add inspector which detects cross origin requests
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(
                                                   new MessageInspector(endpoint));
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint,
                                        ClientRuntime clientRuntime) { }

        public void Validate(OperationDescription operationDescription) { }

        public void ApplyDispatchBehavior(OperationDescription operationDescription,
                                          DispatchOperation dispatchOperation) { }

        public void ApplyClientBehavior(OperationDescription operationDescription,
                                        ClientOperation clientOperation) { }

        public void AddBindingParameters(OperationDescription operationDescription,
                                  BindingParameterCollection bindingParameters) { }

    }
}

