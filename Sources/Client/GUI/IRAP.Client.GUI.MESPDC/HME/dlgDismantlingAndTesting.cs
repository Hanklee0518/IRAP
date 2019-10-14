using IRAP.Client.Global;
using IRAP.Client.Global.GUI;
using IRAP.Client.User;
using IRAP.Global;
using IRAP.Service.Client.Exchange.MES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC.HME
{
    public partial class dlgDismantlingAndTesting : IRAP.Client.Global.frmCustomBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private string dmcCode = "";
        private xucIRAPListView log = null;

        public dlgDismantlingAndTesting()
        {
            InitializeComponent();
        }

        public xucIRAPListView Log { get; set; }
        public string DMC
        {
            get { return dmcCode; }
            set
            {
                string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

                dmcCode = value;
                lblDMC.Text = dmcCode;

                MR_GetSubComponentList trade =
                    new MR_GetSubComponentList(
                        IRAPConst.Instance.WebAPI.URL,
                        IRAPConst.Instance.WebAPI.ContentType,
                        IRAPConst.Instance.WebAPI.ClientID);
                trade.Request =
                    new MRGetSubComponentListRequest()
                    {
                        CommunityID = IRAPUser.Instance.CommunityID,
                        SysLogID = IRAPUser.Instance.SysLogID,
                        DMCNO = dmcCode,
                    };
                try
                {
                    if (trade.Do())
                    {
                        var list =
                            (
                            from r in trade.Response.Output
                            select new SubComponent()
                            {
                                Ordinal = r.Ordinal,
                                NO = r.NO,
                                LotNumber = r.LotNumber,
                                Type = r.Type,
                                QCStatus = "报废",
                            }
                            ).ToList();

                        grdSubComponents.DataSource = list;
                        grdvSubComponents.BestFitColumns();
                    }
                    else
                    {
                        grdSubComponents.DataSource = null;

                        throw new Exception(trade.Error.ErrText);
                    }
                }
                catch (Exception error)
                {
                    WriteLog.Instance.Write(error.Message, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                    throw error;
                }
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            bool enabled = grdvSubComponents.SelectedRowsCount > 0;
            tsmiScrap.Enabled = enabled;
            tsmiRelease.Enabled = enabled;
        }

        private void tsmiScrap_Click(object sender, EventArgs e)
        {
            List<SubComponent> datas = grdSubComponents.DataSource as List<SubComponent>;
            if (datas == null)
            {
                return;
            }

            if (grdvSubComponents.SelectedRowsCount > 0)
            {
                grdvSubComponents.BeginDataUpdate();
                foreach (int idx in grdvSubComponents.GetSelectedRows())
                {
                    if (idx >= 0 && idx < datas.Count)
                    {
                        datas[idx].QCStatus = "报废";
                    }
                }
                grdvSubComponents.EndDataUpdate();
            }
        }

        private void tsmiRelease_Click(object sender, EventArgs e)
        {
            List<SubComponent> datas = grdSubComponents.DataSource as List<SubComponent>;
            if (datas == null)
            {
                return;
            }

            if (grdvSubComponents.SelectedRowsCount > 0)
            {
                grdvSubComponents.BeginDataUpdate();
                foreach (int idx in grdvSubComponents.GetSelectedRows())
                {
                    if (idx >= 0 && idx < datas.Count)
                    {
                        datas[idx].QCStatus = "释放";
                    }
                }
                grdvSubComponents.EndDataUpdate();
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            List<SubComponent> datas = grdSubComponents.DataSource as List<SubComponent>;
            if (datas == null || datas.Count <= 0)
            {
                return;
            }

            MR_DismantleComponent_Save trade =
                new MR_DismantleComponent_Save(
                    IRAPConst.Instance.WebAPI.URL,
                    IRAPConst.Instance.WebAPI.ContentType,
                    IRAPConst.Instance.WebAPI.ClientID);
            trade.Request =
                new MRDismantleComponentSaveRequest()
                {
                    CommunityID = IRAPUser.Instance.CommunityID,
                    SysLogID = IRAPUser.Instance.SysLogID,
                    DMCNO = lblDMC.Text,
                };
            foreach (SubComponent c in datas)
            {
                trade.Request.CompoentList.Add(
                    new MRDismantleComponentSaveRequestDetail()
                    {
                        NO = c.NO,
                        QCStatus = c.QCStatus,
                    });
            }

            try
            {
                trade.Do();
                if (log != null)
                {
                    log.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                }

                Close();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                throw error;
            }
        }
    }

    class SubComponent
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 唯一号(DMC/容器号)
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 类型：精追/批追
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string QCStatus { get; set; }
    }
}
