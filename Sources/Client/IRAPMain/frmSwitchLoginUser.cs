using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IRAP.Global;
using IRAP.Client.User;

namespace IRAP
{
    public partial class frmSwitchLoginUser : IRAP.Client.Global.frmCustomBase
    {
        public frmSwitchLoginUser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void edtNewUserBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (edtNewUserBarCode.Text.Trim() == "")
                {
                    IRAPMessageBox.Instance.ShowErrorMessage("条码内容不能空白！");
                    return;
                }

                try
                {
                    IRAPUser.Instance.SwapLoginUser(edtNewUserBarCode.Text);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception error)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(error.Message);
                }
            }
        }
    }
}
