using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.Global.GUI.Dialogs
{
    public partial class frmWebBrowser : IRAP.Client.Global.frmCustomBase
    {
        public frmWebBrowser()
        {
            InitializeComponent();
        }

        public void SetUrl(string url)
        {
            webBrowser.Navigate(url);
        }
    }

    /// <summary>
	/// 命名空间：IRAP.Client.Clobal.GUI.Dialogs
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/13, 20:28:24
	/// 类    名：NavigateTo
	/// </summary>	
	public class NavigateTo
    {
        private static NavigateTo _instance = null;
        public static NavigateTo Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NavigateTo();
                }
                return _instance;
            }
        }

        private frmWebBrowser browser = null;

        private NavigateTo()
        {
        }

        public void Show(string caption, string url)
        {
            using (frmWebBrowser browser = new frmWebBrowser())
            {
                browser.Text = caption;
                browser.SetUrl(url);
                browser.ShowDialog();
            }
        }
    }
}
