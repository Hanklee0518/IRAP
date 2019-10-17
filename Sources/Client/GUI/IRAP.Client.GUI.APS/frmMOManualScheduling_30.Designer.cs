namespace IRAP.Client.GUI.APS
{
    partial class frmMOManualScheduling_30
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmnMOLineStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gpcMOList = new DevExpress.XtraEditors.GroupControl();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.mitmScheduling = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mitmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.grdvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPriorityOrdinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOrderQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnFinishedQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnUnitOfMeasure = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineStatusString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnATPQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnEstimatedATPTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScheduleStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnActualStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductLine = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.cboAreas = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcMOList)).BeginInit();
            this.gpcMOList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreas.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(887, 56);
            this.lblFuncName.Text = "制造订单手工排程";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(887, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmnMOLineStatus
            // 
            this.grdclmnMOLineStatus.Caption = "gridColumn1";
            this.grdclmnMOLineStatus.FieldName = "MOLineStatus";
            this.grdclmnMOLineStatus.Name = "grdclmnMOLineStatus";
            // 
            // gpcMOList
            // 
            this.gpcMOList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcMOList.AppearanceCaption.Font = new System.Drawing.Font("新宋体", 12F);
            this.gpcMOList.AppearanceCaption.Options.UseFont = true;
            this.gpcMOList.Controls.Add(this.grdOrders);
            this.gpcMOList.Location = new System.Drawing.Point(10, 41);
            this.gpcMOList.Name = "gpcMOList";
            this.gpcMOList.Padding = new System.Windows.Forms.Padding(5);
            this.gpcMOList.Size = new System.Drawing.Size(781, 440);
            this.gpcMOList.TabIndex = 3;
            this.gpcMOList.Text = "制造订单列表";
            // 
            // grdOrders
            // 
            this.grdOrders.ContextMenuStrip = this.contextMenuStrip;
            this.grdOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrders.Location = new System.Drawing.Point(7, 28);
            this.grdOrders.MainView = this.grdvOrders;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.Size = new System.Drawing.Size(767, 405);
            this.grdOrders.TabIndex = 1;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOrders});
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmScheduling,
            this.toolStripMenuItem1,
            this.mitmRefresh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(149, 54);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // mitmScheduling
            // 
            this.mitmScheduling.Name = "mitmScheduling";
            this.mitmScheduling.Size = new System.Drawing.Size(148, 22);
            this.mitmScheduling.Text = "排定生产时间";
            this.mitmScheduling.Click += new System.EventHandler(this.mitmScheduling_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // mitmRefresh
            // 
            this.mitmRefresh.Image = global::IRAP.Client.GUI.APS.Properties.Resources.refresh;
            this.mitmRefresh.Name = "mitmRefresh";
            this.mitmRefresh.Size = new System.Drawing.Size(148, 22);
            this.mitmRefresh.Text = "刷新";
            // 
            // grdvOrders
            // 
            this.grdvOrders.Appearance.HeaderPanel.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvOrders.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOrders.Appearance.Row.Font = new System.Drawing.Font("新宋体", 12F);
            this.grdvOrders.Appearance.Row.Options.UseFont = true;
            this.grdvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPriorityOrdinal,
            this.grdclmnMONo,
            this.grdclmnMOLineNo,
            this.grdclmnProductNo,
            this.grdclmnProductDescription,
            this.grdclmnOrderQuantity,
            this.grdclmnFinishedQuantity,
            this.grdclmnUnitOfMeasure,
            this.grdclmnPlannedStartDate,
            this.grdclmnPlannedEndDate,
            this.grdclmnMOLineStatusString,
            this.grdclmnATPQuantity,
            this.grdclmnEstimatedATPTime,
            this.grdclmnScheduleStartTime,
            this.grdclmnActualStartTime,
            this.grdclmnMOLineStatus,
            this.grdclmnProductLine});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmnMOLineStatus;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.Blue;
            formatConditionRuleValue1.Appearance.Options.UseFont = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = "5";
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmnMOLineStatus;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.Red;
            formatConditionRuleValue2.Appearance.Options.UseFont = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.GreaterOrEqual;
            formatConditionRuleValue2.Value1 = "6";
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.grdclmnMOLineStatus;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleValue3.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.Green;
            formatConditionRuleValue3.Appearance.Options.UseFont = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = "4";
            gridFormatRule3.Rule = formatConditionRuleValue3;
            this.grdvOrders.FormatRules.Add(gridFormatRule1);
            this.grdvOrders.FormatRules.Add(gridFormatRule2);
            this.grdvOrders.FormatRules.Add(gridFormatRule3);
            this.grdvOrders.GridControl = this.grdOrders;
            this.grdvOrders.Name = "grdvOrders";
            this.grdvOrders.OptionsBehavior.Editable = false;
            this.grdvOrders.OptionsView.ColumnAutoWidth = false;
            this.grdvOrders.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnPriorityOrdinal
            // 
            this.grdclmnPriorityOrdinal.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPriorityOrdinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPriorityOrdinal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPriorityOrdinal.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPriorityOrdinal.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPriorityOrdinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPriorityOrdinal.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPriorityOrdinal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPriorityOrdinal.Caption = "优先顺序";
            this.grdclmnPriorityOrdinal.FieldName = "PriorityOrdinal";
            this.grdclmnPriorityOrdinal.Name = "grdclmnPriorityOrdinal";
            this.grdclmnPriorityOrdinal.OptionsColumn.ReadOnly = true;
            this.grdclmnPriorityOrdinal.Visible = true;
            this.grdclmnPriorityOrdinal.VisibleIndex = 0;
            this.grdclmnPriorityOrdinal.Width = 60;
            // 
            // grdclmnMONo
            // 
            this.grdclmnMONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnMONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMONo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONo.Caption = "制造订单号";
            this.grdclmnMONo.FieldName = "MONo";
            this.grdclmnMONo.Name = "grdclmnMONo";
            this.grdclmnMONo.OptionsColumn.ReadOnly = true;
            this.grdclmnMONo.Visible = true;
            this.grdclmnMONo.VisibleIndex = 2;
            this.grdclmnMONo.Width = 120;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.OptionsColumn.ReadOnly = true;
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 3;
            this.grdclmnMOLineNo.Width = 120;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.FieldName = "ProductNo";
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.OptionsColumn.ReadOnly = true;
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 4;
            // 
            // grdclmnProductDescription
            // 
            this.grdclmnProductDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductDescription.Caption = "产品名称";
            this.grdclmnProductDescription.FieldName = "ProductDesc";
            this.grdclmnProductDescription.Name = "grdclmnProductDescription";
            this.grdclmnProductDescription.OptionsColumn.ReadOnly = true;
            this.grdclmnProductDescription.Visible = true;
            this.grdclmnProductDescription.VisibleIndex = 5;
            // 
            // grdclmnOrderQuantity
            // 
            this.grdclmnOrderQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrderQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnOrderQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrderQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnOrderQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOrderQuantity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrderQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnOrderQuantity.Caption = "订单数量";
            this.grdclmnOrderQuantity.FieldName = "OrderQuantity";
            this.grdclmnOrderQuantity.Name = "grdclmnOrderQuantity";
            this.grdclmnOrderQuantity.OptionsColumn.ReadOnly = true;
            this.grdclmnOrderQuantity.Visible = true;
            this.grdclmnOrderQuantity.VisibleIndex = 6;
            // 
            // grdclmnFinishedQuantity
            // 
            this.grdclmnFinishedQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnFinishedQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnFinishedQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFinishedQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnFinishedQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnFinishedQuantity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnFinishedQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnFinishedQuantity.Caption = "完工数量";
            this.grdclmnFinishedQuantity.FieldName = "FinishedQuantity";
            this.grdclmnFinishedQuantity.Name = "grdclmnFinishedQuantity";
            this.grdclmnFinishedQuantity.OptionsColumn.ReadOnly = true;
            // 
            // grdclmnUnitOfMeasure
            // 
            this.grdclmnUnitOfMeasure.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnUnitOfMeasure.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnUnitOfMeasure.Caption = "计量单位";
            this.grdclmnUnitOfMeasure.FieldName = "UnitOfMeasure";
            this.grdclmnUnitOfMeasure.Name = "grdclmnUnitOfMeasure";
            this.grdclmnUnitOfMeasure.OptionsColumn.ReadOnly = true;
            // 
            // grdclmnPlannedStartDate
            // 
            this.grdclmnPlannedStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedStartDate.Caption = "计划投产日期";
            this.grdclmnPlannedStartDate.FieldName = "PlannedStartDate";
            this.grdclmnPlannedStartDate.Name = "grdclmnPlannedStartDate";
            this.grdclmnPlannedStartDate.OptionsColumn.ReadOnly = true;
            this.grdclmnPlannedStartDate.Visible = true;
            this.grdclmnPlannedStartDate.VisibleIndex = 7;
            // 
            // grdclmnPlannedEndDate
            // 
            this.grdclmnPlannedEndDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedEndDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedEndDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedEndDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedEndDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedEndDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedEndDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedEndDate.Caption = "计划完工日期";
            this.grdclmnPlannedEndDate.FieldName = "PlannedEndDate";
            this.grdclmnPlannedEndDate.Name = "grdclmnPlannedEndDate";
            this.grdclmnPlannedEndDate.OptionsColumn.ReadOnly = true;
            this.grdclmnPlannedEndDate.Visible = true;
            this.grdclmnPlannedEndDate.VisibleIndex = 8;
            // 
            // grdclmnMOLineStatusString
            // 
            this.grdclmnMOLineStatusString.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineStatusString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineStatusString.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineStatusString.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMOLineStatusString.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineStatusString.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineStatusString.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineStatusString.Caption = "订单状态";
            this.grdclmnMOLineStatusString.FieldName = "MOLineStatusString";
            this.grdclmnMOLineStatusString.Name = "grdclmnMOLineStatusString";
            this.grdclmnMOLineStatusString.OptionsColumn.ReadOnly = true;
            this.grdclmnMOLineStatusString.Visible = true;
            this.grdclmnMOLineStatusString.VisibleIndex = 1;
            // 
            // grdclmnATPQuantity
            // 
            this.grdclmnATPQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnATPQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnATPQuantity.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnATPQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnATPQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnATPQuantity.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnATPQuantity.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnATPQuantity.Caption = "当前物料可供生产数量";
            this.grdclmnATPQuantity.FieldName = "ATPQuantity";
            this.grdclmnATPQuantity.Name = "grdclmnATPQuantity";
            this.grdclmnATPQuantity.OptionsColumn.ReadOnly = true;
            this.grdclmnATPQuantity.Visible = true;
            this.grdclmnATPQuantity.VisibleIndex = 12;
            // 
            // grdclmnEstimatedATPTime
            // 
            this.grdclmnEstimatedATPTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnEstimatedATPTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnEstimatedATPTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEstimatedATPTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnEstimatedATPTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnEstimatedATPTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnEstimatedATPTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnEstimatedATPTime.Caption = "预计物料备齐时间";
            this.grdclmnEstimatedATPTime.FieldName = "EstimatedATPTime";
            this.grdclmnEstimatedATPTime.Name = "grdclmnEstimatedATPTime";
            this.grdclmnEstimatedATPTime.OptionsColumn.ReadOnly = true;
            this.grdclmnEstimatedATPTime.Visible = true;
            this.grdclmnEstimatedATPTime.VisibleIndex = 13;
            // 
            // grdclmnScheduleStartTime
            // 
            this.grdclmnScheduleStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduleStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduleStartTime.Caption = "排定生产时间";
            this.grdclmnScheduleStartTime.FieldName = "ScheduledStartTime";
            this.grdclmnScheduleStartTime.Name = "grdclmnScheduleStartTime";
            this.grdclmnScheduleStartTime.Visible = true;
            this.grdclmnScheduleStartTime.VisibleIndex = 10;
            // 
            // grdclmnActualStartTime
            // 
            this.grdclmnActualStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnActualStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnActualStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnActualStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnActualStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnActualStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnActualStartTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnActualStartTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnActualStartTime.Caption = "实际生产时间";
            this.grdclmnActualStartTime.FieldName = "ActualStartTime";
            this.grdclmnActualStartTime.Name = "grdclmnActualStartTime";
            this.grdclmnActualStartTime.Visible = true;
            this.grdclmnActualStartTime.VisibleIndex = 11;
            // 
            // grdclmnProductLine
            // 
            this.grdclmnProductLine.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductLine.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductLine.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductLine.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnProductLine.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnProductLine.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductLine.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnProductLine.Caption = "排定生产线";
            this.grdclmnProductLine.FieldName = "T134Name";
            this.grdclmnProductLine.Name = "grdclmnProductLine";
            this.grdclmnProductLine.Visible = true;
            this.grdclmnProductLine.VisibleIndex = 9;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.btnRefresh);
            this.pnlBody.Controls.Add(this.cboAreas);
            this.pnlBody.Controls.Add(this.labelControl1);
            this.pnlBody.Controls.Add(this.gpcMOList);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(887, 493);
            this.pnlBody.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(800, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 27);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboAreas
            // 
            this.cboAreas.Location = new System.Drawing.Point(192, 11);
            this.cboAreas.Name = "cboAreas";
            this.cboAreas.Properties.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.cboAreas.Properties.Appearance.Options.UseFont = true;
            this.cboAreas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAreas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAreas.Size = new System.Drawing.Size(282, 22);
            this.cboAreas.TabIndex = 5;
            this.cboAreas.SelectedIndexChanged += new System.EventHandler(this.cboAreas_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("新宋体", 12F);
            this.labelControl1.Location = new System.Drawing.Point(10, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(176, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "请选择进行排产的工段：";
            // 
            // frmMOManualScheduling_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(887, 549);
            this.Controls.Add(this.pnlBody);
            this.Name = "frmMOManualScheduling_30";
            this.Text = "制造订单手工排程";
            this.Activated += new System.EventHandler(this.frmMOManualScheduling_30_Activated);
            this.Shown += new System.EventHandler(this.frmMOManualScheduling_30_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcMOList)).EndInit();
            this.gpcMOList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAreas.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcMOList;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboAreas;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.GridControl grdOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOrders;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mitmScheduling;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mitmRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPriorityOrdinal;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrderQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnFinishedQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnUnitOfMeasure;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineStatusString;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnATPQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnEstimatedATPTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScheduleStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnActualStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineStatus;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductLine;
    }
}
