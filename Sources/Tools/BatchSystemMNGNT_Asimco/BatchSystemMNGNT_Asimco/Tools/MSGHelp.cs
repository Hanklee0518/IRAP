﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraEditors;

namespace IRAP.Global
{
    public class MSGHelp
    {
        private static MSGHelp _instance = null;

        public static MSGHelp Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MSGHelp();
                return _instance;
            }
        }

        private MSGHelp() { }

        public void ShowErrorMessage(Exception error)
        {
            int errCode = -1;
            string errText = "";

            if (error.Data["ErrCode"] != null)
                errCode = (int)error.Data["ErrCode"];
            if (error.Data["ErrText"] != null)
                errText = error.Data["ErrText"].ToString();

            XtraMessageBox.Show(
                string.Format("({0}){1}", errCode, errText),
                "错误信息",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

    }
}
