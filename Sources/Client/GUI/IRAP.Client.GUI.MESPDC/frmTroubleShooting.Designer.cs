﻿namespace IRAP.Client.GUI.MESPDC
{
    partial class frmTroubleShooting
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
            this.grdRepairItems = new DevExpress.XtraGrid.GridControl();
            this.grdvRepairItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnT110LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.risluSymbol = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT118LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluFailureMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnFailurePointCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT216LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluFailureSrcOperation = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnT183LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluFailureNature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnT184LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluFailureDuty = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnT119LeafID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluRepairMode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnTrackReferenceValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBarCodeConf = new DevExpress.XtraEditors.SimpleButton();
            this.grdProducts = new DevExpress.XtraGrid.GridControl();
            this.grdvProducts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPartNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnInspectStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluInspectStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grdclmnRepairStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riluRepairAction = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.edtBarCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitContainerControl3 = new DevExpress.XtraEditors.SplitContainerControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl4 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRepairItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvRepairItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluSymbol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureSrcOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureNature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureDuty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRepairMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluInspectStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRepairAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBarCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).BeginInit();
            this.splitContainerControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).BeginInit();
            this.splitContainerControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(1169, 56);
            this.lblFuncName.Text = "故障维修";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(1169, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdRepairItems
            // 
            this.grdRepairItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdRepairItems.Location = new System.Drawing.Point(5, 5);
            this.grdRepairItems.MainView = this.grdvRepairItems;
            this.grdRepairItems.Name = "grdRepairItems";
            this.grdRepairItems.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.risluSymbol,
            this.riluFailureMode,
            this.riluFailureSrcOperation,
            this.riluFailureNature,
            this.riluFailureDuty,
            this.riluRepairMode});
            this.grdRepairItems.Size = new System.Drawing.Size(566, 321);
            this.grdRepairItems.TabIndex = 2;
            this.grdRepairItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvRepairItems});
            // 
            // grdvRepairItems
            // 
            this.grdvRepairItems.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvRepairItems.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvRepairItems.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvRepairItems.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvRepairItems.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvRepairItems.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvRepairItems.Appearance.Row.Options.UseFont = true;
            this.grdvRepairItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnT110LeafID,
            this.grdclmnT118LeafID,
            this.grdclmnFailurePointCount,
            this.grdclmnT216LeafID,
            this.grdclmnT183LeafID,
            this.grdclmnT184LeafID,
            this.grdclmnT119LeafID,
            this.grdclmnTrackReferenceValue});
            this.grdvRepairItems.GridControl = this.grdRepairItems;
            this.grdvRepairItems.Name = "grdvRepairItems";
            this.grdvRepairItems.OptionsView.ColumnAutoWidth = false;
            this.grdvRepairItems.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvRepairItems.OptionsView.RowAutoHeight = true;
            this.grdvRepairItems.OptionsView.ShowGroupPanel = false;
            this.grdvRepairItems.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdvRepairItems_InitNewRow);
            // 
            // grdclmnT110LeafID
            // 
            this.grdclmnT110LeafID.Caption = "器件位号/物料编号";
            this.grdclmnT110LeafID.ColumnEdit = this.risluSymbol;
            this.grdclmnT110LeafID.FieldName = "ItemLeafID";
            this.grdclmnT110LeafID.MinWidth = 120;
            this.grdclmnT110LeafID.Name = "grdclmnT110LeafID";
            this.grdclmnT110LeafID.Visible = true;
            this.grdclmnT110LeafID.VisibleIndex = 0;
            this.grdclmnT110LeafID.Width = 130;
            // 
            // risluSymbol
            // 
            this.risluSymbol.AutoHeight = false;
            this.risluSymbol.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.risluSymbol.Name = "risluSymbol";
            this.risluSymbol.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "器件位号/物料编号";
            this.gridColumn1.FieldName = "ItemName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "物料编号";
            this.gridColumn2.FieldName = "AlternateItemName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // grdclmnT118LeafID
            // 
            this.grdclmnT118LeafID.Caption = "失效模式";
            this.grdclmnT118LeafID.ColumnEdit = this.riluFailureMode;
            this.grdclmnT118LeafID.FieldName = "T118LeafID";
            this.grdclmnT118LeafID.Name = "grdclmnT118LeafID";
            this.grdclmnT118LeafID.Visible = true;
            this.grdclmnT118LeafID.VisibleIndex = 1;
            // 
            // riluFailureMode
            // 
            this.riluFailureMode.AutoHeight = false;
            this.riluFailureMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluFailureMode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FailureName", "Name8")});
            this.riluFailureMode.Name = "riluFailureMode";
            this.riluFailureMode.ShowFooter = false;
            this.riluFailureMode.ShowHeader = false;
            // 
            // grdclmnFailurePointCount
            // 
            this.grdclmnFailurePointCount.Caption = "失效点数";
            this.grdclmnFailurePointCount.FieldName = "FailurePointCount";
            this.grdclmnFailurePointCount.Name = "grdclmnFailurePointCount";
            this.grdclmnFailurePointCount.Visible = true;
            this.grdclmnFailurePointCount.VisibleIndex = 2;
            // 
            // grdclmnT216LeafID
            // 
            this.grdclmnT216LeafID.Caption = "根源工序";
            this.grdclmnT216LeafID.ColumnEdit = this.riluFailureSrcOperation;
            this.grdclmnT216LeafID.FieldName = "T216LeafID";
            this.grdclmnT216LeafID.Name = "grdclmnT216LeafID";
            this.grdclmnT216LeafID.Visible = true;
            this.grdclmnT216LeafID.VisibleIndex = 3;
            // 
            // riluFailureSrcOperation
            // 
            this.riluFailureSrcOperation.AutoHeight = false;
            this.riluFailureSrcOperation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluFailureSrcOperation.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OperationName", "Name9")});
            this.riluFailureSrcOperation.DisplayMember = "OperationName";
            this.riluFailureSrcOperation.Name = "riluFailureSrcOperation";
            this.riluFailureSrcOperation.ValueMember = "OperationLeaf";
            // 
            // grdclmnT183LeafID
            // 
            this.grdclmnT183LeafID.Caption = "失效性质";
            this.grdclmnT183LeafID.ColumnEdit = this.riluFailureNature;
            this.grdclmnT183LeafID.FieldName = "T183LeafID";
            this.grdclmnT183LeafID.Name = "grdclmnT183LeafID";
            this.grdclmnT183LeafID.Visible = true;
            this.grdclmnT183LeafID.VisibleIndex = 4;
            // 
            // riluFailureNature
            // 
            this.riluFailureNature.AutoHeight = false;
            this.riluFailureNature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluFailureNature.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("T183NodeName", "Name10")});
            this.riluFailureNature.DisplayMember = "T183NodeName";
            this.riluFailureNature.Name = "riluFailureNature";
            this.riluFailureNature.ValueMember = "T183LeafID";
            // 
            // grdclmnT184LeafID
            // 
            this.grdclmnT184LeafID.Caption = "失效责任";
            this.grdclmnT184LeafID.ColumnEdit = this.riluFailureDuty;
            this.grdclmnT184LeafID.FieldName = "T184LeafID";
            this.grdclmnT184LeafID.Name = "grdclmnT184LeafID";
            this.grdclmnT184LeafID.Visible = true;
            this.grdclmnT184LeafID.VisibleIndex = 5;
            // 
            // riluFailureDuty
            // 
            this.riluFailureDuty.AutoHeight = false;
            this.riluFailureDuty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluFailureDuty.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("T184NodeName", "Name11")});
            this.riluFailureDuty.DisplayMember = "T184NodeName";
            this.riluFailureDuty.Name = "riluFailureDuty";
            this.riluFailureDuty.ValueMember = "T184LeafID";
            // 
            // grdclmnT119LeafID
            // 
            this.grdclmnT119LeafID.Caption = "维修代码";
            this.grdclmnT119LeafID.ColumnEdit = this.riluRepairMode;
            this.grdclmnT119LeafID.FieldName = "T119LeafID";
            this.grdclmnT119LeafID.Name = "grdclmnT119LeafID";
            this.grdclmnT119LeafID.Visible = true;
            this.grdclmnT119LeafID.VisibleIndex = 6;
            // 
            // riluRepairMode
            // 
            this.riluRepairMode.AutoHeight = false;
            this.riluRepairMode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluRepairMode.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LeafName", "Name12")});
            this.riluRepairMode.DisplayMember = "LeafName";
            this.riluRepairMode.Name = "riluRepairMode";
            this.riluRepairMode.ValueMember = "LeafID";
            // 
            // grdclmnTrackReferenceValue
            // 
            this.grdclmnTrackReferenceValue.Caption = "追溯参考值";
            this.grdclmnTrackReferenceValue.FieldName = "TrackReferenceValue";
            this.grdclmnTrackReferenceValue.Name = "grdclmnTrackReferenceValue";
            this.grdclmnTrackReferenceValue.Visible = true;
            this.grdclmnTrackReferenceValue.VisibleIndex = 7;
            this.grdclmnTrackReferenceValue.Width = 90;
            // 
            // btnBarCodeConf
            // 
            this.btnBarCodeConf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarCodeConf.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.btnBarCodeConf.Appearance.Options.UseFont = true;
            this.btnBarCodeConf.Location = new System.Drawing.Point(7, 5);
            this.btnBarCodeConf.Name = "btnBarCodeConf";
            this.btnBarCodeConf.Size = new System.Drawing.Size(104, 37);
            this.btnBarCodeConf.TabIndex = 3;
            this.btnBarCodeConf.Text = "维修确认";
            this.btnBarCodeConf.Click += new System.EventHandler(this.btnBarCodeConf_Click);
            // 
            // grdProducts
            // 
            this.grdProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdProducts.Location = new System.Drawing.Point(5, 5);
            this.grdProducts.MainView = this.grdvProducts;
            this.grdProducts.Name = "grdProducts";
            this.grdProducts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riluRepairAction,
            this.riluInspectStatus});
            this.grdProducts.Size = new System.Drawing.Size(427, 348);
            this.grdProducts.TabIndex = 5;
            this.grdProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvProducts});
            // 
            // grdvProducts
            // 
            this.grdvProducts.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvProducts.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvProducts.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvProducts.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvProducts.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvProducts.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.grdvProducts.Appearance.Row.Options.UseFont = true;
            this.grdvProducts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPartNumber,
            this.gridColumn10,
            this.grdclmnInspectStatus,
            this.grdclmnRepairStatus});
            this.grdvProducts.GridControl = this.grdProducts;
            this.grdvProducts.Name = "grdvProducts";
            this.grdvProducts.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvProducts.OptionsView.RowAutoHeight = true;
            this.grdvProducts.OptionsView.ShowGroupPanel = false;
            this.grdvProducts.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.grdvProducts_RowClick);
            this.grdvProducts.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvProducts_FocusedRowChanged);
            // 
            // grdclmnPartNumber
            // 
            this.grdclmnPartNumber.Caption = "物料代码";
            this.grdclmnPartNumber.FieldName = "PartNumber";
            this.grdclmnPartNumber.Name = "grdclmnPartNumber";
            this.grdclmnPartNumber.Visible = true;
            this.grdclmnPartNumber.VisibleIndex = 0;
            this.grdclmnPartNumber.Width = 61;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "子板条码";
            this.gridColumn10.FieldName = "WIPCode";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 119;
            // 
            // grdclmnInspectStatus
            // 
            this.grdclmnInspectStatus.Caption = "送修状态";
            this.grdclmnInspectStatus.ColumnEdit = this.riluInspectStatus;
            this.grdclmnInspectStatus.FieldName = "InspectStatus";
            this.grdclmnInspectStatus.Name = "grdclmnInspectStatus";
            this.grdclmnInspectStatus.OptionsColumn.AllowEdit = false;
            this.grdclmnInspectStatus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnInspectStatus.OptionsColumn.AllowMove = false;
            this.grdclmnInspectStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnInspectStatus.OptionsColumn.ReadOnly = true;
            this.grdclmnInspectStatus.Visible = true;
            this.grdclmnInspectStatus.VisibleIndex = 2;
            this.grdclmnInspectStatus.Width = 52;
            // 
            // riluInspectStatus
            // 
            this.riluInspectStatus.AutoHeight = false;
            this.riluInspectStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluInspectStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("InspectName", "Name7")});
            this.riluInspectStatus.DisplayMember = "InspectName";
            this.riluInspectStatus.Name = "riluInspectStatus";
            this.riluInspectStatus.ShowFooter = false;
            this.riluInspectStatus.ShowHeader = false;
            this.riluInspectStatus.ValueMember = "InspectStatusID";
            // 
            // grdclmnRepairStatus
            // 
            this.grdclmnRepairStatus.Caption = "维修状态";
            this.grdclmnRepairStatus.ColumnEdit = this.riluRepairAction;
            this.grdclmnRepairStatus.FieldName = "RepairStatus";
            this.grdclmnRepairStatus.Name = "grdclmnRepairStatus";
            this.grdclmnRepairStatus.OptionsColumn.AllowMove = false;
            this.grdclmnRepairStatus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdclmnRepairStatus.Visible = true;
            this.grdclmnRepairStatus.VisibleIndex = 3;
            this.grdclmnRepairStatus.Width = 117;
            // 
            // riluRepairAction
            // 
            this.riluRepairAction.AutoHeight = false;
            this.riluRepairAction.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riluRepairAction.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("OpTypeName", "Name8")});
            this.riluRepairAction.Name = "riluRepairAction";
            this.riluRepairAction.ShowFooter = false;
            this.riluRepairAction.ShowHeader = false;
            // 
            // edtBarCode
            // 
            this.edtBarCode.Location = new System.Drawing.Point(81, 3);
            this.edtBarCode.Name = "edtBarCode";
            this.edtBarCode.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edtBarCode.Properties.Appearance.Options.UseFont = true;
            this.edtBarCode.Size = new System.Drawing.Size(351, 26);
            this.edtBarCode.TabIndex = 6;
            this.edtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtBarCode_KeyDown);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.labelControl5.Location = new System.Drawing.Point(5, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(70, 20);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "条码扫描：";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 56);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl1.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl1.Panel1.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel1.ShowCaption = true;
            this.splitContainerControl1.Panel1.Text = "条码信息";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl3);
            this.splitContainerControl1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1169, 437);
            this.splitContainerControl1.SplitterPosition = 451;
            this.splitContainerControl1.TabIndex = 10;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.Horizontal = false;
            this.splitContainerControl2.IsSplitterFixed = true;
            this.splitContainerControl2.Location = new System.Drawing.Point(5, 5);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl2.Panel1.Controls.Add(this.edtBarCode);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.grdProducts);
            this.splitContainerControl2.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(437, 398);
            this.splitContainerControl2.SplitterPosition = 35;
            this.splitContainerControl2.TabIndex = 8;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // splitContainerControl3
            // 
            this.splitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl3.Horizontal = false;
            this.splitContainerControl3.IsSplitterFixed = true;
            this.splitContainerControl3.Location = new System.Drawing.Point(5, 5);
            this.splitContainerControl3.Name = "splitContainerControl3";
            this.splitContainerControl3.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainerControl3.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl3.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl3.Panel1.Controls.Add(this.lblStatus);
            this.splitContainerControl3.Panel1.ShowCaption = true;
            this.splitContainerControl3.Panel1.Text = "条码/路由信息";
            this.splitContainerControl3.Panel2.Controls.Add(this.splitContainerControl4);
            this.splitContainerControl3.Panel2.Text = "Panel2";
            this.splitContainerControl3.Size = new System.Drawing.Size(703, 427);
            this.splitContainerControl3.SplitterPosition = 62;
            this.splitContainerControl3.TabIndex = 9;
            this.splitContainerControl3.Text = "splitContainerControl3";
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblStatus.Location = new System.Drawing.Point(11, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 0;
            // 
            // splitContainerControl4
            // 
            this.splitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl4.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl4.IsSplitterFixed = true;
            this.splitContainerControl4.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl4.Name = "splitContainerControl4";
            this.splitContainerControl4.Panel1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.splitContainerControl4.Panel1.AppearanceCaption.Options.UseFont = true;
            this.splitContainerControl4.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.splitContainerControl4.Panel1.Controls.Add(this.grdRepairItems);
            this.splitContainerControl4.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerControl4.Panel1.ShowCaption = true;
            this.splitContainerControl4.Panel1.Text = "维修情况";
            this.splitContainerControl4.Panel2.Controls.Add(this.btnBarCodeConf);
            this.splitContainerControl4.Panel2.Text = "Panel2";
            this.splitContainerControl4.Size = new System.Drawing.Size(703, 360);
            this.splitContainerControl4.SplitterPosition = 118;
            this.splitContainerControl4.TabIndex = 4;
            this.splitContainerControl4.Text = "splitContainerControl4";
            // 
            // frmTroubleShooting
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(1169, 493);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmTroubleShooting";
            this.Text = "故障维修";
            this.Activated += new System.EventHandler(this.frmTroubleShooting_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTroubleShooting_FormClosed);
            this.Load += new System.EventHandler(this.frmTroubleShooting_Load);
            this.Enter += new System.EventHandler(this.frmTroubleShooting_Enter);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRepairItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvRepairItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.risluSymbol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureSrcOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureNature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluFailureDuty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRepairMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluInspectStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riluRepairAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBarCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl3)).EndInit();
            this.splitContainerControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl4)).EndInit();
            this.splitContainerControl4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdRepairItems;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvRepairItems;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT110LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit risluSymbol;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT118LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluFailureMode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFailurePointCount;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT216LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluFailureSrcOperation;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT183LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluFailureNature;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT184LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluFailureDuty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT119LeafID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluRepairMode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnTrackReferenceValue;
        private DevExpress.XtraEditors.SimpleButton btnBarCodeConf;
        private DevExpress.XtraGrid.GridControl grdProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvProducts;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPartNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnInspectStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluInspectStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRepairStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riluRepairAction;
        private DevExpress.XtraEditors.TextEdit edtBarCode;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl3;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl4;
    }
}