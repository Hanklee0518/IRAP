namespace IRAP.Client.GUI.MESRMM
{
    partial class frmT102R4GUI_30
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grdProducts = new DevExpress.XtraGrid.GridControl();
            this.grdvProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnNodeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnNodeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblProductType = new DevExpress.XtraEditors.LabelControl();
            this.cboProductType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFilter = new DevExpress.XtraEditors.LabelControl();
            this.edtFilter = new DevExpress.XtraEditors.TextEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.grdWorkCenters = new DevExpress.XtraGrid.GridControl();
            this.grdvWorkCenters = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT134LeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT211LeafName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblProductName = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.chkEffectiveType = new DevExpress.XtraEditors.CheckEdit();
            this.riluT134Items = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.riluT211Items = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkCenters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvWorkCenters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT134Items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT211Items)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(859, 56);
            this.lblFuncName.Text = "frmCustomBase";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(859, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "产品列表";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdWorkCenters);
            this.splitContainerControl1.Panel2.Controls.Add(this.lblProductName);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnSave);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainerControl1.Panel2.Controls.Add(this.chkEffectiveType);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(859, 375);
            this.splitContainerControl1.SplitterPosition = 400;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.grdProducts);
            this.groupControl1.Controls.Add(this.lblProductType);
            this.groupControl1.Controls.Add(this.cboProductType);
            this.groupControl1.Controls.Add(this.lblFilter);
            this.groupControl1.Controls.Add(this.edtFilter);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(400, 375);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "产品列表";
            // 
            // grdProducts
            // 
            this.grdProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProducts.Location = new System.Drawing.Point(7, 103);
            this.grdProducts.MainView = this.grdvProducts;
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.Size = new System.Drawing.Size(388, 267);
            this.grdProducts.TabIndex = 3;
            this.grdProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvProducts});
            // 
            // grdvProducts
            // 
            this.grdvProducts.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvProducts.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvProducts.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvProducts.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvProducts.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvProducts.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvProducts.Appearance.Row.Options.UseFont = true;
            this.grdvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnNodeCode,
            this.grdclmnNodeName});
            this.grdvProducts.GridControl = this.grdProducts;
            this.grdvProducts.Name = "grdvProducts";
            this.grdvProducts.OptionsBehavior.Editable = false;
            this.grdvProducts.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvProducts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvProducts.OptionsView.RowAutoHeight = true;
            this.grdvProducts.OptionsView.ShowGroupPanel = false;
            this.grdvProducts.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvProducts_FocusedRowChanged);
            // 
            // grdclmnNodeCode
            // 
            this.grdclmnNodeCode.Caption = "编号";
            this.grdclmnNodeCode.FieldName = "NodeCode";
            this.grdclmnNodeCode.Name = "grdclmnNodeCode";
            this.grdclmnNodeCode.Visible = true;
            this.grdclmnNodeCode.VisibleIndex = 0;
            this.grdclmnNodeCode.Width = 100;
            // 
            // grdclmnNodeName
            // 
            this.grdclmnNodeName.Caption = "名称";
            this.grdclmnNodeName.FieldName = "NodeName";
            this.grdclmnNodeName.Name = "grdclmnNodeName";
            this.grdclmnNodeName.Visible = true;
            this.grdclmnNodeName.VisibleIndex = 1;
            this.grdclmnNodeName.Width = 156;
            // 
            // lblProductType
            // 
            this.lblProductType.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblProductType.Location = new System.Drawing.Point(13, 39);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(70, 20);
            this.lblProductType.TabIndex = 4;
            this.lblProductType.Text = "产品类型：";
            // 
            // cboProductType
            // 
            this.cboProductType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProductType.Location = new System.Drawing.Point(89, 40);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProductType.Properties.Items.AddRange(new object[] {
            "产成品",
            "半成品"});
            this.cboProductType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboProductType.Size = new System.Drawing.Size(195, 20);
            this.cboProductType.TabIndex = 0;
            // 
            // lblFilter
            // 
            this.lblFilter.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblFilter.Location = new System.Drawing.Point(13, 74);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(70, 20);
            this.lblFilter.TabIndex = 6;
            this.lblFilter.Text = "过滤字串：";
            // 
            // edtFilter
            // 
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.Location = new System.Drawing.Point(89, 71);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Size = new System.Drawing.Size(306, 26);
            this.edtFilter.TabIndex = 1;
            this.edtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtFilter_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(299, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(96, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdWorkCenters
            // 
            this.grdWorkCenters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkCenters.Location = new System.Drawing.Point(0, 99);
            this.grdWorkCenters.MainView = this.grdvWorkCenters;
            this.grdWorkCenters.Name = "grdWorkCenters";
            this.grdWorkCenters.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluT134Items,
            this.riluT211Items});
            this.grdWorkCenters.Size = new System.Drawing.Size(337, 271);
            this.grdWorkCenters.TabIndex = 7;
            this.grdWorkCenters.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvWorkCenters});
            // 
            // grdvWorkCenters
            // 
            this.grdvWorkCenters.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvWorkCenters.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvWorkCenters.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvWorkCenters.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvWorkCenters.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvWorkCenters.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvWorkCenters.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvWorkCenters.Appearance.Row.Options.UseFont = true;
            this.grdvWorkCenters.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnOrdinal,
            this.grdclmnT134LeafName,
            this.grdclmnT211LeafName});
            this.grdvWorkCenters.GridControl = this.grdWorkCenters;
            this.grdvWorkCenters.Name = "grdvWorkCenters";
            this.grdvWorkCenters.OptionsBehavior.Editable = false;
            this.grdvWorkCenters.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvWorkCenters.OptionsView.ColumnAutoWidth = false;
            this.grdvWorkCenters.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvWorkCenters.OptionsView.RowAutoHeight = true;
            this.grdvWorkCenters.OptionsView.ShowGroupPanel = false;
            this.grdvWorkCenters.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvWorkCenters_InitNewRow);
            this.grdvWorkCenters.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.grdvWorkCenters_RowDeleted);
            this.grdvWorkCenters.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.grdvWorkCenters_RowUpdated);
            // 
            // grdclmnOrdinal
            // 
            this.grdclmnOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrdinal.Caption = "序号";
            this.grdclmnOrdinal.FieldName = "Ordinal";
            this.grdclmnOrdinal.Name = "grdclmnOrdinal";
            this.grdclmnOrdinal.Visible = true;
            this.grdclmnOrdinal.VisibleIndex = 0;
            this.grdclmnOrdinal.Width = 65;
            // 
            // grdclmnT134LeafName
            // 
            this.grdclmnT134LeafName.Caption = "产线";
            this.grdclmnT134LeafName.ColumnEdit = this.riluT134Items;
            this.grdclmnT134LeafName.FieldName = "T134LeafID";
            this.grdclmnT134LeafName.Name = "grdclmnT134LeafName";
            this.grdclmnT134LeafName.OptionsColumn.AllowEdit = false;
            this.grdclmnT134LeafName.Visible = true;
            this.grdclmnT134LeafName.VisibleIndex = 1;
            this.grdclmnT134LeafName.Width = 150;
            // 
            // grdclmnT211LeafName
            // 
            this.grdclmnT211LeafName.Caption = "工作中心";
            this.grdclmnT211LeafName.ColumnEdit = this.riluT211Items;
            this.grdclmnT211LeafName.FieldName = "T211LeafID";
            this.grdclmnT211LeafName.Name = "grdclmnT211LeafName";
            this.grdclmnT211LeafName.Visible = true;
            this.grdclmnT211LeafName.VisibleIndex = 2;
            this.grdclmnT211LeafName.Width = 150;
            // 
            // lblProductName
            // 
            this.lblProductName.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.lblProductName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProductName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblProductName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblProductName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblProductName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductName.Location = new System.Drawing.Point(0, 0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(454, 93);
            this.lblProductName.TabIndex = 10;
            this.lblProductName.Text = "{0}的工艺流程";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(341, 99);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 26);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(341, 131);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 26);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkEffectiveType
            // 
            this.chkEffectiveType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEffectiveType.Enabled = false;
            this.chkEffectiveType.Location = new System.Drawing.Point(341, 176);
            this.chkEffectiveType.Name = "chkEffectiveType";
            this.chkEffectiveType.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEffectiveType.Properties.Appearance.Options.UseFont = true;
            this.chkEffectiveType.Properties.Caption = "立即生效";
            this.chkEffectiveType.Size = new System.Drawing.Size(96, 24);
            this.chkEffectiveType.TabIndex = 13;
            this.chkEffectiveType.Visible = false;
            // 
            // riluT134Items
            // 
            this.riluT134Items.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluT134Items.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodeAndName", "Name2")});
            this.riluT134Items.Name = "riluT134Items";
            this.riluT134Items.ShowFooter = false;
            this.riluT134Items.ShowHeader = false;
            // 
            // riluT211Items
            // 
            this.riluT211Items.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluT211Items.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CodeAndName", "Name3")});
            this.riluT211Items.Name = "riluT211Items";
            this.riluT211Items.ShowFooter = false;
            this.riluT211Items.ShowHeader = false;
            // 
            // frmT102R4GUI_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(859, 431);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmT102R4GUI_30";
            this.Shown += new System.EventHandler(this.frmT102R4GUI_30_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProductType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkCenters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvWorkCenters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEffectiveType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT134Items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluT211Items)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit edtFilter;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl lblFilter;
        private DevExpress.XtraEditors.ComboBoxEdit cboProductType;
        private DevExpress.XtraGrid.GridControl grdProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvProducts;
        private DevExpress.XtraEditors.LabelControl lblProductType;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnNodeCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnNodeName;
        private DevExpress.XtraEditors.CheckEdit chkEffectiveType;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblProductName;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl grdWorkCenters;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvWorkCenters;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT134LeafName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT211LeafName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluT134Items;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluT211Items;
    }
}
