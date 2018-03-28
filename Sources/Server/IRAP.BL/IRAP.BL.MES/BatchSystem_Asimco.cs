﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

using IRAP.Global;
using IRAPORM;
using IRAPShared;
using IRAP.Entities.MES;

namespace IRAP.BL.MES
{
    public class BatchSystem_Asimco : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public BatchSystem_Asimco()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 获取指定工序、工位和设备的当前生产状态
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ufn_GetInfo_SmeltBatchProduct(
            int communityID, 
            int t107LeafID, 
            int t216LeafID, 
            int t133LeafID, 
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
                List<SmeltBatchProductionInfo> datas = 
                    new List<SmeltBatchProductionInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T133LeafID", DbType.Int32, t133LeafID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetInfo_SmeltBatchProduct，" +
                        "参数：CommunityID={0}|T107LeafID={1}|T216LeafID={2}|"+
                        "T133LeafID={3}|SysLogID={4}",
                        communityID, t107LeafID, t216LeafID, t133LeafID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetInfo_SmeltBatchProduct(" +
                            "@CommunityID, @T107LeafID, @T216LeafID, @T133LeafID, " +
                            "@SysLogID)";

                        IList<SmeltBatchProductionInfo> lstDatas =
                            conn.CallTableFunc<SmeltBatchProductionInfo>(strSQL, paramList);
                        datas = lstDatas.ToList();

                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPMES..ufn_GetInfo_SmeltBatchProduct 函数发生异常：{0}",
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
        /// 获取订单信息
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="batchNumber">熔炼容次号</param>
        /// <param name="sysLogID">语言标识</param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_SmeltBatchPWONo(
            int communityID, 
            string batchNumber, 
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
                List<OrderInfo> datas = new List<OrderInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAPMES..ufn_GetList_SmeltBatchPWONo,参数：" +
                        "CommunityID={0}|BatchNumber={1}|SysLogID={2}",
                        communityID, batchNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPMES..ufn_GetList_SmeltBatchPWONo(" +
                            "@CommunityID, @BatchNumber, @SysLogID)";
                        IList<OrderInfo> lstDatas = 
                            conn.CallTableFunc<OrderInfo>(strSQL, paramList);
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
                            "调用函数 IRAPMES..ufn_GetList_SmeltBatchPWONo 发生异常：{0}", 
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
        /// 变更正在生产中的炉次绑定生产工单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="batchNumber">熔次号</param>
        /// <param name="opType">操作类别：A-新增；D-删除</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="moNumber">制造订单号</param>
        /// <param name="moLineNo">制造订单行号</param>
        /// <param name="t102Code">产品物料号</param>
        /// <param name="linkedFactID">关联事实号</param>
        /// <param name="t131Code">材质</param>
        /// <param name="qty">计划数量</param>
        /// <param name="plateNo">型板号</param>
        /// <param name="batchLot">容次号</param>
        /// <param name="machineModelling">造型机台号</param>
        /// <param name="foldNumber">叠数</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult usp_SaveChangeFact_SmeltBatchProduction(
            int communityID,
            string batchNumber,
            string opType,
            string pwoNo,
            string moNumber,
            int moLineNo,
            string t102Code,
            long linkedFactID,
            string t131Code,
            long qty,
            string plateNo,
            string batchLot,
            string machineModelling,
            int foldNumber,
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@OpType", DbType.String, opType));
                paramList.Add(new IRAPProcParameter("@PWONo", DbType.String, pwoNo));
                paramList.Add(new IRAPProcParameter("@MONumber", DbType.String, moNumber));
                paramList.Add(new IRAPProcParameter("@MOLineNo", DbType.Int32, moLineNo));
                paramList.Add(new IRAPProcParameter("@T102Code", DbType.String, t102Code));
                paramList.Add(new IRAPProcParameter("@LinkedFactID", DbType.Int64, linkedFactID));
                paramList.Add(new IRAPProcParameter("@T131Code", DbType.String, t131Code));
                paramList.Add(new IRAPProcParameter("@Qty", DbType.Int64, qty));
                paramList.Add(new IRAPProcParameter("@PlateNo", DbType.String, plateNo));
                paramList.Add(new IRAPProcParameter("@BatchLot", DbType.String, batchLot));
                paramList.Add(new IRAPProcParameter("@MachineModelling", DbType.String, machineModelling));
                paramList.Add(new IRAPProcParameter("@FoldNumber", DbType.Int32, foldNumber));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_SaveChangeFact_SmeltBatchProduction，参数：" +
                        "CommunityID={0}|BatchNumber={1}|OpType={2}|" +
                        "PWONo={3}|MONumber={4}|MOLineNo={5}|T102Code={6}|" +
                        "LinkedFactID={7}|T131Code={8}|Qty={9}|PlateNo={10}|" +
                        "BatchLot={11}|MachineModelling={12}|FoldNumber={13}|" +
                        "SysLogID={14}",
                        communityID, batchNumber, opType, pwoNo, moNumber,
                        moLineNo, t102Code, linkedFactID, t131Code,
                        qty, plateNo, batchLot, machineModelling,
                        foldNumber, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveChangeFact_SmeltBatchProduction", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    return Json(error);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "调用 IRAPMES..usp_SaveChangeFact_SmeltBatchProduction 函数发生异常：{0}",
                        error.Message);
                return Json(
                    new IRAPError()
                    {
                        ErrCode = errCode,
                        ErrText = errText,
                    });
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 以保存的熔炼批次检验数据删除
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t216LeafID">产品叶标识</param>
        /// <param name="t107LeafID">工位叶标识</param>
        /// <param name="batchNumber">容次号</param>
        /// <param name="opType">操作标识：D-删除；U-修改(暂不支持)</param>
        /// <param name="factID">保存的工艺参数数据事实编号</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult usp_SaveFact_SmeltBatchMethodCancel(
            int communityID,
            int t216LeafID,
            int t107LeafID,
            string batchNumber,
            string opType,
            long factID,
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
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@T216LeafID", DbType.Int32, t216LeafID));
                paramList.Add(new IRAPProcParameter("@T107LeafID", DbType.Int32, t107LeafID));
                paramList.Add(new IRAPProcParameter("@BatchNumber", DbType.String, batchNumber));
                paramList.Add(new IRAPProcParameter("@OpType", DbType.String, opType));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "执行存储过程 IRAPMES..usp_SaveFact_SmeltBatchMethodCancel，参数：" +
                        "CommunityID={0}|T216LeafID={1}|T107LeafID={2}|BatchNumber={3}|"+
                        "OpType={4}|FactID={5}|SysLogID={6}",
                        communityID, t216LeafID, t107LeafID, batchNumber, opType, 
                        factID, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error =
                        conn.CallProc("IRAPMES..usp_SaveFact_SmeltBatchMethodCancel", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    return Json(error);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText =
                    string.Format(
                        "调用 IRAPMES..usp_SaveFact_SmeltBatchMethodCancel 函数发生异常：{0}",
                        error.Message);
                return Json(
                    new IRAPError()
                    {
                        ErrCode = errCode,
                        ErrText = errText,
                    });
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}