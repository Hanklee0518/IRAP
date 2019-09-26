using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Printing;
using System.Configuration;
using System.IO;

using FastReport;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entities.Asimco;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.Editor
{
    public partial class frmPackageLabelPrint : frmCustomBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private WaitPackageSO mo = null;

        private bool isProgramChanged = false;

        public frmPackageLabelPrint()
        {
            InitializeComponent();

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                cboPrinters.Properties.Items.Add(PrinterSettings.InstalledPrinters[i]);
            }

            PrintDocument prntDoc = new PrintDocument();
            string printerName = prntDoc.PrinterSettings.PrinterName;
            if (ConfigurationManager.AppSettings["LabelPrinter"] != null)
            {
                printerName = ConfigurationManager.AppSettings["LabelPrinter"];
            }

            if (cboPrinters.Properties.Items.Count > 0)
            {
                cboPrinters.SelectedIndex =
                    cboPrinters.Properties.Items.IndexOf(printerName);
            }
            else
            {
                btnLabelPrint.Enabled = false;
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "当前电脑没有安装打印机，无法打印标签");
            }
        }

        public frmPackageLabelPrint(
            WaitPackageSO mo,
            List<PackageLine> lines) : this()
        {
            this.mo = mo;

            foreach (PackageLine line in lines)
            {
                cboPackageLines.Properties.Items.Add(line);
            }
        }

        /// <summary>
        /// 根据订单号和行号获取客户
        /// </summary>
        /// <param name="moNumber"></param>
        /// <param name="moLineNo"></param>
        /// <returns></returns>
        private List<PackageClient> GetCustomersFromPrdt(
            string moNumber, int moLineNo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<PackageClient> datas = new List<PackageClient>();

                AsimcoPackageClient.Instance.ufn_GetList_PackageClient(
                    IRAPUser.Instance.CommunityID,
                    moNumber,
                    moLineNo,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                }

                return datas;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 使用统一标签模板打印内外包装标签
        /// </summary>
        /// <param name="transactNo"></param>
        private void PrintBatchLabel(long transactNo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            #region 准备临时表
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "DataSource";
            dt.Columns.Add("Model", typeof(string));
            dt.Columns.Add("DrawingID", typeof(string));
            dt.Columns.Add("MaterialCategory", typeof(string));
            dt.Columns.Add("CartonQty", typeof(string));
            dt.Columns.Add("CartonProductNo", typeof(string));
            dt.Columns.Add("LotNumberTitle", typeof(string));
            dt.Columns.Add("LotNumber", typeof(string));
            dt.Columns.Add("SupplyCode", typeof(string));
            dt.Columns.Add("T134AlternateCode", typeof(string));
            dt.Columns.Add("BarCode", typeof(string));
            #endregion

            #region 获取外标签打印内容
            int errCode = 0;
            string errText = "";
            List<Carton> cartons = new List<Carton>();

            AsimcoPackageClient.Instance.ufn_GetList_Carton(
                IRAPUser.Instance.CommunityID,
                transactNo,
                IRAPUser.Instance.SysLogID,
                ref cartons,
                out errCode,
                out errText);
            WriteLog.Instance.Write(
                $"({errCode}]{errText}",
                strProcedureName);
            if (errCode != 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"获取标签打印信息时发生错误，请发起重打申请！");
                XtraMessageBox.Show(
                    $"错误信息：{errText}",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (cartons.Count == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"未获取到打印交易号 [{transactNo}] 的外包装标签数据，" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }
            #endregion

            foreach (Carton carton in cartons)
            {
                #region 将外标签打印内容添加到打印数据源中
                for (int i = 0; i < carton.PrintQty; i++)
                {
                    dt.Rows.Add(
                        carton.Model,
                        carton.DrawingID,
                        carton.MaterialCategory,
                        $"{carton.CartonQty} {carton.UnitOfMeasure}",
                        carton.CartonProductNo,
                        "批次号：",
                        carton.LotNumber,
                        carton.SupplyCode,
                        carton.T134AlternateCode,
                        $@"{carton.CartonProductNo}/{carton.CartonNumber}/{carton.CartonQty}");
                }
                #endregion

                #region 获取内包装标签列表
                List<BoxOfCarton> boxes = new List<BoxOfCarton>();
                AsimcoPackageClient.Instance.ufn_GetList_BoxOfCarton(
                    IRAPUser.Instance.CommunityID,
                    carton.CartonNumber,
                    IRAPUser.Instance.SysLogID,
                    ref boxes,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    $"({errCode}){errText}",
                    strProcedureName);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        $"获取标签打印信息时发生错误，请发起重打申请！");
                    XtraMessageBox.Show(
                        $"错误信息：{errText}",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (boxes.Count == 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        $"未获取到外包装号 [{carton.CartonNumber}] 的内包装标签数据，" +
                        "请联系系统开发人员，并发起重打申请！");
                    return;
                }
                #endregion

                foreach (BoxOfCarton box in boxes)
                {
                    #region 将内标签打印内容添加到打印数据源中
                    for (int i = 0; i < box.PrintQty; i++)
                    {
                        dt.Rows.Add(
                            box.Model,
                            box.DrawingID,
                            box.MaterialCategory,
                            $"{box.MaterialQty} {box.UnitOfMeasure}",
                            box.BoxMaterialNo,
                            "筒号：",
                            box.CylinderID,
                            box.SupplyCode,
                            box.T134AlternateCode,
                            box.CylinderID);
                    }
                    #endregion
                }
            }

            ds.Tables.Add(dt);

            Report rpt = new Report();

            #region 加载打印模板
            try
            {
                Stream ms = new MemoryStream(Properties.Resources.成品包装统一标签);
                rpt.Load(ms);
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    $"包装标签打印模板装载失败：{error.Message}，",
                    strProcedureName);
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"包装标签打印模板装载失败：{error.Message}，\n" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }
            #endregion

            rpt.RegisterData(ds);

            #region 打印包装标签
            PrinterSettings prntSettings = new PrinterSettings();
            prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

            if (rpt.Prepare())
            {
                    rpt.PrintPrepared(prntSettings);
            }
            #endregion

            IRAPMessageBox.Instance.ShowInformation("标签打印完成。");
        }

        /// <summary>
        /// 根据打印交易号，打印标签
        /// </summary>
        /// <param name="transactNo"></param>
        private void PrintLabel(long transactNo)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            int errCode = 0;
            string errText = "";
            List<Carton> cartons = new List<Carton>();

            AsimcoPackageClient.Instance.ufn_GetList_Carton(
                IRAPUser.Instance.CommunityID,
                transactNo,
                IRAPUser.Instance.SysLogID,
                ref cartons,
                out errCode,
                out errText);
            WriteLog.Instance.Write(
                $"({errCode}]{errText}",
                strProcedureName);
            if (errCode != 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"获取标签打印信息时发生错误，请发起重打申请！");
                XtraMessageBox.Show(
                    $"错误信息：{errText}",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (cartons.Count == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"未获取到打印交易号 [{transactNo}] 的外包装标签数据，" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }

            int t117LeafID = 0;
            string labelTemplate = "";

            foreach (Carton carton in cartons)
            {
                //if (t117LeafID != carton.T117LeafID)
                //{
                //    #region 根据 T117LeafID 获取标签打印模板
                //    TemplateContent template = new TemplateContent();
                //    IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                //        IRAPUser.Instance.CommunityID,
                //        carton.T117LeafID,
                //        IRAPUser.Instance.SysLogID,
                //        ref template,
                //        out errCode,
                //        out errText);
                //    WriteLog.Instance.Write(
                //        $"({errCode}){errText}",
                //        strProcedureName);
                //    if (errCode != 0 || template.TemplateFMTStr.Trim() == "")
                //    {
                //        IRAPMessageBox.Instance.ShowErrorMessage(
                //            $"无法获取到 [T117LeafID={carton.T117LeafID}] 的模板");
                //        labelTemplate = "";
                //        return;
                //    }
                //    else
                //    {
                //        t117LeafID = carton.T117LeafID;
                //        labelTemplate = template.TemplateFMTStr;
                //    }
                //    #endregion
                //}

                //if (labelTemplate != "")
                //{
                PrintCartonLabel(carton, labelTemplate);
                //}
            }

            IRAPMessageBox.Instance.ShowInformation("标签打印完成。");
        }

        private void PrintCartonLabel(Carton cartonInfo, string labelTemplate)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            Report rpt = new Report();
            try
            {
                Encoding encoding = Encoding.GetEncoding("GB2312");
                int stringLength = encoding.GetBytes(cartonInfo.MaterialCategory).Length;

                if (stringLength <= 30)
                {
                    Stream ms = new MemoryStream(Properties.Resources.外标签);
                    rpt.Load(ms);
                    //rpt.LoadFromString(labelTemplate);
                }
                else
                {
                    Stream ms = new MemoryStream(Properties.Resources.外标签_折行);
                    rpt.Load(ms);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    $"外包装标签打印模板装载失败：{error.Message}，",
                    strProcedureName);
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"外包装标签打印模板装载失败：{error.Message}，\n" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }

            #region 打印外包装标签
            PrinterSettings prntSettings = new PrinterSettings();
            //prntSettings.Copies = Convert.ToInt16(cartonInfo.PrintQty);
            prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

            rpt.Parameters.FindByName("Model").Value = cartonInfo.Model;
            rpt.Parameters.FindByName("DrawingID").Value = cartonInfo.DrawingID;
            rpt.Parameters.FindByName("MaterialCategory").Value = cartonInfo.MaterialCategory;
            rpt.Parameters.FindByName("CartonQty").Value = $"{cartonInfo.CartonQty} {cartonInfo.UnitOfMeasure}";
            rpt.Parameters.FindByName("CartonProductNo").Value = cartonInfo.CartonProductNo;
            rpt.Parameters.FindByName("LotNumber").Value = cartonInfo.LotNumber;
            rpt.Parameters.FindByName("SupplyCode").Value = cartonInfo.SupplyCode;
            rpt.Parameters.FindByName("T134AlternateCode").Value = cartonInfo.T134AlternateCode;
            rpt.Parameters.FindByName("BarCode").Value =
                $"{cartonInfo.CartonProductNo}/" +
                $"{cartonInfo.CartonNumber}/" +
                $"{cartonInfo.CartonQty.ToString()}";

            if (rpt.Prepare())
            {
                for (int i = 0; i < cartonInfo.PrintQty; i++)
                {
                    rpt.PrintPrepared(prntSettings);
                }
            }
            #endregion

            #region 获取内包装标签列表
            int errCode = 0;
            string errText = "";
            List<BoxOfCarton> boxes = new List<BoxOfCarton>();
            AsimcoPackageClient.Instance.ufn_GetList_BoxOfCarton(
                IRAPUser.Instance.CommunityID,
                cartonInfo.CartonNumber,
                IRAPUser.Instance.SysLogID,
                ref boxes,
                out errCode,
                out errText);
            WriteLog.Instance.Write(
                $"({errCode}){errText}",
                strProcedureName);
            if (errCode != 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"获取标签打印信息时发生错误，请发起重打申请！");
                XtraMessageBox.Show(
                    $"错误信息：{errText}",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (boxes.Count == 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"未获取到外包装号 [{cartonInfo.CartonNumber}] 的内包装标签数据，" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }
            #endregion

            #region 打印内标签
            int t117LeafID = 0;
            string boxLabelTemplate = "";

            foreach (BoxOfCarton box in boxes)
            {
                //if (t117LeafID != box.T117LeafID)
                //{
                //    #region 根据 T117LeafID 获取标签打印模板
                //    TemplateContent template = new TemplateContent();
                //    IRAPMDMClient.Instance.ufn_GetInfo_TemplateFMTStr(
                //        IRAPUser.Instance.CommunityID,
                //        box.T117LeafID,
                //        IRAPUser.Instance.SysLogID,
                //        ref template,
                //        out errCode,
                //        out errText);
                //    WriteLog.Instance.Write(
                //        $"({errCode}){errText}",
                //        strProcedureName);
                //    if (errCode != 0 || template.TemplateFMTStr.Trim() == "")
                //    {
                //        IRAPMessageBox.Instance.ShowErrorMessage(
                //            $"无法获取到 [T117LeafID={box.T117LeafID}] 的模板");
                //        boxLabelTemplate = "";
                //    }
                //    else
                //    {
                //        t117LeafID = box.T117LeafID;
                //        boxLabelTemplate = template.TemplateFMTStr;
                //    }
                //    #endregion
                //}

                //if (boxLabelTemplate != "")
                //{
                PrintBoxLabel(box, boxLabelTemplate);
                //}
            }
            #endregion
        }

        private void PrintBoxLabel(BoxOfCarton box, string labelTemplate)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            Report rpt = new Report();
            try
            {
                Encoding encoding = Encoding.GetEncoding("GB2312");
                int stringLength = encoding.GetBytes(box.MaterialCategory).Length;

                if (stringLength <= 20)
                {
                    Stream ms = new MemoryStream(Properties.Resources.内标签);
                    rpt.Load(ms);
                    //rpt.LoadFromString(labelTemplate);
                }
                else
                {
                    Stream ms = new MemoryStream(Properties.Resources.内标签_折行);
                    rpt.Load(ms);
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(
                    $"内包装标签打印模板装载失败：{error.Message}，",
                    strProcedureName);
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"内包装标签打印模板装载失败：{error.Message}，\n" +
                    "请联系系统开发人员，并发起重打申请！");
                return;
            }

            #region 打印内包装标签
            PrinterSettings prntSettings = new PrinterSettings();
            //prntSettings.Copies = Convert.ToInt16(box.PrintQty);
            prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

            rpt.Parameters.FindByName("Model").Value = box.Model;
            rpt.Parameters.FindByName("DrawingID").Value = box.DrawingID;
            rpt.Parameters.FindByName("MaterialCategory").Value = box.MaterialCategory;
            rpt.Parameters.FindByName("BoxQty").Value = $"{box.MaterialQty} {box.UnitOfMeasure}";
            rpt.Parameters.FindByName("MaterialCode").Value = box.BoxMaterialNo;
            rpt.Parameters.FindByName("LotNumber").Value = box.LotNumber;
            rpt.Parameters.FindByName("CylinderID").Value = box.CylinderID;
            rpt.Parameters.FindByName("SupplyCode").Value = box.SupplyCode;
            rpt.Parameters.FindByName("T134AlternateCode").Value = box.T134AlternateCode;
            rpt.Parameters.FindByName("BarCode").Value = box.CylinderID;

            if (rpt.Prepare())
            {
                for (int i = 0; i < box.PrintQty; i++)
                {
                    rpt.PrintPrepared(prntSettings);
                }
            }
            #endregion
        }

        private void frmPackageLabelPrint_Shown(object sender, EventArgs e)
        {
            if (mo != null)
            {
                #region 获取当前订单可配送的客户清单
                List<PackageClient> customers =
                    GetCustomersFromPrdt(
                        mo.MONumber,
                        mo.MOLineNo);

                int idx = -1;
                isProgramChanged = true;
                try
                {
                    for (int i = 0; i < customers.Count; i++)
                    {
                        if (customers[i].T105Code == mo.CustomerCode)
                        {
                            idx = i;
                        }
                        cboCustomers.Properties.Items.Add(customers[i]);
                    }
                }
                finally
                {
                    isProgramChanged = false;
                }

                cboCustomers.SelectedIndex = idx;
                cboCustomers.Enabled = idx < 0;
                #endregion
            }
        }

        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            PackageClient customer = cboCustomers.SelectedItem as PackageClient;
            if (customer != null)
            {
                edtCartonNumber.Value = customer.NumberOfCarton;
                edtBoxNumber.Value = customer.NumberOfBox;
            }
        }

        private void edtCartonNumber_Validating(object sender, CancelEventArgs e)
        {
            if (!isProgramChanged)
            {
                int t105LeafID = 0;
                long maxNumberOfCarton = 0;
                if (cboCustomers.SelectedItem == null)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        "未选择客户");
                    return;
                }
                else
                {
                    t105LeafID =
                        (cboCustomers.SelectedItem as PackageClient).T105LeafID;
                    maxNumberOfCarton =
                        (cboCustomers.SelectedItem as PackageClient).NumberOfCarton;
                }

                if (edtCartonNumber.Value > maxNumberOfCarton)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(
                        $"外箱数量不能大于 [{maxNumberOfCarton}] ！");
                    edtCartonNumber.Value = 0;
                    e.Cancel = true;
                    return;
                }

                string strProcedureName =
                    $"{className}.{MethodBase.GetCurrentMethod().Name}";

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    int errCode = 0;
                    string errText = "";
                    int cartonNumber = Convert.ToInt32(edtCartonNumber.Value);
                    int boxNumber = 0;

                    AsimcoPackageClient.Instance.usp_PokaYoke_Package(
                        IRAPUser.Instance.CommunityID,
                        mo.MONumber,
                        mo.MOLineNo,
                        t105LeafID,
                        cartonNumber,
                        IRAPUser.Instance.SysLogID,
                        out boxNumber,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}",
                        strProcedureName);
                    if (errCode == 0)
                    {
                        edtBoxNumber.Value = boxNumber;
                    }
                    else
                    {
                        IRAPMessageBox.Instance.ShowErrorMessage(errText);
                        cboCustomers_SelectedIndexChanged(cboCustomers, null);
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
        }

        private void btnLabelPrint_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            long numberOfCarton = 0;
            if (cboCustomers.SelectedItem == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("请选择客户！");
                cboCustomers.Focus();
                return;
            }
            else
            {
                PackageClient customer = cboCustomers.SelectedItem as PackageClient;
                numberOfCarton = customer.NumberOfCarton;
            }
            if (cboPackageLines.SelectedItem == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("请选择包装线！");
                cboPackageLines.Focus();
                return;
            }
            if (edtCartonNumber.Value <= 0)
            {
                IRAPMessageBox.Instance.ShowErrorMessage("外箱数量不能小于等于零！");
                edtCartonNumber.Focus();
                return;
            }
            if (Convert.ToInt64(edtCartonNumber.Value) > numberOfCarton)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    $"外箱数量不能大于 [{numberOfCarton}]");
                edtCartonNumber.Value = numberOfCarton;
                edtCartonNumber.Focus();
                return;
            }
            if (cboPrinters.SelectedItem == null)
            {
                IRAPMessageBox.Instance.ShowErrorMessage(
                    "请选择一台打印机！");
                cboPrinters.Focus();
                return;
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                long transactNo = 0;

                long numberOfBox = Convert.ToInt64(edtBoxNumber.Value);
                long cartonNumber = Convert.ToInt64(edtCartonNumber.Value);
                PackageClient customer = cboCustomers.SelectedItem as PackageClient;
                PackageLine line = cboPackageLines.SelectedItem as PackageLine;

                AsimcoPackageClient.Instance.usp_SaveFact_PackagePrint(
                    IRAPUser.Instance.CommunityID,
                    mo.MONumber,
                    mo.MOLineNo,
                    0,
                    cartonNumber,
                    customer.T105LeafID,
                    line.T134LeafID,
                    numberOfBox,
                    IRAPUser.Instance.SysLogID,
                    ref transactNo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    $"({errCode}){errText}",
                    strProcedureName);
                if (errCode == 0)
                {
                    WriteLog.Instance.Write($"得到打印交易号 [{transactNo}]。", strProcedureName);
                    //PrintLabel(transactNo);
                    PrintBatchLabel(transactNo);

                    btnCancel.PerformClick();
                }
                else
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void cboPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            IRAPConst.Instance.SaveParams(
                "LabelPrinter",
                (string)cboPrinters.SelectedItem);
        }
    }
}
