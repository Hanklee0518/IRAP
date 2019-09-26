namespace IRAP.Client.GUI.SCES
{
    partial class frmLST_UnclosedRMDelivery_30
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.grdclmnOTDStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gpcResults = new DevExpress.XtraEditors.GroupControl();
            this.grdResults = new DevExpress.XtraGrid.GridControl();
            this.cmsAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiUndoDelivery = new System.Windows.Forms.ToolStripMenuItem();
            this.grdvResults = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnDeliverStatusString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOrderQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScheduledStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyToDeliver = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnRequestedArrivalTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMaterialDeliverTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnDeliverTimeSpan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnQtyDelivered = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnContainerNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnOTDStatusString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGetData = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportTo = new DevExpress.XtraEditors.SimpleButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboDstStoreSites = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpcResults)).BeginInit();
            this.gpcResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).BeginInit();
            this.cmsAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDstStoreSites.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(702, 56);
            this.lblFuncName.Text = "未结配送指令查询";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(702, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // grdclmnOTDStatus
            // 
            this.grdclmnOTDStatus.Caption = "准时配送状态";
            this.grdclmnOTDStatus.FieldName = "OTDStatus";
            this.grdclmnOTDStatus.Name = "grdclmnOTDStatus";
            this.grdclmnOTDStatus.Visible = true;
            this.grdclmnOTDStatus.VisibleIndex = 17;
            // 
            // gpcResults
            // 
            this.gpcResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcResults.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcResults.Appearance.Options.UseFont = true;
            this.gpcResults.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpcResults.AppearanceCaption.Options.UseFont = true;
            this.gpcResults.Controls.Add(this.grdResults);
            this.gpcResults.Location = new System.Drawing.Point(12, 130);
            this.gpcResults.Name = "gpcResults";
            this.gpcResults.Padding = new System.Windows.Forms.Padding(5);
            this.gpcResults.Size = new System.Drawing.Size(565, 259);
            this.gpcResults.TabIndex = 1;
            this.gpcResults.Text = "查询结果";
            // 
            // grdResults
            // 
            this.grdResults.ContextMenuStrip = this.cmsAction;
            this.grdResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResults.Location = new System.Drawing.Point(7, 32);
            this.grdResults.MainView = this.grdvResults;
            this.grdResults.Name = "grdResults";
            this.grdResults.Size = new System.Drawing.Size(551, 220);
            this.grdResults.TabIndex = 2;
            this.grdResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvResults});
            // 
            // cmsAction
            // 
            this.cmsAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUndoDelivery});
            this.cmsAction.Name = "cmsAction";
            this.cmsAction.Size = new System.Drawing.Size(153, 48);
            this.cmsAction.Opening += new System.ComponentModel.CancelEventHandler(this.cmsAction_Opening);
            // 
            // tsmiUndoDelivery
            // 
            this.tsmiUndoDelivery.Name = "tsmiUndoDelivery";
            this.tsmiUndoDelivery.Size = new System.Drawing.Size(152, 22);
            this.tsmiUndoDelivery.Text = "撤销配送";
            this.tsmiUndoDelivery.Click += new System.EventHandler(this.tsmiUndoDelivery_Click);
            // 
            // grdvResults
            // 
            this.grdvResults.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvResults.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvResults.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grdvResults.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdvResults.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdvResults.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdvResults.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdvResults.Appearance.Row.Options.UseFont = true;
            this.grdvResults.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnDeliverStatusString,
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmnPWONo,
            this.grdclmnProductNo,
            this.grdclmnProductName,
            this.grdclmnOrderQty,
            this.grdclmnScheduledStartTime,
            this.grdclmnMaterialCode,
            this.grdclmnMaterialName,
            this.grdclmnQtyToDeliver,
            this.grdclmnRequestedArrivalTime,
            this.grdclmnMaterialDeliverTime,
            this.grdclmnDeliverTimeSpan,
            this.grdclmnQtyDelivered,
            this.grdclmnContainerNo,
            this.grdclmnOTDStatusString,
            this.grdclmnOTDStatus});
            this.grdvResults.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.grdclmnOTDStatus;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.Yellow;
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue1.Value1 = ((short)(0));
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.grdclmnOTDStatus;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.Green;
            formatConditionRuleValue2.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = ((short)(1));
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Column = this.grdclmnOTDStatus;
            gridFormatRule3.Name = "Format2";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.Red;
            formatConditionRuleValue3.Appearance.ForeColor = System.Drawing.Color.White;
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = ((short)(2));
            gridFormatRule3.Rule = formatConditionRuleValue3;
            this.grdvResults.FormatRules.Add(gridFormatRule1);
            this.grdvResults.FormatRules.Add(gridFormatRule2);
            this.grdvResults.FormatRules.Add(gridFormatRule3);
            this.grdvResults.GridControl = this.grdResults;
            this.grdvResults.Name = "grdvResults";
            this.grdvResults.OptionsBehavior.Editable = false;
            this.grdvResults.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvResults.OptionsView.ColumnAutoWidth = false;
            this.grdvResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.grdvResults.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvResults.OptionsView.EnableAppearanceOddRow = true;
            this.grdvResults.OptionsView.RowAutoHeight = true;
            this.grdvResults.OptionsView.ShowGroupPanel = false;
            // 
            // grdclmnDeliverStatusString
            // 
            this.grdclmnDeliverStatusString.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnDeliverStatusString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnDeliverStatusString.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnDeliverStatusString.Caption = "配送状态";
            this.grdclmnDeliverStatusString.FieldName = "DeliverStatusString";
            this.grdclmnDeliverStatusString.Name = "grdclmnDeliverStatusString";
            this.grdclmnDeliverStatusString.Visible = true;
            this.grdclmnDeliverStatusString.VisibleIndex = 0;
            // 
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.Caption = "制造订单";
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 1;
            this.grdclmnMONumber.Width = 120;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 2;
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.Caption = "生产工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 3;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.Caption = "产品编号";
            this.grdclmnProductNo.FieldName = "ProductNo";
            this.grdclmnProductNo.Name = "grdclmnProductNo";
            this.grdclmnProductNo.Visible = true;
            this.grdclmnProductNo.VisibleIndex = 4;
            // 
            // grdclmnProductName
            // 
            this.grdclmnProductName.Caption = "产品名称";
            this.grdclmnProductName.FieldName = "ProductName";
            this.grdclmnProductName.Name = "grdclmnProductName";
            this.grdclmnProductName.Visible = true;
            this.grdclmnProductName.VisibleIndex = 5;
            // 
            // grdclmnOrderQty
            // 
            this.grdclmnOrderQty.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnOrderQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOrderQty.Caption = "工单数量";
            this.grdclmnOrderQty.FieldName = "OrderQty";
            this.grdclmnOrderQty.Name = "grdclmnOrderQty";
            this.grdclmnOrderQty.Visible = true;
            this.grdclmnOrderQty.VisibleIndex = 6;
            // 
            // grdclmnScheduledStartTime
            // 
            this.grdclmnScheduledStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnScheduledStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduledStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduledStartTime.Caption = "排定生产时间";
            this.grdclmnScheduledStartTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.grdclmnScheduledStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnScheduledStartTime.FieldName = "ScheduledStartTime";
            this.grdclmnScheduledStartTime.Name = "grdclmnScheduledStartTime";
            this.grdclmnScheduledStartTime.Visible = true;
            this.grdclmnScheduledStartTime.VisibleIndex = 7;
            // 
            // grdclmnMaterialCode
            // 
            this.grdclmnMaterialCode.Caption = "要求配送物料号";
            this.grdclmnMaterialCode.FieldName = "MaterialCode";
            this.grdclmnMaterialCode.Name = "grdclmnMaterialCode";
            this.grdclmnMaterialCode.Visible = true;
            this.grdclmnMaterialCode.VisibleIndex = 8;
            // 
            // grdclmnMaterialName
            // 
            this.grdclmnMaterialName.Caption = "物料名称";
            this.grdclmnMaterialName.FieldName = "MaterialName";
            this.grdclmnMaterialName.Name = "grdclmnMaterialName";
            this.grdclmnMaterialName.Visible = true;
            this.grdclmnMaterialName.VisibleIndex = 9;
            // 
            // grdclmnQtyToDeliver
            // 
            this.grdclmnQtyToDeliver.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQtyToDeliver.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQtyToDeliver.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyToDeliver.Caption = "要求配送数量";
            this.grdclmnQtyToDeliver.FieldName = "QtyToDeliver";
            this.grdclmnQtyToDeliver.Name = "grdclmnQtyToDeliver";
            this.grdclmnQtyToDeliver.Visible = true;
            this.grdclmnQtyToDeliver.VisibleIndex = 10;
            // 
            // grdclmnRequestedArrivalTime
            // 
            this.grdclmnRequestedArrivalTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnRequestedArrivalTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnRequestedArrivalTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnRequestedArrivalTime.Caption = "要求送达时间";
            this.grdclmnRequestedArrivalTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.grdclmnRequestedArrivalTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnRequestedArrivalTime.FieldName = "RequestedArrivalTime";
            this.grdclmnRequestedArrivalTime.Name = "grdclmnRequestedArrivalTime";
            this.grdclmnRequestedArrivalTime.Visible = true;
            this.grdclmnRequestedArrivalTime.VisibleIndex = 11;
            // 
            // grdclmnMaterialDeliverTime
            // 
            this.grdclmnMaterialDeliverTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMaterialDeliverTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMaterialDeliverTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMaterialDeliverTime.Caption = "实际配送时间";
            this.grdclmnMaterialDeliverTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss.fff";
            this.grdclmnMaterialDeliverTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.grdclmnMaterialDeliverTime.FieldName = "MaterialDeliverTime";
            this.grdclmnMaterialDeliverTime.Name = "grdclmnMaterialDeliverTime";
            this.grdclmnMaterialDeliverTime.Visible = true;
            this.grdclmnMaterialDeliverTime.VisibleIndex = 12;
            // 
            // grdclmnDeliverTimeSpan
            // 
            this.grdclmnDeliverTimeSpan.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnDeliverTimeSpan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnDeliverTimeSpan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnDeliverTimeSpan.Caption = "时间差";
            this.grdclmnDeliverTimeSpan.FieldName = "DeliverTimeSpan";
            this.grdclmnDeliverTimeSpan.Name = "grdclmnDeliverTimeSpan";
            this.grdclmnDeliverTimeSpan.Visible = true;
            this.grdclmnDeliverTimeSpan.VisibleIndex = 13;
            // 
            // grdclmnQtyDelivered
            // 
            this.grdclmnQtyDelivered.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnQtyDelivered.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnQtyDelivered.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnQtyDelivered.Caption = "实际配送数量";
            this.grdclmnQtyDelivered.FieldName = "QtyDelivered";
            this.grdclmnQtyDelivered.Name = "grdclmnQtyDelivered";
            this.grdclmnQtyDelivered.Visible = true;
            this.grdclmnQtyDelivered.VisibleIndex = 14;
            // 
            // grdclmnContainerNo
            // 
            this.grdclmnContainerNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnContainerNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnContainerNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnContainerNo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnContainerNo.Caption = "配送使用的容器";
            this.grdclmnContainerNo.FieldName = "ContainerNo";
            this.grdclmnContainerNo.Name = "grdclmnContainerNo";
            this.grdclmnContainerNo.Visible = true;
            this.grdclmnContainerNo.VisibleIndex = 15;
            // 
            // grdclmnOTDStatusString
            // 
            this.grdclmnOTDStatusString.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnOTDStatusString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnOTDStatusString.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnOTDStatusString.Caption = "准时配送状态";
            this.grdclmnOTDStatusString.FieldName = "OTDStatusString";
            this.grdclmnOTDStatusString.Name = "grdclmnOTDStatusString";
            this.grdclmnOTDStatusString.Visible = true;
            this.grdclmnOTDStatusString.VisibleIndex = 16;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Appearance.Options.UseFont = true;
            this.btnGetData.Location = new System.Drawing.Point(592, 62);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(98, 31);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "查询(&S)";
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnExportTo
            // 
            this.btnExportTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportTo.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportTo.Appearance.Options.UseFont = true;
            this.btnExportTo.Location = new System.Drawing.Point(592, 99);
            this.btnExportTo.Name = "btnExportTo";
            this.btnExportTo.Size = new System.Drawing.Size(98, 31);
            this.btnExportTo.TabIndex = 5;
            this.btnExportTo.Text = "导出(&E)...";
            this.btnExportTo.Click += new System.EventHandler(this.btnExportTo_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xlsx";
            this.saveFileDialog.Filter = "Excel 文件(*.xlsx)|*.xlsx";
            this.saveFileDialog.Title = "导出到......";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboDstStoreSites);
            this.groupControl1.Location = new System.Drawing.Point(12, 62);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(565, 62);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "目标仓储地点";
            // 
            // cboDstStoreSites
            // 
            this.cboDstStoreSites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDstStoreSites.Location = new System.Drawing.Point(7, 30);
            this.cboDstStoreSites.Name = "cboDstStoreSites";
            this.cboDstStoreSites.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.cboDstStoreSites.Properties.Appearance.Options.UseFont = true;
            this.cboDstStoreSites.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDstStoreSites.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDstStoreSites.Size = new System.Drawing.Size(551, 26);
            this.cboDstStoreSites.TabIndex = 7;
            this.cboDstStoreSites.SelectedIndexChanged += new System.EventHandler(this.cboDstStoreSites_SelectedIndexChanged);
            // 
            // frmLST_UnclosedRMDelivery_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(702, 401);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnExportTo);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.gpcResults);
            this.Name = "frmLST_UnclosedRMDelivery_30";
            this.Text = "未结配送指令查询";
            this.Activated += new System.EventHandler(this.frmLST_UnclosedRMDelivery_30_Activated);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.gpcResults, 0);
            this.Controls.SetChildIndex(this.btnGetData, 0);
            this.Controls.SetChildIndex(this.btnExportTo, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpcResults)).EndInit();
            this.gpcResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResults)).EndInit();
            this.cmsAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDstStoreSites.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpcResults;
        private DevExpress.XtraGrid.GridControl grdResults;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvResults;
        private System.Windows.Forms.ContextMenuStrip cmsAction;
        private System.Windows.Forms.ToolStripMenuItem tsmiUndoDelivery;
        private DevExpress.XtraEditors.SimpleButton btnGetData;
        private DevExpress.XtraEditors.SimpleButton btnExportTo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboDstStoreSites;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDeliverStatusString;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOrderQty;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScheduledStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyToDeliver;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnRequestedArrivalTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMaterialDeliverTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnDeliverTimeSpan;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnQtyDelivered;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnContainerNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOTDStatusString;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnOTDStatus;
    }
}
