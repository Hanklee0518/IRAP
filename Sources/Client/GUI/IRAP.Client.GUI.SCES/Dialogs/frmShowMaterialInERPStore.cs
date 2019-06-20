using IRAP.Client.Global;
using IRAP.Client.User;
using IRAP.Entities.RIMCS;
using IRAP.Global;
using IRAP.WCF.Client.Method;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.GUI.SCES.Dialogs
{
    public partial class frmShowMaterialInERPStore : IRAP.Client.Global.frmCustomBase
    {
        public frmShowMaterialInERPStore()
        {
            InitializeComponent();
        }

        public frmShowMaterialInERPStore(
            long tf482PK,
            long factID) : this()
        {
            GetMaterialList(tf482PK, factID);
        }

        private void GetMaterialList(long tf482PK, long factID)
        {
            int errCode = 0;
            string errText = "";
            List<ERPRealTimeMaterialStore> datas = new List<ERPRealTimeMaterialStore>();

            try
            {
                TWaitting.Instance.ShowWaitForm("获取四班实时库存");

                IRAPRIMCSClient.Instance.ufn_GetList_ERPRealTimeMaterialStore(
                    IRAPUser.Instance.CommunityID,
                    tf482PK,
                    factID,
                    IRAPUser.Instance.SysLogID,
                    ref datas,
                    out errCode,
                    out errText);
                if (errCode != 0)
                {
                    IRAPMessageBox.Instance.ShowErrorMessage(errText);
                    grdERPStore.DataSource = null;
                    grdvERPStore.BestFitColumns();
                }
                else
                {
                    grdERPStore.DataSource = datas;
                    grdvERPStore.BestFitColumns();
                }
            }
            finally
            {
                TWaitting.Instance.CloseWaitForm();
            }
        }
    }
}
