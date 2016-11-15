﻿namespace IRAP.Client.GUI.SCES
{
    partial class frmDeliveryMngmt_30
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliveryMngmt_30));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.mitmDeliver = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeprater = new System.Windows.Forms.ToolStripSeparator();
            this.mitmRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBody = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboDstStoreSites = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnDeliver = new DevExpress.XtraEditors.SimpleButton();
            this.gpcAndonEvents = new DevExpress.XtraEditors.GroupControl();
            this.grdOrders = new DevExpress.XtraGrid.GridControl();
            this.grdvOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdclmnPWONo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnMOLineNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnProductDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT134Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnT134Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedQuantityString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnPlannedCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdclmnScheduleStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.report = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).BeginInit();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDstStoreSites.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).BeginInit();
            this.gpcAndonEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFuncName
            // 
            this.lblFuncName.Appearance.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFuncName.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblFuncName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFuncName.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblFuncName.Size = new System.Drawing.Size(660, 56);
            this.lblFuncName.Text = "物料配送管理";
            // 
            // panelControl1
            // 
            this.panelControl1.Size = new System.Drawing.Size(660, 56);
            // 
            // toolTipController
            // 
            this.toolTipController.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.Appearance.Options.UseFont = true;
            this.toolTipController.AppearanceTitle.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTipController.AppearanceTitle.Options.UseFont = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitmDeliver,
            this.tsmiSeprater,
            this.mitmRefresh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(103, 54);
            // 
            // mitmDeliver
            // 
            this.mitmDeliver.Name = "mitmDeliver";
            this.mitmDeliver.Size = new System.Drawing.Size(102, 22);
            this.mitmDeliver.Text = "配送";
            this.mitmDeliver.Click += new System.EventHandler(this.mitmDeliver_Click);
            // 
            // tsmiSeprater
            // 
            this.tsmiSeprater.Name = "tsmiSeprater";
            this.tsmiSeprater.Size = new System.Drawing.Size(99, 6);
            // 
            // mitmRefresh
            // 
            this.mitmRefresh.Name = "mitmRefresh";
            this.mitmRefresh.Size = new System.Drawing.Size(102, 22);
            this.mitmRefresh.Text = "刷新";
            this.mitmRefresh.Click += new System.EventHandler(this.mitmRefresh_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.btnRefresh);
            this.pnlBody.Controls.Add(this.groupControl1);
            this.pnlBody.Controls.Add(this.btnDeliver);
            this.pnlBody.Controls.Add(this.gpcAndonEvents);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(660, 386);
            this.pnlBody.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("等线", 10.5F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(573, 102);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.cboDstStoreSites);
            this.groupControl1.Location = new System.Drawing.Point(10, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(552, 52);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "目标仓储地点";
            // 
            // cboDstStoreSites
            // 
            this.cboDstStoreSites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDstStoreSites.Location = new System.Drawing.Point(5, 25);
            this.cboDstStoreSites.Name = "cboDstStoreSites";
            this.cboDstStoreSites.Properties.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDstStoreSites.Properties.Appearance.Options.UseFont = true;
            this.cboDstStoreSites.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDstStoreSites.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboDstStoreSites.Size = new System.Drawing.Size(542, 20);
            this.cboDstStoreSites.TabIndex = 0;
            this.cboDstStoreSites.SelectedIndexChanged += new System.EventHandler(this.cboDstStoreSites_SelectedIndexChanged);
            // 
            // btnDeliver
            // 
            this.btnDeliver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeliver.Appearance.Font = new System.Drawing.Font("等线", 10.5F);
            this.btnDeliver.Appearance.Options.UseFont = true;
            this.btnDeliver.Location = new System.Drawing.Point(573, 68);
            this.btnDeliver.Name = "btnDeliver";
            this.btnDeliver.Size = new System.Drawing.Size(75, 28);
            this.btnDeliver.TabIndex = 2;
            this.btnDeliver.Text = "配送";
            this.btnDeliver.Click += new System.EventHandler(this.btnDeliver_Click);
            // 
            // gpcAndonEvents
            // 
            this.gpcAndonEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpcAndonEvents.Appearance.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpcAndonEvents.Appearance.Options.UseFont = true;
            this.gpcAndonEvents.AppearanceCaption.Font = new System.Drawing.Font("等线", 10.5F);
            this.gpcAndonEvents.AppearanceCaption.Options.UseFont = true;
            this.gpcAndonEvents.Controls.Add(this.grdOrders);
            this.gpcAndonEvents.Location = new System.Drawing.Point(10, 68);
            this.gpcAndonEvents.Name = "gpcAndonEvents";
            this.gpcAndonEvents.Size = new System.Drawing.Size(554, 306);
            this.gpcAndonEvents.TabIndex = 1;
            this.gpcAndonEvents.Text = "待处理的配料单列表";
            // 
            // grdOrders
            // 
            this.grdOrders.ContextMenuStrip = this.contextMenuStrip;
            this.grdOrders.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrders.Location = new System.Drawing.Point(2, 21);
            this.grdOrders.MainView = this.grdvOrders;
            this.grdOrders.Name = "grdOrders";
            this.grdOrders.Size = new System.Drawing.Size(550, 283);
            this.grdOrders.TabIndex = 1;
            this.grdOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdvOrders});
            // 
            // grdvOrders
            // 
            this.grdvOrders.Appearance.HeaderPanel.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdvOrders.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdvOrders.Appearance.Preview.ForeColor = System.Drawing.Color.Blue;
            this.grdvOrders.Appearance.Preview.Options.UseForeColor = true;
            this.grdvOrders.Appearance.Row.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdvOrders.Appearance.Row.ForeColor = System.Drawing.Color.Blue;
            this.grdvOrders.Appearance.Row.Options.UseFont = true;
            this.grdvOrders.Appearance.Row.Options.UseForeColor = true;
            this.grdvOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdclmnPWONo,
            this.grdclmnMONumber,
            this.grdclmnMOLineNo,
            this.grdclmnProductNo,
            this.grdclmnProductDescription,
            this.grdclmnT134Code,
            this.grdclmnT134Name,
            this.grdclmnPlannedQuantityString,
            this.grdclmnPlannedStartDate,
            this.grdclmnPlannedCloseDate,
            this.grdclmnScheduleStartTime});
            this.grdvOrders.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdvOrders.GridControl = this.grdOrders;
            this.grdvOrders.Name = "grdvOrders";
            this.grdvOrders.OptionsBehavior.Editable = false;
            this.grdvOrders.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grdvOrders.OptionsView.ColumnAutoWidth = false;
            this.grdvOrders.OptionsView.EnableAppearanceEvenRow = true;
            this.grdvOrders.OptionsView.EnableAppearanceOddRow = true;
            this.grdvOrders.OptionsView.ShowGroupPanel = false;
            this.grdvOrders.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdvOrders_FocusedRowChanged);
            this.grdvOrders.DoubleClick += new System.EventHandler(this.grdvOrders_DoubleClick);
            // 
            // grdclmnPWONo
            // 
            this.grdclmnPWONo.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPWONo.AppearanceCell.Options.UseFont = true;
            this.grdclmnPWONo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnPWONo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPWONo.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnPWONo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPWONo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPWONo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPWONo.Caption = "生产工单号";
            this.grdclmnPWONo.FieldName = "PWONo";
            this.grdclmnPWONo.Name = "grdclmnPWONo";
            this.grdclmnPWONo.OptionsColumn.ReadOnly = true;
            this.grdclmnPWONo.Visible = true;
            this.grdclmnPWONo.VisibleIndex = 3;
            this.grdclmnPWONo.Width = 120;
            // 
            // grdclmnMONumber
            // 
            this.grdclmnMONumber.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnMONumber.AppearanceCell.Options.UseFont = true;
            this.grdclmnMONumber.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnMONumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnMONumber.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMONumber.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMONumber.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMONumber.Caption = "制造订单号";
            this.grdclmnMONumber.FieldName = "MONumber";
            this.grdclmnMONumber.Name = "grdclmnMONumber";
            this.grdclmnMONumber.OptionsColumn.ReadOnly = true;
            this.grdclmnMONumber.Visible = true;
            this.grdclmnMONumber.VisibleIndex = 1;
            this.grdclmnMONumber.Width = 120;
            // 
            // grdclmnMOLineNo
            // 
            this.grdclmnMOLineNo.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnMOLineNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnMOLineNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnMOLineNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseFont = true;
            this.grdclmnMOLineNo.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnMOLineNo.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnMOLineNo.Caption = "行号";
            this.grdclmnMOLineNo.FieldName = "MOLineNo";
            this.grdclmnMOLineNo.Name = "grdclmnMOLineNo";
            this.grdclmnMOLineNo.OptionsColumn.ReadOnly = true;
            this.grdclmnMOLineNo.Visible = true;
            this.grdclmnMOLineNo.VisibleIndex = 2;
            // 
            // grdclmnProductNo
            // 
            this.grdclmnProductNo.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnProductNo.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductNo.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductNo.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnProductNo.AppearanceHeader.Options.UseFont = true;
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
            this.grdclmnProductDescription.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnProductDescription.AppearanceCell.Options.UseFont = true;
            this.grdclmnProductDescription.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnProductDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnProductDescription.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnProductDescription.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnProductDescription.AppearanceHeader.Options.UseFont = true;
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
            // grdclmnT134Code
            // 
            this.grdclmnT134Code.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnT134Code.AppearanceCell.Options.UseFont = true;
            this.grdclmnT134Code.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT134Code.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.grdclmnT134Code.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Code.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnT134Code.AppearanceHeader.Options.UseFont = true;
            this.grdclmnT134Code.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT134Code.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT134Code.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Code.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnT134Code.Caption = "产线代码";
            this.grdclmnT134Code.FieldName = "T134Code";
            this.grdclmnT134Code.Name = "grdclmnT134Code";
            this.grdclmnT134Code.OptionsColumn.ReadOnly = true;
            this.grdclmnT134Code.Visible = true;
            this.grdclmnT134Code.VisibleIndex = 9;
            // 
            // grdclmnT134Name
            // 
            this.grdclmnT134Name.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnT134Name.AppearanceCell.Options.UseFont = true;
            this.grdclmnT134Name.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnT134Name.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Name.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnT134Name.AppearanceHeader.Options.UseFont = true;
            this.grdclmnT134Name.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnT134Name.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnT134Name.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnT134Name.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnT134Name.Caption = "产线名称";
            this.grdclmnT134Name.FieldName = "T134Name";
            this.grdclmnT134Name.Name = "grdclmnT134Name";
            this.grdclmnT134Name.OptionsColumn.ReadOnly = true;
            this.grdclmnT134Name.Visible = true;
            this.grdclmnT134Name.VisibleIndex = 10;
            // 
            // grdclmnPlannedQuantityString
            // 
            this.grdclmnPlannedQuantityString.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPlannedQuantityString.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedQuantityString.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedQuantityString.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.grdclmnPlannedQuantityString.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnPlannedQuantityString.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedQuantityString.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedQuantityString.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedQuantityString.Caption = "排产数量";
            this.grdclmnPlannedQuantityString.FieldName = "PlannedQuantity";
            this.grdclmnPlannedQuantityString.Name = "grdclmnPlannedQuantityString";
            this.grdclmnPlannedQuantityString.OptionsColumn.ReadOnly = true;
            this.grdclmnPlannedQuantityString.Visible = true;
            this.grdclmnPlannedQuantityString.VisibleIndex = 6;
            // 
            // grdclmnPlannedStartDate
            // 
            this.grdclmnPlannedStartDate.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPlannedStartDate.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedStartDate.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnPlannedStartDate.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedStartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedStartDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedStartDate.Caption = "计划开工日期";
            this.grdclmnPlannedStartDate.FieldName = "PlannedStartDate";
            this.grdclmnPlannedStartDate.Name = "grdclmnPlannedStartDate";
            this.grdclmnPlannedStartDate.Visible = true;
            this.grdclmnPlannedStartDate.VisibleIndex = 7;
            this.grdclmnPlannedStartDate.Width = 82;
            // 
            // grdclmnPlannedCloseDate
            // 
            this.grdclmnPlannedCloseDate.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnPlannedCloseDate.AppearanceCell.Options.UseFont = true;
            this.grdclmnPlannedCloseDate.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnPlannedCloseDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnPlannedCloseDate.AppearanceHeader.Options.UseFont = true;
            this.grdclmnPlannedCloseDate.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnPlannedCloseDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnPlannedCloseDate.Caption = "计划完工日期";
            this.grdclmnPlannedCloseDate.FieldName = "PlannedCloseDate";
            this.grdclmnPlannedCloseDate.Name = "grdclmnPlannedCloseDate";
            this.grdclmnPlannedCloseDate.OptionsColumn.ReadOnly = true;
            this.grdclmnPlannedCloseDate.Visible = true;
            this.grdclmnPlannedCloseDate.VisibleIndex = 8;
            this.grdclmnPlannedCloseDate.Width = 82;
            // 
            // grdclmnScheduleStartTime
            // 
            this.grdclmnScheduleStartTime.AppearanceCell.Font = new System.Drawing.Font("等线", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdclmnScheduleStartTime.AppearanceCell.Options.UseFont = true;
            this.grdclmnScheduleStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduleStartTime.AppearanceHeader.Font = new System.Drawing.Font("等线", 10.5F);
            this.grdclmnScheduleStartTime.AppearanceHeader.Options.UseFont = true;
            this.grdclmnScheduleStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdclmnScheduleStartTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grdclmnScheduleStartTime.Caption = "要求送达时间";
            this.grdclmnScheduleStartTime.FieldName = "RequireDeliveryTime";
            this.grdclmnScheduleStartTime.Name = "grdclmnScheduleStartTime";
            this.grdclmnScheduleStartTime.Visible = true;
            this.grdclmnScheduleStartTime.VisibleIndex = 0;
            this.grdclmnScheduleStartTime.Width = 161;
            // 
            // report
            // 
            this.report.ReportResourceString = resources.GetString("report.ReportResourceString");
            // 
            // frmDeliveryMngmt_30
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(660, 442);
            this.Controls.Add(this.pnlBody);
            this.Name = "frmDeliveryMngmt_30";
            this.Text = "物料配送管理";
            this.Shown += new System.EventHandler(this.frmDeliveryMngmt_30_Shown);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.pnlBody, 0);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlBody)).EndInit();
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDstStoreSites.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gpcAndonEvents)).EndInit();
            this.gpcAndonEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.report)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mitmDeliver;
        private System.Windows.Forms.ToolStripSeparator tsmiSeprater;
        private System.Windows.Forms.ToolStripMenuItem mitmRefresh;
        private DevExpress.XtraEditors.PanelControl pnlBody;
        private DevExpress.XtraEditors.SimpleButton btnDeliver;
        private DevExpress.XtraEditors.GroupControl gpcAndonEvents;
        private DevExpress.XtraGrid.GridControl grdOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView grdvOrders;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPWONo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMONumber;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnMOLineNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductNo;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnProductDescription;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT134Code;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnT134Name;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedQuantityString;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedCloseDate;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnScheduleStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn grdclmnPlannedStartDate;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboDstStoreSites;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private FastReport.Report report;
    }
}