using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

using Softland.Tools.Print;

namespace USBPrintDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                comboBox1.Items.Add(PrinterSettings.InstalledPrinters[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("未选择打印机或未安装打印机");
                return;
            }

            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("没有需要打印的内容");
                return;
            }

            ZebraPrintHelper.PrintWithDRV(
                textBox1.Text.Trim(),
                (string)comboBox1.SelectedItem,
                true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
