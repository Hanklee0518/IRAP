using DevExpress.XtraEditors;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entity.Kanban;
using IRAP.Entity.SSO;
using IRAP.Global;
using IRAP.WCF.Client.Method;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESRMM
{
    public partial class frmT102R4GUI_30 : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private readonly string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private int resourceTreeID = 0;
        private List<SubTreeLeaf> prdts = new List<SubTreeLeaf>();
        private List<LineOrWorkCenterForAProduct> workCentersWithPrdt =
            new List<LineOrWorkCenterForAProduct>();
        private DataTable dtProcesses = null;
        private List<LeafSetEx> lines = new List<LeafSetEx>();
        private List<LeafSetEx> workCenters = new List<LeafSetEx>();

        public frmT102R4GUI_30()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 根据产成品或者半成品列表
        /// </summary>
        /// <param name="nodeID"></param>
        /// <param name="filterString"></param>
        private void GetProductList(int nodeID, string filterString)
        {
            string strProductName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProductName);
            try
            {
                WriteLog.Instance.Write("获取产成品或半成品", strProductName);

                int errCode = 0;
                string errText = "";

                IRAPKBClient.Instance.mfn_SubtreeLeaves(
                    IRAPUser.Instance.CommunityID,
                    102,
                    nodeID,
                    filterString,
                    ref prdts,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProductName);

                grdProducts.DataSource = prdts;
                for (int i = 0; i < grdvProducts.Columns.Count; i++)
                {
                    if (grdvProducts.Columns[i].Visible)
                    {
                        grdvProducts.Columns[i].BestFit();
                    }
                }
                grdvProducts.LayoutChanged();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProductName);

                grdProducts.DataSource = null;
                grdvProducts.LayoutChanged();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProductName);
            }
        }

        private void ClearProcessPanel()
        {
            lblProductName.Text = "";
            grdvWorkCenters.OptionsBehavior.Editable = false;
            grdvWorkCenters.OptionsView.NewItemRowPosition =
                DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdWorkCenters.UseEmbeddedNavigator = false;

            grdvWorkCenters.LayoutChanged();
        }

        /// <summary>
        /// 根据参数返回产线/工作中心标题格式串
        /// </summary>
        private string GetProductLineTitleFormat(int resourceTreeID)
        {
            string rlt = "{0}\"{1}\"的生产线";
            switch (resourceTreeID)
            {
                case 134:
                    rlt = "{0}\"{1}\"的产线";
                    break;
                case 221:
                    rlt = "{0}\"{1}\"的工作中心";
                    break;
                default:
                    rlt = "{0}\"{1}\"的生产线";
                    break;
            }
            return rlt;
        }

        private DataTable InitDataTable(string tableType)
        {
            DataTable dt = new DataTable();
            switch (tableType)
            {
                case "WorkCenter":
                    dt.Columns.Add("Ordinal", typeof(int));
                    dt.Columns.Add("T134LeafID", typeof(int));
                    dt.Columns.Add("T211LeafID", typeof(int));
                    break;
                case "ProcessItems":
                    dt.Columns.Add("LeafID", typeof(int));
                    dt.Columns.Add("LeafName", typeof(string));
                    break;
            }
            return dt;
        }

        private void SetEditorMode(bool isEdit)
        {
            groupControl1.Enabled = !isEdit;
            btnSave.Enabled = isEdit;
            btnCancel.Enabled = isEdit;
        }

        private string GenerateRSAttrXML()
        {
            string strProductProcessXML = "";

            int i = 1;
            dtProcesses.DefaultView.Sort = "Ordinal asc";
            DataTable dt = dtProcesses.Copy();
            dt = dtProcesses.DefaultView.ToTable();

            foreach (DataRow dr in dt.Rows)
            {
                strProductProcessXML +=
                    $"<Row RealOrdinal=\"{i++}\" " +
                    $"T134LeafID=\"{Tools.ConvertToInt32(dr["T134LeafID"].ToString())}\" " +
                    $"T211LeafID=\"{Tools.ConvertToInt32(dr["T211LeafID"].ToString())}\"/>";
            }

            return $"<RSAttr>{strProductProcessXML}</RSAttr>";
        }

        private void LoadProductLines()
        {
            int errCode = 0;
            string errText = "";

            lines = 
                IRAPKBClient.Instance.mfn_GetList_ProductLines(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
            if (errCode == 0)
            {
                LeafSetEx_ComparerByCode cbc = new LeafSetEx_ComparerByCode();
                (lines as List<LeafSetEx>).Sort(cbc);

                riluT134Items.DataSource = lines;
                riluT134Items.DisplayMember = "CodeAndName";
                riluT134Items.ValueMember = "LeafID";
                riluT134Items.NullText = "";
            }
            else
            {
                riluT134Items.DataSource = null;
            }
        }

        private void LoadWorkCenters()
        {
            int errCode = 0;
            string errText = "";

            workCenters = 
                IRAPKBClient.Instance.mfn_GetList_WorkCenters(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.ScenarioIndex,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
            if (errCode == 0)
            {
                riluT211Items.DataSource = workCenters;
                riluT211Items.DisplayMember = "CodeAndName";
                riluT211Items.ValueMember = "LeafID";
                riluT211Items.NullText = "";
            }
            else
            {
                riluT211Items.DataSource = null;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (edtFilter.Text.Trim() == "")
            {
                if (XtraMessageBox.Show(
                    $"您没有输入过滤条件，在加载{cboProductType.SelectedItem.ToString()}" +
                    "列表的时候，需要较长时间。\n\n请问是否要继续？",
                    "系统信息",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            int nodeID = 0;
            switch (cboProductType.SelectedIndex)
            {
                case 0:
                    nodeID = 22114;
                    break;
                case 1:
                    nodeID = 22115;
                    break;
                default:
                    return;
            }

            GetProductList(nodeID, edtFilter.Text.Trim());

            dtProcesses.Clear();
            ClearProcessPanel();

            if (prdts.Count > 0)
            {
                grdvProducts.SelectRow(0);
                grdvProducts_FocusedRowChanged(grdvProducts, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, 0));
            }
        }

        private void grdvWorkCenters_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow dr = grdvWorkCenters.GetDataRow(e.RowHandle);
            dr["Ordinal"] = dtProcesses.Rows.Count + 1;
            dr["T134LeafID"] = 0;
            dr["T211LeafID"] = 0;

            SetEditorMode(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtProcesses.Clear();
            foreach (LineOrWorkCenterForAProduct workCenter in workCentersWithPrdt)
            {
                dtProcesses.Rows.Add(new object[]
                            {
                                workCenter.Ordinal,
                                workCenter.T134LeafID,
                                workCenter.T211LeafID,
                            });
            }
            for (int i = 0; i < grdvWorkCenters.Columns.Count; i++)
            {
                if (grdvWorkCenters.Columns[i].Visible)
                    grdvWorkCenters.Columns[i].BestFit();
            }

            SetEditorMode(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region 保存修改后的产品与产线/工作中心对应关系
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                string effectiveTime = "";

                if (!chkEffectiveType.Checked)
                {
                    #region 要求输入生效日期和时间

                    #endregion
                }

                IRAPMDMClient.Instance.ssp_SaveRSAttrChange(
                    IRAPUser.Instance.CommunityID,
                    102,
                    prdts[grdvProducts.GetFocusedDataSourceRowIndex()].LeafID,
                    4,
                    "",
                    effectiveTime,
                    true,
                    GenerateRSAttrXML(),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write($"({errCode}){errText}", strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "系统信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    grdvProducts_FocusedRowChanged(grdvProducts, null);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            #endregion

            SetEditorMode(false);
        }

        private void grdvWorkCenters_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            SetEditorMode(true);
        }

        private void grdvWorkCenters_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            SetEditorMode(true);
        }

        private void frmT102R4GUI_30_Shown(object sender, EventArgs e)
        {
            if (Tag != null)
            {
                if (Tag is SystemMenuInfoButtonStyle)
                {
                    resourceTreeID = Tools.ConvertToInt32((Tag as SystemMenuInfoButtonStyle).Parameters);
                }
                if (Tag is SystemMenuInfoMenuStyle)
                {
                    resourceTreeID = Tools.ConvertToInt32((Tag as SystemMenuInfoMenuStyle).Parameters);
                }
            }

            switch (resourceTreeID)
            {
                case 134:
                    grdclmnT134LeafName.OptionsColumn.AllowEdit = true;
                    grdclmnT211LeafName.Visible = false;
                    break;
                case 211:
                    grdclmnT134LeafName.OptionsColumn.AllowEdit = false;
                    grdclmnT211LeafName.Visible = true;
                    break;
            }

            lblProductName.Text = "";
            dtProcesses = InitDataTable("WorkCenter");
            grdWorkCenters.DataSource = dtProcesses;

            LoadProductLines();
            LoadWorkCenters();
        }

        private void grdvProducts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = grdvProducts.GetFocusedDataSourceRowIndex();
            if (index >= 0 && index < prdts.Count)
            {
                string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

                WriteLog.Instance.WriteBeginSplitter(strProcedureName);
                try
                {
                    lblProductName.Text = string.Format(GetProductLineTitleFormat(resourceTreeID),
                            cboProductType.SelectedItem.ToString(),
                            prdts[index].NodeName);

                    int errCode = 0;
                    string errText = "";

                    IRAPMDMClient.Instance.ufn_GetList_LineOrWorkCenterForAProduct(
                        IRAPUser.Instance.CommunityID,
                        prdts[index].LeafID,
                        resourceTreeID,
                        "",
                        IRAPUser.Instance.SysLogID,
                        ref workCentersWithPrdt,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        $"({errCode}){errText}", 
                        strProcedureName);

                    dtProcesses.Clear();
                    foreach (LineOrWorkCenterForAProduct workCenter in workCentersWithPrdt)
                    {
                        dtProcesses.Rows.Add(new object[]
                            {
                                workCenter.Ordinal,
                                workCenter.T134LeafID,
                                workCenter.T211LeafID,
                            });
                    }
                    for (int i = 0; i < grdvWorkCenters.Columns.Count; i++)
                    {
                        if (grdvWorkCenters.Columns[i].Visible)
                            grdvWorkCenters.Columns[i].BestFit();
                    }

                    grdvWorkCenters.OptionsBehavior.Editable = true;
                    grdvWorkCenters.OptionsView.NewItemRowPosition = 
                        DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    grdWorkCenters.UseEmbeddedNavigator = true;
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            else
            {
                ClearProcessPanel();
            }
        }

        private void edtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
