﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

using IRAP.Global;
using IRAP.Server.Global;
using IRAPShared;
using IRAPORM;
using IRAP.Entity.SSO;
using IRAP.Entities.SSO;
using IRAP.Entities.IRAP;

namespace IRAP.BL.SSO
{
    public class IRAPUser : IRAPBLLBase
    {
        private static string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public IRAPUser()
        {
            WriteLog.Instance.WriteLogFileName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        public IRAPJsonResult sfn_PostLoginCMDs(
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<CMDString> datas = new List<CMDString>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(string.Format("调用函数 IRAP..sfn_PostLoginCMDs，参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_PostLoginCMDs(@SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<CMDString> lstDatas = conn.CallTableFunc<CMDString>(strSQL, paramList);
                        datas = lstDatas.ToList<CMDString>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_PostLoginCMDs 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult sfn_PostLogoutCMDs(
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<CMDString> datas = new List<CMDString>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(string.Format("调用函数 IRAP..sfn_PostLogoutCMDs，参数：SysLogID={0}",
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_PostLogoutCMDs(@SysLogID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<CMDString> lstDatas = conn.CallTableFunc<CMDString>(strSQL, paramList);
                        datas = lstDatas.ToList<CMDString>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_PostLogoutCMDs 函数发生异常：{0}", error.Message);
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
        /// 获取用户名及密码验证的结果（0:验证不通过；-1:信息站点未注册;>0:验证通过，返回社区标识号）
        /// </summary>
        /// <param name="userCode">用户代码</param>
        /// <param name="plainPWD">用户密码明码</param>
        /// <param name="veriCode">验证码，不需时传空串</param>
        /// <param name="stationID">验证站点或社区标识</param>
        public IRAPJsonResult sfn_UserPWDVerify(
            string userCode,
            string plainPWD,
            string veriCode,
            string stationID,
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
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@PlainPWD", DbType.String, plainPWD));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP.dbo.sfn_UserPWDVerify，参数：UserCode={0}|"+
                        "PlainPWD={1}|VeriCode={2}|StationID={3}",
                        userCode,
                        plainPWD,
                        veriCode,
                        stationID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        int rlt = (int)conn.CallScalarFunc("IRAP.dbo.sfn_UserPWDVerify", paramList);
                        if (rlt == -1)
                        {
                            errCode = -1;
                            errText =
                                string.Format(
                                    "站点[{0}]未注册！",
                                    stationID);
                        }
                        else
                        {
                            errCode = 0;
                            errText = "调用成功！";
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP.dbo.sfn_UserPWDVerify 函数发生异常：{0}", error.Message);
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

        /// <summary>
        /// 申请系统登录标识 , 必要时也获取短信验证码
        /// </summary>
        /// <remarks>
        /// UserCode        string          用户代码
        /// StationID       string          站点标识/社区标识
        /// 输出
        /// SysLogID        long            系统登录标识
        /// SMSVeriCode     string          短信验证码
        /// </remarks>
        /// <param name="userCode">用户代码</param>
        /// <param name="stationID">站点标识/社区标识</param>
        public IRAPJsonResult ssp_GetSysLogID(
            string userCode,
            string stationID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}", className, MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@SMSVeriCode", DbType.String, ParameterDirection.Output, 10));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_GetSysLogID", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        Hashtable rlt = new Hashtable();
                        rlt = DBUtils.DBParamsToHashtable(paramList);

                        foreach (DictionaryEntry entry in rlt)
                        {
                            WriteLog.Instance.Write(
                                string.Format(
                                    "[{0}]=[{1}]",
                                    entry.Key,
                                    entry.Value),
                                strProcedureName);
                        }

                        return Json(rlt);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 ssp_GetSysLogID 函数发生异常：{0}", error.Message);
                    return Json(new Hashtable());
                }
                #endregion
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 退出 IRAP 平台
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="userDiary">工作日志</param>
        public IRAPJsonResult ssp_Logout(
            int communityID,
            long sysLogID,
            string userDiary,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserDiary", DbType.String, userDiary));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrCode",
                        DbType.Int32,
                        ParameterDirection.Output,
                        4));
                paramList.Add(
                    new IRAPProcParameter(
                        "@ErrText",
                        DbType.String,
                        ParameterDirection.Output,
                        400));
                WriteLog.Instance.Write(string.Format("执行存储过程 IRAP..ssp_Logout，参数：" +
                        "CommunityID={0}|UserDiary={1}|SysLogID={2}",
                        communityID, userDiary, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_Logout", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_Logout 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult ssp_ModiPWD(
            int communityID,
            string userCode,
            string oldPassword,
            string newPassword,
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
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@OldPWD", DbType.String, oldPassword));
                paramList.Add(new IRAPProcParameter("@NewPWD", DbType.String, newPassword));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAP..ssp_ModiPWD，参数：" +
                        "CommunityID={0}|UserCode={1}|OldPWD={2}|NewPWD={3}",
                        communityID, userCode, oldPassword, newPassword),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_ModiPWD", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;

                    return Json("");
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_ModiPWD 时发生异常：{0}", error.Message);
                return Json("");
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 登录 IRAP 平台
        /// 1、校验用户名、用户密码、验证码集信息站点的合法性
        /// 2、校验通过时写系统登录日志，取得用户及站点的有关信息
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="plainPWD">登录密码</param>
        /// <param name="veriCode">验证码</param>
        /// <param name="stationID">站点标识</param>
        /// <param name="ipAddress">IP 地址</param>
        /// <param name="agencyLeaf">登录机构叶标识</param>
        /// <param name="roleLeaf">登录角色叶标识</param>
        /// <param name="sysLogID">系统登录标识（可预先获取）</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns>
        /// [
        ///     UserName string: 用户姓名
        ///     NickName string: 用户昵称
        ///     SysLogID long: 系统登录标识
        ///     LanguageID int: 语言标识
        ///     OPHoneNo string: 办公电话
        ///     HPhoneNo string: 住宅电话
        ///     MPhoneNo string: 移动电话
        ///     AgencyID int: 机构标识
        ///     AgencyName string: 机构名称
        ///     HostName string: 主机名
        /// ]
        /// </returns>
        public IRAPJsonResult ssp_Login(
            string dbName,
            string userCode,
            string plainPWD,
            string veriCode,
            string stationID,
            string ipAddress,
            int agencyLeaf,
            int roleLeaf,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            string userName = "";
            string nickName = "";
            int languageID = 30;
            string oPhoneNo = "";
            string hPhoneNo = "";
            string mPhoneNo = "";
            int agencyID = 0;
            string hostName = "";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@DBName", DbType.String, dbName));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@PlainPWD", DbType.String, plainPWD));
                paramList.Add(new IRAPProcParameter("@VeriCode", DbType.String, veriCode));
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                paramList.Add(new IRAPProcParameter("@IPAddress", DbType.String, ipAddress));
                paramList.Add(new IRAPProcParameter("@AgencyLeaf", DbType.Int32, agencyLeaf));
                paramList.Add(new IRAPProcParameter("@RoleLeaf", DbType.Int32, roleLeaf));
                paramList.Add(new IRAPProcParameter("@UserName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@NickName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, ParameterDirection.InputOutput, 8)
                {
                    Value = sysLogID,
                });
                paramList.Add(new IRAPProcParameter("@LanguageID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@OPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@HPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@MPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@AgencyID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@AgencyName", DbType.String, ParameterDirection.Output, 100));
                paramList.Add(new IRAPProcParameter("@HostName", DbType.String, ParameterDirection.Output, 30));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format("执行存储过程 IRAP..ssp_Login，参数：" +
                        "DBName={0}|UserCode={1}|PlainPWD={2}|VeriCode={3}"+
                        "StationID={4}|IPAddress={5}|AgencyLeaf={6}|"+
                        "RoleLeaf={7}|SysLogID={8}",
                        dbName, userCode, plainPWD, veriCode, stationID, 
                        ipAddress, agencyLeaf, roleLeaf, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                using (IRAPSQLConnection conn = new IRAPSQLConnection())
                {
                    IRAPError error = conn.CallProc("IRAP..ssp_Login", ref paramList);
                    errCode = error.ErrCode;
                    errText = error.ErrText;
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", 
                            errCode, 
                            errText), 
                        strProcedureName);

                    Hashtable rtnParams = new Hashtable();
                    rtnParams = DBUtils.DBParamsToHashtable(paramList);

                    foreach (DictionaryEntry entry in rtnParams)
                    {
                        WriteLog.Instance.Write(
                            string.Format(
                                "[{0}]=[{1}]",
                                entry.Key,
                                entry.Value),
                            strProcedureName);
                    }

                    return Json(rtnParams);
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = 99000;
                errText = string.Format("调用 IRAP..ssp_Login 时发生异常：{0}", error.Message);
                return Json(new Hashtable());
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据员工身份识别卡获取用户信息
        /// </summary>
        /// <param name="communityID">社区标识号</param>
        /// <param name="cardNo">用户 ID 卡号</param>
        /// <returns>UserInfo</returns>
        public IRAPJsonResult sfn_GetInfo_UserFromIDCard(int communityID, string cardNo, out int errCode, out string errText)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                UserInfo data = new UserInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@CardNo", DbType.String, cardNo));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetInfo_UserFromIDCard，" +
                        "参数：CommunityID={0}|CardNo={1}",
                        communityID, cardNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_GetInfo_UserFromIDCard(" +
                            "@CommunityID, @CardNo)";

                        IList<UserInfo> lstDatas = conn.CallTableFunc<UserInfo>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("没有[{0}]的用户信息", cardNo);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetInfo_UserFromIDCard 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(data);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 根据用户 ID 卡号，获取用户名
        /// </summary>
        public IRAPJsonResult sfn_GetUserCodeFromIDCard(int communityID, string cardNo, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        public IRAPJsonResult sfn_UserAgencies(int communityID, string userCode, out int errCode, out string errText)
        {
            string strProcedureName = 
                string.Format(
                    "{0}.{1}", 
                    className, 
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<AgencyInfo> datas = new List<AgencyInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_UserAgencies，" +
                        "参数：CommunityID={0}|UserCode={1}",
                        communityID, userCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_UserAgencies(" +
                            "@CommunityID, @UserCode)";

                        IList<AgencyInfo> lstDatas = conn.CallTableFunc<AgencyInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<AgencyInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_UserAgencies 函数发生异常：{0}", error.Message);
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

        public IRAPJsonResult sfn_UserRoles(int communityID, string userCode, out int errCode, out string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<RoleInfo> datas = new List<RoleInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_UserRoles，" +
                        "参数：CommunityID={0}|UserCode={1}",
                        communityID, userCode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_UserRoles(" +
                            "@CommunityID, @UserCode)";

                        IList<RoleInfo> lstDatas = conn.CallTableFunc<RoleInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<RoleInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_UserRoles 函数发生异常：{0}", error.Message);
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
        /// 获取机构中用户角色清单用于登录时角色选择
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="agencyID">机构实体标识</param>
        /// <returns>List[RoleInfo]</returns>
        public IRAPJsonResult sfn_UserRolesInAgency(
            int communityID,
            string userCode,
            int agencyID,
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
                List<RoleInfo> datas = new List<RoleInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@AgencyID", DbType.Int32, agencyID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_UserRolesInAgency，" +
                        "参数：CommunityID={0}|UserCode={1}|AgencyID={2}",
                        communityID, userCode, agencyID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_UserRolesInAgency(" +
                            "@CommunityID, @UserCode, @AgencyID)";
                        WriteLog.Instance.Write(strSQL, strProcedureName);

                        IList<RoleInfo> lstDatas = conn.CallTableFunc<RoleInfo>(strSQL, paramList);
                        datas = lstDatas.ToList<RoleInfo>();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_UserRolesInAgency 函数发生异常：{0}", error.Message);
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

        public void ssp_SetPWD(string userCode, string userPWD, out int errCode, out string errText)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 返回指定信息站点的系统登录信息（适合无登录的展现系统）
        /// </summary>
        /// <param name="stationID">站点标识</param>
        /// <returns>StationLogin</returns>
        public IRAPJsonResult sfn_GetInfo_StationLogin(
            string stationID, 
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
                StationLogin data = new StationLogin();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@StationID", DbType.String, stationID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetInfo_StationLogin，" +
                        "参数：StationID={0}",
                        stationID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * FROM IRAP..sfn_GetInfo_StationLogin(" +
                            "@StationID)";

                        IList<StationLogin> lstDatas = conn.CallTableFunc<StationLogin>(strSQL, paramList);
                        if (lstDatas.Count > 0)
                        {
                            data = lstDatas[0].Clone();
                            errCode = 0;
                            errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                        }
                        else
                        {
                            errCode = 99001;
                            errText = string.Format("没有[{0}]站点的系统登录信息", stationID);
                        }
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 IRAP..sfn_GetInfo_StationLogin 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(data);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public IRAPJsonResult sfn_CIDInfo(
            string idCardNo,
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
                EntityCIDInfo data = new EntityCIDInfo();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@IDCardNo", DbType.String, idCardNo));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 sfn_CIDInfo，" +
                        "参数：IDCardNo={0}",
                        idCardNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    //using (IRAPOracleConnection conn = new IRAPOracleConnection())
                    //{
                    //    IList<EntityCIDInfo> lstDatas = conn.CallFunction<EntityCIDInfo>("sfn_CIDInfo", paramList);
                    //    if (lstDatas.Count > 0)
                    //    {
                    //        data = lstDatas[0].Clone();
                    //        errCode = 0;
                    //        errText = string.Format("调用成功！共获得 {0} 条记录", lstDatas.Count);
                    //    }
                    //    else
                    //    {
                    //        errCode = 99001;
                    //        errText = string.Format("身份证号[{0}]解析失败！", idCardNo);
                    //    }
                    //    WriteLog.Instance.Write(errText, strProcedureName);
                    //}
                    errCode = 99001;
                    errText = $"身份证号[{idCardNo}]解析失败，未找到 sfn_CIDInfo 函数";
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText = string.Format("调用 sfn_CIDInfo 函数发生异常：{0}", error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(data);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 替换交易操作员
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">交易号</param>
        /// <param name="operatorUserCode">替换后的交易操作员号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public IRAPJsonResult ssp_ReplaceTranOperator(
            int communityID,
            long transactNo,
            string operatorUserCode,
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
                paramList.Add(new IRAPProcParameter("@TransactNo", DbType.Int64, transactNo));
                paramList.Add(new IRAPProcParameter("@OperatorUserCode", DbType.String, operatorUserCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 IRAP..ssp_ReplaceTranOperator，输入参数：" +
                        "CommunityID={0}|TransactNo={1}|OperatorUserCode={2}"+
                        "|SysLogID={3}",
                        communityID, transactNo, operatorUserCode, sysLogID),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        IRAPError error = conn.CallProc("IRAP..ssp_ReplaceTranOperator", ref paramList);
                        errCode = error.ErrCode;
                        errText = error.ErrText;

                        rlt = DBUtils.DBParamsToHashtable(paramList);

                        foreach (DictionaryEntry entry in rlt)
                        {
                            WriteLog.Instance.Write(
                                string.Format(
                                    "[{0}]=[{1}]",
                                    entry.Key,
                                    entry.Value),
                                strProcedureName);
                        }
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

        /// <summary>
        /// 根据社区号获取系统登记的用户列表
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">需要检索的用户代码</param>
        /// <param name="userBarcode">需要检索的用户替代代码</param>
        /// <returns>List[UserDetailInfo]</returns>
        public IRAPJsonResult sfn_GetList_UsersOfACommunity(
            int communityID,
            string userCode,
            string userBarcode,
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
                List<UserDetailInfo> datas = new List<UserDetailInfo>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                WriteLog.Instance.Write(
                    string.Format(
                        "调用函数 IRAP..sfn_GetList_UsersOfACommunity，" +
                        "参数：CommunityID={0}|UserCode={1}|UserCodeBarcode={2}",
                        communityID,
                        userCode,
                        userBarcode),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..sfn_GetList_UsersOfACommunity(" +
                            "@CommunityID) ";

                        if (userCode != "")
                            strSQL +=
                                string.Format("WHERE UserCode='{0}'", userCode);
                        else if (userBarcode != "")
                            strSQL +=
                                string.Format("WHERE UserCodeBarcode='{0}'", userBarcode);

                        IList<UserDetailInfo> lstDatas =
                            conn.CallTableFunc<UserDetailInfo>(strSQL, paramList);
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
                            "调用 IRAP..sfn_GetList_UsersOfACommunity 函数发生异常：{0}",
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

        public IRAPJsonResult mfn_GetList_Users(
            int communityID,
            string userCode,
            string idCardNo,
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
                List<STB006> datas = new List<STB006>();
                long partitioningKey = communityID * 10000;

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@PartitioningKey", DbType.Int64, partitioningKey));
                paramList.Add(new IRAPProcParameter("@UserCode", DbType.String, userCode));
                paramList.Add(new IRAPProcParameter("@IDCardNo", DbType.String, idCardNo));
                WriteLog.Instance.Write(
                    string.Format(
                        "检索 IRAP..stb006 表，" +
                        "参数：CommunityID={0}|UserCode={1}|IDCardNo={2}",
                        communityID,
                        userCode,
                        idCardNo),
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAP..stb006 WHERE PartitioningKey=@PartitioningKey";

                        if (userCode != "")
                            strSQL += $" AND UserCode='{userCode}' OR CardNo='{userCode}'";
                        if (idCardNo != "")
                            strSQL += $" AND CardNo='{idCardNo}' OR UserCode='{idCardNo}'";

                        IList<STB006> lstDatas =
                            conn.CallTableFunc<STB006>(strSQL, paramList);
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
                            "检索 IRAP..stb006 表发生异常：{0}",
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
        /// 切换当前登录用户
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="newUserBarCode">新登录用户的登录条码</param>
        public IRAPJsonResult usp_SwapUserLogin(
            int communityID, 
            long sysLogID, 
            string newUserBarCode, 
            out int errCode, 
            out string errText)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                Hashtable rlt = new Hashtable();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@NewUserBarCode", DbType.String, newUserBarCode));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                paramList.Add(new IRAPProcParameter("@ErrCode", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@ErrText", DbType.String, ParameterDirection.Output, 400));
                paramList.Add(new IRAPProcParameter("@NewSysLogID", DbType.Int64, ParameterDirection.Output, 8));
                paramList.Add(new IRAPProcParameter("@NewUserCode", DbType.String, ParameterDirection.Output, 100));
                paramList.Add(new IRAPProcParameter("@NewUserName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@NewLanguageID", DbType.Int32, ParameterDirection.Output, 4));
                paramList.Add(new IRAPProcParameter("@NewNickName", DbType.String, ParameterDirection.Output, 40));
                paramList.Add(new IRAPProcParameter("@NewOPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@NewHPhoneNo", DbType.String, ParameterDirection.Output, 20));
                paramList.Add(new IRAPProcParameter("@NewMPhoneNo", DbType.String, ParameterDirection.Output, 20));
                WriteLog.Instance.Write(
                    $"执行存储过程 IRAP..usp_SwapUserLogin，参数：" +
                    $"CommunityID={communityID}|NewUserBarCode={newUserBarCode}|" +
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
                                "IRAP..usp_SwapUserLogin",
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
                            "调用 IRAP..usp_SwapUserLogin 函数发生异常：{0}",
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
    }
}