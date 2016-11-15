﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Reflection;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.SCES;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;
using IRAP.Client.Global.GUI.Dialogs;

namespace IRAP.Client.GUI.SCES
{
    public partial class frmMaterialsToDeliver : IRAP.Client.Global.frmCustomBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private List<ProductionWorkOrder> orders = new List<ProductionWorkOrder>();
        private ProductionWorkOrder order = null;
        private List<MaterialToDeliver> materials = new List<MaterialToDeliver>();
        private DstDeliveryStoreSite dstStoreSite = null;
        private string OpNode = "";
        /// <summary>
        /// 需要打印配送单的排产订单事实编号
        /// </summary>
        private long orderFactID = 0;

        public frmMaterialsToDeliver()
        {
            InitializeComponent();
        }

        public frmMaterialsToDeliver(long orderFactID, DstDeliveryStoreSite storeSite, string opNode)
            : this()
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            this.orderFactID = orderFactID;
            this.dstStoreSite = storeSite;
            this.OpNode = opNode;

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                try
                {
                    IRAPSCESClient.Instance.ufn_GetList_ProductionWorkOrdersToDeliverMaterial(
                        IRAPUser.Instance.CommunityID,
                        storeSite.T173LeafID,
                        IRAPUser.Instance.SysLogID,
                        orderFactID,
                        ref orders,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    XtraMessageBox.Show(
                        string.Format(
                            "获取订单信息时发生错误：{0}", 
                            error.Message),
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            grdOrders.DataSource = orders;
            for (int i = 0; i < grdvOrders.Columns.Count; i++)
            {
                grdvOrders.Columns[i].BestFit();
            }
        }

        private void frmMaterialToDeliverPreview_Shown(object sender, EventArgs e)
        {
            if (orders.Count == 0)
            {
                Close();
                return;
            }
            else
            {
                order = orders[0];
            }

            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPSCESClient.Instance.ufn_GetList_MaterialToDeliverForPWO(IRAPUser.Instance.CommunityID,
                        orderFactID,
                        IRAPUser.Instance.SysLogID,
                        ref materials,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode != 0)
                    {
                        ShowMessageBox.Show(
                            errText, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        grdMaterials.DataSource = materials;
                        for (int i = 0; i < grdvMaterials.Columns.Count; i++)
                        {
                            grdvMaterials.Columns[i].BestFit();
                        }

                        lblNoneMaterialInStore.Visible = materials.Count <= 0;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    ShowMessageBox.Show(
                        error.Message, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                #region 设置当前工单可以操作的功能
                if (materials.Count > 0)
                {
                    switch (materials[0].ActionCode)
                    {
                        case 1:
                            btnPrint.Visible = true;
                            break;
                        case 2:
                            btnSpiliteOrderNotify.Visible = true;
                            break;
                        case 3:
                            if (materials[0].ATPQty <= materials[0].ContainerCapacity)
                                btnSpiliteOrderNotify.Visible = true;
                            else
                                btnSpilitePKGNotify.Visible = true;
                            break;
                        case 9:
                            ShowMessageBox.Show(
                                string.Format(
                                    "[{0}]车间无空闲库位，请稍后再配送！", 
                                    materials[0].DstWorkShopDesc),
                                "系统信息",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            btnPrint.Visible = false;
                            btnSpiliteOrderNotify.Visible = false;
                            btnSpilitePKGNotify.Visible = false;
                            break;
                        default:
                            break;
                    }
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSpilitePKGNotify_Click(object sender, EventArgs e)
        {
            ShowMessageBox.Show(
                "请将库位上的物料保留配送所需数量，剩余的物料移到其它库位中！", 
                "系统信息", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Exclamation);
            btnClose.PerformClick();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 调用存储过程，在系统中登记当前生产工单的物料配送信息已经被打印
                bool saveSucccessed = false;
                saveSucccessed = SavePWOMaterialDeliver();
                #endregion

                if (saveSucccessed)
                {
                    #region 打印
                    MemoryStream ms;
                    switch (IRAPUser.Instance.CommunityID)
                    {
                        case 60023:
                            ms = new MemoryStream(Properties.Resources.WIPTransferTrackSheet_60023);
                            break;
                        default:
                            ms = new MemoryStream(Properties.Resources.WIPTransferTrackSheet);
                            break;
                    }
                    report.Load(ms);

                    try
                    {
                        switch (IRAPUser.Instance.CommunityID)
                        {
                            case 60023:  // 新康达打印的生产流转卡
                                #region 获取生产流传卡打印的要素
                                int errCode = 0;
                                string errText = "";
                                List<ProductionFlowCard> datas = new List<ProductionFlowCard>();
                                IRAPSCESClient.Instance.ufn_GetList_ProductionFlowCard(
                                    IRAPUser.Instance.CommunityID,
                                    orderFactID,
                                    IRAPUser.Instance.SysLogID,
                                    ref datas,
                                    out errCode,
                                    out errText);
                                WriteLog.Instance.Write(
                                    string.Format("({0}){1}", errCode, errText),
                                    strProcedureName);
                                if (errCode != 0)
                                {
                                    ShowMessageBox.Show(
                                        errText,
                                        "获取流转卡打印要素",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    return;
                                }
                                #endregion

                                #region 向内存表中插入记录，以便生成打印内容
                                DataSet ds = new DataSet();
                                DataTable dt = new DataTable();
                                dt.TableName = "ProductionFlowCard";
                                dt.Columns.Add("Ordinal", typeof(int));
                                dt.Columns.Add("T102Code", typeof(string));
                                dt.Columns.Add("T102NodeName", typeof(string));
                                dt.Columns.Add("PWONo", typeof(string));
                                dt.Columns.Add("PWOIssuingFactID", typeof(long));
                                dt.Columns.Add("MONumber", typeof(string));
                                dt.Columns.Add("OrderQty", typeof(int));
                                dt.Columns.Add("StartTime", typeof(string));
                                dt.Columns.Add("MaterialList", typeof(string));
                                dt.Columns.Add("T134NodeName", typeof(string));
                                dt.Columns.Add("T211NodeName", typeof(string));
                                dt.Columns.Add("T216Name", typeof(string));
                                dt.Columns.Add("T133Name", typeof(string));
                                dt.Columns.Add("T106Name", typeof(string));
                                dt.Columns.Add("Remark", typeof(string));

                                foreach (ProductionFlowCard data in datas)
                                {
                                    dt.Rows.Add(
                                        data.Ordinal,
                                        data.T102Code,
                                        data.T102NodeName,
                                        data.PWONo,
                                        data.PWOIssuingFactID,
                                        data.MONumber,
                                        data.OrderQty,
                                        data.StartTime,
                                        data.MaterialList,
                                        data.T134NodeName,
                                        data.T211NodeName,
                                        data.T216Name,
                                        data.T133Name,
                                        data.T106Name,
                                        data.Remark);
                                }

                                ds.Tables.Add(dt);
                                #endregion

                                report.RegisterData(ds);
                                report.GetDataSource("ProductionFlowCard").Enabled = true;

                                break;
                            default:    // 仪征打印的生产流转卡
                                report.Parameters.FindByName("BarCode").Value = order.PWONo;
                                report.Parameters.FindByName("DeliveryWorkshop").Value = "";
                                report.Parameters.FindByName("StorehouseCode").Value =
                                    string.Format(
                                        "{0}({1})",
                                        materials[0].T173Name,
                                        materials[0].T173Code);
                                report.Parameters.FindByName("T106Code").Value = materials[0].AtStoreLocCode;
                                report.Parameters.FindByName("WorkshopName").Value =
                                    string.Format(
                                        "{0}({1})",
                                        materials[0].DstWorkShopDesc,
                                        materials[0].DstWorkShopCode);
                                report.Parameters.FindByName("ProductLine").Value = order.T134Name;
                                report.Parameters.FindByName("AdvicedPickedQty").Value = materials[0].SuggestedQuantityToPick;
                                report.Parameters.FindByName("StartingDate").Value = order.PlannedStartDate;
                                report.Parameters.FindByName("CompletingDate").Value = order.PlannedCloseDate;
                                report.Parameters.FindByName("PrintingDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
                                report.Parameters.FindByName("Unit").Value = materials[0].UnitOfMeasure;
                                report.Parameters.FindByName("MONo").Value = order.MONumber;
                                report.Parameters.FindByName("LineNo").Value = order.MOLineNo;
                                report.Parameters.FindByName("LotNumber").Value = materials[0].LotNumber;
                                report.Parameters.FindByName("MaterialTexture").Value = materials[0].T131Code;
                                report.Parameters.FindByName("ActualPickedBars").Value = materials[0].ActualQtyDecompose;
                                report.Parameters.FindByName("OrderQty").Value = order.PlannedQuantity;
                                report.Parameters.FindByName("MaterialCode").Value = materials[0].MaterialCode;
                                report.Parameters.FindByName("MaterialDescription").Value = materials[0].MaterialDesc;
                                report.Parameters.FindByName("TransferringInDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
                                report.Parameters.FindByName("InQuantity").Value = materials[0].ActualQuantityToDeliver.ToString();
                                report.Parameters.FindByName("FatherMaterialCode").Value = order.ProductNo;
                                report.Parameters.FindByName("FatherMaterialName").Value = order.ProductDesc;
                                report.Parameters.FindByName("DstT106Code").Value = materials[0].DstT106Code;
                                break;
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        ShowMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (report.Prepare())
                    {
                        System.Drawing.Printing.PrinterSettings prnSetting = 
                            new System.Drawing.Printing.PrinterSettings();
                        bool rePrinter = false;
                        do
                        {
                            if (report.ShowPrintDialog(out prnSetting))
                            {
                                report.PrintPrepared(prnSetting);
                                rePrinter = (
                                    ShowMessageBox.Show(
                                        "物料配送流转卡已经打印完成，是否需要重新打印？",
                                        "系统信息",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2) == DialogResult.Yes);
                            }
                        } while (rePrinter);
                    }
                    btnClose.PerformClick();
                    #endregion
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 生成物料配送 XML 串
        /// </summary>
        public string GeneratePickedUpXML(List<MaterialToDeliver> materials)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            string pickedUpStringXML = "";
            for (int i = 0; i < materials.Count; i++)
            {
                MaterialToDeliver material = materials[i];
                pickedUpStringXML += string.Format(
                    "<PUS Ordina=\"{0}\" TreeID=\"{1}\" LeafID=\"{2}\" " +
                    "T106LeafID=\"{3}\" Qty=\"{4}\" Scale=\"{5}\" " +
                    "LotNumber=\"{6}\" MFGDate=\"{7}\"/>",
                    i + 1,
                    material.TreeID,
                    material.LeafID,
                    material.AtT106LeafID,
                    material.ActualQtyToDeliver,
                    material.Scale,
                    material.LotNumber,
                    material.MFGDate);
            }
            pickedUpStringXML = string.Format("<ROOT>{0}</ROOT>", pickedUpStringXML);
            WriteLog.Instance.Write(pickedUpStringXML, strProcedureName);
            return pickedUpStringXML;
        }

        /// <summary>
        /// 记录指定的生产工单物料配送卡打印完成
        /// </summary>
        public bool SavePWOMaterialDeliver()
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 保存物料配送事实
                try
                {
                    int errCode = 0;
                    string errText = "";
                    long transactNo = 0;
                    try
                    {
                        transactNo = 
                            IRAPUTSClient.Instance.mfn_GetTransactNo(
                                IRAPUser.Instance.CommunityID, 
                                1, 
                                IRAPUser.Instance.SysLogID, 
                                this.OpNode);
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                        ShowMessageBox.Show(
                            error.Message, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        return false;
                    }

                    string pickedUpStringXML = GeneratePickedUpXML(materials);
                    IRAPSCESClient.Instance.usp_PrintVoucher_PWOMaterialDelivery(
                        IRAPUser.Instance.CommunityID,
                        transactNo,
                        orderFactID,
                        materials[0].T173LeafID,
                        dstStoreSite.T173LeafID,
                        materials[0].DstT106LeafID,
                        dstStoreSite.T1LeafID_Recv,
                        pickedUpStringXML,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(string.Format("({0}){1}", errCode, errText), strProcedureName);
                    if (errCode != 0)
                    {
                        ShowMessageBox.Show(errText, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    ShowMessageBox.Show(
                        error.Message, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnSpiliteOrderNotify_Click(object sender, EventArgs e)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                try
                {
                    switch (materials[0].ActionCode)
                    {
                        case 2:
                            IRAPAPSClient.Instance.usp_RequestForMODispatching(
                                IRAPUser.Instance.CommunityID,
                                order.FactID,
                                order.MONumber,
                                order.MOLineNo,
                                order.PlannedQty,
                                materials[0].ATPQty,
                                IRAPUser.Instance.SysLogID,
                                out errCode,
                                out errText);
                            break;
                        case 3:
                            IRAPAPSClient.Instance.usp_RequestForMOQtyModification(
                                IRAPUser.Instance.CommunityID,
                                order.FactID,
                                order.MONumber,
                                order.MOLineNo,
                                order.PlannedQty,
                                materials[0].ATPQty,
                                IRAPUser.Instance.SysLogID,
                                out errCode,
                                out errText);
                            break;
                    }

                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }
                finally
                {
                }

                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText), 
                    strProcedureName);
                if (errCode == 0)
                {
                    ShowMessageBox.Show(
                        errText, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Asterisk);
                }
                else
                {
                    ShowMessageBox.Show(
                        errText, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
                btnClose.PerformClick();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}