using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Service.Client.Exchange.MES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC.HME
{
    public partial class frmQualityInspection : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        public frmQualityInspection()
        {
            InitializeComponent();
        }

        private void edtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MR_Scan trade =
                    new MR_Scan(
                        IRAPConst.Instance.WebAPI.URL,
                        IRAPConst.Instance.WebAPI.ContentType,
                        IRAPConst.Instance.WebAPI.ClientID);
                trade.Request =
                    new MRScanRequest()
                    {
                        CommunityID = IRAPUser.Instance.CommunityID,
                        SysLogID = IRAPUser.Instance.SysLogID,
                        BarCode = edtBarCode.Text.Trim(),
                    };
                try
                {
                    if (trade.Do())
                    {
                        switch (trade.Response.Output.ComponentType)
                        {
                            case "SemiFinished":
                            case "AccurateTrace":
                                MR_QC_GetProductSourceInfo tradeGetPSI =
                                    new MR_QC_GetProductSourceInfo(
                                        IRAPConst.Instance.WebAPI.URL,
                                        IRAPConst.Instance.WebAPI.ContentType,
                                        IRAPConst.Instance.WebAPI.ClientID);
                                tradeGetPSI.Request =
                                    new MRQCGetProductSourceInfoRequest()
                                    {
                                        CommunityID = IRAPUser.Instance.CommunityID,
                                        SysLogID = IRAPUser.Instance.SysLogID,
                                        DMCNO = edtBarCode.Text.Trim(),
                                    };

                                tradeGetPSI.Do();
                                if (tradeGetPSI.Error.ErrCode != 0)
                                {
                                    throw new Exception(tradeGetPSI.Error.ErrText);
                                }

                                using (dlgQIComponent component = new dlgQIComponent())
                                {
                                    component.DMC = tradeGetPSI.Request.DMCNO;
                                    component.SourceInfo = tradeGetPSI.Response.Output.ProductionLine;
                                    component.ComponentType = trade.Response.Output.ComponentType;
                                    component.Log = lvLogs;

                                    component.ShowDialog();
                                }
                                break;
                            case "Batch":
                                using (dlgQIContainer container = new dlgQIContainer())
                                {
                                    container.ContainerNo = trade.Request.BarCode;
                                    container.Log = lvLogs;

                                    container.ShowDialog();
                                }
                                break;
                            default:
                                lvLogs.WriteLog(
                                    -1,
                                    $"为止的部件类型[{trade.Response.Output.ComponentType}]",
                                    DateTime.Now);
                                break;
                        }
                    }
                    else
                    {
                        lvLogs.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                    }
                }
                catch (Exception error)
                {
                    lvLogs.WriteLog(-1, error.Message, DateTime.Now);
                }
                finally
                {
                    edtBarCode.Text = "";
                    edtBarCode.Focus();
                }
            }
        }
    }
}
