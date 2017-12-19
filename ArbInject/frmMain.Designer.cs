namespace ArbInject
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblDllPath = new System.Windows.Forms.Label();
            this.txtDllPath = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.cbMethod = new System.Windows.Forms.ComboBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.cmdProcess = new System.Windows.Forms.Button();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.gbDLL = new System.Windows.Forms.GroupBox();
            this.txtDllManaged = new System.Windows.Forms.TextBox();
            this.lblDllManaged = new System.Windows.Forms.Label();
            this.txtDllArchitecture = new System.Windows.Forms.TextBox();
            this.lblDllArchitecture = new System.Windows.Forms.Label();
            this.gbProcess = new System.Windows.Forms.GroupBox();
            this.lblProcessIcon = new System.Windows.Forms.Label();
            this.txtProcessArchitecture = new System.Windows.Forms.TextBox();
            this.lblProcessArchitecture = new System.Windows.Forms.Label();
            this.cmdClearLog = new System.Windows.Forms.Button();
            this.lblCredits = new System.Windows.Forms.Label();
            this.chkShowLog = new System.Windows.Forms.CheckBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.lblPID = new System.Windows.Forms.Label();
            this.txtProcessPID = new System.Windows.Forms.TextBox();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.gbDLL.SuspendLayout();
            this.gbProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDllPath
            // 
            this.lblDllPath.AutoSize = true;
            this.lblDllPath.Location = new System.Drawing.Point(6, 22);
            this.lblDllPath.Name = "lblDllPath";
            this.lblDllPath.Size = new System.Drawing.Size(32, 13);
            this.lblDllPath.TabIndex = 0;
            this.lblDllPath.Text = "Path:";
            // 
            // txtDllPath
            // 
            this.txtDllPath.Location = new System.Drawing.Point(44, 19);
            this.txtDllPath.Name = "txtDllPath";
            this.txtDllPath.ReadOnly = true;
            this.txtDllPath.Size = new System.Drawing.Size(247, 20);
            this.txtDllPath.TabIndex = 1;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(297, 17);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(57, 23);
            this.cmdBrowse.TabIndex = 2;
            this.cmdBrowse.Text = "Browse";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lblMethod);
            this.gbSettings.Controls.Add(this.cbMethod);
            this.gbSettings.Location = new System.Drawing.Point(15, 176);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(360, 52);
            this.gbSettings.TabIndex = 5;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(6, 22);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(89, 13);
            this.lblMethod.TabIndex = 6;
            this.lblMethod.Text = "Injection Method:";
            // 
            // cbMethod
            // 
            this.cbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMethod.FormattingEnabled = true;
            this.cbMethod.Items.AddRange(new object[] {
            "CreateRemoteThread",
            "NtCreateThreadEx (Not Yet Implemented)",
            "QueueUserAPC (Not Yet Implemented)"});
            this.cbMethod.Location = new System.Drawing.Point(101, 19);
            this.cbMethod.Name = "cbMethod";
            this.cbMethod.Size = new System.Drawing.Size(253, 21);
            this.cbMethod.TabIndex = 6;
            // 
            // pbIcon
            // 
            this.pbIcon.ErrorImage = null;
            this.pbIcon.InitialImage = null;
            this.pbIcon.Location = new System.Drawing.Point(333, 46);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(21, 21);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 6;
            this.pbIcon.TabStop = false;
            // 
            // cmdProcess
            // 
            this.cmdProcess.Location = new System.Drawing.Point(301, 18);
            this.cmdProcess.Name = "cmdProcess";
            this.cmdProcess.Size = new System.Drawing.Size(53, 23);
            this.cmdProcess.TabIndex = 7;
            this.cmdProcess.Text = "Browse";
            this.cmdProcess.UseVisualStyleBackColor = true;
            this.cmdProcess.Click += new System.EventHandler(this.cmdProcess_Click);
            // 
            // cmdExecute
            // 
            this.cmdExecute.Location = new System.Drawing.Point(15, 234);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(75, 23);
            this.cmdExecute.TabIndex = 8;
            this.cmdExecute.Text = "Execute";
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // gbDLL
            // 
            this.gbDLL.Controls.Add(this.txtDllManaged);
            this.gbDLL.Controls.Add(this.lblDllManaged);
            this.gbDLL.Controls.Add(this.txtDllArchitecture);
            this.gbDLL.Controls.Add(this.lblDllArchitecture);
            this.gbDLL.Controls.Add(this.lblDllPath);
            this.gbDLL.Controls.Add(this.txtDllPath);
            this.gbDLL.Controls.Add(this.cmdBrowse);
            this.gbDLL.Location = new System.Drawing.Point(15, 12);
            this.gbDLL.Name = "gbDLL";
            this.gbDLL.Size = new System.Drawing.Size(360, 77);
            this.gbDLL.TabIndex = 9;
            this.gbDLL.TabStop = false;
            this.gbDLL.Text = "DLL";
            // 
            // txtDllManaged
            // 
            this.txtDllManaged.Location = new System.Drawing.Point(254, 48);
            this.txtDllManaged.Name = "txtDllManaged";
            this.txtDllManaged.ReadOnly = true;
            this.txtDllManaged.Size = new System.Drawing.Size(100, 20);
            this.txtDllManaged.TabIndex = 3;
            this.txtDllManaged.TextChanged += new System.EventHandler(this.txtDllManaged_TextChanged);
            // 
            // lblDllManaged
            // 
            this.lblDllManaged.AutoSize = true;
            this.lblDllManaged.Location = new System.Drawing.Point(190, 51);
            this.lblDllManaged.Name = "lblDllManaged";
            this.lblDllManaged.Size = new System.Drawing.Size(55, 13);
            this.lblDllManaged.TabIndex = 2;
            this.lblDllManaged.Text = "Managed:";
            // 
            // txtDllArchitecture
            // 
            this.txtDllArchitecture.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDllArchitecture.Location = new System.Drawing.Point(79, 48);
            this.txtDllArchitecture.Name = "txtDllArchitecture";
            this.txtDllArchitecture.ReadOnly = true;
            this.txtDllArchitecture.Size = new System.Drawing.Size(100, 20);
            this.txtDllArchitecture.TabIndex = 1;
            this.txtDllArchitecture.TextChanged += new System.EventHandler(this.txtDllArchitecture_TextChanged);
            // 
            // lblDllArchitecture
            // 
            this.lblDllArchitecture.AutoSize = true;
            this.lblDllArchitecture.Location = new System.Drawing.Point(6, 51);
            this.lblDllArchitecture.Name = "lblDllArchitecture";
            this.lblDllArchitecture.Size = new System.Drawing.Size(67, 13);
            this.lblDllArchitecture.TabIndex = 0;
            this.lblDllArchitecture.Text = "Architecture:";
            // 
            // gbProcess
            // 
            this.gbProcess.Controls.Add(this.txtProcessPID);
            this.gbProcess.Controls.Add(this.lblPID);
            this.gbProcess.Controls.Add(this.lblName);
            this.gbProcess.Controls.Add(this.lblProcessIcon);
            this.gbProcess.Controls.Add(this.txtProcessName);
            this.gbProcess.Controls.Add(this.txtProcessArchitecture);
            this.gbProcess.Controls.Add(this.cmdProcess);
            this.gbProcess.Controls.Add(this.pbIcon);
            this.gbProcess.Controls.Add(this.lblProcessArchitecture);
            this.gbProcess.Location = new System.Drawing.Point(15, 95);
            this.gbProcess.Name = "gbProcess";
            this.gbProcess.Size = new System.Drawing.Size(360, 75);
            this.gbProcess.TabIndex = 10;
            this.gbProcess.TabStop = false;
            this.gbProcess.Text = "Process";
            // 
            // lblProcessIcon
            // 
            this.lblProcessIcon.AutoSize = true;
            this.lblProcessIcon.Location = new System.Drawing.Point(300, 49);
            this.lblProcessIcon.Name = "lblProcessIcon";
            this.lblProcessIcon.Size = new System.Drawing.Size(31, 13);
            this.lblProcessIcon.TabIndex = 8;
            this.lblProcessIcon.Text = "Icon:";
            // 
            // txtProcessArchitecture
            // 
            this.txtProcessArchitecture.Location = new System.Drawing.Point(79, 46);
            this.txtProcessArchitecture.Name = "txtProcessArchitecture";
            this.txtProcessArchitecture.ReadOnly = true;
            this.txtProcessArchitecture.Size = new System.Drawing.Size(216, 20);
            this.txtProcessArchitecture.TabIndex = 1;
            this.txtProcessArchitecture.TextChanged += new System.EventHandler(this.txtProcessArchitecture_TextChanged);
            // 
            // lblProcessArchitecture
            // 
            this.lblProcessArchitecture.AutoSize = true;
            this.lblProcessArchitecture.Location = new System.Drawing.Point(6, 49);
            this.lblProcessArchitecture.Name = "lblProcessArchitecture";
            this.lblProcessArchitecture.Size = new System.Drawing.Size(67, 13);
            this.lblProcessArchitecture.TabIndex = 0;
            this.lblProcessArchitecture.Text = "Architecture:";
            // 
            // cmdClearLog
            // 
            this.cmdClearLog.Location = new System.Drawing.Point(290, 277);
            this.cmdClearLog.Name = "cmdClearLog";
            this.cmdClearLog.Size = new System.Drawing.Size(53, 23);
            this.cmdClearLog.TabIndex = 12;
            this.cmdClearLog.Text = "Clear";
            this.cmdClearLog.UseVisualStyleBackColor = true;
            this.cmdClearLog.Click += new System.EventHandler(this.cmdClearLog_Click);
            // 
            // lblCredits
            // 
            this.lblCredits.AutoSize = true;
            this.lblCredits.Location = new System.Drawing.Point(113, 239);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.Size = new System.Drawing.Size(167, 13);
            this.lblCredits.TabIndex = 4;
            // 
            // chkShowLog
            // 
            this.chkShowLog.AutoSize = true;
            this.chkShowLog.Location = new System.Drawing.Point(301, 238);
            this.chkShowLog.Name = "chkShowLog";
            this.chkShowLog.Size = new System.Drawing.Size(74, 17);
            this.chkShowLog.TabIndex = 13;
            this.chkShowLog.Text = "Show Log";
            this.chkShowLog.UseVisualStyleBackColor = true;
            this.chkShowLog.CheckedChanged += new System.EventHandler(this.chkShowLog_CheckedChanged);
            // 
            // rtbLog
            // 
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbLog.Location = new System.Drawing.Point(15, 264);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbLog.Size = new System.Drawing.Size(360, 113);
            this.rtbLog.TabIndex = 14;
            this.rtbLog.Text = "Log:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name:";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(50, 19);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.ReadOnly = true;
            this.txtProcessName.Size = new System.Drawing.Size(121, 20);
            this.txtProcessName.TabIndex = 5;
            // 
            // lblPID
            // 
            this.lblPID.AutoSize = true;
            this.lblPID.Location = new System.Drawing.Point(177, 22);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(28, 13);
            this.lblPID.TabIndex = 9;
            this.lblPID.Text = "PID:";
            // 
            // txtProcessPID
            // 
            this.txtProcessPID.Location = new System.Drawing.Point(211, 19);
            this.txtProcessPID.Name = "txtProcessPID";
            this.txtProcessPID.ReadOnly = true;
            this.txtProcessPID.Size = new System.Drawing.Size(84, 20);
            this.txtProcessPID.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 264);
            this.Controls.Add(this.chkShowLog);
            this.Controls.Add(this.lblCredits);
            this.Controls.Add(this.cmdClearLog);
            this.Controls.Add(this.gbProcess);
            this.Controls.Add(this.gbDLL);
            this.Controls.Add(this.cmdExecute);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.rtbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "ArbInject";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.gbDLL.ResumeLayout(false);
            this.gbDLL.PerformLayout();
            this.gbProcess.ResumeLayout(false);
            this.gbProcess.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDllPath;
        private System.Windows.Forms.TextBox txtDllPath;
        private System.Windows.Forms.Button cmdBrowse;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox cbMethod;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Button cmdProcess;
        private System.Windows.Forms.Button cmdExecute;
        private System.Windows.Forms.GroupBox gbDLL;
        private System.Windows.Forms.TextBox txtDllManaged;
        private System.Windows.Forms.Label lblDllManaged;
        private System.Windows.Forms.TextBox txtDllArchitecture;
        private System.Windows.Forms.Label lblDllArchitecture;
        private System.Windows.Forms.GroupBox gbProcess;
        private System.Windows.Forms.TextBox txtProcessArchitecture;
        private System.Windows.Forms.Label lblProcessArchitecture;
        private System.Windows.Forms.Label lblProcessIcon;
        private System.Windows.Forms.Button cmdClearLog;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.CheckBox chkShowLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.TextBox txtProcessPID;
        private System.Windows.Forms.Label lblPID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtProcessName;
    }
}

