namespace ArbInject
{
    partial class frmProcess
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
            this.components = new System.ComponentModel.Container();
            this.lstProcesses = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageIcons = new System.Windows.Forms.ImageList(this.components);
            this.cmdSelect = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkWindowOnly = new System.Windows.Forms.CheckBox();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstProcesses
            // 
            this.lstProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chPath,
            this.chPID});
            this.lstProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstProcesses.FullRowSelect = true;
            this.lstProcesses.GridLines = true;
            this.lstProcesses.LargeImageList = this.imageIcons;
            this.lstProcesses.Location = new System.Drawing.Point(0, 0);
            this.lstProcesses.MultiSelect = false;
            this.lstProcesses.Name = "lstProcesses";
            this.lstProcesses.Size = new System.Drawing.Size(377, 208);
            this.lstProcesses.SmallImageList = this.imageIcons;
            this.lstProcesses.StateImageList = this.imageIcons;
            this.lstProcesses.TabIndex = 0;
            this.lstProcesses.UseCompatibleStateImageBehavior = false;
            this.lstProcesses.View = System.Windows.Forms.View.Details;
            this.lstProcesses.SelectedIndexChanged += new System.EventHandler(this.lstProcesses_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 117;
            // 
            // chPath
            // 
            this.chPath.Text = "Path";
            this.chPath.Width = 177;
            // 
            // chPID
            // 
            this.chPID.Text = "PID";
            this.chPID.Width = 79;
            // 
            // imageIcons
            // 
            this.imageIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cmdSelect
            // 
            this.cmdSelect.Enabled = false;
            this.cmdSelect.Location = new System.Drawing.Point(93, 218);
            this.cmdSelect.Name = "cmdSelect";
            this.cmdSelect.Size = new System.Drawing.Size(191, 23);
            this.cmdSelect.TabIndex = 1;
            this.cmdSelect.Text = "Select";
            this.cmdSelect.UseVisualStyleBackColor = true;
            this.cmdSelect.Click += new System.EventHandler(this.cmdSelect_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(290, 218);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkWindowOnly
            // 
            this.chkWindowOnly.AutoSize = true;
            this.chkWindowOnly.Location = new System.Drawing.Point(12, 247);
            this.chkWindowOnly.Name = "chkWindowOnly";
            this.chkWindowOnly.Size = new System.Drawing.Size(190, 17);
            this.chkWindowOnly.TabIndex = 3;
            this.chkWindowOnly.Text = "List Processes Only With Windows";
            this.chkWindowOnly.UseVisualStyleBackColor = true;
            this.chkWindowOnly.CheckedChanged += new System.EventHandler(this.chkWindowOnly_CheckedChanged);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(12, 218);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 23);
            this.cmdRefresh.TabIndex = 4;
            this.cmdRefresh.Text = "Refresh";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 270);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.chkWindowOnly);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSelect);
            this.Controls.Add(this.lstProcesses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProcess";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Process";
            this.Load += new System.EventHandler(this.frmProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstProcesses;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chPath;
        private System.Windows.Forms.ColumnHeader chPID;
        private System.Windows.Forms.ImageList imageIcons;
        private System.Windows.Forms.Button cmdSelect;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkWindowOnly;
        private System.Windows.Forms.Button cmdRefresh;
    }
}