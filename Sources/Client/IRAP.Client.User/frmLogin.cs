using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;

using IRAP.Global;
using IRAP.Entity.SSO;
using System.Configuration;
using IRAP.Client.Global;

namespace IRAP.Client.User
{
    public partial class frmLogin : IRAP.Client.Global.frmCustomBase
    {
        private bool formMove = false;  // 窗体是否移动
        private Point formPoint;        // 记录窗体的位置
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public frmLogin()
        {
            InitializeComponent();
        }

        private bool firstShow = true;

        private bool LoginPWDVerify()
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            TWaitting.Instance.ShowWaitForm("正在校验密码....");
            try
            {
                IRAPUser.Instance.Password = edtUserPWD.Text;
                if (IRAPUser.Instance.IsPWDVerified)
                {
                    cboAgencies.Properties.Items.Clear();
                    cboRoles.Properties.Items.Clear();

                    foreach (AgencyInfo agency in IRAPUser.Instance.AvailableAgencies)
                    {
                        cboAgencies.Properties.Items.Add(agency);
                    }
                    if (cboAgencies.Properties.Items.Count > 0)
                        cboAgencies.SelectedIndex = 0;
                    cboAgencies.Enabled = cboAgencies.Properties.Items.Count > 1;

                    foreach (RoleInfo role in IRAPUser.Instance.AvailableRoles)
                    {
                        cboRoles.Properties.Items.Add(role);
                    }
                    if (cboRoles.Properties.Items.Count > 0)
                        cboRoles.SelectedIndex = 0;
                    cboRoles.Enabled = cboRoles.Properties.Items.Count > 1;

                    btnLogin.Enabled =
                        ((cboAgencies.SelectedIndex >= 0) &&
                        (cboRoles.SelectedIndex >= 0));
                    if (btnLogin.Enabled)
                        btnLogin.Focus();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                IRAPMessageBox.Instance.Show(
                    error.Message,
                    "错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                edtUserPWD.Text = "";
                edtUserPWD.Focus();

                return false;
            }
            finally
            {
                chkChangePWD.Enabled = IRAPUser.Instance.IsPWDVerified;
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
                TWaitting.Instance.CloseWaitForm();
            }
        }

        private void edtUserCode_Leave(object sender, EventArgs e)
        {
            IRAPUser.Instance.UserCode = edtUserCode.Text;

            edtUserPWD.Text = "";
            cboAgencies.Properties.Items.Clear();
            cboRoles.Properties.Items.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                string.Format(
                    "{0}.{1}",
                    className,
                    MethodBase.GetCurrentMethod().Name);

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                IRAPUser.Instance.SelectAgency(cboAgencies.SelectedIndex);
                IRAPUser.Instance.SelectRole(cboRoles.SelectedIndex);

                try
                {
                    IRAPUser.Instance.Login();
                }
                catch (Exception error)
                {
                    MessageBox.Show(
                        error.Message,
                        "请联系系统维护人员",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (IRAPUser.Instance.IsLogon)
                {
                    IRAPConst.Instance.SaveParams("LoginUser", edtUserCode.Text.Trim());
                    IRAPConst.Instance.SaveParams("LoginPWD", edtUserPWD.Text.Trim());

                    Hide();

                    #region 登录成功后，如果用户选择了“修改登录密码”后，进入密码修改界面
                    if (chkChangePWD.Checked)
                    {
                        using (frmChangePassword changePassword = new frmChangePassword())
                        {
                            changePassword.ShowDialog();
                        }
                    }
                    #endregion
                }

                btnCancel.PerformClick();
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (formMove)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(formPoint.X, formPoint.Y);
                Location = mousePos;
            }
        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                formMove = false;
        }

        private void edtUserPWD_Validating(object sender, CancelEventArgs e)
        {
            if (edtUserPWD.Text != "")
            {
                e.Cancel = !LoginPWDVerify();
            }
            else
            {
                cboAgencies.Properties.Items.Clear();
                cboRoles.Properties.Items.Clear();
                chkChangePWD.Enabled = false;
                btnLogin.Enabled = false;

                e.Cancel = false;
            }
        }

        private void edtUserPWD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return || e.KeyCode != Keys.Tab)
            {
                cboAgencies.Properties.Items.Clear();
                cboRoles.Properties.Items.Clear();
                chkChangePWD.Enabled = false;
                btnLogin.Enabled = false;
            }
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            formPoint = new Point();
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X;
                yOffset = -e.Y;
                if (FormBorderStyle != FormBorderStyle.None)
                {
                    xOffset -= SystemInformation.FrameBorderSize.Width;
                    yOffset -= SystemInformation.FrameBorderSize.Height;
                }
                if (ControlBox)
                    yOffset -= SystemInformation.CaptionHeight;

                formPoint = new Point(xOffset, yOffset);
                formMove = true;
            }
        }

        private void cboAgencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            IRAPUser.Instance.SelectAgency(cboAgencies.SelectedIndex);
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            if (firstShow)
            {
                try
                {
                    string pwd = "";
                    if (ConfigurationManager.AppSettings["LoginUser"] != null)
                    {
                        edtUserCode.Text = ConfigurationManager.AppSettings["LoginUser"];
                        IRAPUser.Instance.UserCode = edtUserCode.Text;
                    }
                    if (ConfigurationManager.AppSettings["LoginPWD"] != null)
                    {
                        pwd = ConfigurationManager.AppSettings["LoginPWD"];
                    }

                    if (edtUserCode.Text.Trim() == "")
                    {
                        edtUserCode.Focus();
                    }
                    else
                    {
                        edtUserPWD.Focus();
                        edtUserPWD.Text = pwd;
                        Application.DoEvents();
                    }

                    if (edtUserCode.Text.Trim() != "" && edtUserPWD.Text.Trim() != "")
                    {
                        LoginPWDVerify();
                    }
                }
                finally
                {
                    firstShow = false;
                }
            }
        }
    }
}
