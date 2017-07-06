﻿using System;
using System.Configuration;

namespace IRAP.Client.Global
{
    public class IRAPConst
    {
        private static IRAPConst _instance = null;

        private IRAPConst() { }

        public static IRAPConst Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPConst();
                return _instance;
            }
        }

        /// <summary>
        /// 当前编程语言标识
        /// </summary>
        public int IRAP_PROGLANGUAGEID { get { return 9; } }

        /// <summary>
        /// 安灯表格的行高
        /// </summary>
        public int ANDON_GRID_ROWHEIGHT { get { return 55; } }

        /// <summary>
        /// UDP 通讯消息接收端口号
        /// </summary>
        public int MESSAGE_LISTEN_PORT { get { return 17001; } }

        /// <summary>
        /// UDP 通讯消息发送端口号
        /// </summary>
        public int MESSAGE_SEND_PORT { get { return 17002; } }

        /// <summary>
        /// 三色告警灯控制盒类型
        /// </summary>
        public string WarningLightCtrlBoxType
        {
            get { return GetString("ControlBoxType"); }
            set { SaveParams("ControlBoxType", value); }
        }

        /// <summary>
        /// ZLAN6042控制盒的 IP 地址
        /// </summary>
        public string Zlan6042IPAddress
        {
            get { return GetString("ZLan6042IPAddr"); }
            set { SaveParams("ZLan6042IPAddr", value); }
        }

        private string GetString(string key)
        {
            string rlt = "";
            if (ConfigurationManager.AppSettings[key] != null)
            {
                rlt = ConfigurationManager.AppSettings[key];
            }
            return rlt;
        }

        private bool GetBoolean(string key)
        {
            bool rlt = false;
            if (ConfigurationManager.AppSettings[key] != null)
            {
                try { rlt = Convert.ToBoolean(ConfigurationManager.AppSettings[key]); }
                catch { rlt = false; }
            }
            return rlt;
        }

        private void SaveParams(string key, string value)
        {
            Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] == null)
                config.AppSettings.Settings.Add(key, value);
            else
                config.AppSettings.Settings[key].Value = value;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
