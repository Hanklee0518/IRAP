﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

using DevExpress.XtraEditors;

using IRAP.Client.Global;

namespace IRAP.Client.User
{
    public partial class frmChangePassword : frmCustomBase
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                IRAPUser.Instance.ChangePassword(
                    IRAPUser.Instance.Password,
                    edtPassword.Text,
                    edtConfPassword.Text);

                #region 国际化
                string msgContent = "";
                string msgTitle = "";
                switch (Thread.CurrentThread.CurrentCulture.Name)
                {
                    case "en_US":
                        msgContent = "New password update successfully, it will be worded at next login.";
                        msgTitle = "Change password";
                        break;
                    default:
                        msgContent = "登录密码修改完成，新的登录密码将在下次登录时生效。";
                        msgTitle = "登录密码修改";
                        break;
                }
                XtraMessageBox.Show(
                    msgContent,
                    msgTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                #endregion

                btnCancel.PerformClick();
            }
            catch (Exception error)
            {
                #region 国际化
                string msgContent = "";
                string msgTitle = "";
                switch (Thread.CurrentThread.CurrentCulture.Name)
                {
                    case "en_US":
                        msgContent = "New password update failure: {0}";
                        msgTitle = "Change password";
                        break;
                    default:
                        msgContent = "修改登录密码失败：{0}";
                        msgTitle = "登录密码修改";
                        break;
                }
                XtraMessageBox.Show(
                    string.Format(
                        msgContent,
                        error.Message),
                    msgTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                #endregion

                edtPassword.Text = "";
                edtConfPassword.Text = "";

                edtPassword.Focus();
            }
        }
    }
}
