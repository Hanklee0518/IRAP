using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Softland.Tools.Print
{
    public enum ProgrammingLanguage
    {
        ZPL,
        EPL,
        CPCL,
    };

    public enum DeviceType
    {
        COM,
        LPT,
        DRV,
        TCP,
    };

    public enum LogType
    {
        Error,
        Print,
    };

    public class ZebraPrintHelper
    {
        /// <summary>
        /// 斑马打印助手，支持 LPT/COM/USB/TCP 
        /// 四种模式，适用于标签、票据、条码打印
        /// </summary>
        public static class ZebraPrintHelper
        {
            internal class KeyValue
            {
                public char Key { get; set; }
                public int Value { get; set; }
            }

            #region 定义私有字段
            /// <summary>
            /// 线程锁，防止多线程调用
            /// </summary>
            private static object syncRoot = new object();
            /// <summary>
            /// ZPL 压缩字典
            /// </summary>
            private static List<KeyValue> compressDictionary =
                new List<KeyValue>();
            #endregion

            #region 定义属性
            public static float TcpLabelMaxHeightCM { get; set; }
            public static int TcpPrinterDPI { get; set; }
            public static string TcpIPAddress { get; set; }
            public static int TcpPort { get; set; }
            public static int Copies { get; set; }
            public static int Port { get; set; }
            public static string PrinterName { get; set; }
            public static bool IsWriteLog { get; set; }
            public static DeviceType PrinterType { get; set; }
            public static ProgrammingLanguage PrinterProgrammingLanguage { get; set; }
            /// <summary>
            /// 日志保存目录，Web 应用注意不能放在 BIN 目录下
            /// </summary>
            public static string LogsDirectory { get; set; }
            public static byte[] GraphBuffer { get; set; }
            public static int GraphWidth { get; set; }
            public static int GraphHeight { get; set; }

            private static int RowSize
            {
                get
                {
                    return (((GraphWidth) + 31) >> 5) << 2;
                }
            }
            private static int RowRealBytesCount
            {
                get
                {
                    if ((GraphWidth % 8) > 0)
                    {
                        return GraphWidth / 8 + 1;
                    }
                    else
                    {
                        return GraphWidth / 8;
                    }
                }
            }
            #endregion

            #region 静态构造方法
            static ZebraPrintHelper()
            {
                InitCompressCode();
                Port = 1;
                GraphBuffer = new byte[0];
                IsWriteLog = false;
                LogsDirectory = "logs";
                PrinterProgrammingLanguage = ProgrammingLanguage.ZPL;
            }

            private static void InitCompressCode()
            {
                for (int i = 0; i < 19; i++)
                {
                    compressDictionary.Add(
                        new KeyValue()
                        {
                            Key = Convert.ToChar(71 + i),
                            Value = i + 1,
                        });
                }
                for (int i = 0; i < 19; i++)
                {
                    compressDictionary.Add(
                        new KeyValue()
                        {
                            Key = Convert.ToChar(103 + i),
                            Value = (i + 1) * 20,
                        });
                }
            }
            #endregion

            #region 日志记录方法
            private static void WriteLog(string text, LogType logType)
            {
                string endTag = $"\r\n{new string('=', 80)}\r\n";
                string path =
                    $"{LogsDirectory}\\{DateTime.Now.ToString("yyyy-MM-dd")}" +
                    $"-{logType}.log";

                if (!Directory.Exists(LogsDirectory))
                {
                    Directory.CreateDirectory(LogsDirectory);
                }
                if (logType == LogType.Error)
                {
                    File.AppendAllText(
                        path,
                        $"{text}-{endTag}",
                        Encoding.UTF8);
                }
                if (logType== LogType.Print)
                {
                    File.AppendAllText(
                        path,
                        $"{text}-{endTag}",
                        Encoding.UTF8);
                }
            }
            #endregion
        }
    }
}
