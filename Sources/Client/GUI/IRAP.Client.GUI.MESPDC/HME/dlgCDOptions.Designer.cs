namespace IRAP.Client.GUI.MESPDC.HME
{
    partial class dlgCDOptions
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
            this.btnDismantle = new DevExpress.XtraEditors.SimpleButton();
            this.btnQualityTest = new DevExpress.XtraEditors.SimpleButton();
            this.lnkPIT = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // btnDismantle
            // 
            this.btnDismantle.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDismantle.Appearance.Options.UseFont = true;
            this.btnDismantle.Enabled = false;
            this.btnDismantle.Location = new System.Drawing.Point(153, 32);
            this.btnDismantle.Name = "btnDismantle";
            this.btnDismantle.Size = new System.Drawing.Size(115, 44);
            this.btnDismantle.TabIndex = 0;
            this.btnDismantle.Text = "拆解";
            this.btnDismantle.Click += new System.EventHandler(this.btnDismantle_Click);
            // 
            // btnQualityTest
            // 
            this.btnQualityTest.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQualityTest.Appearance.Options.UseFont = true;
            this.btnQualityTest.Enabled = false;
            this.btnQualityTest.Location = new System.Drawing.Point(153, 106);
            this.btnQualityTest.Name = "btnQualityTest";
            this.btnQualityTest.Size = new System.Drawing.Size(115, 44);
            this.btnQualityTest.TabIndex = 1;
            this.btnQualityTest.Text = "质量检测";
            this.btnQualityTest.Click += new System.EventHandler(this.btnQualityTest_Click);
            // 
            // lnkPIT
            // 
            this.lnkPIT.Appearance.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkPIT.Enabled = false;
            this.lnkPIT.Location = new System.Drawing.Point(342, 155);
            this.lnkPIT.Name = "lnkPIT";
            this.lnkPIT.Size = new System.Drawing.Size(80, 19);
            this.lnkPIT.TabIndex = 2;
            this.lnkPIT.Text = "PIT 明细";
            this.lnkPIT.Click += new System.EventHandler(this.lnkPIT_Click);
            // 
            // dlgCDOptions
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(434, 186);
            this.Controls.Add(this.lnkPIT);
            this.Controls.Add(this.btnQualityTest);
            this.Controls.Add(this.btnDismantle);
            this.Name = "dlgCDOptions";
            this.Text = "部件拆解-选项";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDismantle;
        private DevExpress.XtraEditors.SimpleButton btnQualityTest;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkPIT;
    }
}
