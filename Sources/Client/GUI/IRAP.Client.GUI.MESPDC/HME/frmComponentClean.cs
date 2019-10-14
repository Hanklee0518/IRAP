using IRAP.Client.Global;
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
    public partial class frmComponentClean : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        public frmComponentClean()
        {
            InitializeComponent();
        }

        private void frmComponentClean_Activated(object sender, EventArgs e)
        {
            edtBarCode.Focus();
        }

        private void edtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TWaitting.Instance.ShowWaitForm("正在处理");

                MR_Clear trade =
                    new MR_Clear(
                        IRAPConst.Instance.WebAPI.URL,
                        IRAPConst.Instance.WebAPI.ContentType,
                        IRAPConst.Instance.WebAPI.ClientID);
                trade.Request =
                    new MRClearRequest()
                    {
                        CommunityID = IRAPUser.Instance.CommunityID,
                        SysLogID = IRAPUser.Instance.SysLogID,
                        BarCode = edtBarCode.Text.Trim(),
                    };
                try
                {
                    trade.Do();
                    lvLogs.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                }
                catch (Exception error)
                {
                    lvLogs.WriteLog(-1, error.Message, DateTime.Now);
                }
                finally
                {
                    edtBarCode.Text = "";
                    edtBarCode.Focus();

                    TWaitting.Instance.CloseWaitForm();
                }
            }
        }
    }
}
