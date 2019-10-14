using DevExpress.XtraEditors;
using IRAP.Client.Global;
using IRAP.Client.Global.GUI;
using IRAP.Client.User;
using IRAP.Global;
using IRAP.Service.Client;
using IRAP.Service.Client.Exchange.MES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC.HME
{
    public partial class dlgQIComponent : IRAP.Client.Global.frmCustomBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private xucIRAPListView _log = null;

        public dlgQIComponent()
        {
            InitializeComponent();
        }

        /// <summary>
        /// DMC码
        /// </summary>
        public string DMC
        {
            get { return lblDMC.Text; }
            set { lblDMC.Text = value; }
        }
        public string SourceInfo
        {
            get { return lblSourceInfo.Text; }
            set { lblSourceInfo.Text = value; }
        }
        public string ComponentType
        {
            set
            {
                switch (value)
                {
                    case "SemiFinished":
                        btnScrap.Text = "拆解";
                        break;
                    case "AccurateTrace":
                        btnScrap.Text = "报废";
                        break;
                }
            }
        }
        public xucIRAPListView Log
        {
            get { return _log; }
            set { _log = value; }
        }

        private void btnReuse_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            MR_QC_Recycle trade =
                new MR_QC_Recycle(
                    IRAPConst.Instance.WebAPI.URL,
                    IRAPConst.Instance.WebAPI.ContentType,
                    IRAPConst.Instance.WebAPI.ClientID);
            trade.Request =
                new MRQCRecycleRequest()
                {
                    CommunityID = IRAPUser.Instance.CommunityID,
                    SysLogID = IRAPUser.Instance.SysLogID,
                    DMCNO = lblDMC.Text,
                };
            try
            {
                trade.Do();
                if (_log != null)
                {
                    _log.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                }

                Close();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                XtraMessageBox.Show(
                    error.Message,
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            CustomWebAPICall trade = null;
            switch (btnScrap.Text)
            {
                case "报废":
                    trade =
                        new MR_QC_Scrap(
                            IRAPConst.Instance.WebAPI.URL,
                            IRAPConst.Instance.WebAPI.ContentType,
                            IRAPConst.Instance.WebAPI.ClientID);
                    ((MR_QC_Scrap)trade).Request =
                        new MRQCScrapRequest()
                        {
                            CommunityID = IRAPUser.Instance.CommunityID,
                            SysLogID = IRAPUser.Instance.SysLogID,
                            DMCNO = lblDMC.Text,
                        };
                    break;
                case "拆解":
                    trade =
                        new MR_QC_NeedDismantle(
                            IRAPConst.Instance.WebAPI.URL,
                            IRAPConst.Instance.WebAPI.ContentType,
                            IRAPConst.Instance.WebAPI.ClientID);
                    ((MR_QC_NeedDismantle)trade).Request =
                        new MRQCNeedDismantleRequest()
                        {
                            CommunityID = IRAPUser.Instance.CommunityID,
                            SysLogID = IRAPUser.Instance.SysLogID,
                            DMCNO = lblDMC.Text,
                        };
                    break;
            }

            try
            {
                trade.Do();
                if (_log != null)
                {
                    _log.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                }

                Close();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                XtraMessageBox.Show(
                    error.Message,
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            string url =
                $"{IRAPConst.Instance.PITUrl}?" +
                $"SysLogID={IRAPUser.Instance.SysLogID}&" +
                $"CommunityID={IRAPUser.Instance.CommunityID}&" +
                $"DMCCode={DMC}";

            Process p = new Process();
            ProcessStartInfo startinfo =
                new ProcessStartInfo(
                    @"shell:Appsfolder\Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge",
                    url);
            p.EnableRaisingEvents = true;
            startinfo.RedirectStandardInput = false;
            startinfo.RedirectStandardOutput = false;
            startinfo.RedirectStandardError = false;
            p.StartInfo = startinfo;
            p.Start();
        }
    }
}
