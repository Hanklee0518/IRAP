using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace SendMessageToESB
{
    class Program
    {
        static void Main(string[] args)
        {
            string brokeUri =
                $"failover://(tcp://192.168.1.2:61616)?&" +
                "transport.startupMaxReconnectAttempts=1&" +
                "transport.initialReconnectDelay=10";

            try
            {
                IConnectionFactory factory = new ConnectionFactory(brokeUri);
                IConnection esbConn = factory.CreateConnection();
                ISession session = esbConn.CreateSession();
                IMessageProducer prod =
                    session.CreateProducer(
                        new ActiveMQQueue(
                            "SCESPrint_Test"));

                ITextMessage message = prod.CreateTextMessage();
                message.Text = "<Softland><Head><ExCode>PrintZPL</ExCode><CorrelationID>54P9L00000DVKD000G</CorrelationID><CommunityID>60036</CommunityID><SysLogID>1</SysLogID><UserCode>003</UserCode><AgencyLeaf>41464</AgencyLeaf><RoleLeaf>282</RoleLeaf><StationID /><UnixTime>1553837930</UnixTime></Head><Body><ROOT><Action Ordinal=\"\" Action=\"ZebraPrint\" PrinterName=\"ZebraPrinter\" Data=\"^XA ^MCY ^XZ ^XA ^FWN^CFD,24^PW1200^LH0,0 ^CI0^PR2^MNY^MTT^MMT^MD0^PON^PMN^LRN ^XZ ^XA ^MCY ^XZ ^XA ^DFR:TEMP_FMT.ZPL ^LRN ^A0N,74,86^FO78,50^FD3210-13170^FS ^FO40,139^GB1200,1,1,B,0^FS ^FO40,294^GB700,1,1,B,0^FS ^BY5^FO59,155^BCN,118,N,N,N^FD&gt;:3210-13170^FS ^FO943,158 ^BQ,3,7.0  ^FDQA,54P9L00000DVKD000G^FS ^A0N,45,26^FO887,375^FD54P9L00000DVKD000G^FS ^A0N,50,50^FO62,318^FD横梁座^FS ^A0N,50,50^FO65,420^FDSUP:^FS ^A0N,50,50^FO443,419^FDQTY:^FS ^A0N,50,50^FO747,414^FDREV:V^FS ^XZ ^XA ^XFR:TEMP_FMT.ZPL ^PQ1,1,1,Y ^XZ ^XA ^IDR:TEMP_FMT.ZPL ^XZ\" /></ROOT></Body><Log /></Softland>";
                message.Properties.SetString("ESBServerAddr", "");
                message.Properties.SetString("ExCode", "PrintZPL");
                message.Properties.SetString("Filter", "Test");
                message.NMSCorrelationID = "12345678";
                message.NMSType = "XML";
                prod.Send(message, MsgDeliveryMode.Persistent, MsgPriority.Normal, TimeSpan.MinValue);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            Console.ReadKey();
        }
    }
}
