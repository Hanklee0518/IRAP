﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Client.Global;
using IRAP.Client.Global.GUI;
using IRAP.Entities.DPA;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.AsimcoPrdtPackage
{
    public partial class frmImportOrders : frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private const string DB_IMPORT_TABLENAME = "dpa_DBF_MO";

        private long importID = 0;

        public frmImportOrders()
        {
            InitializeComponent();
        }

        private Exception BuildErrorObject(int errCode, string errText)
        {
            Exception error = new Exception(errText);
            error.Data["ErrCode"] = errCode;
            error.Data["ErrText"] = errText;
            return error;
        }

        /// <summary>
        /// 检查需要导入的数据是否全部通过检验
        /// </summary>
        private bool CanBeImported()
        {
            List<dpa_DBF_MO> items =
                grdImportData.DataSource as List<dpa_DBF_MO>;
            foreach (dpa_DBF_MO item in items)
            {
                if (item.ErrCode != 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 从 DBF 中读取需要导入的数据
        /// </summary>
        /// <param name="dbfName"></param>
        /// <returns></returns>
        private List<dpa_DBF_MO> GetDataFromDBF(string dbfName)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            int errCode = 0;
            string errText = "";

            #region 获取数据导入日志标识
            if (importID == 0)
            {
                IRAPUTSClient.Instance.msp_GetSequenceNo(
                    IRAPUser.Instance.CommunityID,
                    "NextUDFLogID",
                    1,
                    IRAPUser.Instance.SysLogID,
                    ref importID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                    throw
                        BuildErrorObject(
                            errCode,
                            string.Format(
                                "获取数据导入日志标识时发生错误：{0}",
                                errText));
            }
            #endregion

            List<dpa_DBF_MO> datas = new List<dpa_DBF_MO>();

            if (!File.Exists(dbfName))
            {
                throw new Exception($"文件[{dbfName}]未找到！");
            }

            FileInfo fi = new FileInfo(dbfName);
            string directory = fi.DirectoryName;
            string tableName = fi.Name;

            OleDbConnection conn = new OleDbConnection();
            string connStr =
                $"Provider=VFPOLEDB.1;Data Source={directory};" +
                "Collating Sequence=MACHINE";
            conn.ConnectionString = connStr;

            try
            {
                conn.Open();
            }
            catch (Exception error)
            {
                throw new Exception(
                    "在读取 DBF 文件的时候发生错误，可能是该文件被其它程序打开了。\n" +
                    $"错误信息：[{error.Message}]");
            }

            DataTable dt = new DataTable();
            try
            {
                string sqlStr = $"SELECT * FROM {tableName}";
                OleDbDataAdapter da = new OleDbDataAdapter(sqlStr, conn);
                da.Fill(dt);
            }
            catch (Exception error)
            {
                throw new Exception(
                    $"在读取文件的时候发生错误：[{error.Message}]");
            }

            if (!dt.Columns.Contains("DDSOURCE_M"))
                throw new Exception("文件中未找到 DDSOURCE_M 字段");
            if (!dt.Columns.Contains("DDTYPE_I"))
                throw new Exception("文件中未找到 DDTYPE_I 字段");
            if (!dt.Columns.Contains("PICKDDH"))
                throw new Exception("文件中未找到 PICKDDH 字段");
            if (!dt.Columns.Contains("LN_NO"))
                throw new Exception("文件中未找到 LN_NO 字段");
            if (!dt.Columns.Contains("ITEM"))
                throw new Exception("文件中未找到 ITEM 字段");
            if (!dt.Columns.Contains("STK_75"))
                throw new Exception("文件中未找到 STK_75 字段");
            if (!dt.Columns.Contains("KW"))
                throw new Exception("文件中未找到 KW 字段");
            if (!dt.Columns.Contains("LOT"))
                throw new Exception("文件中未找到 LOT 字段");
            if (!dt.Columns.Contains("STK_QTY"))
                throw new Exception("文件中未找到 STK_QTY 字段");
            if (!dt.Columns.Contains("CPLOT"))
                throw new Exception("文件中未找到 CPLOT 字段");

            long partitioningKey = IRAPUser.Instance.CommunityID * 10000;
            foreach (DataRow row in dt.Rows)
            {
                dpa_DBF_MO data =
                    new dpa_DBF_MO()
                    {
                        PartitioningKey = partitioningKey,
                        ImportID = importID,
                        ErrCode = -1,
                        ErrText = "未校验",
                    };

                if (row["DDSOURCE_M"] != null)
                    data.MOSource = row["DDSOURCE_M"].ToString().Trim();
                if (row["DDTYPE_I"] != null)
                    data.MOType = row["DDTYPE_I"].ToString().Trim();
                if (row["PICKDDH"] != null)
                    data.MONumber = row["PICKDDH"].ToString().Trim();
                try
                {
                    data.MOLineNo = Convert.ToInt32(row["LN_NO"].ToString());
                }
                catch { data.MOLineNo = 0; }
                if (row["ITEM"] != null)
                    data.MaterialCode = row["ITEM"].ToString().Trim();
                if (row["STK_75"] != null)
                    data.Treasury = row["STK_75"].ToString().Trim();
                if (row["KW"] != null)
                    data.Location = row["KW"].ToString().Trim();
                if (row["LOT"] != null)
                    data.LotNumber = row["LOT"].ToString().Trim();
                if (row["CPLOT"] != null)
                    data.CPLot = row["CPLOT"].ToString().Trim();
                try
                {
                    data.OrderQty = Convert.ToDecimal(row["STK_QTY"].ToString());
                }
                catch { data.OrderQty = 0; }

                datas.Add(data);
            }

            return datas;
        }

        /// <summary>
        /// 从数据库表 dpa_DBF_MO 中移除指定 ID 的记录
        /// </summary>
        /// <param name="importLogID"></param>
        private void RemoveDataFromDBTable(long imporID)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";
                IRAPDPAClient.Instance.msp_Delete_DPA_DBFMOData(
                    IRAPUser.Instance.CommunityID,
                    importID,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    Exception error = new Exception(errText);
                    throw BuildErrorObject(errCode, errText);
                }
                return;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                throw BuildErrorObject(-1, error.Message);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string dbfFileName;
            if (ConfigurationManager.AppSettings["DBFImportFileName"] != null)
            {
                dbfFileName =
                    ConfigurationManager.AppSettings["DBFImportFileName"];
            }
            else
            {
                XtraMessageBox.Show(
                    "导入文件名未在配置文件中定义，不能执行导入功能",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            List<dpa_DBF_MO> datas = null;
            try
            {
                TWaitting.Instance.ShowWaitForm("正在读取导入的数据");
                datas = GetDataFromDBF(dbfFileName);
            }
            catch (Exception error)
            {
                TWaitting.Instance.CloseWaitForm();
                XtraMessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            grdImportData.DataSource = datas;
            grdvImportData.BestFitColumns();

            TWaitting.Instance.CloseWaitForm();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if ((grdImportData.DataSource as List<dpa_DBF_MO>).Count <= 0)
            {
                XtraMessageBox.Show(
                    "没有读取到需要导入的订单数据",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                TWaitting.Instance.ShowWaitForm("删除历史数据");
                try
                {
                    RemoveDataFromDBTable(importID);
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(
                        error.Message,
                        "",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                #region 将当前表格中的记录插入数据库中
                int errCode = 0;
                string errText = "";
                try
                {
                    TWaitting.Instance.ShowWaitForm("将读取到的数据上传到数据库中");
                    IRAPDPAClient.Instance.msp_InsertIntoDBF_MO(
                        grdImportData.DataSource as List<dpa_DBF_MO>,
                        out errCode,
                        out errText);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                              errText,
                              "提示信息",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception error)
                {
                    XtraMessageBox.Show(
                        error.Message,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion

                #region 检验指定 ImportLogID 的导入数据记录
                try
                {
                    TWaitting.Instance.ShowWaitForm("校验上传的数据");
                    IRAPDPAClient.Instance.usp_PokaYoke_DBF_MONumber(
                        IRAPUser.Instance.CommunityID,
                        importID,
                        IRAPUser.Instance.SysLogID,
                        out errCode,
                        out errText);
                    if (errCode != 0)
                    {
                        XtraMessageBox.Show(
                            errText,
                            "提示信息",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    TWaitting.Instance.ShowWaitForm("获取校验结果");
                    List<dpa_DBF_MO> datas = new List<dpa_DBF_MO>();
                    IRAPDPAClient.Instance.mfn_GetList_DBF_MO(
                        IRAPUser.Instance.CommunityID,
                        importID,
                        IRAPUser.Instance.SysLogID,
                        ref datas,
                        out errCode,
                        out errText);

                    grdvImportData.BeginDataUpdate();
                    grdImportData.DataSource = datas;
                    grdvImportData.EndDataUpdate();
                    grdvImportData.BestFitColumns();
                }
                catch (Exception error)
                {
                    TWaitting.Instance.CloseWaitForm();
                    XtraMessageBox.Show(
                        error.Message,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                #endregion
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!CanBeImported())
            {
                XtraMessageBox.Show(
                    "还有记录没有进行校验或者校验不通过，请修改后重新校验！",
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            int errCode = 0;
            string errText = "";

            try
            {
                TWaitting.Instance.ShowWaitForm("正在处理上传的数据");
                IRAPDPAClient.Instance.usp_UploadMO(
                    IRAPUser.Instance.CommunityID,
                    importID,
                    IRAPUser.Instance.SysLogID,
                    out errCode,
                    out errText);
                TWaitting.Instance.CloseWaitForm();

                if (errCode != 0)
                    XtraMessageBox.Show(
                        errText,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                {
                    XtraMessageBox.Show(
                        errText,
                        "提示信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    importID = 0;
                    grdvImportData.BeginDataUpdate();
                    grdImportData.DataSource = null;
                    grdvImportData.EndDataUpdate();
                    grdvImportData.BestFitColumns();
                }
            }
            catch (Exception error)
            {
                XtraMessageBox.Show(
                    error.Message,
                    "提示信息",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
    }
}
