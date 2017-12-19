using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbInject
{
    public partial class frmProcess : Form
    {
        /*
         * TODO:
         * If windowOnly == true then no Icons are displayed
        */

        #region Init
        public TextBox txtProcessName { get; set; }
        public TextBox txtPID { get; set; }
        public frmProcess(TextBox processName, TextBox pID)
        {
            txtProcessName = processName;
            txtPID = pID;
            InitializeComponent();
            lstProcesses.DoubleBuffering(true);
        }
        private void frmProcess_Load(object sender, EventArgs e)
        {
            RefreshProcesses(chkWindowOnly.Checked);
        }
        #endregion

        #region Methods
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }
        private void RefreshProcesses(bool windowOnly)
        {
            Process[] processes = Process.GetProcesses();
            imageIcons.Images.Clear();
            lstProcesses.Items.Clear();
            for (int i = 0; i < processes.Length; i++)
            {
                if(windowOnly == false || windowOnly == true && processes[i].MainWindowHandle != IntPtr.Zero)
                {
                    try
                    {
                        imageIcons.Images.Add(i.ToString(), Icon.ExtractAssociatedIcon(Injector.GetExecutablePath(processes[i])).ToBitmap());
                    }
                    catch
                    {
                        imageIcons.Images.Add(i.ToString(), new System.Drawing.Bitmap(16, 16));
                    }

                    ListViewItem lvi = new ListViewItem(processes[i].ProcessName, i);
                    lvi.SubItems.Add(Injector.GetExecutablePath(processes[i]));
                    lvi.SubItems.Add(processes[i].Id.ToString());
                    lstProcesses.Items.Add(lvi);
                }
            }
        }
        #endregion

        #region Events
        private void lstProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdSelect.Enabled = true;
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            txtProcessName.Text = lstProcesses.SelectedItems[0].SubItems[0].Text;
            txtPID.Text = lstProcesses.SelectedItems[0].SubItems[2].Text;
            this.Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcesses(chkWindowOnly.Checked);
        }
        private void chkWindowOnly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshProcesses(chkWindowOnly.Checked);
        }
        #endregion
    }

    public static class ControlExtensions
    {
        public static void DoubleBuffering(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }
    }
}