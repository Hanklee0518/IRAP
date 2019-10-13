using DevExpress.XtraEditors;
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
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.MESPDC.HME
{
    public partial class dlgQIContainer : IRAP.Client.Global.frmCustomBase
    {
        private string className = MethodBase.GetCurrentMethod().DeclaringType.FullName;
        private xucIRAPListView _log = null;

        public dlgQIContainer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 容器码
        /// </summary>
        public string ContainerNo
        {
            get { return lblContainerNo.Text; }
            set { lblContainerNo.Text = value; }
        }
        public xucIRAPListView Log
        {
            set { _log = value; }
        }

        private void edtGoodQuantity_Validating(object sender, CancelEventArgs e)
        {
            TextEdit edit = sender as TextEdit;
            if (edit != null)
            {
                if (edit.Text != "")
                {
                    if (Tools.IsNumberic(edit.Text))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            "只能输入数字哦",
                            "提示",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                else
                {
                    edit.Text = "0";
                    e.Cancel = false;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string strProcedureName =
                $"{className}.{MethodBase.GetCurrentMethod().Name}";

            MR_QC_BatchInfoSave trade =
                new MR_QC_BatchInfoSave(
                    IRAPConst.Instance.WebAPI.URL,
                    IRAPConst.Instance.WebAPI.ContentType,
                    IRAPConst.Instance.WebAPI.ClientID);
            trade.Request =
                new MRQCBatchInfoSaveRequest()
                {
                    CommunityID = IRAPUser.Instance.CommunityID,
                    SysLogID = IRAPUser.Instance.SysLogID,
                    NO = ContainerNo,
                    GoodQty = Tools.ConvertToInt32(edtGoodQuantity.Text),
                    NGQty = Tools.ConvertToInt32(edtNGQuantity.Text),
                };
            try
            {
                trade.Do();
                if (_log != null)
                {
                    _log.WriteLog(trade.Error.ErrCode, trade.Error.ErrText, DateTime.Now);
                }

                Close();
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                WriteLog.Instance.Write(error.StackTrace, strProcedureName);

                XtraMessageBox.Show(
                    error.Message,
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
