﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraEditors;
using DevExpress.XtraTab;

using IRAP.Global;
using IRAP.Client.User;
using IRAP.Entities.MDM;
using IRAP.WCF.Client.Method;

namespace IRAP.Client.GUI.MESPDC
{
    public partial class frmProductionParamsCollection : IRAP.Client.Global.GUI.frmCustomFuncBase
    {
        private string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private List<WIPStation> stations = new List<WIPStation>();

        public frmProductionParamsCollection()
        {
            InitializeComponent();
        }

        private void GetStations()
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

                stations.Clear();
                IRAPMDMClient.Instance.ufn_GetList_WIPStationsOfAHost(
                    IRAPUser.Instance.CommunityID,
                    IRAPUser.Instance.SysLogID,
                    ref stations,
                    out errCode,
                    out errText);
                WriteLog.Instance.Write(
                    string.Format("({0}){1}", errCode, errText),
                    strProcedureName);
                if (errCode != 0)
                {
                    XtraMessageBox.Show(
                        errText,
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }

        private void frmProductionParamsCollection_Shown(object sender, EventArgs e)
        {
            GetStations();

#if DEBUG
            stations.Add(
                new WIPStation()
                {
                    T107Code = "123456",
                    T107Name = "热定型设备 1",
                    T134LeafID = 5357576,
                });
            stations.Add(
                new WIPStation()
                {
                    T107Code = "123457",
                    T107Name = "热定型设备 2",
                    T134LeafID = 5357576,
                });
#endif

            foreach (WIPStation station in stations)
            {
                XtraTabPage page = new XtraTabPage();
                page.Text =
                    string.Format(
                        "[{0}]{1}",
                        station.T107Code,
                        station.T107Name);

                UserControls.ucBatchSysProduction prdt = new UserControls.ucBatchSysProduction(station);
                prdt.Dock = DockStyle.Fill;

                page.Controls.Add(prdt);

                tcMain.TabPages.Add(page);
            }
        }
    }
}