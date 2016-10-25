﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Reflection;
using System.Configuration;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entity.SSO;
using IRAP.Entity.MDM;
using IRAP.Entity.FVS;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO
{
    public partial class frmFVSCell_Visteon : DevExpress.XtraEditors.XtraForm
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        /// <summary>
        /// 当前站点的 MAC 地址
        /// </summary>
        private string macAddress = "";
        /// <summary>
        /// 应用服务器的当前时间
        /// </summary>
        private DateTime serverTime = DateTime.Now;
        /// <summary>
        /// 当前站点的登录信息
        /// </summary>
        private StationLogin stationUser = null;
        /// <summary>
        /// 最近一次更新
        /// </summary>
        private DateTime LastUpdatedTime = DateTime.Now;

        public frmFVSCell_Visteon()
        {
            InitializeComponent();

            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            #region 读取虚拟的 MAC 地址，用于程序调试
            if (config.AppSettings.Settings["Virtual Station Used"] != null)
            {
                if (config.AppSettings.Settings["Virtual Station Used"].Value.ToUpper() == "TRUE")
                {
                    if (config.AppSettings.Settings["Virtual Station"] != null)
                    {
                        macAddress = config.AppSettings.Settings["Virtual Station"].Value;
                    }
                }
            }
            if (macAddress.Trim() == "")
                GetMacAddress();
            #endregion

            lblLineName.Parent = picLineName;
        }

        /// <summary>
        /// 获取当前真实的 MAC 地址
        /// </summary>
        protected virtual void GetMacAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                try
                {
                    if ((bool)mo["IPEnabled"])
                    {
                        macAddress = mo["MacAddress"].ToString();
                        macAddress = macAddress.Replace(":", "");
                        break;
                    }
                }
                catch
                {
                    mo.Dispose();
                }
            }
        }

        /// <summary>
        /// 当前站点登录
        /// </summary>
        private StationLogin PadLogin(
            ref int errCode,
            ref string errText)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                StationLogin stationUser = new StationLogin();

                IRAPUserClient.Instance.sfn_GetInfo_StationLogin(
                    macAddress != "" ? macAddress : "60010MDV1101001",
                    ref stationUser,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode == 0)
                    return stationUser;
                else
                    return null;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        /// <summary>
        /// 刷新产线及产品
        /// </summary>
        private void RefreshProductionLineInfo()
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

                if (stationUser == null || stationUser.SysLogID <= 0)
                {
                    #region 获取当前站点的登录信息
                    stationUser = PadLogin(ref errCode, ref errText);
                    if (errCode != 0)
                    {
                        return;
                    }
                    #endregion
                }

                if (stationUser != null && stationUser.SysLogID != 0)
                {
                    ProductionLineInfo line = new ProductionLineInfo();

                    IRAPMDMClient.Instance.ufn_GetInfo_ProductionLine(
                        stationUser.CommunityID,
                        stationUser.SysLogID,
                        ref line,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        lblLineName.Text =
                            string.Format(
                                "[{0}] {1}",
                                line.T134Code,
                                line.T134NodeName);
                    }
                    else
                    {
                        lblLineName.Text = "当前站点未配置产线信息";
                        return;
                    }

                    FVS_LogoImages images = new FVS_LogoImages();
                    IRAPMDMClient.Instance.ufn_GetInfo_LogoImages(
                        stationUser.CommunityID,
                        line.T134LeafID,
                        line.T102LeafID_InProduction,
                        ref images,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format("({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0 && images != null)
                    {
                        string pwoNo = "";

                        picCompanyLogo.Image = images.CompanyLogo;
                        picCustomLogo.Image = images.CustomerLogo;
                        picProduction.Image = images.CustomerProduct;

                        // 当前工单执行的瞬时达成率
                        RefreshExecutePWOInfo(line);

                        // 安灯状态
                        ucAndonStatus.SetSearchCondition(
                            stationUser.CommunityID,
                            line.T134LeafID,
                            stationUser.SysLogID);

                        // 未关闭工单
                        ucOpenPWOs.SetSearchCondition(
                            stationUser.CommunityID,
                            134,
                            line.T134LeafID,
                            stationUser.SysLogID,
                            ucKPIBTS,
                            ref pwoNo);

                        // FTT
                        ucFTT.SetSearchCondition(
                            stationUser.CommunityID,
                            pwoNo,
                            stationUser.SysLogID);

                        // 技能矩阵
                        ucOperatorSkillsMatrix.SetSearchCondition(
                            stationUser.CommunityID,
                            line.T102LeafID_InProduction,
                            line.T134LeafID,
                            "",
                            stationUser.SysLogID);

                        // 一点课
                        ucOnePointLessons.SetSearchCondition(
                            stationUser.CommunityID,
                            line.T102LeafID_InProduction,
                            "",
                            stationUser.SysLogID);

                        // 未关闭的变更事项
                        ucECNtoLine.SetSearchCondition(
                            stationUser.CommunityID,
                            line.T102LeafID_InProduction,
                            stationUser.SysLogID);
                    }
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void RefreshExecutePWOInfo(ProductionLineInfo line)
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
                LineKPI_BTS pwoBTS = new LineKPI_BTS();

                IRAPFVSClient.Instance.ufn_GetInfo_LineKPI_BTS(
                    stationUser.CommunityID,
                    134,
                    line.T134LeafID,
                    "",
                    stationUser.SysLogID,
                    ref pwoBTS,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                if (errCode != 0)
                {
                    pwoBTS.BTSStatus = (int)UserControls.TrackBarStyle.tbsNone;
                }

                ucKPIBTS.Minimum = 0;
                ucKPIBTS.Maximum = pwoBTS.PlanQuantity.DoubleValue;
                ucKPIBTS.KPIName = pwoBTS.KPIName;
                ucKPIBTS.KPIValue = Convert.ToDouble(pwoBTS.KPIValue);
                ucKPIBTS.KPIProgress = Convert.ToDouble(pwoBTS.BTSProgress);
                ucKPIBTS.TrackBarStyle = (UserControls.TrackBarStyle)pwoBTS.BTSStatus;
                ucKPIBTS.ActualOutputQuantity = pwoBTS.ActualQuantity.DoubleValue;

                ucKPIBTS.Tag = pwoBTS;
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmFVSCell_Visteon_Shown(object sender, EventArgs e)
        {
        }

        private void lblLineName_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFVSCell_Visteon_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            pnlTop.Height = Height / 2;
            pnlFirstQuadrant.Width = pnlTop.Width / 100 * 48;
            pnlThirdQuadrant.Width = pnlBotton.Width / 100 * 45;

            int errCode = 0;
            string errText = "";

            #region 获取服务器的当前时间，并设置当前的系统时间
            IRAPSystemClient.Instance.sfn_GetServerDateTime(
                ref serverTime,
                out errCode,
                out errText);
            if (errCode == 0)
            {
                SetSystemDateTime.SetSystemTime(serverTime);
            }
            #endregion

            RefreshProductionLineInfo();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - LastUpdatedTime;
            if (span.TotalMinutes > 2)
            {
                LastUpdatedTime = DateTime.Now;

                RefreshProductionLineInfo();
            }
        }
    }
}