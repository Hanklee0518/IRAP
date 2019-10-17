using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

using IRAP.Entities.APS;
using IRAP.Entity.Kanban;
using IRAP.Entity.SSO;
using IRAP.Client.Global;
using IRAP.Global;
using IRAP.WCF.Client.Method;
using IRAP.Client.User;
using IRAP.Client.Global.GUI.Dialogs;

namespace IRAP.Client.GUI.APS
{
    public partial class frmMOManualScheduling_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private string moPattern = "";
        private List<ManufacturingOrder> orders = new List<ManufacturingOrder>();
        private List<LeafSetEx> areas = new List<LeafSetEx>();
        private SystemMenuInfoButtonStyle btnMenuInfo = null;
        private SystemMenuInfoMenuStyle mnuMenuInfo = null;
        private bool ShownRunning = false;

        public frmMOManualScheduling_30()
        {
            InitializeComponent();
        }

        private void GetT124Items()
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPKBClient.Instance.sfn_AccessibleLeafSetEx(
                    IRAPUser.Instance.CommunityID,
                    124,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    ref areas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode == 0)
                {
                    LeafSetEx_ComparerByLeafID comparer = new LeafSetEx_ComparerByLeafID();
                    areas.Sort(comparer);

                    foreach (LeafSetEx area in areas)
                    {
                        cboAreas.Properties.Items.Add(area);
                    }

                    if (cboAreas.Properties.Items.Count > 1)
                        cboAreas.SelectedIndex = 0;
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
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取制造订单格式字符串
        /// </summary>
        private void GetMOPattern()
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                try
                {
                    int errCode = 0;
                    string errText = "";

                    IRAPAPSClient.Instance.ufn_GetAccessibleMOPattern(
                        IRAPUser.Instance.CommunityID,
                        IRAPUser.Instance.SysLogID,
                        ref moPattern,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                    if (errCode != 0)
                        ShowMessageBox.Show(
                            errText, 
                            "系统信息", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    ShowMessageBox.Show(
                        error.Message, 
                        "系统信息", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据制造订单格式串获得制造订单列表
        /// </summary>
        private void GetOrdersWithMOPattern()
        {
            orders.Clear();
            grdvOrders.ClearSorting();
            grdvOrders.ClearColumnsFilter();
            Application.DoEvents();

            if (btnMenuInfo == null && mnuMenuInfo == null)
            {
                XtraMessageBox.Show(
                    "没有传入正确的菜单参数！", 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            if (cboAreas.SelectedItem == null)
            {
                ShowMessageBox.Show(
                    "请选择一个区域!", 
                    "系统信息", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }

            int dtfInDays = 0;
            if (btnMenuInfo != null)
                dtfInDays = Tools.ConvertToInt32(btnMenuInfo.Parameters);
            if (mnuMenuInfo != null)
                dtfInDays = Tools.ConvertToInt32(mnuMenuInfo.Parameters);

            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                TWaitting.Instance.ShowWaitForm("正在获取制造订单......");

                int errCode = 0;
                string errText = "";

                IRAPAPSClient.Instance.ufn_GetList_ManufacturingOrdersToDispatch(
                    IRAPUser.Instance.CommunityID,
                    ((LeafSetEx)cboAreas.SelectedItem).LeafID,
                    moPattern,
                    dtfInDays,
                    IRAPUser.Instance.SysLogID,
                    ref orders,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);

                if (errCode == 0)
                {
                    for (int i = orders.Count - 1; i >= 0; i--)
                    {
                        if (orders[i].MOLineStatus == 6 || orders[i].MOLineStatus == 7)
                        {
                            if (Convert.ToDateTime(orders[i].ScheduledStartTime) < DateTime.Now)
                                orders.Remove(orders[i]);
                        }
                    }

                    grdOrders.DataSource = orders;
                    for (int i = 0; i < grdvOrders.Columns.Count; i++)
                    {
                        if (grdvOrders.Columns[i].Visible)
                        {
                            grdvOrders.Columns[i].BestFit();
                            Application.DoEvents();
                        }
                    }
                    grdOrders.MainView.LayoutChanged();
                }
                else
                {
                    ShowMessageBox.Show(
                        errText,
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    grdOrders.DataSource = null;
                    return;
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
                grdOrders.DataSource = null;
                return;
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private string GetMinSchedulingTime(int orderIndex)
        {
            string rlt = "";
            for (int i = orderIndex - 1; i >= 0; i--)
            {
                if (orders[i].PlannedStartDate == orders[orderIndex].PlannedStartDate
                    && orders[i].ProductNo == orders[orderIndex].ProductNo
                    && orders[i].MONo == orders[orderIndex].MONo)
                {
                    if (orders[i].MOLineNo < orders[orderIndex].MOLineNo)
                    {
                        return orders[i].ScheduledStartTime;
                    }
                }
            }
            return rlt;
        }

        private string GetMaxSchedulingTime(int orderIndex)
        {
            string rlt = "";
            for (int i = orderIndex + 1; i < orders.Count; i++)
            {
                if (orders[i].PlannedStartDate == orders[orderIndex].PlannedStartDate
                    && orders[i].ProductNo == orders[orderIndex].ProductNo
                    && orders[i].MONo == orders[orderIndex].MONo)
                {
                    if (orders[i].MOLineNo > orders[orderIndex].MOLineNo)
                    {
                        return orders[i].ScheduledStartTime;
                    }
                }
            }
            return rlt;
        }

        private void frmMOManualScheduling_30_Activated(object sender, EventArgs e)
        {
        }

        private void mitmScheduling_Click(object sender, EventArgs e)
        {
            if (btnMenuInfo == null && mnuMenuInfo == null)
            {
                XtraMessageBox.Show(
                    "没有传入正确的菜单参数！",
                    "系统信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string opNode = "";
            int dtfInDays = 0;

            if (btnMenuInfo != null)
            {
                opNode = btnMenuInfo.OpNode;
                dtfInDays = Tools.ConvertToInt32(btnMenuInfo.Parameters);
            }
            if (mnuMenuInfo != null)
            {
                opNode = mnuMenuInfo.OpNode;
                dtfInDays = Tools.ConvertToInt32(mnuMenuInfo.Parameters);
            }

            int selectedIndex = grdvOrders.GetFocusedDataSourceRowIndex();

            using (frmOrderScheduling OrderScheduling = new frmOrderScheduling(opNode))
            {
                ManufacturingOrder order = orders[selectedIndex].Clone();

                OrderScheduling.DTFInDays = dtfInDays;
                OrderScheduling.Order = order;
                OrderScheduling.MinScheduleTime = GetMinSchedulingTime(selectedIndex);
                OrderScheduling.MaxScheduleTime = GetMaxSchedulingTime(selectedIndex);

                if (OrderScheduling.ShowDialog() == DialogResult.OK)
                {
                    orders[selectedIndex].DispatchingTransNo = order.DispatchingTransNo;
                    orders[selectedIndex].DispatchingFactID = order.DispatchingFactID;
                    orders[selectedIndex].MOLineStatus = 5;
                    orders[selectedIndex].T134LeafID = order.T134LeafID;
                    orders[selectedIndex].T134Code = order.T134Code;
                    orders[selectedIndex].T134Name = order.T134Name;
                    orders[selectedIndex].ScheduledStartTime = order.ScheduledStartTime;
                    orders[selectedIndex].ATPQty = order.ATPQty;
                    orders[selectedIndex].EstimatedATPTime = order.EstimatedATPTime;

                    grdvOrders.LayoutChanged();
                    grdvOrders.BestFitColumns();
                }

                btnRefresh.PerformClick();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetOrdersWithMOPattern();
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (orders.Count > 0)
            {
                int selectedIndex = grdvOrders.GetFocusedDataSourceRowIndex();
                 
                #region 确定能否排当前计划投产日期的订单
                int unDispatchedCount = 0;
                for (int i = 0; i < selectedIndex; i++)
                {
                    if (orders[i].MOLineStatus == 4 && 
                        orders[i].PlannedStartDate != orders[selectedIndex].PlannedStartDate)
                        unDispatchedCount++;
                }
                mitmScheduling.Enabled = unDispatchedCount == 0;
                #endregion

                #region 对于同一产品、同一制造订单号中需要先排行号小的订单
                if (unDispatchedCount == 0)
                {
                    ManufacturingOrder currentOrder = orders[selectedIndex];
                    foreach (ManufacturingOrder order in orders)
                    {
                        if (order.PlannedStartDate == currentOrder.PlannedStartDate
                            && order.ProductNo == currentOrder.ProductNo
                            && order.MONo == currentOrder.MONo)
                        {
                            if (order.MOLineNo < currentOrder.MOLineNo && order.MOLineStatus == 4)
                            {
                                mitmScheduling.Enabled = false;
                                return;
                            }
                        }
                    }
                    mitmScheduling.Enabled = true;
                }
                #endregion
            }
            else
            {
                mitmScheduling.Enabled = false;
            }
        }

        private void frmMOManualScheduling_30_Shown(object sender, EventArgs e)
        {
            if (Tag is SystemMenuInfoButtonStyle)
                btnMenuInfo = (SystemMenuInfoButtonStyle)Tag;
            if (Tag is SystemMenuInfoMenuStyle)
                mnuMenuInfo = (SystemMenuInfoMenuStyle)Tag;

            if (moPattern == "")
            {
                try
                {
                    TWaitting.Instance.ShowWaitForm("获取制造订单格式字符串");
                    GetMOPattern();
                }
                finally
                {
                    TWaitting.Instance.CloseWaitForm();
                }
            }

            ShownRunning = true;
            GetT124Items();
            ShownRunning = false;
        }

        private void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ShownRunning)
                GetOrdersWithMOPattern();
        }
    }
}
