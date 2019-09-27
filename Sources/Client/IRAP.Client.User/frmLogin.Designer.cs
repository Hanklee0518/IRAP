namespace IRAP.Client.User
{
    partial class frmLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.edtUserCode = new DevExpress.XtraEditors.TextEdit();
            this.edtUserPWD = new DevExpress.XtraEditors.TextEdit();
            this.cboAgencies = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cboRoles = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chkChangePWD = new DevExpress.XtraEditors.CheckEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePWD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.Appearance.Font")));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = ((System.Drawing.Font)(resources.GetObject("toolTipController.AppearanceTitle.Font")));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // edtUserCode
            // 
            resources.ApplyResources(this.edtUserCode, "edtUserCode");
            this.edtUserCode.EnterMoveNextControl = true;
            this.edtUserCode.Name = "edtUserCode";
            this.edtUserCode.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtUserCode.Properties.Appearance.Font")));
            this.edtUserCode.Properties.Appearance.Options.UseFont = true;
            this.edtUserCode.Leave += new System.EventHandler(this.edtUserCode_Leave);
            // 
            // edtUserPWD
            // 
            resources.ApplyResources(this.edtUserPWD, "edtUserPWD");
            this.edtUserPWD.EnterMoveNextControl = true;
            this.edtUserPWD.Name = "edtUserPWD";
            this.edtUserPWD.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("edtUserPWD.Properties.Appearance.Font")));
            this.edtUserPWD.Properties.Appearance.Options.UseFont = true;
            this.edtUserPWD.Properties.UseSystemPasswordChar = true;
            this.edtUserPWD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtUserPWD_KeyDown);
            this.edtUserPWD.Validating += new System.ComponentModel.CancelEventHandler(this.edtUserPWD_Validating);
            // 
            // cboAgencies
            // 
            resources.ApplyResources(this.cboAgencies, "cboAgencies");
            this.cboAgencies.EnterMoveNextControl = true;
            this.cboAgencies.Name = "cboAgencies";
            this.cboAgencies.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboAgencies.Properties.Appearance.Font")));
            this.cboAgencies.Properties.Appearance.Options.UseFont = true;
            this.cboAgencies.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("cboAgencies.Properties.AppearanceDisabled.Font")));
            this.cboAgencies.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboAgencies.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("cboAgencies.Properties.AppearanceDropDown.Font")));
            this.cboAgencies.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboAgencies.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("cboAgencies.Properties.AppearanceFocused.Font")));
            this.cboAgencies.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboAgencies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboAgencies.Properties.Buttons"))))});
            this.cboAgencies.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAgencies.SelectedIndexChanged += new System.EventHandler(this.cboAgencies_SelectedIndexChanged);
            // 
            // cboRoles
            // 
            resources.ApplyResources(this.cboRoles, "cboRoles");
            this.cboRoles.EnterMoveNextControl = true;
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cboRoles.Properties.Appearance.Font")));
            this.cboRoles.Properties.Appearance.Options.UseFont = true;
            this.cboRoles.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("cboRoles.Properties.AppearanceDisabled.Font")));
            this.cboRoles.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cboRoles.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("cboRoles.Properties.AppearanceDropDown.Font")));
            this.cboRoles.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboRoles.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("cboRoles.Properties.AppearanceFocused.Font")));
            this.cboRoles.Properties.AppearanceFocused.Options.UseFont = true;
            this.cboRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboRoles.Properties.Buttons"))))});
            this.cboRoles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl3.Appearance.Font")));
            resources.ApplyResources(this.labelControl3, "labelControl3");
            this.labelControl3.Name = "labelControl3";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl4.Appearance.Font")));
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.Name = "labelControl4";
            // 
            // chkChangePWD
            // 
            resources.ApplyResources(this.chkChangePWD, "chkChangePWD");
            this.chkChangePWD.Name = "chkChangePWD";
            this.chkChangePWD.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("chkChangePWD.Properties.Appearance.Font")));
            this.chkChangePWD.Properties.Appearance.Options.UseFont = true;
            this.chkChangePWD.Properties.Caption = resources.GetString("chkChangePWD.Properties.Caption");
            this.chkChangePWD.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnLogin.Appearance.Font")));
            this.btnLogin.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            // 
            // frmLogin
            // 
            this.Appearance.Options.UseFont = true;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::IRAP.Client.User.Properties.Resources.login;
            this.CancelButton = this.btnCancel;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkChangePWD);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.cboAgencies);
            this.Controls.Add(this.edtUserPWD);
            this.Controls.Add(this.edtUserCode);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.ShowInTaskbar = true;
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmLogin_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserPWD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRoles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkChangePWD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit edtUserCode;
        private DevExpress.XtraEditors.TextEdit edtUserPWD;
        private DevExpress.XtraEditors.ComboBoxEdit cboAgencies;
        private DevExpress.XtraEditors.ComboBoxEdit cboRoles;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkChangePWD;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
