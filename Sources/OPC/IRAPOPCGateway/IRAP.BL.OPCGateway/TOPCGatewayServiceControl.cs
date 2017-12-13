﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Diagnostics;
using System.Reflection;

using IRAP.OPC.Entity;
using IRAP.OPC.Library;

namespace IRAP.BL.OPCGateway
{
    public class TOPCGatewayServiceControl
    {
        private static TOPCGatewayServiceControl _instance = null;

        public static TOPCGatewayServiceControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TOPCGatewayServiceControl();
                return _instance;
            }
        }

        private ServiceHost _host = null;
        private bool statueOPCService = false;
        private List<TKepServerListener> listeners = new List<TKepServerListener>();

        private TOPCGatewayServiceControl() { }

        public bool OPCServiceStatue
        {
            get { return statueOPCService; }
        }

        public void Start()
        {
            // 打开 OPC 网关 WebAPI 服务
            try
            {
                _host = new ServiceHost(typeof(OPCGatewayService));
                _host.Open();
                statueOPCService = true;
                Debug.WriteLine("OPC 网关服务启动完成");
            }
            catch (Exception error)
            {
                Debug.WriteLine("OPC 网关服务启动失败，原因：[{0}]", error.Message);
            }

            TIRAPOPCDevices.Instance.Load(TOPCGatewayGlobal.Instance.ConfigurationFile);

            // 根据配置文件内容，创建 KepServer 连接
            TIRAPOPCServers.Instance.Load(TOPCGatewayGlobal.Instance.ConfigurationFile);
            foreach (TIRAPOPCServer server in TIRAPOPCServers.Instance.Servers)
            {
                TKepServerListener listener = new TKepServerListener();
                listener.Init(server.Address, server.Name);
                listeners.Add(listener);
            }
        }

        public void Stop()
        {
            // 终止 OPC 网关 WebAPI 服务 
            try
            {
                _host.Close();
                _host = null;
                Debug.WriteLine("OPC 网关服务关闭");
            }
            finally
            {
                statueOPCService = false;
            }

            // 终止 KepServer 消息侦听
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                TKepServerListener listener = listeners[i];
                listeners.Remove(listener);

                listener = null;
            }
        }
    }
}