using System;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ArbInject
{
    public partial class frmMain : Form
    {
        #region Init
        public Log log;
        public frmMain()
        {
            InitializeComponent();
            log = new Log(rtbLog);
        }
        #endregion

        #region Events
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (IsAdministrator() == false || Environment.Is64BitOperatingSystem == false)
            {
                MessageBox.Show("You either do not have elevated priveleges to run ArbInject, or you are not running a 64 bit OS.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            cbMethod.SelectedIndex = 0;
        }
        private void cmdProcess_Click(object sender, EventArgs e)
        {
            frmProcess process = new frmProcess(txtProcessName, txtProcessPID);
            process.ShowDialog();
            if (!String.IsNullOrWhiteSpace(txtProcessName.Text))
            {
                string path = Injector.GetExecutablePath(Process.GetProcessById(int.Parse(txtProcessPID.Text)));
                pbIcon.Image = Icon.ExtractAssociatedIcon(path).ToBitmap();
                txtProcessArchitecture.Text = GetProcessArchitecture(path);
            }
        }
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a DLL to Inject";
            ofd.Filter = "DLL Files|*.dll";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDllPath.Text = ofd.FileName;
                txtDllArchitecture.Text = GetDllArchitecture(ofd.FileName);
                txtDllManaged.Text = IsDllManaged(ofd.FileName).ToString();
            }
        }
        private void cmdExecute_Click(object sender, EventArgs e)
        {
            string[] logMessage;
            int[] logType;

            if (CheckMatchingArchitectures(txtDllArchitecture, txtProcessArchitecture) == false)
            {
                ErrorMessage("The DLL you are injecting must have the same architecture as the process.");
                return;
            }

            if (txtDllManaged.Text == "True")
            {
                ErrorMessage("Injecting managed binaries are unsupported at this release.");
                return;
            }

            log.Write(string.Format(Environment.NewLine + "Process Started ({0} | {1} => {2})", 
                    cbMethod.SelectedItem.ToString(), Path.GetFileName(txtDllPath.Text), txtProcessPID.Text));

            bool result = Injector.Inject((uint)int.Parse(txtProcessPID.Text), txtDllPath.Text, out logMessage, out logType);

            if (result)
                MessageBox.Show(string.Format("{0} has successfully been injected into {1}", Path.GetFileName(txtDllPath.Text), txtProcessName.Text), "Injection Successful", MessageBoxButtons.OK);
            else
                MessageBox.Show(string.Format("{0} has not been injected into {1}", Path.GetFileName(txtDllPath.Text), txtProcessName.Text), "Injection Unsuccessful", MessageBoxButtons.OK);

            for (int i = 0; i < logMessage.Length; i++)
            {
                if(!String.IsNullOrWhiteSpace(logMessage[i]))
                    log.Write(logMessage[i], logType[i]);
            }

            log.Write(string.Format("Process Ended ({0})" + Environment.NewLine, result));
        }
        private void txtDllArchitecture_TextChanged(object sender, EventArgs e)
        {
            CheckMatchingArchitectures(txtDllArchitecture, txtProcessArchitecture);
        }
        private void txtProcessArchitecture_TextChanged(object sender, EventArgs e)
        {
            CheckMatchingArchitectures(txtDllArchitecture, txtProcessArchitecture);
        }
        private void txtDllManaged_TextChanged(object sender, EventArgs e)
        {
            txtDllManaged.BackColor = SystemColors.Control;
            if (txtDllManaged.Text == "True")
                txtDllManaged.ForeColor = Color.Red;
            else
                txtDllManaged.ForeColor = Color.Green;
        }
        private void cmdClearLog_Click(object sender, EventArgs e)
        {
            log.Clear();
        }
        private void chkShowLog_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowLog.Checked)
                this.Size = new Size(this.Width, 428);
            else
                this.Size = new Size(this.Width, 303);
        }
        #endregion

        #region Methods
        private static bool IsAdministrator()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }
        private string GetDllArchitecture(string dllPath)
        {
            FileStream fileStream = new FileStream(dllPath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);

            if (binaryReader.ReadUInt16() == 23117)
            {
                fileStream.Position = 60L;
                uint num = binaryReader.ReadUInt32();
                fileStream.Position = (long)((ulong)(num + 4u));
                ushort num2 = binaryReader.ReadUInt16();
                if (num2 == 512 || num2 == 34404)
                    return "x64/64bit";
                if (num2 == 332)
                    return "x86/32bit";
                fileStream.Close();
                binaryReader.Close();
            }
            else
            {
                fileStream.Close();
            }
            binaryReader.Close();

            return "Unable To Retrieve Architecture";
        }
        private bool IsDllManaged(string dllPath)
        {
            uint[] array = new uint[16];
            uint[] array2 = new uint[16];
            Stream stream = new FileStream(dllPath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(stream);
            stream.Position = 60L;
            uint num = binaryReader.ReadUInt32();
            stream.Position = (long)((ulong)num);
            binaryReader.ReadUInt32();
            binaryReader.ReadUInt16();
            binaryReader.ReadUInt16();
            binaryReader.ReadUInt32();
            binaryReader.ReadUInt32();
            binaryReader.ReadUInt32();
            binaryReader.ReadUInt16();
            binaryReader.ReadUInt16();
            ushort num2 = Convert.ToUInt16((int)(Convert.ToUInt16(stream.Position) + 96));
            stream.Position = (long)((ulong)num2);
            int num3 = 0;
            do
            {
                array[num3] = binaryReader.ReadUInt32();
                array2[num3] = binaryReader.ReadUInt32();
                num3++;
            }
            while (num3 < 15);
            stream.Close();
            return array[14] != 0u;
        }
        private string GetProcessArchitecture(string processPath)
        {
            FileStream fileStream = new FileStream(processPath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            ushort num2 = binaryReader.ReadUInt16();
            if (num2 == 23117)
            {
                fileStream.Position = 60L;
                uint num3 = binaryReader.ReadUInt32();
                fileStream.Position = (long)((ulong)(num3 + 4u));
                ushort num4 = binaryReader.ReadUInt16();
                if (num4 == 512 || num4 == 34404)
                    return "x64/64bit";
                if (num4 == 332)
                    return "x86/32bit";
                return "Unable To Retrieve Architecture";
            }
            else
                return "Unable To Retrieve Architecture";
        }
        private static bool CheckMatchingArchitectures(TextBox textBox1, TextBox textBox2)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox1.BackColor = SystemColors.Control;
                textBox2.BackColor = SystemColors.Control;
                if (textBox1.Text == textBox2.Text)
                {
                    textBox1.ForeColor = Color.Green;
                    textBox2.ForeColor = Color.Green;
                    return true;
                }
                else
                {
                    textBox1.ForeColor = Color.Red;
                    textBox2.ForeColor = Color.Red;
                    return false;
                }
            }
            return false;
        }
        private static void ErrorMessage(string text)
        {
            MessageBox.Show("Error", text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}