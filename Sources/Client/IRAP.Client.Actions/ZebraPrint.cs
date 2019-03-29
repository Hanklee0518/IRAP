using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Drawing.Printing;

using IRAP.Global;
using Softland.Tools.Print;

namespace IRAP.Client.Actions
{
    /// <summary>
    /// 斑马打印机输出
    /// </summary>
    public class ZebraPrintAction : CustomAction, IUDFAction
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string printerName = "";
        private string data = "";

        public ZebraPrintAction(
            XmlNode actionParams,
            ExtendEventHandler extendAction) : base(actionParams, extendAction)
        {
            if (actionParams.Attributes["PrinterName"] != null)
            {
                printerName = actionParams.Attributes["PrinterName"].Value;
            }
            if (actionParams.Attributes["Data"]!= null)
            {
                data = actionParams.Attributes["Data"].Value;
            }
        }

        private bool FindPrinter(string prntName)
        {
            bool rlt = false;
            foreach (string prnt in PrinterSettings.InstalledPrinters)
            {
                if (prnt == prntName)
                {
                    return true;
                }
            }
            return rlt;
        }

        public void DoAction(
            bool printerMode,
            bool canGenerate,
            string generatePrinterName,
            string printerName)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            if (this.printerName.Trim() == "")
            {
                throw new Exception("未指定打印机");
            }
            if (!FindPrinter(this.printerName))
            {
                throw new Exception($"未安装打印机[{this.printerName}]");
            }
            if (data.Trim() == "")
            {
                throw new Exception("未指定打印内容");
            }

            try
            {
                ZebraPrintHelper.PrintWithDRV(data, this.printerName, false);
            }
            catch (Exception error)
            {
                throw new Exception($"打印时出错：{error.Message}");
            }
        }
    }

    public class ZebraPrintFactory :
        CustomActionFactory, IUDFActionFactory
    {
        public IUDFAction CreateAction(
            XmlNode actionParams, 
            ExtendEventHandler extendAction)
        {
            return
                new ZebraPrintAction(
                    actionParams,
                    extendAction);
        }
    }
}
