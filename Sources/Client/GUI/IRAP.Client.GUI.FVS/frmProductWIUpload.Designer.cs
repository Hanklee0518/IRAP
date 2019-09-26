namespace IRAP.Client.GUI.FVS
{
    partial class frmProductWIUpload
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
            DevExpress.XtraTreeList.FilterCondition filterCondition1 = new DevExpress.XtraTreeList.FilterCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductWIUpload));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tlcName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlProducts = new DevExpress.XtraTreeList.TreeList();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.edtFilterText = new DevExpress.XtraEditors.ButtonEdit();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.tlOperations = new DevExpress.XtraTreeList.TreeList();
            this.tlclmnOperationName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tlLogs = new DevExpress.XtraTreeList.TreeList();
            this.tlcMessage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
            this.edtUploadPath = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlOperations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlLogs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUploadPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(1070, 56);
            this.lblFuncName.Text = "frmProductWIUpload";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(1070, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // tlcName
            // 
            this.tlcName.Caption = "产品名称";
            this.tlcName.FieldName = "产品名称";
            this.tlcName.MinWidth = 34;
            this.tlcName.Name = "tlcName";
            this.tlcName.Visible = true;
            this.tlcName.VisibleIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.tlProducts);
            this.splitContainerControl1.Panel1.Controls.Add(this.separatorControl1);
            this.splitContainerControl1.Panel1.Controls.Add(this.edtFilterText);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "产品列表";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1070, 600);
            this.splitContainerControl1.SplitterPosition = 346;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // tlProducts
            // 
            this.tlProducts.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlProducts.Appearance.Row.Options.UseFont = true;
            this.tlProducts.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcName});
            this.tlProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            filterCondition1.Column = this.tlcName;
            filterCondition1.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Like;
            filterCondition1.Value1 = "23";
            filterCondition1.Visible = true;
            this.tlProducts.FilterConditions.AddRange(new DevExpress.XtraTreeList.FilterCondition[] {
            filterCondition1});
            this.tlProducts.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlProducts.Location = new System.Drawing.Point(5, 37);
            this.tlProducts.Name = "tlProducts";
            this.tlProducts.OptionsBehavior.Editable = false;
            this.tlProducts.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tlProducts.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tlProducts.OptionsView.ShowColumns = false;
            this.tlProducts.OptionsView.ShowHorzLines = false;
            this.tlProducts.OptionsView.ShowVertLines = false;
            this.tlProducts.Size = new System.Drawing.Size(332, 533);
            this.tlProducts.TabIndex = 1;
            this.tlProducts.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlProducts_FocusedNodeChanged);
            // 
            // separatorControl1
            // 
            this.separatorControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.separatorControl1.Location = new System.Drawing.Point(5, 27);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(332, 10);
            this.separatorControl1.TabIndex = 2;
            // 
            // edtFilterText
            // 
            this.edtFilterText.Dock = System.Windows.Forms.DockStyle.Top;
            this.edtFilterText.Location = new System.Drawing.Point(5, 5);
            this.edtFilterText.Name = "edtFilterText";
            this.edtFilterText.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtFilterText.Properties.Appearance.Options.UseFont = true;
            this.edtFilterText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.edtFilterText.Properties.NullValuePrompt = "根据输入的内容进行模糊查询";
            this.edtFilterText.Size = new System.Drawing.Size(332, 22);
            this.edtFilterText.TabIndex = 0;
            this.edtFilterText.ToolTip = "请在此处输入产品名称或者产品编号的部分内容，以便进行模糊查询过滤";
            this.edtFilterText.ToolTipController = this.toolTipController;
            this.edtFilterText.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.edtFilterText.ToolTipTitle = "提示";
            this.edtFilterText.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtFilterText_ButtonClick);
            this.edtFilterText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtFilterText_KeyDown);
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel1.Controls.Add(this.tlOperations);
            this.splitContainerControl2.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl2.Panel1.ShowCaption = true;
            this.splitContainerControl2.Panel1.Text = "工序列表";
            this.splitContainerControl2.Panel2.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl2.Panel2.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl2.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl2.Panel2.Controls.Add(this.tlLogs);
            this.splitContainerControl2.Panel2.Controls.Add(this.btnUpload);
            this.splitContainerControl2.Panel2.Controls.Add(this.edtUploadPath);
            this.splitContainerControl2.Panel2.Controls.Add(this.labelControl1);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl2.Panel2.ShowCaption = true;
            this.splitContainerControl2.Panel2.Text = "上传";
            this.splitContainerControl2.Size = new System.Drawing.Size(719, 600);
            this.splitContainerControl2.SplitterPosition = 257;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // tlOperations
            // 
            this.tlOperations.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlOperations.Appearance.Row.Options.UseFont = true;
            this.tlOperations.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlclmnOperationName});
            this.tlOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlOperations.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlOperations.Location = new System.Drawing.Point(5, 5);
            this.tlOperations.Name = "tlOperations";
            this.tlOperations.OptionsBehavior.Editable = false;
            this.tlOperations.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tlOperations.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tlOperations.OptionsView.ShowColumns = false;
            this.tlOperations.OptionsView.ShowHorzLines = false;
            this.tlOperations.OptionsView.ShowVertLines = false;
            this.tlOperations.Size = new System.Drawing.Size(705, 303);
            this.tlOperations.TabIndex = 2;
            // 
            // tlclmnOperationName
            // 
            this.tlclmnOperationName.Caption = "工序";
            this.tlclmnOperationName.FieldName = "OperationName";
            this.tlclmnOperationName.Name = "tlclmnOperationName";
            this.tlclmnOperationName.Visible = true;
            this.tlclmnOperationName.VisibleIndex = 0;
            // 
            // tlLogs
            // 
            this.tlLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlLogs.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlLogs.Appearance.Row.Options.UseFont = true;
            this.tlLogs.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.tlcMessage});
            this.tlLogs.Font = new System.Drawing.Font("新宋体", 12F);
            this.tlLogs.Location = new System.Drawing.Point(10, 45);
            this.tlLogs.Name = "tlLogs";
            this.tlLogs.OptionsBehavior.Editable = false;
            this.tlLogs.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.tlLogs.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.tlLogs.Size = new System.Drawing.Size(696, 182);
            this.tlLogs.TabIndex = 3;
            // 
            // tlcMessage
            // 
            this.tlcMessage.AppearanceCell.Font = new System.Drawing.Font("新宋体", 12F);
            this.tlcMessage.AppearanceCell.Options.UseFont = true;
            this.tlcMessage.AppearanceHeader.Font = new System.Drawing.Font("新宋体", 12F);
            this.tlcMessage.AppearanceHeader.Options.UseFont = true;
            this.tlcMessage.Caption = "日志";
            this.tlcMessage.FieldName = "日志";
            this.tlcMessage.Name = "tlcMessage";
            this.tlcMessage.Visible = true;
            this.tlcMessage.VisibleIndex = 0;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnUpload.Appearance.Options.UseFont = true;
            this.btnUpload.Location = new System.Drawing.Point(607, 11);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(103, 28);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "上传";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // edtUploadPath
            // 
            this.edtUploadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUploadPath.Location = new System.Drawing.Point(128, 14);
            this.edtUploadPath.Name = "edtUploadPath";
            this.edtUploadPath.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtUploadPath.Properties.Appearance.Options.UseFont = true;
            this.edtUploadPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("edtUploadPath.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "GetFileName", null, true)});
            this.edtUploadPath.Size = new System.Drawing.Size(469, 22);
            this.edtUploadPath.TabIndex = 1;
            this.edtUploadPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.edtUploadPath_ButtonClick);
            this.edtUploadPath.Validating += new System.ComponentModel.CancelEventHandler(this.edtUploadPath_Validating);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(10, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(112, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "待上传的文件：";
            // 
            // frmProductWIUpload
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1070, 656);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmProductWIUpload";
            this.Text = "frmProductWIUpload";
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlOperations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tlLogs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUploadPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.ButtonEdit edtFilterText;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraTreeList.TreeList tlProducts;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcName;
        private DevExpress.XtraEditors.ButtonEdit edtUploadPath;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList tlOperations;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlclmnOperationName;
        private DevExpress.XtraTreeList.TreeList tlLogs;
        private DevExpress.XtraTreeList.Columns.TreeListColumn tlcMessage;
        private DevExpress.XtraEditors.SimpleButton btnUpload;
    }
}
