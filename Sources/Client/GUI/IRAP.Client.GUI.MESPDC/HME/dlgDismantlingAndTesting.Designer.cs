namespace IRAP.Client.GUI.MESPDC.HME
{
    partial class dlgDismantlingAndTesting
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmnType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblDMC = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnCommit = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdSubComponents = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.tsmiScrap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRelease = new System.Windows.Forms.ToolStripMenuItem();
            this.grdvSubComponents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnLotNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQCStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubComponents)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvSubComponents)).BeginInit();
            this.SuspendLayout();
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmnType
            // 
            this.grdclmnType.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnType.Caption = "对应类型";
            this.grdclmnType.FieldName = "Type";
            this.grdclmnType.Name = "grdclmnType";
            this.grdclmnType.Visible = true;
            this.grdclmnType.VisibleIndex = 3;
            this.grdclmnType.Width = 202;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 21);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "DMC 码：";
            // 
            // lblDMC
            // 
            this.lblDMC.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblDMC.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblDMC.Location = new System.Drawing.Point(106, 12);
            this.lblDMC.Name = "lblDMC";
            this.lblDMC.Size = new System.Drawing.Size(588, 21);
            this.lblDMC.TabIndex = 1;
            this.lblDMC.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.btnCommit);
            this.groupControl1.Controls.Add(this.textEdit1);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.grdSubComponents);
            this.groupControl1.Location = new System.Drawing.Point(12, 39);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(10);
            this.groupControl1.Size = new System.Drawing.Size(1029, 638);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Components";
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommit.Appearance.Options.UseFont = true;
            this.btnCommit.Location = new System.Drawing.Point(899, 41);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(115, 44);
            this.btnCommit.TabIndex = 4;
            this.btnCommit.Text = "提交";
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(87, 50);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(388, 28);
            this.textEdit1.TabIndex = 3;
            this.textEdit1.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("新宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(15, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 21);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "检索：";
            this.labelControl2.Visible = false;
            // 
            // grdSubComponents
            // 
            this.grdSubComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSubComponents.ContextMenuStrip = this.contextMenuStrip;
            this.grdSubComponents.Location = new System.Drawing.Point(15, 105);
            this.grdSubComponents.MainView = this.grdvSubComponents;
            this.grdSubComponents.Name = "grdSubComponents";
            this.grdSubComponents.Size = new System.Drawing.Size(999, 518);
            this.grdSubComponents.TabIndex = 0;
            this.grdSubComponents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvSubComponents});
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiScrap,
            this.tsmiRelease});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 48);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // tsmiScrap
            // 
            this.tsmiScrap.Name = "tsmiScrap";
            this.tsmiScrap.Size = new System.Drawing.Size(100, 22);
            this.tsmiScrap.Text = "报废";
            this.tsmiScrap.Click += new System.EventHandler(this.tsmiScrap_Click);
            // 
            // tsmiRelease
            // 
            this.tsmiRelease.Name = "tsmiRelease";
            this.tsmiRelease.Size = new System.Drawing.Size(100, 22);
            this.tsmiRelease.Text = "释放";
            this.tsmiRelease.Click += new System.EventHandler(this.tsmiRelease_Click);
            // 
            // grdvSubComponents
            // 
            this.grdvSubComponents.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvSubComponents.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvSubComponents.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvSubComponents.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvSubComponents.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvSubComponents.Appearance.Row.Font = new System.Drawing.Font("新宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grdvSubComponents.Appearance.Row.Options.UseFont = true;
            this.grdvSubComponents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnNO,
            this.grdclmnLotNumber,
            this.grdclmnType,
            this.grdclmnQCStatus});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmnType;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = "精追";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.grdvSubComponents.FormatRules.Add(gridFormatRule2);
            this.grdvSubComponents.GridControl = this.grdSubComponents;
            this.grdvSubComponents.Name = "grdvSubComponents";
            this.grdvSubComponents.OptionsBehavior.Editable = false;
            this.grdvSubComponents.OptionsSelection.MultiSelect = true;
            this.grdvSubComponents.OptionsView.ColumnAutoWidth = false;
            this.grdvSubComponents.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            this.grdclmnOrdinal.Width = 40;
            // 
            // grdclmnNO
            // 
            this.grdclmnNO.Caption = "唯一码";
            this.grdclmnNO.FieldName = "NO";
            this.grdclmnNO.Name = "grdclmnNO";
            this.grdclmnNO.Visible = true;
            this.grdclmnNO.VisibleIndex = 1;
            this.grdclmnNO.Width = 234;
            // 
            // grdclmnLotNumber
            // 
            this.grdclmnLotNumber.Caption = "批次码";
            this.grdclmnLotNumber.FieldName = "LotNumber";
            this.grdclmnLotNumber.Name = "grdclmnLotNumber";
            this.grdclmnLotNumber.Visible = true;
            this.grdclmnLotNumber.VisibleIndex = 2;
            this.grdclmnLotNumber.Width = 234;
            // 
            // grdclmnQCStatus
            // 
            this.grdclmnQCStatus.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQCStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnQCStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQCStatus.Caption = "操作";
            this.grdclmnQCStatus.FieldName = "QCStatus";
            this.grdclmnQCStatus.Name = "grdclmnQCStatus";
            this.grdclmnQCStatus.Visible = true;
            this.grdclmnQCStatus.VisibleIndex = 4;
            this.grdclmnQCStatus.Width = 239;
            // 
            // dlgDismantlingAndTesting
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1053, 689);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.lblDMC);
            this.Controls.Add(this.labelControl1);
            this.Name = "dlgDismantlingAndTesting";
            this.Text = "拆解检测";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSubComponents)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdvSubComponents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblDMC;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grdSubComponents;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvSubComponents;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnNO;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnLotNumber;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnCommit;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnType;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQCStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiScrap;
        private System.Windows.Forms.ToolStripMenuItem tsmiRelease;
    }
}
