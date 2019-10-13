using DevExpress.XtraEditors;
using IRAP.Client.Global;
using IRAP.Client.Global.GUI.Dialogs;
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
    public partial class frmComponentDismantle : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        public frmComponentDismantle()
        {
            InitializeComponent();
        }

        private void frmComponentDisassemble_Activated(object sender, EventArgs e)
        {
            edtBarCode.Focus();
        }

        private void edtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MR_Scan trade =
                    new MR_Scan(
                        IRAPConst.Instance.WebAPI.URL,
                        IRAPConst.Instance.WebAPI.ContentType,
                        IRAPConst.Instance.WebAPI.ClientID);
                trade.Request =
                    new MRScanRequest()
                    {
                        CommunityID = IRAPUser.Instance.CommunityID,
                        SysLogID = IRAPUser.Instance.SysLogID,
                        BarCode = edtBarCode.Text.Trim(),
                    };
                try
                {
                    if (trade.Do())
                    {
                        using (dlgCDOptions options = new dlgCDOptions())
                        {
                            options.DMC = edtBarCode.Text.Trim();
                            options.Log = lvLogs;
                            options.ShowDialog();
                        }
                    }
                    else
                    {
                        lvLogs.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                    }
                }
                catch (Exception error)
                {
                    lvLogs.WriteLog(-1, error.Message, DateTime.Now);
                }
                finally
                {
                    edtBarCode.Text = "";
                    edtBarCode.Focus();
                }
            }
        }
    }
}
