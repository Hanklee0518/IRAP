﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Data;

using IRAP.Global;
using IRAP.Server.Global;
using IRAP.Entities.DPA;
using IRAPORM;
using IRAPShared;

namespace IRAP.BL.DPA
{
    public class IRAPDPA : IRAPBLLBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPDPA()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult msp_InsertIntoSmeltProductionPlanTable(
            List<dpa_Imp_SmeltProductionPlan> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            Hashtable rlt = new Hashtable();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    try
                    {
                        int count = conn.BatchInsert(datas);

                        errCode = 0;
                        errText =
                            string.Format(
                                "在 IRAPDPA..dpa_Imp_SmeltProductionPlan 表中插入 [{0}] 条记录",
                                count);
                    }
                    catch (Exception error)
                    {
                        errCode = 99000;
                        errText =
                            string.Format(
                                "在向 IRAPDPA..dpa_Imp_SmeltProductionPlan 表中插入记录时发生异常：{0}",
                                error.Message);
                        WriteLog.Instance.Write(errText, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    }
                }

                return Json(rlt);
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "在向 IRAPDPA..dpa_Imp_SmeltProductionPlan 表中插入记录时发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult msp_InsertIntoDBF_MO(
            List<dpa_DBF_MO> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            Hashtable rlt = new Hashtable();

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    try
                    {
                        int count = conn.BatchInsert(datas);

                        errCode = 0;
                        errText =
                            string.Format(
                                "在 IRAPDPA..dpa_DBF_MO 表中插入 [{0}] 条记录",
                                count);
                    }
                    catch (Exception error)
                    {
                        errCode = 99000;
                        errText =
                            string.Format(
                                "在向 IRAPDPA..dpa_DBF_MO 表中插入记录时发生异常：{0}",
                                error.Message);
                        WriteLog.Instance.Write(errText, strProcedureName);
                        WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    }
                }

                return Json(rlt);
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "在向 IRAPDPA..dpa_DBF_MO 表中插入记录时发生异常：{0}",
                        error.Message);
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 校验 dpa_Imp_SmeltProductionPlan 中的生产计划是否正确
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="importID">导入批次标识</param>
        /// <param name="sysLogID">系统登录 标识</param>
        public IRAPJsonResult usp_PokaYoke_SmeltPWORelease(
            int communityID,
            long importID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ImportID", DbType.Int64, importID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAPDPA..usp_PokaYoke_SmeltPWORelease，输入参数：" +
                        "CommunityID={0}|ImportID={1}|SysLogID={2}",
                        communityID,
                        importID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error =
                            conn.CallProc(
                                "IRAPDPA..usp_PokaYoke_SmeltPWORelease",
                                ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPDPA..usp_PokaYoke_SmeltPWORelease 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult usp_PokaYoke_DBF_MONumber(
            int communityID,
            long importID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ImportID", DbType.Int64, importID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAPDPA..usp_PokaYoke_DBF_MONumber，输入参数：" +
                        "CommunityID={0}|ImportID={1}|SysLogID={2}",
                        communityID,
                        importID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error =
                            conn.CallProc(
                                "IRAPDPA..usp_PokaYoke_DBF_MONumber",
                                ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPDPA..usp_PokaYoke_DBF_MONumber 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取指定 ImportLogID 的导入记录
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="importLogID">导入标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <returns>List&lt;pda_Imp_SmeltProductionPlan&gt;</returns>
        public IRAPJsonResult mfn_GetList_SmeltProductionPlan(
            int communityID,
            long importLogID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<dpa_Imp_SmeltProductionPlan> datas = new List<dpa_Imp_SmeltProductionPlan>();
                long partitioningKey = communityID * 10000;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@PartitioningKey", DbType.Int64, partitioningKey));
                paramList.Add(new IRAPProcParameter("@ImportLogID", DbType.Int64, importLogID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPDPA..dpa_Imp_SmeltProductionPlan " +
                            "WHERE PartitioningKey=@PartitioningKey AND ImportLogID=@ImportLogID " +
                            "ORDER BY Ordinal";
                        WriteLog.Instance.Write(
                            string.Format(
                                "执行 SQL 语句：[{0}]，" +
                                "参数：@PartitioningKey={1}|@ImportLogID={2}",
                                strSQL, partitioningKey, importLogID),
                            strProcedureName);

                        IList<dpa_Imp_SmeltProductionPlan> lstDatas =
                            conn.CallTableFunc<dpa_Imp_SmeltProductionPlan>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "执行 SQL 语句发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult mfn_GetList_DBF_MO(
            int communityID,
            long importID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<dpa_DBF_MO> datas = new List<dpa_DBF_MO>();
                long partitioningKey = communityID * 10000;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@PartitioningKey", DbType.Int64, partitioningKey));
                paramList.Add(new IRAPProcParameter("@ImportID", DbType.Int64, importID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPDPA..dpa_DBF_MO " +
                            "WHERE PartitioningKey=@PartitioningKey AND ImportID=@ImportID";
                        WriteLog.Instance.Write(
                            string.Format(
                                "执行 SQL 语句：[{0}]，" +
                                "参数：@PartitioningKey={1}|@ImportID={2}",
                                strSQL, partitioningKey, importID),
                            strProcedureName);

                        IList<dpa_DBF_MO> lstDatas =
                            conn.CallTableFunc<dpa_DBF_MO>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "执行 SQL 语句发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 删除 IRAPDPA..dpa_DBF_MO 中指定 importID 的记录
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="importID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult msp_Delete_DPA_DBFMOData(
            int communityID,
            long importID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().DeclaringType.FullName}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            List<IRAPError> data = new List<IRAPError>();
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@ImportID", DbType.Int64, importID));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL =
                            "DELETE FROM IRAPDPA..dpa_DBF_MO " +
                            "WHERE ImportID=@ImportID";
                        WriteLog.Instance.Write(
                            $"执行 SQL 语句:[{strSQL}]，参数：@ImportID={importID}",
                            strProcedureName);
                        var count = conn.CallScalar(strSQL, paramList);
                        IRAPError errInfo = new IRAPError(0, "成功删除旧数据");
                        errCode = errInfo.ErrCode;
                        errText = errInfo.ErrText;
                        WriteLog.Instance.Write(errInfo.ErrText, strProcedureName);
                        data.Add(errInfo);
                    }
                }
                catch (Exception error)
                {
                    IRAPError errInfo = new IRAPError(9999, error.Message);
                    errCode = 9999;
                    errText = $"删除表 IRAPDPA..dpa_DBF_MO 中的数据发生异常：{error.Message}";
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    data.Add(errInfo);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
            return Json(data);
        }

        public IRAPJsonResult usp_UploadMO(
            int communityID,
            long importID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@ImportID", DbType.Int64, importID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    "调用 IRAPDPA..usp_UploadMO，输入参数：" +
                    $"CommunityID={communityID}|ImportID={importID}|" +
                    $"SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error =
                            conn.CallProc(
                                "IRAPDPA..usp_UploadMO",
                                ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPDPA..usp_UploadMO 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(rlt);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 从四班中获取物料的表面处理特性代码
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="materialCode">物料号</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>物料的表面处理特性代码</returns>
        public IRAPJsonResult ufn_GetSurfaceProcessingPropertyCodeFromERP_FourthShift(
            int communityID,
            string materialCode,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@MateiralCode", DbType.String, materialCode));
                WriteLog.Instance.Write(
                    $"调用函数 IRAPDPA.dbo.ufn_GetSurfaceProcessingPropertyCode" +
                    $"FromERP_FourthShift，参数：CommunityID={communityID}|" +
                    $"MaterialCode={1}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string rlt =
                            (string)conn.CallScalarFunc(
                                "IRAPDPA.dbo.ufn_GetSurfaceProcessingPropertyCodeFromERP_FourthShift",
                                paramList);
                        errCode = 0;
                        errText = $"调用成功！Result=[{rlt}]";
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        $"调用 IRAPDPA.dbo.ufn_GetSurfaceProcessingPropertyCodeFromERP_FourthShift " +
                        $"函数发生异常：{error.Message}";
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    return Json(0);
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
