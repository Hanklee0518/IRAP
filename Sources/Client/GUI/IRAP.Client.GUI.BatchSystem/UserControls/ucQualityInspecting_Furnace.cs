﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraVerticalGrid.Rows;

using IRAP.Global;
using IRAP.Client.Global.Enums;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.Entities.IRAP;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.BatchSystem.UserControls
{
    public partial class ucQualityInspecting_Furnace : XtraUserControl
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private WIPStation station = null;
        private STB006 currentOperator = null;
        private List<BatchByEquipment> batchs = new List<BatchByEquipment>();
        private List<BatchPWOInfo> pwos = new List<BatchPWOInfo>();
        private List<InspectionItem> inspectionItems = new List<InspectionItem>();
        private DataTable dtInspection = new DataTable();
        /// <summary>
        /// 参数缺省值集
        /// </summary>
        private Dictionary<string, string> defaultValues = new Dictionary<string, string>();

        public ucQualityInspecting_Furnace()
        {
            InitializeComponent();
        }

        public ucQualityInspecting_Furnace(WIPStation station) : this()
        {
            this.station = station;
        }

        public void ClearAll()
        {
            currentOperator = null;
            edtOperatorCode.Text = "";

            Clear();
        }

        private void Clear()
        {
            batchs.Clear();
            grdvBatchNos.RefreshData();

            pwos.Clear();
            grdvPWOs.RefreshData();

            dtInspection.Clear();
            dtInspection.Columns.Clear();
            vgrdInspectParams.Rows.Clear();
            vgrdInspectParams.RefreshDataSource();

            RefreshCtrlInForm();
        }

        private STB006 GetUserInfoWithIDCode(string idCode)
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
                List<STB006> users = new List<STB006>();

                IRAPUserClient.Instance.mfn_GetList_Users(
                    IRAPUser.Instance.CommunityID,
                    "",
                    idCode,
                    ref users,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
                else
                {
                    if (users.Count == 0)
                    {
                        XtraMessageBox.Show(
                            string.Format(
                                "未找到[{0}]的用户",
                                idCode),
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return null;
                    }
                    else
                    {
                        return users[0];
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void GetBatchsFromEquipment(WIPStation station)
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

                batchs.Clear();
                IRAPMESClient.Instance.ufn_GetList_BatchByEquipment(
                    IRAPUser.Instance.CommunityID,
                    station.T133LeafID,
                    "IQ",
                    IRAPUser.Instance.SysLogID,
                    ref batchs,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void RefreshCtrlInForm()
        {
            grdBatchNos.RefreshDataSource();
            grdPWOs.RefreshDataSource();
            vgrdInspectParams.RefreshDataSource();

            if (currentOperator == null)
            {
                splitContainerControl2.Enabled = false;
                vgrdInspectParams.Enabled = false;
                btnPWONew.Enabled = false;
                btnPWOModify.Enabled = false;
                btnPWORemove.Enabled = false;
                btnSaveParams.Enabled = false;
            }
            else
            {
                if (currentOperator != null)
                {
                    splitContainerControl2.Enabled = true;
                }
                if (grdvPWOs.GetFocusedDataSourceRowIndex() >= 0)
                {
                    vgrdInspectParams.Enabled = true;
                    btnPWONew.Enabled = true;
                    btnPWOModify.Enabled = true;
                    btnPWORemove.Enabled = true;
                    btnSaveParams.Enabled = true;
                }
                else
                {
                    vgrdInspectParams.Enabled = false;
                    btnPWONew.Enabled = false;
                    btnPWOModify.Enabled = false;
                    btnPWORemove.Enabled = false;
                    btnSaveParams.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 根据工位叶标识和生产容器批次号获取工单信息列表
        /// </summary>
        /// <param name="batchNumber">生产容器批次号</param>
        /// <returns></returns>
        private List<BatchPWOInfo> GetPWOWithBatchNo(string batchNumber)
        {
            List<BatchPWOInfo> rlt = new List<BatchPWOInfo>();

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

                IRAPMESClient.Instance.ufn_GetList_WorkUnitBatchPWONo(
                    IRAPUser.Instance.CommunityID,
                    station.T107LeafID,
                    batchNumber,
                    IRAPUser.Instance.SysLogID,
                    ref rlt,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    for (int i = rlt.Count - 1; i >= 0; i--)
                    {
                        if (rlt[i].QCStatus != 0 ||
                            rlt[i].BatchEndDate.Trim() == "")
                            rlt.RemoveAt(i);
                    }
                }
            }
            catch (Exception error)
            {
                string errMsg =
                    string.Format(
                        "获取工单信息列表时发生错误：[{0}]",
                        error.Message);
                WriteLog.Instance.Write(errMsg, strProcedureName);

                XtraMessageBox.Show(
                    errMsg,
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }

            return rlt;
        }

        /// <summary>
        /// 生成质量检验值临时表
        /// </summary>
        /// <param name="items"></param>
        private void InitInspectionItemsGrid(List<InspectionItem> items)
        {
            dtInspection.Clear();
            dtInspection.Columns.Clear();

            vgrdInspectParams.Rows.Clear();
            defaultValues.Clear();

            foreach (InspectionItem item in items)
            {
                string colName = string.Format("Column{0}", item.Ordinal);
                DataColumn dc = dtInspection.Columns.Add(colName, typeof(string));
                dc.Caption = item.T20Name;

                EditorRow row = new EditorRow();
                row.Properties.Caption = item.T20Name;
                row.Properties.FieldName = colName;
                row.Height = 35;
                vgrdInspectParams.Rows.Add(row);

                defaultValues.Add(item.T20Name, item.DefaultValue);
            }

            vgrdInspectParams.DataSource = dtInspection;
            vgrdInspectParams.BestFit();
        }

        private string GenerateRSFactXML()
        {
            string rlt = "";

            for (int i = 0; i < dtInspection.Rows.Count; i++)
            {
                int rowNo = i + 1;
                for (int j = 0; j < dtInspection.Columns.Count; j++)
                {
                    rlt +=
                        string.Format(
                            "<RF6_2 RowNum=\"{0}\" Ordinal=\"{1}\" " +
                            "T20LeafID=\"{2}\" LowLimit=\"\" " +
                            "Criterion=\"\" HighLimit=\"\" UnitOfMeasure=\"\" " +
                            "Metric01=\"{3}\" />",
                            rowNo,
                            inspectionItems[j].Ordinal,
                            inspectionItems[j].T20LeafID,
                            dtInspection.Rows[i][j].ToString());
                }
            }

            rlt = string.Format("<RSFact>{0}</RSFact>", rlt);
            return rlt;
        }

        private void ucQualityInspecting_Furnace_Enter(object sender, EventArgs e)
        {
            ClearAll();

            edtOperatorCode.Focus();
        }

        private void edtOperatorCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (edtOperatorCode.Text.Trim() != "")
                {
                    currentOperator = GetUserInfoWithIDCode(edtOperatorCode.Text.Trim());
                    if (currentOperator != null)
                    {
                        edtOperatorCode.Text =
                            string.Format(
                                "{0}[{1}]",
                                currentOperator.UserName,
                                currentOperator.UserCode);
                    }
                    else
                    {
                        edtOperatorCode.Text = "";
                    }
                }
                else
                {
                    edtOperatorCode.Text = "";
                    currentOperator = null;
                }

                Clear();

                if (currentOperator != null)
                {
                    GetBatchsFromEquipment(station);

                    grdBatchNos.DataSource = batchs;
                    grdvBatchNos.UpdateCurrentRow();
                    grdvBatchNos.BestFitColumns();
                }

                RefreshCtrlInForm();
            }
        }

        private void grdvBatchNos_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            grdPWOs.DataSource = null;
            vgrdInspectParams.Rows.Clear();

            int idx = grdvBatchNos.GetFocusedDataSourceRowIndex();
            if (idx >= 0 && idx < batchs.Count)
            {
                BatchByEquipment batch = batchs[idx];
                pwos = GetPWOWithBatchNo(batch.BatchNumber);
                grdPWOs.DataSource = pwos;
            }
            else
            {
                pwos.Clear();
                grdPWOs.DataSource = null;
            }

            grdPWOs.RefreshDataSource();
            grdvPWOs.BestFitColumns();

            RefreshCtrlInForm();
        }

        private void grdvPWOs_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            int idx = grdvPWOs.GetFocusedDataSourceRowIndex();
            if (idx >= 0 && idx < pwos.Count)
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

                    IRAPMDMClient.Instance.ufn_GetList_InspectionItems(
                        IRAPUser.Instance.CommunityID,
                        pwos[idx].T102LeafID,
                        station.T216LeafID,
                        pwos[idx].PWONo,
                        pwos[idx].BatchNumber,
                        IRAPUser.Instance.SysLogID,
                        ref inspectionItems,
                        out errCode,
                        out errText);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                            errText,
                            "",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    WriteLog.Instance.WriteEndSplitter(strProcedureName);
                }
            }
            else
            {
                inspectionItems.Clear();
            }

            InitInspectionItemsGrid(inspectionItems);
        }

        private void btnPWONew_Click(object sender, EventArgs e)
        {
            if (dtInspection.Columns.Count < 0)
            {
                XtraMessageBox.Show(
                    "当前生产工单的在制品没有配置检验项",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (Dialogs.frmItemsEditor formEditor =
                new Dialogs.frmItemsEditor(
                    EditStatus.New,
                    splitContainerControl1.Panel2.Text,
                    dtInspection,
                    defaultValues,
                    -1))
            {
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    vgrdInspectParams.RefreshDataSource();
                }
            }
        }

        private void btnPWOModify_Click(object sender, EventArgs e)
        {
            if (dtInspection.Columns.Count < 0)
            {
                XtraMessageBox.Show(
                    "当前生产工单的在制品没有配置检验项",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (dtInspection.Rows.Count <= 0)
            {
                XtraMessageBox.Show(
                    "当前没有需要修改的检验项值",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            int idx = vgrdInspectParams.FocusedRecord;
            if (idx < 0)
            {
                XtraMessageBox.Show(
                    "当前没有需要修改的检验项值",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            using (Dialogs.frmItemsEditor formEditor =
                new Dialogs.frmItemsEditor(
                    EditStatus.Edit,
                    splitContainerControl1.Panel2.Text,
                    dtInspection,
                    defaultValues,
                    idx))
            {
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    vgrdInspectParams.RefreshDataSource();
                }
            }
        }

        private void btnPWORemove_Click(object sender, EventArgs e)
        {
            int idx = vgrdInspectParams.FocusedRecord;
            if (idx >= 0)
            {
                if (XtraMessageBox.Show(
                    string.Format(
                        "是否要删除选择的第[{0}]组参数值？",
                        idx + 1),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    dtInspection.Rows.RemoveAt(idx);

                    vgrdInspectParams.RefreshDataSource();
                }
            }
        }

        private void btnSaveParams_Click(object sender, EventArgs e)
        {
            if (dtInspection.Columns.Count < 0)
            {
                XtraMessageBox.Show(
                    "当前生产工单的在制品没有配置检验项",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (dtInspection.Rows.Count < 0)
            {
                XtraMessageBox.Show(
                    "当前生产工单还没有输入检验值",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

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
                long factID = 0;

                int idx = grdvPWOs.GetFocusedDataSourceRowIndex();
                if (idx >= 0 && idx < pwos.Count)
                    factID = pwos[idx].FactID;

                IRAPMESClient.Instance.usp_SaveFact_BatchManualInspecting(
                    IRAPUser.Instance.CommunityID,
                    pwos[idx].FactID,
                    pwos[idx].T102LeafID,
                    station.T107LeafID,
                    pwos[idx].BatchNumber,
                    pwos[idx].LotNumber,
                    pwos[idx].PWONo,
                    1,
                    GenerateRSFactXML(),
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    dtInspection.Rows.Clear();
                    dtInspection.Columns.Clear();
                    vgrdInspectParams.Rows.Clear();

                    GetBatchsFromEquipment(station);

                    grdBatchNos.DataSource = batchs;
                    grdvBatchNos.UpdateCurrentRow();
                    grdvBatchNos.BestFitColumns();

                    RefreshCtrlInForm();
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
