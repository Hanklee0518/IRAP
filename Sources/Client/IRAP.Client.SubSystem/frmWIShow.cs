using IRAP.Client.SubSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IRAP.Client.SubSystem
{
    public partial class frmWIShow : Form
    {
        WIScreen _screen = null;

        public frmWIShow()
        {
            InitializeComponent();

            ShowInTaskbar = false;

            if (Screen.AllScreens.Length != 1)
            {

            }
        }
        internal frmWIShow(WIScreen screen) : this()
        {
            _screen = screen;
        }

        private void ShowOnMonitor()
        {
            DesktopBounds = _screen.Bounds;
            WindowState = FormWindowState.Maximized;
        }

        private void frmWIShow_Load(object sender, EventArgs e)
        {
            ShowOnMonitor();
        }
    }

    internal class WIScreen
    {
        public WIScreen()
        {
            Detected = false;
        }

        public int ScreenIndex { get; set; }
        public string DeviceName { get; set; }
        public long SysLogID { get; set; }
        /// <summary>
        ///  看板屏幕是否检测到
        /// </summary>
        public bool Detected { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool Show { get; set; }
        public Rectangle Bounds { get; set; }

        public override string ToString()
        {
            return DeviceName;
        }

        public static WIScreen CreateInstance()
        {
            if (Screen.AllScreens.Length <= 1)
            {
                return null;
            }

            WIScreen rlt = new WIScreen()
            {
                ScreenIndex = 1,
                Detected = true,
                Bounds = Screen.AllScreens[1].Bounds,
            };

            return rlt;
        }
    }

    public class WIShow
    {
        private static WIShow _instance = null;
        private frmWIShow showWI = null;

        public static WIShow Instance
        {
            get
            {
                if (_instance== null)
                {
                    _instance = new WIShow();
                }
                return _instance;
            }
        }

        private WIShow() { }

        public void ShowWI(int T102LeafID, int T107LeafID)
        {
            if (Screen.AllScreens.Length >= 2)
            {
                if (showWI == null)
                {
                    showWI = new frmWIShow(WIScreen.CreateInstance());
                }

                showWI.DesktopBounds = Screen.AllScreens[1].Bounds;
                showWI.Show();
            }
        }

        public void HideWI()
        {
            if (showWI != null)
            {
                showWI.Hide();
            }
        }
    }
}
