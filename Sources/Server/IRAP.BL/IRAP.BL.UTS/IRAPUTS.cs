﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Data;

using IRAP.Global;
using IRAP.Server.Global;
using IRAPShared;
using IRAPORM;

namespace IRAP.BL.UTS
{
    public class IRAPUTS : IRAPBLLBase
    {
        private static string className = 
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPUTS()
        {
            WriteLog.Instance.WriteLogFileName = 
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 申请序列号
        /// ⒈ 申请预定义序列的一个或多个序列号；
        /// ⒉ 如果序列是交易号的，自动写交易日志。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sequenceCode">序列代码</param>
        /// <param name="count">申请序列值个数</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="opNode">业务操作节点列表</param>
        /// <param name="voucherNo">业务凭证号</param>
        /// <returns>申请到的第一个序列值[long]</returns>
        public IRAPJsonResult ssp_GetSequenceNo(
            int communityID, 
            string sequenceCode, 
            int count, 
            long sysLogID, 
            string opNode, 
            string voucherNo, 
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
                paramList.Add(new IRAPProcParameter("@SequenceCode", DbType.String, sequenceCode));
                paramList.Add(new IRAPProcParameter("@Count", DbType.Int32, count));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@OpNode", DbType.String, opNode));
                paramList.Add(new IRAPProcParameter("@VoucherNo", DbType.String, voucherNo));
                paramList.Add(new IRAPProcParameter("@SequenceNo", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_GetSequenceNo，输入参数：" +
                        "CommunityID={0}|SequenceCode={1}|Count={2}|SysLogID={3}"+
                        "OpNode={4}|VoucherNo={5}",
                        communityID, sequenceCode, count, sysLogID, opNode, voucherNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_GetSequenceNo", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_GetSequenceNo 函数发生异常：{0}", error.Message);
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
        /// 保存万能表单采集的数据
        /// </summary>
        public IRAPJsonResult ssp_OLTP_UDFForm(
            int communityID, 
            long transactNo, 
            long factID, 
            int ctrlParameter1, 
            int ctrlParameter2, 
            int ctrlParameter3, 
            long sysLogID, 
            string strParameter1, 
            string strParameter2, 
            string strParameter3, 
            string strParameter4, 
            string strParameter5, 
            string strParameter6, 
            string strParameter7, 
            string strParameter8, 
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
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@CtrlParameter1", DbType.Int32, ctrlParameter1));
                paramList.Add(new IRAPProcParameter("@CtrlParameter2", DbType.Int32, ctrlParameter2));
                paramList.Add(new IRAPProcParameter("@CtrlParameter3", DbType.Int32, ctrlParameter3));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@OutputStr", DbType.String, ParameterDirection.Output, 2147483647));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                paramList.Add(new IRAPProcParameter("@StrParameter1", DbType.String, strParameter1));
                paramList.Add(new IRAPProcParameter("@StrParameter2", DbType.String, strParameter2));
                paramList.Add(new IRAPProcParameter("@StrParameter3", DbType.String, strParameter3));
                paramList.Add(new IRAPProcParameter("@StrParameter4", DbType.String, strParameter4));
                paramList.Add(new IRAPProcParameter("@StrParameter5", DbType.String, strParameter5));
                paramList.Add(new IRAPProcParameter("@StrParameter6", DbType.String, strParameter6));
                paramList.Add(new IRAPProcParameter("@StrParameter7", DbType.String, strParameter7));
                paramList.Add(new IRAPProcParameter("@StrParameter8", DbType.String, strParameter8));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_OLTP_UDFForm，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|FactID={2}|CtrlParameter1={3}" +
                        "CtrlParameter2={4}|CtrlParameter3={5}|SysLogID={6}|StrParameter1={7}|" +
                        "StrParameter2={8}|StrParameter3={9}|StrParameter4={10}|StrParameter5={11}|" +
                        "StrParameter6={12}|StrParameter7={13}|StrParameter8={14}",
                        communityID, transactNo, factID, ctrlParameter1, ctrlParameter2,
                        ctrlParameter3, sysLogID, strParameter1, strParameter2, strParameter3,
                        strParameter4, strParameter5, strParameter6, strParameter7, strParameter8),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_OLTP_UDFForm", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..ssp_OLTP_UDFForm 函数发生异常：{0}", error.Message);
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
    }
}