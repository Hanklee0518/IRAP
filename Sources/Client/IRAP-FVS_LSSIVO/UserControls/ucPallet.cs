using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraCharts;

using IRAP.Global;
using IRAP.Entities.MES;
using IRAP.WCF.Client.Method;

namespace IRAP_FVS_LSSIVO.UserControls
{
    public partial class ucPallet : IRAP_FVS_LSSIVO.UserControls.ucCustomFVSKanban
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<FailureModeOfPallet> datas = new List<FailureModeOfPallet>();

        public ucPallet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建右侧纵坐标
        /// </summary>
        /// <param name="xyDiagram"></param>
        /// <param name="series"></param>
        private void CreateSecondaryAxisY(XYDiagram xyDiagram, Series series)
        {
            if (xyDiagram == null)
                return;
            if (series == null)
                return;

            SecondaryAxisY newAxis = new SecondaryAxisY(series.Name);
            newAxis.Title.Text = series.Name;
            newAxis.Title.Alignment = StringAlignment.Center;
            newAxis.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            newAxis.Title.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular);
            newAxis.Title.TextColor = series.View.Color;
            newAxis.Label.TextColor = series.View.Color;
            newAxis.Color = series.View.Color;
            newAxis.NumericScaleOptions.ScaleMode = ScaleMode.Manual;
            newAxis.NumericScaleOptions.CustomMeasureUnit = 1;
            newAxis.WholeRange.SetMinMaxValues(0, 100);
            newAxis.WholeRange.SideMarginsValue = 0;
            newAxis.VisualRange.SetMinMaxValues(0, 100);
            newAxis.VisualRange.SideMarginsValue = 0;
            newAxis.Label.TextPattern = "{V} %";

            xyDiagram.SecondaryAxesY.Add(newAxis);
            ((LineSeriesView)series.View).AxisY = newAxis;
        }

        private void GetFailureModesPallet(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
            string pwoNo,
            long sysLogID)
        {
            string strProcedureName =
               string.Format(
                   "{0}.{1}",
                   className,
                   MethodBase.GetCurrentMethod().Name);
            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                int errCode = 0;
                string errText = "";

                IRAPMESClient.Instance.ufn_GetPallet_FailureMode(
                    communityID,
                    productLeaf,
                    workUnitLeaf,
                    pwoNo,
                    sysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);

                chartPallet.Series.Clear();
                if (errCode == 0)
                {
                    Series series1 = new Series("不良个数", ViewType.Bar)
                    {
                        ArgumentScaleType = ScaleType.Qualitative,
                        LabelsVisibility = DevExpress.Utils.DefaultBoolean.True,
                    };
                    Series series2 = new Series("累计比率", ViewType.Line)
                    {
                        ArgumentScaleType = ScaleType.Qualitative,
                        LabelsVisibility = DevExpress.Utils.DefaultBoolean.True,
                    };

                    foreach (FailureModeOfPallet data in datas)
                    {
                        string seriesCaption = string.Format("{0}",
                            data.T118Name,
                            data.T118Code);
                        if (data.FailureQty > 0)
                        {
                            series1.Points.Add(new SeriesPoint(seriesCaption, data.FailureQty));
                        }
                        if (data.FailRate > 0)
                        {
                            series2.Points.Add(
                                new SeriesPoint(
                                    seriesCaption, 
                                    string.Format(
                                        "{0}",
                                        data.FailRate * 100)));
                        }
                    }

                    //
                    series1.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    series2.Label.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
                    //
                    series1.Label.TextColor = Color.Black;
                    series2.Label.TextColor = Color.Black;
                    series1.Label.BackColor = System.Drawing.Color.Transparent;
                    series2.Label.BackColor = System.Drawing.Color.Transparent;
                    series2.ToolTipHintDataMember = "{V} %";
                    //
                    series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                    series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;

                    chartPallet.Series.Add(series1);
                    chartPallet.Series.Add(series2);

                    XYDiagram xyDiagram = (XYDiagram)chartPallet.Diagram;
                    if (xyDiagram != null)
                    {
                        xyDiagram.SecondaryAxesY.Clear();
                        xyDiagram.AxisX.VisualRange.Auto = false;
                        xyDiagram.AxisX.VisualRange.AutoSideMargins = false;

                        xyDiagram.AxisY.Title.Text = "不良个数";
                        xyDiagram.AxisY.Title.Font = new Font("微软雅黑", 10.5f, FontStyle.Regular);
                        xyDiagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                        CreateSecondaryAxisY(xyDiagram, series2);
                    }
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        public void SetSearchCondition(
            int communityID,
            int productLeaf,
            int workUnitLeaf,
            string pwoNo,
            long sysLogID)
        {
            GetFailureModesPallet(
                communityID,
                productLeaf,
                workUnitLeaf,
                pwoNo,
                sysLogID);
        }
    }
}