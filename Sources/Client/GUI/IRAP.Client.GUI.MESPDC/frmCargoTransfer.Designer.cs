﻿namespace IRAP.Client.GUI.MESPDC
{
    partial class frmCargoTransfer
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
            this.lblPartNumber = new DevExpress.XtraEditors.LabelControl();
            this.edtPartNumber = new DevExpress.XtraEditors.TextEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.edtCopies = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.edtProductDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.edtTransferQuantity = new DevExpress.XtraEditors.TextEdit();
            this.cboAddresses = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboCustomers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xucIRAPListView = new IRAP.Client.Global.GUI.xucIRAPListView();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.edtTempPKGQuantity = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtPartNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCopies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProductDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProductDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTransferQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAddresses.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTempPKGQuantity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Text = "货品发运";
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // lblPartNumber
            // 
            this.lblPartNumber.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPartNumber.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPartNumber.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPartNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPartNumber.Location = new System.Drawing.Point(16, 40);
            this.lblPartNumber.Name = "lblPartNumber";
            this.lblPartNumber.Size = new System.Drawing.Size(116, 17);
            this.lblPartNumber.TabIndex = 1;
            this.lblPartNumber.Text = "部件编号：";
            // 
            // edtPartNumber
            // 
            this.edtPartNumber.EnterMoveNextControl = true;
            this.edtPartNumber.Location = new System.Drawing.Point(138, 37);
            this.edtPartNumber.Name = "edtPartNumber";
            this.edtPartNumber.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.edtPartNumber.Properties.Appearance.Options.UseFont = true;
            this.edtPartNumber.Size = new System.Drawing.Size(209, 24);
            this.edtPartNumber.TabIndex = 2;
            this.edtPartNumber.EditValueChanged += new System.EventHandler(this.edtPartNumber_EditValueChanged);
            this.edtPartNumber.Validating += new System.ComponentModel.CancelEventHandler(this.edtPartNumber_Validating);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.edtTempPKGQuantity);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.edtCopies);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.edtProductDate);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.edtTransferQuantity);
            this.groupControl1.Controls.Add(this.cboAddresses);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.cboCustomers);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.lblPartNumber);
            this.groupControl1.Controls.Add(this.edtPartNumber);
            this.groupControl1.Location = new System.Drawing.Point(12, 62);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(867, 198);
            this.groupControl1.TabIndex = 3;
            // 
            // edtCopies
            // 
            this.edtCopies.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtCopies.EnterMoveNextControl = true;
            this.edtCopies.Location = new System.Drawing.Point(469, 157);
            this.edtCopies.Name = "edtCopies";
            this.edtCopies.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edtCopies.Properties.Appearance.Options.UseFont = true;
            this.edtCopies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtCopies.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.edtCopies.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtCopies.Size = new System.Drawing.Size(82, 24);
            this.edtCopies.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Location = new System.Drawing.Point(347, 160);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(116, 17);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "打印份数：";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(764, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 29);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // edtProductDate
            // 
            this.edtProductDate.EditValue = null;
            this.edtProductDate.EnterMoveNextControl = true;
            this.edtProductDate.Location = new System.Drawing.Point(138, 157);
            this.edtProductDate.Name = "edtProductDate";
            this.edtProductDate.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.edtProductDate.Properties.Appearance.Options.UseFont = true;
            this.edtProductDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtProductDate.Size = new System.Drawing.Size(163, 24);
            this.edtProductDate.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(16, 160);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(116, 17);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "生产日期：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(16, 130);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(116, 17);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "发运确认量：";
            // 
            // edtTransferQuantity
            // 
            this.edtTransferQuantity.EnterMoveNextControl = true;
            this.edtTransferQuantity.Location = new System.Drawing.Point(138, 127);
            this.edtTransferQuantity.Name = "edtTransferQuantity";
            this.edtTransferQuantity.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.edtTransferQuantity.Properties.Appearance.Options.UseFont = true;
            this.edtTransferQuantity.Size = new System.Drawing.Size(209, 24);
            this.edtTransferQuantity.TabIndex = 8;
            // 
            // cboAddresses
            // 
            this.cboAddresses.EnterMoveNextControl = true;
            this.cboAddresses.Location = new System.Drawing.Point(138, 97);
            this.cboAddresses.Name = "cboAddresses";
            this.cboAddresses.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.cboAddresses.Properties.Appearance.Options.UseFont = true;
            this.cboAddresses.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAddresses.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAddresses.Size = new System.Drawing.Size(712, 24);
            this.cboAddresses.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(16, 100);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(116, 17);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "发运地点：";
            // 
            // cboCustomers
            // 
            this.cboCustomers.EnterMoveNextControl = true;
            this.cboCustomers.Location = new System.Drawing.Point(138, 67);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.cboCustomers.Properties.Appearance.Options.UseFont = true;
            this.cboCustomers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCustomers.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboCustomers.Size = new System.Drawing.Size(378, 24);
            this.cboCustomers.TabIndex = 4;
            this.cboCustomers.SelectedIndexChanged += new System.EventHandler(this.cboCustomers_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(16, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(116, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "客户：";
            // 
            // xucIRAPListView
            // 
            this.xucIRAPListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xucIRAPListView.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xucIRAPListView.Appearance.Options.UseFont = true;
            this.xucIRAPListView.Caption = "操作日志";
            this.xucIRAPListView.Location = new System.Drawing.Point(12, 266);
            this.xucIRAPListView.MaxLineNumber = 1000;
            this.xucIRAPListView.Name = "xucIRAPListView";
            this.xucIRAPListView.Padding = new System.Windows.Forms.Padding(5);
            this.xucIRAPListView.Size = new System.Drawing.Size(867, 217);
            this.xucIRAPListView.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(413, 130);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(138, 17);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "临时标准包装量：";
            // 
            // edtTempPKGQuantity
            // 
            this.edtTempPKGQuantity.EnterMoveNextControl = true;
            this.edtTempPKGQuantity.Location = new System.Drawing.Point(557, 127);
            this.edtTempPKGQuantity.Name = "edtTempPKGQuantity";
            this.edtTempPKGQuantity.Properties.Appearance.Font = new System.Drawing.Font("等线", 12F);
            this.edtTempPKGQuantity.Properties.Appearance.Options.UseFont = true;
            this.edtTempPKGQuantity.Size = new System.Drawing.Size(111, 24);
            this.edtTempPKGQuantity.TabIndex = 14;
            // 
            // frmCargoTransfer
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(891, 495);
            this.Controls.Add(this.xucIRAPListView);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmCargoTransfer";
            this.Text = "货品发运";
            this.Activated += new System.EventHandler(this.frmCargoTransfer_Activated);
            this.Shown += new System.EventHandler(this.frmCargoTransfer_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.xucIRAPListView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtPartNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtCopies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProductDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProductDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTransferQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAddresses.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCustomers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTempPKGQuantity.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblPartNumber;
        private DevExpress.XtraEditors.TextEdit edtPartNumber;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboAddresses;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboCustomers;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit edtProductDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit edtTransferQuantity;
        private Global.GUI.xucIRAPListView xucIRAPListView;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SpinEdit edtCopies;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit edtTempPKGQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
