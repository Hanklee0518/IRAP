using IRAP.Client.Global;
using IRAP.Client.Global.GUI;
using IRAP.Client.User;
using IRAP.Service.Client.Exchange.MES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC.HME
{
    public partial class dlgCDOptions : IRAP.Client.Global.frmCustomBase
    {
        private string dmcCode = "";
        private xucIRAPListView log = null;

        public dlgCDOptions()
        {
            InitializeComponent();
        }

        public string DMC
        {
            get { return dmcCode; }
            set
            {
                dmcCode = value;
                if (dmcCode.Trim() != "")
                {
                    btnDismantle.Enabled = true;
                    btnQualityTest.Enabled = true;
                    lnkPIT.Enabled = true && IRAPConst.Instance.PITUrl != "";
                }
                else
                {
                    btnDismantle.Enabled = false;
                    btnQualityTest.Enabled = false;
                    lnkPIT.Enabled = false;
                }
            }
        }

        public xucIRAPListView Log
        {
            get { return log; }
            set { log = value; }
        }

        private void btnQualityTest_Click(object sender, EventArgs e)
        {
            MR_DismantleComponent_NeedQC trade =
                new MR_DismantleComponent_NeedQC(
                    IRAPConst.Instance.WebAPI.URL,
                    IRAPConst.Instance.WebAPI.ContentType,
                    IRAPConst.Instance.WebAPI.ClientID);
            trade.Request =
                new MRDismantleComponentNeedQCRequest()
                {
                    CommunityID = IRAPUser.Instance.CommunityID,
                    SysLogID = IRAPUser.Instance.SysLogID,
                    BarCode = dmcCode,
                };
            try
            {
                trade.Do();
                if (log != null)
                {
                    log.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                }
            }
            catch (Exception error)
            {
                if (log != null)
                {
                    log.WriteLog(-1, error.Message, DateTime.Now);
                }
            }
            finally
            {
                Close();
            }
        }

        private void btnDismantle_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    using (dlgDismantlingAndTesting dismantle = new dlgDismantlingAndTesting())
                    {
                        dismantle.DMC = dmcCode;
                        dismantle.Log = log;
                        dismantle.ShowDialog();
                    }
                }
                catch (Exception error)
                {
                    if (log!= null)
                    {
                        log.WriteLog(-1, error.Message, DateTime.Now);
                    }
                }
            }
            finally
            {
                Close();
            }
        }

        private void lnkPIT_Click(object sender, EventArgs e)
        {
            string url =
                $"{IRAPConst.Instance.PITUrl}?" +
                $"SysLogID={IRAPUser.Instance.SysLogID}&" +
                $"CommunityID={IRAPUser.Instance.CommunityID}&" +
                $"DMCCode={dmcCode}";

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
