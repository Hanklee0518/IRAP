using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Configuration;
using System.Reflection;
using System.IO;

using FastReport;
using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Entities.Asimco;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage.UserControls
{
    public partial class ucPackageLabelPrintAgain : XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public ucPackageLabelPrintAgain()
        {
            InitializeComponent();
        }

        private DataSet GenerateTempleDataSet()
        {
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
            ds.Tables.Add(dt);
            #endregion

            return ds;
        }

        private void ucPackageLabelPrintAgain_Load(object sender, EventArgs e)
        {
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
                btnPrintBoxLabel.Enabled = false;
                XtraMessageBox.Show(
                    "当前电脑中没有安装打印机，无法打印标签！",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnPrintBoxLabel_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            if (edtBoxNumber.Text.Trim() == "")
            {
                XtraMessageBox.Show(
                    "请输入需要补打的内包装筒号",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                edtBoxNumber.Focus();
                return;
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<RePrintBoxNumber> items = new List<RePrintBoxNumber>();

                #region 获取内标签打印内容
                AsimcoPackageClient.Instance.usp_RePrintBoxNumber(
                    IRAPUser.Instance.CommunityID,
                    edtBoxNumber.Text.Trim(),
                    IRAPUser.Instance.SysLogID,
                    ref items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    edtBoxNumber.Text = "";
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtBoxNumber.Focus();
                    return;
                }

                if (items.Count == 0)
                {
                    edtBoxNumber.Text = "";
                    XtraMessageBox.Show(
                        $"没有找到筒号 [{edtBoxNumber.Text}] 的标签信息！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtBoxNumber.Focus();
                    return;
                }
                #endregion

                #region 打印内标签

                DataSet ds = GenerateTempleDataSet();
                #region 将内标签打印内容添加到打印数据源中
                foreach (RePrintBoxNumber item in items)
                {
                    ds.Tables["DataSource"].Rows.Add(
                        item.Model,
                        item.DrawingID,
                        item.MaterialCategory,
                        $"{item.MaterialQty} {item.UnitOfMeasure}",
                        item.BoxMaterialNo,
                        "筒号：",
                        item.CylinderID,
                        item.SupplyCode,
                        item.T134AlternateCode,
                        item.CylinderID);
                }
                #endregion

                #region 加载打印模板
                Report rpt = new Report();
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

                #region 打印
                PrinterSettings prntSettings = new PrinterSettings();
                prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

                if (rpt.Prepare())
                {
                    rpt.PrintPrepared(prntSettings);
                }
                #endregion

                #endregion

                XtraMessageBox.Show(
                    "内标签打印完成。",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                edtBoxNumber.Text = "";
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void rbByCartonNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (rbByCartonNumber.Checked)
            {
                edtCartonNumber.Enabled = true;
                edtMONumber.Enabled = false;
                edtMOLineNo.Enabled = false;
                edtCartonNumber.Focus();
            }
            else
            {
                edtCartonNumber.Enabled = false;
                edtMONumber.Enabled = true;
                edtMOLineNo.Enabled = true;
                edtMONumber.Focus();
            }
        }

        private void btnPrintCartonLabel_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            string cartonNumber = "";
            string moNumber = "";
            int moLineNo = 0;

            #region 外包装标签内容查询条件校验
            if (rbByCartonNumber.Checked)
            {
                if (edtCartonNumber.Text.Trim() == "")
                {
                    XtraMessageBox.Show(
                        "请输入外包装标签号！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    edtCartonNumber.Focus();
                    return;
                }
                else
                {
                    cartonNumber = edtCartonNumber.Text.Trim();
                }
            }
            if (rbByMONumber.Checked)
            {
                if (edtMONumber.Text.Trim() == "")
                {
                    XtraMessageBox.Show(
                        "请输入订单号！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    edtMONumber.Focus();
                    return;
                }
                else
                {
                    moNumber = edtMONumber.Text.Trim();
                }

                int.TryParse(edtMOLineNo.Text.Trim(), out moLineNo);
                if (moLineNo <= 0)
                {
                    XtraMessageBox.Show(
                        "请输入正确的订单行号！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    edtMOLineNo.Focus();
                    return;
                }
            }
            #endregion

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                List<RePrintCartonNumber> items = new List<RePrintCartonNumber>();

                #region 获取外标签打印内容
                AsimcoPackageClient.Instance.usp_RePrintCartonNumber(
                    IRAPUser.Instance.CommunityID,
                    moNumber,
                    moLineNo,
                    cartonNumber,
                    IRAPUser.Instance.SysLogID,
                    ref items,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    edtCartonNumber.Text = "";
                    edtMONumber.Text = "";
                    edtMOLineNo.Text = "";
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    if (rbByCartonNumber.Checked)
                    {
                        edtCartonNumber.Focus();
                    }
                    else
                    {
                        edtMONumber.Focus();
                    }
                    return;
                }

                if (items.Count == 0)
                {
                    edtCartonNumber.Text = "";
                    edtMONumber.Text = "";
                    edtMOLineNo.Text = "";
                    XtraMessageBox.Show(
                        $"没有找到需要打印的外标签信息！",
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    if (rbByCartonNumber.Checked)
                    {
                        edtCartonNumber.Focus();
                    }
                    else
                    {
                        edtMONumber.Focus();
                    }
                    return;
                }
                #endregion

                #region 打印外标签

                DataSet ds = GenerateTempleDataSet();
                #region 将外标签打印内容添加到打印数据源中
                foreach (RePrintCartonNumber item in items)
                {
                    ds.Tables["DataSource"].Rows.Add(
                        item.Model,
                        item.DrawingID,
                        item.MaterialCategory,
                        $"{item.CartonQty} {item.UnitOfMeasure}",
                        item.CartonProductNo,
                        "批次号：",
                        item.LotNumber,
                        item.SupplyCode,
                        item.T134AlternateCode,
                        $@"{item.CartonProductNo}/{item.CartonNumber}/{item.CartonQty}");
                }
                #endregion

                #region 加载打印模板
                Report rpt = new Report();
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

                #region 打印
                PrinterSettings prntSettings = new PrinterSettings();
                prntSettings.PrinterName = (string)cboPrinters.SelectedItem;

                if (rpt.Prepare())
                {
                    rpt.PrintPrepared(prntSettings);
                }
                #endregion

                #endregion

                XtraMessageBox.Show(
                    "外标签打印完成。",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                edtCartonNumber.Text = "";
                edtMONumber.Text = "";
                edtMOLineNo.Text = "";
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
