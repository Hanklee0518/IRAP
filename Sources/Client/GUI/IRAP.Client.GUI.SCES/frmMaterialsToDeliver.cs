﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Configuration;

using DevExpress.XtraEditors;
using FastReport;

using IRAP.Global;
using IRAP.Client.Global;
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
        private List<ProductionWorkOrderEx> orders = new List<ProductionWorkOrderEx>();
        private ProductionWorkOrderEx order = null;
        private List<MaterialToDeliver> materials = new List<MaterialToDeliver>();
        private DstDeliveryStoreSite dstStoreSite = null;
        private string opNode = "";
        /// <summary>
        /// 需要打印配送单的排产订单事实编号
        /// </summary>
        private long orderFactID = 0;
        /// <summary>
        /// 需要打印配送单的辅助事实分区键
        /// </summary>
        private long af482PK = 0;

        /// <summary>
        /// 打印暂存文件夹
        /// </summary>
        private string fpxBackupFolder = "";

        private bool printWIPProductInfoTrack = false;

        public frmMaterialsToDeliver()
        {
            InitializeComponent();
        }

        public frmMaterialsToDeliver(
            long orderFactID,
            long af482PK,
            DstDeliveryStoreSite storeSite,
            string opNode)
            : this()
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className,
                    MethodBase.GetCurrentMethod().Name);

            this.orderFactID = orderFactID;
            this.af482PK = af482PK;
            dstStoreSite = storeSite;
            this.opNode = opNode;

            fpxBackupFolder = string.Format("{0}FPX\\", AppDomain.CurrentDomain.BaseDirectory);
            if (!Directory.Exists(fpxBackupFolder))
            {
                Directory.CreateDirectory(fpxBackupFolder);
            }

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("正在获取指定的待配送制造订单");
            try
            {
                int errCode = 0;
                string errText = "";
                try
                {
                    IRAPSCESClient.Instance.ufn_GetList_ProductionWorkOrdersToDeliverMaterial_N(
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
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            grdOrders.DataSource = orders;
            for (int i = 0; i < grdvOrders.Columns.Count; i++)
            {
                grdvOrders.Columns[i].BestFit();
            }

            switch (IRAPUser.Instance.CommunityID)
            {
                case 60010:
                case 60030:
                    if (ConfigurationManager.AppSettings["PrintProductInfoTrack"] != null)
                        printWIPProductInfoTrack =
                            ConfigurationManager.AppSettings["PrintProductInfoTrack"].ToUpper() == "TRUE";

                    break;
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

            string strProcedureName = 
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("获取工单物料配送指令单");
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

                            #region 当用户社区是 60010、60030 时，允许用户可以调整每杆数量，且若物料库房是粗检库(2155630)时，允许用户修改配送数量
                            switch (IRAPUser.Instance.CommunityID)
                            {
                                case 60010:
                                    switch (dstStoreSite.T173LeafID)
                                    {
                                        case 2155631:
                                        case 5259040:
                                            btnActualQtyToDeliverModify.Visible = false;
                                            break;
                                        case 5360016:
                                        case 5460148:
                                            grdclmnStickQty.Visible = true;
                                            grdclmnPerStickQty.Visible = true;

                                            btnT157R3.Visible = true;
                                            break;
                                        default:
                                            btnActualQtyToDeliverModify.Visible = true;
                                            break;
                                    }


                                    btnCapacityModify.Visible = true;
                                    btnCapacityModify.Text = "每杆数量调整";

                                    break;
                                case 60030:
                                    switch (dstStoreSite.T173LeafID)
                                    {
                                        case 5453745:
                                        case 5453792:
                                            btnActualQtyToDeliverModify.Visible = true;
                                            break;
                                        default:
                                            btnActualQtyToDeliverModify.Visible = true;
                                            break;
                                    }

                                    btnCapacityModify.Visible = true;
                                    btnCapacityModify.Text = "每杆数量调整";
                                    break;
                                default:
                                    btnActualQtyToDeliverModify.Visible = false;
                                    btnCapacityModify.Visible = false;
                                    break;
                            }
                            #endregion

                            break;
                        case 2:
                            btnSpiliteOrderNotify.Visible = true;
                            break;
                        case 3:
                            if (materials.Count > 0)
                            {
                                if (materials[0].ATPQty > materials[0].ContainerCapacity)
                                {
                                    btnSpilitePKGNotify.Visible = true;
                                }
                                else
                                {
                                    btnSpiliteOrderNotify.Visible = true;
                                }
                            }
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
                            btnCapacityModify.Visible = false;
                            btnActualQtyToDeliverModify.Visible = false;
                            break;
                        default:
                            break;
                    }
                }
                #endregion
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
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
                string lotNumber = "";

                #region 调用存储过程，在系统中登记当前生产工单的物料配送信息已经被打印
                bool saveSucccessed = false;
#if DEBUG
                XtraMessageBox.Show(
                    "程序调试模式下，不调用 usp_PrintVoucher_PWOMaterialDelivery 。",
                    "系统提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                saveSucccessed = true;
#else
                saveSucccessed = SavePWOMaterialDeliver();
#endif
                #endregion

                if (saveSucccessed)
                {
#region 获取当前工单的生产批次号
                    {
                        int errCode = 0;
                        string errText = "";

                        IRAPMESClient.Instance.ufn_GetLotNumberFromPWO(
                            IRAPUser.Instance.CommunityID,
                            order.AF482PK,
                            order.PWONo,
                            ref lotNumber,
                            out errCode,
                            out errText);
                        WriteLog.Instance.Write(
                            string.Format("({0}){1}", errCode, errText),
                            strProcedureName);
                    }
#endregion

#region 打印
                    Report report = new Report();
                    Report report1 = new Report();
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

                    if (printWIPProductInfoTrack)
                    {
                        switch (IRAPUser.Instance.CommunityID)
                        {
                            case 60010:
                                switch (materials[0].T173LeafID)
                                {
                                    case 2155630:
                                        ms = new MemoryStream(Properties.Resources.WIPProductInfoTrack_60010_2155630);
                                        break;
                                    default:
                                        switch (IRAPUser.Instance.Agency.AgencyLeaf)
                                        {
                                            case 353081:
                                            case 354089:
                                                ms = new MemoryStream(Properties.Resources.WIPProductInfoTrack_60010_2155630);
                                                break;
                                            default:
                                                ms = new MemoryStream(Properties.Resources.WIPProductInfoTrack);
                                                break;
                                        }
                                        break;
                                }
                                report1.Load(ms);
                                break;
                            case 60030:
                                if (IRAPUser.Instance.HostName == "RMS115301")
                                {
                                    ms =
                                        new MemoryStream(
                                            Properties.Resources.WIPProductInfoTrack_60030_RMS115301);
                                }
                                else
                                {
                                    ms =
                                        new MemoryStream(
                                            Properties.Resources.WIPProductInfoTrack_60030);
                                }
                                report1.Load(ms);
                                break;
                        }
                    }

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
                                dt.Columns.Add("OrderQty", typeof(string));
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
                                        data.OrderQuantity.ToString(),
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
                                report.Parameters.FindByName("PrintingDate").Value = DateTime.Now.ToString("MM-dd HH:mm");
                                report.Parameters.FindByName("Unit").Value = materials[0].UnitOfMeasure;
                                report.Parameters.FindByName("MONo").Value = order.MONumber;
                                report.Parameters.FindByName("LineNo").Value = order.MOLineNo;
                                report.Parameters.FindByName("LotNumber").Value = lotNumber;
                                report.Parameters.FindByName("MaterialTexture").Value = materials[0].T131Code;
                                report.Parameters.FindByName("ActualPickedBars").Value = materials[0].ActualQtyDecompose;
                                report.Parameters.FindByName("OrderQty").Value = order.PlannedQuantity;
                                report.Parameters.FindByName("MaterialCode").Value = materials[0].MaterialCode;
                                report.Parameters.FindByName("MaterialDescription").Value = materials[0].MaterialDesc;
                                report.Parameters.FindByName("TransferringInDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
                                if (materials[0].ActualQuantityToDeliver.IntValue != 0)
                                    report.Parameters.FindByName("InQuantity").Value = materials[0].ActualQuantityToDeliver.ToStringWithoutUnitOfMeasure();
                                else
                                    report.Parameters.FindByName("InQuantity").Value = "";
                                report.Parameters.FindByName("FatherMaterialCode").Value = order.ProductNo;
                                report.Parameters.FindByName("FatherMaterialName").Value = order.ProductDesc;
                                report.Parameters.FindByName("DstT106Code").Value = materials[0].DstT106Code;
                                report.Parameters.FindByName("OperatorName").Value = IRAPUser.Instance.UserName;
                                break;
                        }

                        if (printWIPProductInfoTrack)
                        {
                            switch (IRAPUser.Instance.CommunityID)
                            {
                                case 60010:
                                    DataSet ds = new DataSet();
                                    DataTable dt = new DataTable();
                                    dt.TableName = "WIPProductInfoTrack";
                                    dt.Columns.Add("BarCode", typeof(string));
                                    dt.Columns.Add("DeliveryWorkShop", typeof(string));
                                    dt.Columns.Add("StorehouseCode", typeof(string));
                                    dt.Columns.Add("T106Code", typeof(string));
                                    dt.Columns.Add("WorkshopName", typeof(string));
                                    dt.Columns.Add("ProductLine", typeof(string));
                                    dt.Columns.Add("AdvicedPickedQty", typeof(string));
                                    dt.Columns.Add("StartingDate", typeof(string));
                                    dt.Columns.Add("CompletingDate", typeof(string));
                                    dt.Columns.Add("PrintingDate", typeof(string));
                                    dt.Columns.Add("Unit", typeof(string));
                                    dt.Columns.Add("MONo", typeof(string));
                                    dt.Columns.Add("MOLineNo", typeof(string));
                                    dt.Columns.Add("LotNumber", typeof(string));
                                    dt.Columns.Add("MaterialTexture", typeof(string));
                                    dt.Columns.Add("ActualPickedBars", typeof(string));
                                    dt.Columns.Add("OrderQty", typeof(int));
                                    dt.Columns.Add("MaterialCode", typeof(string));
                                    dt.Columns.Add("MaterialDescription", typeof(string));
                                    dt.Columns.Add("TransferringInDate", typeof(string));
                                    dt.Columns.Add("InQuantity", typeof(string));
                                    dt.Columns.Add("FatherMaterialCode", typeof(string));
                                    dt.Columns.Add("FatherMaterialName", typeof(string));
                                    dt.Columns.Add("DstT106Code", typeof(string));
                                    dt.Columns.Add("GateWayWC", typeof(string));
                                    dt.Columns.Add("PageNo", typeof(int));
                                    dt.Columns.Add("PageCount", typeof(int));
                                    dt.Columns.Add("ActualQuantity", typeof(string));

                                    long perContainerQty = materials[0].PerStickQty * materials[0].StickQty;
                                    if (perContainerQty == 0)
                                    {
                                        #region 未设置镀铬车间的容器容量
                                        dt.Rows.Add(
                                            order.PWONo,
                                            "",
                                            string.Format("{0}({1})", materials[0].T173Name, materials[0].T173Code),
                                            materials[0].AtStoreLocCode,
                                            materials[0].DstWorkShopCode,
                                            order.T134Name,
                                            materials[0].SuggestedQuantityToPick.ToString(),
                                            order.PlannedStartDate.Substring(5, 5),
                                            order.PlannedCloseDate.Substring(5, 5),
                                            DateTime.Now.ToString("MM-dd HH:mm:ss"),
                                            materials[0].UnitOfMeasure,
                                            order.MONumber,
                                            order.MOLineNo,
                                            lotNumber,
                                            materials[0].T131Code,
                                            materials[0].ActualQtyDecompose,
                                            order.PlannedQuantity.IntValue.ToString(),
                                            materials[0].MaterialCode,
                                            materials[0].MaterialDesc,
                                            DateTime.Now.ToString("yyyy-MM-dd"),
                                            materials[0].ActualQuantityToDeliver.IntValue != 0 ?
                                                materials[0].ActualQuantityToDeliver.ToStringWithoutUnitOfMeasure() :
                                                "",
                                            order.ProductNo,
                                            order.ProductDesc,
                                            materials[0].DstT106Code,
                                            order.GateWayWC,
                                            1,
                                            1,
                                            materials[0].ActualQuantityToDeliver.IntValue != 0 ?
                                                materials[0].ActualQuantityToDeliver.ToStringWithoutUnitOfMeasure() :
                                                "");
                                        #endregion
                                    }
                                    else
                                    {
                                        long count = materials[0].ActualQuantityToDeliver.IntValue / perContainerQty + 1;
                                        long sum = materials[0].ActualQuantityToDeliver.IntValue;
                                        for (int i = 1; i <= count; i++)
                                        {
                                            long qty = 0;
                                            string actualQtyDecompose = "";
                                            if (sum >= perContainerQty)
                                            {
                                                qty = perContainerQty;
                                                actualQtyDecompose =
                                                    string.Format(
                                                        "{0}*{1}",
                                                        materials[0].StickQty,
                                                        materials[0].PerStickQty);
                                            }
                                            else
                                            {
                                                qty = sum;
                                                actualQtyDecompose =
                                                    string.Format(
                                                        "{0}*{1}+{2}",
                                                        qty / materials[0].PerStickQty,
                                                        materials[0].PerStickQty,
                                                        qty % materials[0].PerStickQty);
                                            }
                                            sum = sum - qty;

                                            dt.Rows.Add(
                                                order.PWONo,
                                                "",
                                                string.Format("{0}({1})", materials[0].T173Name, materials[0].T173Code),
                                                materials[0].AtStoreLocCode,
                                                materials[0].DstWorkShopCode,
                                                order.T134Name,
                                                materials[0].SuggestedQuantityToPick.ToString(),
                                                order.PlannedStartDate.Substring(5, 5),
                                                order.PlannedCloseDate.Substring(5, 5),
                                                DateTime.Now.ToString("MM-dd HH:mm:ss"),
                                                materials[0].UnitOfMeasure,
                                                order.MONumber,
                                                order.MOLineNo,
                                                lotNumber,
                                                materials[0].T131Code,
                                                actualQtyDecompose,
                                                order.PlannedQuantity.IntValue.ToString(),
                                                materials[0].MaterialCode,
                                                materials[0].MaterialDesc,
                                                DateTime.Now.ToString("yyyy-MM-dd"),
                                                qty.ToString(),
                                                order.ProductNo,
                                                order.ProductDesc,
                                                materials[0].DstT106Code,
                                                order.GateWayWC,
                                                i,
                                                count,
                                                materials[0].ActualQuantityToDeliver.IntValue.ToString());
                                        }
                                    }

                                    ds.Tables.Add(dt);

                                    report1.RegisterData(ds);
                                    report1.GetDataSource("WIPProductInfoTrack").Enabled = true;

                                    break;
                                case 60030:
                                    report1.Parameters.FindByName("BarCode").Value = order.PWONo;
                                    report1.Parameters.FindByName("DeliveryWorkshop").Value = "";
                                    report1.Parameters.FindByName("StorehouseCode").Value =
                                        string.Format(
                                            "{0}({1})",
                                            materials[0].T173Name,
                                            materials[0].T173Code);
                                    report1.Parameters.FindByName("T106Code").Value = materials[0].AtStoreLocCode;
                                    report1.Parameters.FindByName("WorkshopName").Value = materials[0].DstWorkShopCode;
                                    report1.Parameters.FindByName("ProductLine").Value = order.T134Name;
                                    report1.Parameters.FindByName("AdvicedPickedQty").Value = materials[0].SuggestedQuantityToPick;
                                    report1.Parameters.FindByName("StartingDate").Value = order.PlannedStartDate.Substring(5, 5);
                                    report1.Parameters.FindByName("CompletingDate").Value = order.PlannedCloseDate.Substring(5, 5);
                                    report1.Parameters.FindByName("PrintingDate").Value = DateTime.Now.ToString("MM-dd HH:mm:ss");
                                    report1.Parameters.FindByName("Unit").Value = materials[0].UnitOfMeasure;
                                    report1.Parameters.FindByName("MONo").Value = order.MONumber;
                                    report1.Parameters.FindByName("LineNo").Value = order.MOLineNo;
                                    report1.Parameters.FindByName("LotNumber").Value = lotNumber;
                                    report1.Parameters.FindByName("MaterialTexture").Value = materials[0].T131Code;
                                    report1.Parameters.FindByName("ActualPickedBars").Value = materials[0].ActualQtyDecompose;
                                    report1.Parameters.FindByName("OrderQty").Value = order.PlannedQuantity.IntValue.ToString();
                                    report1.Parameters.FindByName("MaterialCode").Value = materials[0].MaterialCode;
                                    report1.Parameters.FindByName("MaterialDescription").Value = materials[0].MaterialDesc;
                                    report1.Parameters.FindByName("TransferringInDate").Value = DateTime.Now.ToString("yyyy-MM-dd");
                                    if (materials[0].ActualQuantityToDeliver.IntValue != 0)
                                        report1.Parameters.FindByName("InQuantity").Value = materials[0].ActualQuantityToDeliver.ToStringWithoutUnitOfMeasure();
                                    else
                                        report1.Parameters.FindByName("InQuantity").Value = "";
                                    report1.Parameters.FindByName("FatherMaterialCode").Value = order.ProductNo;
                                    report1.Parameters.FindByName("FatherMaterialName").Value = order.ProductDesc;
                                    report1.Parameters.FindByName("DstT106Code").Value = materials[0].DstT106Code;

                                    if (IRAPUser.Instance.CommunityID == 60030)
                                        report1.Parameters.FindByName("GateWayWC").Value = order.GateWayWC;

                                    break;
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        WriteLog.Instance.Write(error.Message, strProcedureName);
                        ShowMessageBox.Show(error.Message, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 流转卡保存文件名
                    string fileNameTransferTrack =
                        string.Format(
                            @"{0}FPX\{1}.{2}_Transfer.fpx",
                            AppDomain.CurrentDomain.BaseDirectory,
                            order.MONumber,
                            order.MOLineNo);
                    // 跟踪卡保存文件名
                    string fileNameProductTrack =
                        string.Format(
                            @"{0}FPX\{1}.{2}_ProductTrack.fpx",
                            AppDomain.CurrentDomain.BaseDirectory,
                            order.MONumber,
                            order.MOLineNo);

                    System.Drawing.Printing.PrinterSettings prnSetting =
                        new System.Drawing.Printing.PrinterSettings();
                    if (report.Prepare())
                    {
                        // 保留物料配送流转卡的副本
                        if (IRAPUser.Instance.CommunityID == 60010 ||
                            IRAPUser.Instance.CommunityID == 60030)
                        {
                            report.SavePrepared(fileNameTransferTrack);
                        }

                        bool rePrinter = false;
                        do
                        {
                            prnSetting.PrinterName = IRAPConst.Instance.CurrentPrinterName;
                            if (report.ShowPrintDialog(out prnSetting))
                            {
                                IRAPConst.Instance.CurrentPrinterName = prnSetting.PrinterName;
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

                    if (printWIPProductInfoTrack && dstStoreSite.T173LeafID != 2155631)
                    {
                        switch (IRAPUser.Instance.CommunityID)
                        {
                            case 60010:
                            case 60030:
                                IRAPMessageBox.Instance.ShowInformation(
                                    "请将打印机中的打印纸更换为【产品信息跟踪卡】，更换完毕后点击确认开始打印");

                                if (report1.Prepare())
                                {
                                    // 保留产品信息跟踪卡的副本
                                    report1.SavePrepared(fileNameProductTrack);

                                    bool rePrint = false;
                                    do
                                    {
                                        prnSetting.PrinterName = IRAPConst.Instance.CurrentPrinterName;
                                        if (report1.ShowPrintDialog(out prnSetting))
                                        {
                                            IRAPConst.Instance.CurrentPrinterName = prnSetting.PrinterName;
                                            report1.PrintPrepared(prnSetting);
                                            rePrint =
                                                (
                                                    ShowMessageBox.Show(
                                                        "【产品信息跟踪卡】已经打印完成，是否需要重新打印？",
                                                        "系统信息",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button2) == DialogResult.Yes
                                                );
                                        }
                                    } while (rePrint);
                                }

                                break;
                        }
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
                                this.opNode);
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
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

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

        private void btnCapacityModify_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmContainerPapacityEditor formEditor =
                new Dialogs.frmContainerPapacityEditor(materials[0].MaterialCode))
            {
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    frmMaterialToDeliverPreview_Shown(this, null);
                }
            }
        }

        private void btnActualQtyToDeliverModify_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmActualQtyToDeliverEditor formEditor =
                new Dialogs.frmActualQtyToDeliverEditor())
            {
                formEditor.OrderFactID = orders[0].FactID;
                formEditor.SubTreeID = materials[0].TreeID;
                formEditor.SubLeafID = materials[0].LeafID;
                formEditor.ActualQtyInStore = materials[0].QtyInStore;
                formEditor.ActualQtyToDeliver = materials[0].ActualQtyToDeliver;

                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    frmMaterialToDeliverPreview_Shown(this, null);
                }
            }
        }

        private void btnT157R3_Click(object sender, EventArgs e)
        {
            using (Dialogs.frmT157R3Editor formEditor =
                new Dialogs.frmT157R3Editor())
            {
                formEditor.TreeID = materials[0].TreeID;
                formEditor.LeafID = materials[0].LeafID;
                formEditor.StickQty = materials[0].StickQty;
                formEditor.PerStickQty = materials[0].PerStickQty;

                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    frmMaterialToDeliverPreview_Shown(this, null);
                }
            }
        }
    }
}
