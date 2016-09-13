﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

using IRAP.Global;
using IRAP.Entity.MES;

namespace IRAP.WCF.Client.Method
{
    public class IRAPMESClient
    {
        private static IRAPMESClient _instance = null;
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private IRAPMESClient()
        {

        }

        public static IRAPMESClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPMESClient();
                return _instance;
            }
        }

        /// <summary>
        /// 获取SPC控制图信息：⒈ 支持彩虹图；⒉ 支持Xbar-R图
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="pwoNo">生产工单号</param>
        /// <param name="t47LeafID">SPC控制图类型代码：373564-彩虹图；373565-Xbar-R图</param>
        /// <param name="t216LeafID">工序叶标识</param>
        /// <param name="t133LeafID">设备叶标识</param>
        /// <param name="t20LeafID">工艺参数叶标识</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void ufn_GetInfo_SPCChart(
            int communityID,
            string pwoNo,
            int t47LeafID,
            int t216LeafID,
            int t133LeafID,
            int t20LeafID,
            long sysLogID,
            ref EntitySPCChart data,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                data = new EntitySPCChart();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("pwoNo", pwoNo);
                hashParams.Add("t47LeafID", t47LeafID);
                hashParams.Add("t216LeafID", t216LeafID);
                hashParams.Add("t133LeafID", t133LeafID);
                hashParams.Add("t20LeafID", t20LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 ufn_GetInfo_SPCChart，输入参数：" +
                        "CommunityID={0}|PWONo={1}|T47LeafID={2}|" +
                        "T216LeafID={3}|T133LeafID={4}|T20LeafID={5}|"+
                        "SysLogID={6}",
                        communityID,
                        pwoNo,
                        t47LeafID,
                        t216LeafID,
                        t133LeafID,
                        t20LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.QC",
                        "ufn_GetInfo_SPCChart",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}",
                            errCode,
                            errText),
                        strProcedureName);

                    if (errCode == 0)
                        data = (EntitySPCChart)rlt;
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
        /// 统计过程重置
        /// ⒈ 更新工艺调整时间点为当前时间点，从此时点以后的数据计入SPC图；
        /// ⒉ 写工艺调整日志。
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="c1ID">产品工位关联标识</param>
        /// <param name="t47LeafID">SPC控制图标识号：373564-彩虹图；373565-XBarR图</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_WriteLog_SPCReset(
            int communityID,
            int c1ID,
            int t47LeafID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("c1ID", c1ID);
                hashParams.Add("t47LeafID", t47LeafID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_WriteLog_SPCReset，输入参数：" +
                        "CommunityID={0}|C1ID={1}|T47LeafID={2}|" +
                        "SysLogID={3}",
                        communityID,
                        c1ID,
                        t47LeafID,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.QC",
                        "usp_WriteLog_SPCReset",
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
        /// 设置统计过程控制中 XBar-R 图的上下控制线
        /// </summary>
        /// <param name="communityID">社区标识</param>
        /// <param name="c1ID">产品工位关联标识</param>\
        /// <param name="t47LeafID">SPC控制图标识号：373564-彩虹图；373565-XBarR图</param>
        /// <param name="lcl">XBar 控制线下限</param>
        /// <param name="ucl">XBar 控制线上限</param>
        /// <param name="rlcl">R 控制线下限</param>
        /// <param name="rucl">R 控制线上限</param>
        /// <param name="rbar">R 的均值</param>
        /// <param name="sysLogID">系统登录标识</param>
        public void usp_WriteLog_SPCCtrlLineSet(
            int communityID,
            int c1ID,
            int t47LeafID,
            long lcl,
            long ucl,
            long rlcl,
            long rucl,
            long rbar,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = string.Format("{0}.{1}",
                className,
                MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();
                hashParams.Add("communityID", communityID);
                hashParams.Add("c1ID", c1ID);
                hashParams.Add("t47LeafID", t47LeafID);
                hashParams.Add("lcl", lcl);
                hashParams.Add("ucl", ucl);
                hashParams.Add("rlcl", rlcl);
                hashParams.Add("rucl", rucl);
                hashParams.Add("rbar", rbar);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    string.Format(
                        "调用 usp_WriteLog_SPCCtrlLineSet，输入参数：" +
                        "CommunityID={0}|C1ID={1}|T47LeafID={2}|"+
                        "LCL={3}|UCL={4}|RLCL={5}|RUCL={6}|RBar={7}|"+
                        "SysLogID={8}",
                        communityID,
                        c1ID,
                        t47LeafID,
                        lcl,
                        ucl,
                        rlcl,
                        rucl,
                        rbar,
                        sysLogID),
                    strProcedureName);
                #endregion

                #region 调用应用服务过程，并解析返回值
                using (WCFClient client = new WCFClient())
                {
                    object rlt = client.WCFRESTFul(
                        "IRAP.BL.MES.dll",
                        "IRAP.BL.MES.QC",
                        "usp_WriteLog_SPCCtrlLineSet",
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
    }
}