﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

using IRAP.Global;
using IRAP.Entity.FVS;

namespace IRAP.WCF.Client.Method
{
    public class IRAPFVSClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private static IRAPFVSClient _instance = null;

        private IRAPFVSClient()
        {
        }

        public static IRAPFVSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPFVSClient();
                return _instance;
            }
        }

        public void ufn_GetT132ClickStream(
            int communityID,
            long sysLogID,
            ref string t132ClickStream,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                t132ClickStream = "";

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetT132ClickStream，输入参数：" +
                        "CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.IRAPFVS",
                        "ufn_GetT132ClickStream",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        t132ClickStream = rlt as string;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_GetT134ClickStream(
            int communityID,
            long sysLogID,
            ref string t134ClickStream,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                t134ClickStream = "";

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetT134ClickStream，输入参数：" +
                        "CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.IRAPFVS",
                        "ufn_GetT134ClickStream",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        t134ClickStream = rlt as string;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取当前站点绑定产线的安灯告警灯状态
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonLightStatus(
            int communityID,
            long sysLogID,
            ref List<AndonLightStatus> datas,
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
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_AndonLightStatus 函数， " +
                        "参数：CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonLightStatus",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonLightStatus>;
                    }
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 从产线触发安灯呼叫：
        /// ⒈ 呼叫产线设备的故障维修；
        /// ⒉ 呼叫产线的原辅材料及半成品配送；
        /// ⒊ 呼叫产线在制品的质量问题解决；
        /// ⒋ 呼叫产线设备的工装更换；
        /// ⒌ 呼叫产线安全问题解决；
        /// ⒍ 呼叫产线其他干系人现场支持
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="t179LeafID">安灯事件类型叶标识</param>
        /// <param name="t134LeafID">呼叫产线叶标识</param>
        /// <param name="t133LeafID">呼叫设备叶标识</param>
        /// <param name="objectTreeID">呼叫对象树标识</param>
        /// <param name="objectLeafID">呼叫对象叶标识</param>
        /// <param name="objectCode">呼叫对象代码</param>
        /// <param name="productionDown">是否已停产(0-未停产；1-已停产)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_AndonEventCallFromProductionLine(
            int communityID,
            long transactNo,
            long factID,
            int t179LeafID,
            int t134LeafID,
            int t133LeafID,
            int objectTreeID,
            int objectLeafID,
            string objectCode,
            bool productionDown,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("transactNo", transactNo);
                    hashParams.Add("factID", factID);
                    hashParams.Add("t179LeafID", t179LeafID);
                    hashParams.Add("t134LeafID", t134LeafID);
                    hashParams.Add("t133LeafID", t133LeafID);
                    hashParams.Add("objectTreeID", objectTreeID);
                    hashParams.Add("objectLeafID", objectLeafID);
                    hashParams.Add("objectCode", objectCode);
                    hashParams.Add("productionDown", productionDown);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventCallFromProductionLine，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "T179LeafID={3}|T134LeafID={4}|T133LeafID={5}|"+
                            "ObjectTreeID={6}|ObjectLeafID={7}|ObjectCode={8}|"+
                            "ProductionDown={9}|SysLogID={10}",
                            communityID, transactNo, factID, t179LeafID, t134LeafID, 
                            t133LeafID, objectTreeID, objectLeafID, objectCode,
                            productionDown, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventCallFromProductionLine",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件现场响应
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">关闭人用户代码</param>
        /// <param name="sysLogID">关闭站点系统登录标识</param>
        public void usp_SaveFact_AndonEventOnSiteRespond(
            int communityID,
            long transactNo,
            long factID,
            long eventFactID,
            int opID,
            string userCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("transactNo", transactNo);
                    hashParams.Add("factID", factID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventOnSiteRespond，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "EventFactID={3}|OpID={4}|UserCode={5}|SysLogID={6}",
                            communityID, transactNo, factID, eventFactID, opID,
                            userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventOnSiteRespond",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件关闭
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">申请到的交易号</param>
        /// <param name="factID">申请到的事实编号</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">关闭人用户代码</param>
        /// <param name="satisfactoryLevel">
        /// 满意度评价：
        /// 1-非常满意；
        /// 2-满意；
        /// 3-一般；
        /// 4-不满意
        /// </param>
        /// <param name="sysLogID">关闭站点系统登录标识</param>
        public void usp_SaveFact_AndonEventClose(
            int communityID,
            long transactNo,
            long factID,
            long eventFactID,
            int opID,
            string userCode,
            int satisfactoryLevel,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("transactNo", transactNo);
                    hashParams.Add("factID", factID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("satisfactoryLevel", satisfactoryLevel);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventOnSiteRespond，输入参数：" +
                            "CommunityID={0}|TransactNo={1}|FactID={2}|" +
                            "EventFactID={3}|OpID={4}|UserCode={5}|"+
                            "SatisfactoryLevel={6}|SysLogID={7}",
                            communityID, transactNo, factID, eventFactID, opID,
                            userCode, satisfactoryLevel, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_SaveFact_AndonEventClose",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取待响应的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public void ufn_GetList_AndonEventsToRespond(
            int communityID,
            string userCode,
            long sysLogID,
            ref List<AndonRspEventInfo> datas,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToRespond，输入参数：" +
                            "CommunityID={0}|UserCode={1}|SysLogID={2}",
                            communityID, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToRespond",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonRspEventInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取待关闭的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_AndonEventsToClose(
            int communityID,
            long sysLogID,
            ref List<AndonEventToClose> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToClose，输入参数：" +
                            "CommunityID={0}|SysLogID={1}",
                            communityID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToClose",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventToClose>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取可撤销的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public void ufn_GetList_AndonEventsToCancel(
            int communityID,
            string userCode,
            long sysLogID,
            ref List<AndonEventInfo> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToCancel，输入参数：" +
                            "CommunityID={0}|UserCode={1}|SysLogID={2}",
                            communityID, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToCancel",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件撤销授权请求
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventID">申请授权事件标识(事实编号/交易号)</param>
        /// <param name="userCode">申请授权人用户代码</param>
        /// <param name="userName">申请授权人姓名</param>
        /// <param name="menuItemID">当前菜单项标识</param>
        /// <param name="t2LeafID">授权人角色叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_AuthorizationRequest(
            int communityID,
            long eventID,
            string userCode,
            string userName,
            int menuItemID,
            int t2LeafID,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventID", eventID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("userName", userName);
                    hashParams.Add("menuItemID", menuItemID);
                    hashParams.Add("t2LeafID", t2LeafID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_SaveFact_AndonEventOnSiteRespond，输入参数：" +
                            "CommunityID={0}|EventID={1}|UserCode={2}|" +
                            "UserName={3}|MenuItemID={4}|T2LeafID={5}|" +
                            "SysLogID={6}",
                            communityID, eventID, userCode, userName, menuItemID,
                            t2LeafID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AuthorizationRequest",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件撤销
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="eventFactID">安灯事件标识</param>
        /// <param name="opID">业务操作标识</param>
        /// <param name="userCode">撤销人用户代码</param>
        /// <param name="veriCode">撤销授权码(短信)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_AndonEventCancel(
            int communityID,
            long eventFactID,
            int opID,
            string userCode,
            string veriCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("veriCode", veriCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_AndonEventCancel，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|" +
                            "UserCode={3}|VeriCode={4}|SysLogID={5}",
                            communityID, eventFactID, opID, userCode,
                            veriCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AndonEventCancel",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 获取本人已响应未关闭的安灯事件清单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="userCode">用户代码</param>
        /// <param name="sysLogID">响应站点系统登录标识</param>
        public void ufn_GetList_AndonEventsToForward(
            int communityID,
            string userCode,
            long sysLogID,
            ref List<AndonEventInfo> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_AndonEventsToForward，输入参数：" +
                            "CommunityID={0}|UserCode={1}|SysLogID={2}",
                            communityID, userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_AndonEventsToForward",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<AndonEventInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_GetList_ResponsibleRespondersToInform(
            int communityID,
            long eventFactID,
            int opID,
            long sysLogID,
            ref List<ResponsibleResponderInfo> datas,
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
                datas.Clear();

                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 ufn_GetList_ResponsibleRespondersToInform，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|SysLogID={3}",
                            communityID, eventFactID, opID, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 执行存储过程或者函数
                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.FVS.dll",
                            "IRAP.BL.FVS.Andon",
                            "ufn_GetList_ResponsibleRespondersToInform",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ResponsibleResponderInfo>;
                    }
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 安灯事件追加呼叫
        /// </summary>
        public void usp_AndonEventForwarding(
            int communityID,
            long eventFactID,
            int opID,
            int ordinal,
            string userCode,
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
                using (WCFClient client = new WCFClient())
                {
                    Hashtable hashParams = new Hashtable();

                    #region 将函数参数加入 Hashtable 中
                    hashParams.Add("communityID", communityID);
                    hashParams.Add("eventFactID", eventFactID);
                    hashParams.Add("opID", opID);
                    hashParams.Add("ordinal", ordinal);
                    hashParams.Add("userCode", userCode);
                    hashParams.Add("sysLogID", sysLogID);
                    WriteLog.Instance.Write(
                        string.Format(
                            "执行存储过程 usp_AndonEventForwarding，输入参数：" +
                            "CommunityID={0}|EventFactID={1}|OpID={2}|" +
                            "Ordinal={3}|UserCode={4}|SysLogID={5}",
                            communityID, eventFactID, opID, ordinal,
                            userCode, sysLogID),
                        strProcedureName);
                    #endregion

                    #region 调用应用服务过程，并解析返回值
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.Andon",
                        "usp_AndonEventForwarding",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
                    #endregion
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_EWI_GetInfo_ShowPaper(
            int communityID,
            int processLeaf,
            int workUnitLeaf,
            long sysLogID,
            ref EWIShowPaperInfo data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new EWIShowPaperInfo();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("processLeaf", processLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_EWI_GetInfo_ShowPaper，输入参数：" +
                        "CommunityID={0}|ProcessLeaf={1}|WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        processLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.EWI",
                        "ufn_EWI_GetInfo_ShowPaper",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as EWIShowPaperInfo;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void ufn_EWI_GetInfo_PSShowPaper(
            int communityID,
            int processLeaf,
            int workUnitLeaf,
            long sysLogID,
            ref EWIPSShowPaperInfo data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new EWIPSShowPaperInfo();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("processLeaf", processLeaf);
                hashParams.Add("workUnitLeaf", workUnitLeaf);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_EWI_GetInfo_PSShowPaper，输入参数：" +
                        "CommunityID={0}|ProcessLeaf={1}|WorkUnitLeaf={2}|SysLogID={3}",
                        communityID,
                        processLeaf,
                        workUnitLeaf,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.FVS.dll",
                        "IRAP.BL.FVS.EWI",
                        "ufn_EWI_GetInfo_PSShowPaper",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = rlt as EWIPSShowPaperInfo;
                }
                #endregion
            }
            catch (Exception error)
            {
                errCode = -1001;
                errText = error.Message;
                WriteLog.Instance.Write(errText, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}