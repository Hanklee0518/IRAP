﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entities.APS;

namespace IRAP.WCF.Client.Method
{
    public class IRAPAPSClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static IRAPAPSClient _instance = null;

        private IRAPAPSClient()
        {

        }

        public static IRAPAPSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPAPSClient();
                return _instance;
            }
        }

        /// <summary>
        /// 获取制造订单格式字符串
        /// </summary>
        public void ufn_GetAccessibleMOPattern(
            int communityID,
            long sysLogID,
            ref string moPattern,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetAccessibleMOPattern，输入参数：" +
                        "CommunityID={0}|SysLogID={1}",
                        communityID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.APS.dll",
                        "IRAP.BL.APS.IRAPAPS",
                        "ufn_GetAccessibleMOPattern",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}，MOPattern={2}",
                            errCode,
                            errText,
                            (string)rlt),
                        strProcedureName);

                    if (errCode == 0)
                        moPattern = (string)rlt;
                    else
                        moPattern = "";
                }
                #endregion
            }
            catch (Exception error)
            {
                moPattern = "";
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="t124LeafID">制造区域叶标识</param>
        /// <param name="moPattern">MO号格式</param>
        /// <param name="dtfInDays">需求时间栏天数</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetList_ManufacturingOrdersToDispatch(
            int communityID,
            int t124LeafID,
            string moPattern,
            int dtfInDays,
            long sysLogID,
            ref List<ManufacturingOrder> datas,
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
                hashParams.Add("t124LeafID", t124LeafID);
                hashParams.Add("moPattern", moPattern);
                hashParams.Add("dtfInDays", dtfInDays);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetList_ManufacturingOrdersToDispatch 函数， " +
                        "参数：CommunityID={0}|T124LeafID={1}|" +
                        "MOPattern={2}|DTFInDays={3}|SysLogID={4}",
                        communityID,
                        t124LeafID,
                        moPattern,
                        dtfInDays,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.APS.dll",
                            "IRAP.BL.APS.IRAPAPS",
                            "ufn_GetList_ManufacturingOrdersToDispatch",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ManufacturingOrder>;
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

        public void usp_RequestForMODispatching(
            int communityID,
            long pwoIssuingFactID,
            string moNumber,
            int moLineNo,
            long orderQty,
            long atpQty,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("orderQty", orderQty);
                hashParams.Add("atpQty", atpQty);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_RequestForMODispatching，输入参数：" +
                        "CommunityID={0}|PWOIssuingFactID={1}|MONumber={2}|" +
                        "MOLineNo={3}|OrderQty={4}|ATPQty={5}|" +
                        "SysLogID={6}",
                        communityID,
                        pwoIssuingFactID,
                        moNumber,
                        moLineNo,
                        orderQty,
                        atpQty,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.APS.dll",
                        "IRAP.BL.APS.IRAPAPS",
                        "usp_RequestForMODispatching",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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
        /// 
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoIssuingFactID">工单签发事实编号</param>
        /// <param name="moNumber">制造订单号</param>
        /// <param name="moLineNo">制造订单行号</param>
        /// <param name="orderQty">订单数量</param>
        /// <param name="atpQty">物料齐套数量</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_RequestForMOQtyModification(
            int communityID,
            long pwoIssuingFactID,
            string moNumber,
            int moLineNo,
            long orderQty,
            long atpQty,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("pwoIssuingFactID", pwoIssuingFactID);
                hashParams.Add("moNumber", moNumber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("orderQty", orderQty);
                hashParams.Add("atpQty", atpQty);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_RequestForMOQtyModification，输入参数：" +
                        "CommunityID={0}|PWOIssuingFactID={1}|MONumber={2}|" +
                        "MOLineNo={3}|OrderQty={4}|ATPQty={5}|" +
                        "SysLogID={6}",
                        communityID,
                        pwoIssuingFactID,
                        moNumber,
                        moLineNo,
                        orderQty,
                        atpQty,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.APS.dll",
                        "IRAP.BL.APS.IRAPAPS",
                        "usp_RequestForMOQtyModification",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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
        /// 手动同步指定目标产线的四班订单
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="dstT173LeafID">目标产线叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        public void usp_ManualMODispatch(
            int communityID,
            int dstT173LeafID,
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
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("dstT173LeafID", dstT173LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_ManualMODispatch，输入参数：" +
                        "CommunityID={0}|DstT173LeafI={1}|SysLogID={2}",
                        communityID,
                        dstT173LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.APS.dll",
                        "IRAP.BL.APS.IRAPAPS",
                        "usp_ManualMODispatch",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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
        /// 制造订单人工分单保存
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="transactNo">交易号</param>
        /// <param name="factID">事实编号</param>
        /// <param name="opType">操作类型：1-新排；2-修改</param>
        /// <param name="moNumbber">制造订单号</param>
        /// <param name="moLineNo">制造订单行号</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="t134LeafID">生产线叶标识</param>
        /// <param name="dispatchedQty">排定生产数量</param>
        /// <param name="scheduledStartTime">排定生产时间(yyyy-mm-dd hh:mm)</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_SaveFact_MODispatching(
            int communityID,
            long transactNo,
            long factID,
            int opType,
            string moNumbber,
            int moLineNo,
            string productNo,
            int t134LeafID,
            long dispatchedQty,
            string scheduledStartTime,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("transactNo", transactNo);
                hashParams.Add("factID", factID);
                hashParams.Add("opType", opType);
                hashParams.Add("moNumber", moNumbber);
                hashParams.Add("moLineNo", moLineNo);
                hashParams.Add("productNo", productNo);
                hashParams.Add("t134LeafID", t134LeafID);
                hashParams.Add("dispatchedQty", dispatchedQty);
                hashParams.Add("scheduledStartTime", scheduledStartTime);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    $"调用 usp_SaveFact_MODispatching，输入参数：" +
                    $"CommunityID={communityID}|TransactNo={transactNo}|FactID={factID}|" +
                    $"OpType={opType}|MONumber={moNumbber}|MOLineNo={moLineNo}|" +
                    $"ProductNo={productNo}|T134LeafID={t134LeafID}|DispatchedQty={dispatchedQty}|" +
                    $"ScheduledStartTime={scheduledStartTime}|SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.APS.dll",
                        "IRAP.BL.APS.IRAPAPS",
                        "usp_SaveFact_MODispatching",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);
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
        /// 根据产品编号查询可供生产物料的数量
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="productNo">产品编号</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_MaterialATP(
            int communityID,
            string productNo,
            long sysLogID,
            ref MaterialATP data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new MaterialATP();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("productNo", productNo);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    $"调用 ufn_GetInfo_MaterialATP 函数，参数："+
                    $"CommunityID={communityID}|ProductNo={productNo}|SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.APS.dll",
                            "IRAP.BL.APS.IRAPAPS",
                            "ufn_GetInfo_MaterialATP",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        data = rlt as MaterialATP;
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
    }
}