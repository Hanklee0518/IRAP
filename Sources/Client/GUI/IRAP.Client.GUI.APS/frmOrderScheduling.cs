using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using IRAP.Client.User;
using IRAP.Entities.APS;
using IRAP.Entity.MDM;
using IRAP.WCF.Client.Method;
using IRAP.Client.Global.GUI.Dialogs;
using IRAP.Client.Global;
using IRAP.Global;
using IRAP.Entity.MES;

namespace IRAP.Client.GUI.APS
{
    public partial class frmOrderScheduling : IRAP.Client.Global.frmCustomBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private ManufacturingOrder order = null;
        private List<ProductionLineOfProduct> lines = new List<ProductionLineOfProduct>();
        private int dtfInDays = 0;
        private string maxScheduleTime = "";
        private string minScheduleTime = "";
        private string opNode = "";

        public frmOrderScheduling()
        {
            InitializeComponent();
        }

        public frmOrderScheduling(string opNode)
            : this()
        {
            this.opNode = opNode;
        }

        public int DTFInDays
        {
            get { return dtfInDays; }
            set
            {
                dtfInDays = value + 7;
            }
        }

        public ManufacturingOrder Order
        {
            get { return order; }
            set
            {
                order = value;

                edtPriorityOrdinal.Text = order.PriorityOrdinal.ToString();
                edtMONo.Text = order.MONo;
                edtMOLineNo.Text = order.MOLineNo.ToString();
                edtProduct.Text = string.Format("[{0}]{1}", order.ProductNo, order.ProductDesc);
                edtOrderQuantity.Text = string.Format("{0} {1}", order.OrderQuantity.ToString(), order.UnitOfMeasure);
                edtFinishedQuantity.Text = string.Format("{0} {1}", order.FinishedQuantity.ToString(), order.UnitOfMeasure);
                edtPlannedStartDate.Text = order.PlannedStartDate;
                edtPlannedEndDate.Text = order.PlannedEndDate;
                edtMOLineStatus.Text = order.MOLineStatusString;

                #region 获取生产线
                int errCode = 0;
                string errText = "";

                try
                {
                    IRAPMDMClient.Instance.ufn_GetList_ProductionLinesOfProduct(
                        IRAPUser.Instance.CommunityID,
                        order.ProductNo,
                        IRAPUser.Instance.SysLogID,
                        ref lines,
                        out errCode,
                        out errText);
                }
                catch (Exception error)
                {
                    errCode = -1;
                    errText = error.Message;
                }

                if (errCode == 0)
                {
                    foreach (ProductionLineOfProduct line in lines)
                    {
                        cboProductLines.Properties.Items.Add(line);
                        if (cboProductLines.SelectedItem == null && 
                            line.T134LeafID == order.T134LeafID)
                        {
                            cboProductLines.SelectedItem = line;
                        }
                    }
                }
                else
                {
                    btnOK.Enabled = false;
                    MessageBox.Show(errText, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
        }

        /// <summary>
        /// 排产限制最晚时间
        /// </summary>
        public string MaxScheduleTime
        {
            get { return maxScheduleTime; }
            set { maxScheduleTime = value; }
        }

        /// <summary>
        /// 排产限制最早时间
        /// </summary>
        public string MinScheduleTime
        {
            get { return minScheduleTime; }
            set { minScheduleTime = value; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboProductLines.SelectedIndex < 0)
            {
                ShowMessageBox.Show(
                    "请选择排定的生产线！", 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                cboProductLines.Focus();
                return;
            }

            #region 排产事件约束
            string scheduleStartTime = string.Format("{0} {1}:{2}:00",
                cboSchedulingStartDate.SelectedItem.ToString(),
                edtStartTimeHour.Text.ToString(),
                edtStartTimeMinutes.Text.ToString());
            DateTime dtSchudelingTime = Convert.ToDateTime(scheduleStartTime);
            DateTime dtMinTime = Convert.ToDateTime(string.Format("{0}:00", minScheduleTime));
            DateTime dtMaxTime = Convert.ToDateTime(string.Format("{0}:00", maxScheduleTime));
            if (dtMinTime < DateTime.Now)
                dtMinTime = DateTime.Now;
            if (dtSchudelingTime <= dtMinTime)
            {
                ShowMessageBox.Show(
                    $"本订单排产时间不能早于：{dtMinTime.ToString("yyyy-MM-dd HH:mm")}",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtStartTimeHour.Focus();
                return;
            }
            if (dtSchudelingTime >= dtMaxTime)
            {
                ShowMessageBox.Show(
                    $"本订单排产时间不能晚于：{dtMaxTime.ToString("yyyy-MM-dd HH:mm")}",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtStartTimeHour.Focus();
                return;
            }
            #endregion

            #region 保存排产事实
            TWaitting.Instance.ShowWaitForm("正在排产......");

            long transactNo = 0;
            long factID = 0;
            int opType = 1;

            int errCode = 0;
            string errText = "";

            try
            {
                if (order.DispatchingTransNo == 0 || order.DispatchingFactID == 0)
                {
                    opType = 1;  // 新排
                    try
                    {
                        transactNo =
                            IRAPUTSClient.Instance.mfn_GetTransactNo(
                                IRAPUser.Instance.CommunityID,
                                1,
                                IRAPUser.Instance.SysLogID,
                                opNode);
                    }
                    catch (Exception error)
                    {
                        errCode = -1;
                        errText = error.Message;
                    }

                    if (errCode == 0)
                    {
                        try
                        {
                            factID = 
                                IRAPUTSClient.Instance.mfn_GetFactID(
                                    IRAPUser.Instance.CommunityID, 
                                    1, 
                                    IRAPUser.Instance.SysLogID, 
                                    opNode);
                        }
                        catch (Exception error)
                        {
                            errCode = -1;
                            errText = error.Message;
                        }
                    }
                }
                else
                {
                    opType = 2;  // 修改
                    transactNo = order.DispatchingTransNo;
                    factID = order.DispatchingFactID;
                }

                if (errCode == 0)
                {
                    IRAPAPSClient.Instance.usp_SaveFact_MODispatching(
                        IRAPUser.Instance.CommunityID,
                        transactNo,
                        factID,
                        opType,
                        order.MONo,
                        order.MOLineNo,
                        order.ProductNo,
                        (cboProductLines.SelectedItem as ProductionLineOfProduct).T134LeafID,
                        order.OrderQty,
                        scheduleStartTime.Substring(0, 16),
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                }
            }
            catch (Exception error)
            {
                errCode = -1;
                errText = error.Message;
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
            }

            if (errCode == 0)
            {
                order.ScheduledStartTime = scheduleStartTime.Substring(0, 16);
                ProductionLineOfProduct line = cboProductLines.SelectedItem as ProductionLineOfProduct;
                order.T134LeafID = line.T134LeafID;
                order.T134Code = line.T134Code;
                order.T134Name = line.T134Name;

                order.DispatchingTransNo = transactNo;
                order.DispatchingFactID = factID;

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
            #endregion

            DialogResult = DialogResult.OK;
        }

        private void btnATPChecking_Click(object sender, EventArgs e)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                MaterialATP atpInfo = new MaterialATP();

                TWaitting.Instance.ShowWaitForm("请稍等......");

                IRAPAPSClient.Instance.ufn_GetInfo_MaterialATP(
                    IRAPUser.Instance.CommunityID,
                    order.ProductNo,
                    IRAPUser.Instance.SysLogID,
                    ref atpInfo,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode == 0)
                {
                    order.ATPQty = atpInfo.ATPQty;
                    order.EstimatedATPTime = atpInfo.EstimatedATPTime;

                    edtATPQuantity.Text = $"{order.ATPQty} {order.UnitOfMeasure}";
                    edtEstimatedATPTime.Text = order.EstimatedATPTime;
                }
                else
                {
                    ShowMessageBox.Show(
                        errText, 
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
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
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmOrderScheduling_Shown(object sender, EventArgs e)
        {
            #region 限制排产日期
            int intMinDate = 0;
            int intMaxDate = 0;

            if (minScheduleTime.Trim() == "")
            {
                minScheduleTime = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00";
            }
            if (maxScheduleTime.Trim() == "")
            {
                maxScheduleTime = 
                    DateTime.Now.AddDays(dtfInDays).ToString("yyyy-MM-dd") + " 23:59";
            }

            intMinDate = Convert.ToInt32(minScheduleTime.Substring(0, 10).Replace("-", ""));
            intMaxDate = Convert.ToInt32(maxScheduleTime.Substring(0, 10).Replace("-", ""));

            for (int i = 0; i <= this.dtfInDays; i++)
            {
                int intNewDate = Convert.ToInt32(DateTime.Now.AddDays(i).ToString("yyyyMMdd"));
                if (intNewDate >= intMinDate && intNewDate <= intMaxDate)
                {
                    cboSchedulingStartDate.Properties.Items.Add(
                        DateTime.Now.AddDays(i).ToString("yyyy-MM-dd"));
                }
            }
            cboSchedulingStartDate.SelectedIndex = 
                cboSchedulingStartDate.Properties.Items.Count - 1;
            #endregion

            if (order.ScheduledStartTime.Trim() != "")
            {
                for (int i = 0; i < cboSchedulingStartDate.Properties.Items.Count; i++)
                {
                    if (cboSchedulingStartDate.Properties.Items[i].ToString() == 
                        order.ScheduledStartTime.Substring(0, 10))
                    {
                        cboSchedulingStartDate.SelectedIndex = i;
                        break;
                    }
                }
                edtStartTimeHour.Value = 
                    Convert.ToDecimal(order.ScheduledStartTime.Substring(11, 2));
                edtStartTimeMinutes.Value = 
                    Convert.ToDecimal(order.ScheduledStartTime.Substring(14, 2));
            }
        }

        private void cboProductLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProductLines.SelectedItem == null)
            {
                grdOrders.DataSource = null;
                return;
            }
            else
            {
                grdOrders.DataSource = null;
                grdvOrders.BestFitColumns();
            }

            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                TWaitting.Instance.ShowWaitForm($"正在获取已排订单列表......");

                List<OpenProductionWorkOrder> orders = new List<OpenProductionWorkOrder>();
                int errCode = 0;
                string errText = "";

                int t134LeafID = 
                    (cboProductLines.SelectedItem as ProductionLineOfProduct).T134LeafID;
                string filterString = $"T134LeafID = {t134LeafID} AND PWOStatus != 5";
                string orderString = "ScheduledStartTime DESC";
                IRAPMESClient.Instance.ufn_GetList_OpenProductionWorkOrders(
                    IRAPUser.Instance.CommunityID,
                    filterString,
                    orderString,
                    ref orders,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                grdOrders.DataSource = orders;
                grdvOrders.BestFitColumns();
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
