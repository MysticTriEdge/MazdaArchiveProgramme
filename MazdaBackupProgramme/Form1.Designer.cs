namespace MazdaBackupProgramme
{
    partial class Form1
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
            this.btnRunManual = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cbxInteriorImages = new System.Windows.Forms.CheckBox();
            this.cbxExteriorImages = new System.Windows.Forms.CheckBox();
            this.btnImageArchive = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnklblExclude = new System.Windows.Forms.LinkLabel();
            this.btnSelectCustomFolder = new System.Windows.Forms.Button();
            this.tbCustomFolderPath = new System.Windows.Forms.TextBox();
            this.cbxCustomFolder = new System.Windows.Forms.CheckBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRunManual
            // 
            this.btnRunManual.Location = new System.Drawing.Point(6, 19);
            this.btnRunManual.Name = "btnRunManual";
            this.btnRunManual.Size = new System.Drawing.Size(125, 23);
            this.btnRunManual.TabIndex = 4;
            this.btnRunManual.Text = "Run DigiStore Archive";
            this.btnRunManual.UseVisualStyleBackColor = true;
            this.btnRunManual.Click += new System.EventHandler(this.btnRunManual_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Timer Will continue to run";
            this.notifyIcon1.BalloonTipTitle = "Mazda Backup Programme Minimized";
            this.notifyIcon1.Icon = global::MazdaBackupProgramme.Properties.Resources.Tray;
            this.notifyIcon1.Text = "Mazda Backup Programme";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // cbxInteriorImages
            // 
            this.cbxInteriorImages.AutoSize = true;
            this.cbxInteriorImages.Location = new System.Drawing.Point(6, 28);
            this.cbxInteriorImages.Name = "cbxInteriorImages";
            this.cbxInteriorImages.Size = new System.Drawing.Size(257, 17);
            this.cbxInteriorImages.TabIndex = 5;
            this.cbxInteriorImages.Text = "Interior Images Folder (excludes .psd\'s and aep\'s)";
            this.cbxInteriorImages.UseVisualStyleBackColor = true;
            // 
            // cbxExteriorImages
            // 
            this.cbxExteriorImages.AutoSize = true;
            this.cbxExteriorImages.Location = new System.Drawing.Point(6, 51);
            this.cbxExteriorImages.Name = "cbxExteriorImages";
            this.cbxExteriorImages.Size = new System.Drawing.Size(263, 17);
            this.cbxExteriorImages.TabIndex = 6;
            this.cbxExteriorImages.Text = "Exterior Images Folder (excludes .psd\'s and .aep\'s)";
            this.cbxExteriorImages.UseVisualStyleBackColor = true;
            // 
            // btnImageArchive
            // 
            this.btnImageArchive.Location = new System.Drawing.Point(295, 19);
            this.btnImageArchive.Name = "btnImageArchive";
            this.btnImageArchive.Size = new System.Drawing.Size(139, 23);
            this.btnImageArchive.TabIndex = 7;
            this.btnImageArchive.Text = "Run Image Folder Archive";
            this.btnImageArchive.UseVisualStyleBackColor = true;
            this.btnImageArchive.Click += new System.EventHandler(this.btnImageArchive_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnRunManual);
            this.groupBox1.Location = new System.Drawing.Point(34, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 113);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DigiStore Archive";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 76);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(429, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnklblExclude);
            this.groupBox2.Controls.Add(this.btnSelectCustomFolder);
            this.groupBox2.Controls.Add(this.tbCustomFolderPath);
            this.groupBox2.Controls.Add(this.cbxCustomFolder);
            this.groupBox2.Controls.Add(this.progressBar2);
            this.groupBox2.Controls.Add(this.btnImageArchive);
            this.groupBox2.Controls.Add(this.cbxExteriorImages);
            this.groupBox2.Controls.Add(this.cbxInteriorImages);
            this.groupBox2.Location = new System.Drawing.Point(34, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 169);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HTML Folder Archive";
            // 
            // lnklblExclude
            // 
            this.lnklblExclude.AutoSize = true;
            this.lnklblExclude.Location = new System.Drawing.Point(310, 79);
            this.lnklblExclude.Name = "lnklblExclude";
            this.lnklblExclude.Size = new System.Drawing.Size(124, 13);
            this.lnklblExclude.TabIndex = 12;
            this.lnklblExclude.TabStop = true;
            this.lnklblExclude.Text = "Exclude certain file types";
            this.lnklblExclude.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblExclude_LinkClicked);
            // 
            // btnSelectCustomFolder
            // 
            this.btnSelectCustomFolder.Enabled = false;
            this.btnSelectCustomFolder.Location = new System.Drawing.Point(324, 96);
            this.btnSelectCustomFolder.Name = "btnSelectCustomFolder";
            this.btnSelectCustomFolder.Size = new System.Drawing.Size(94, 23);
            this.btnSelectCustomFolder.TabIndex = 11;
            this.btnSelectCustomFolder.Text = "Select Folder";
            this.btnSelectCustomFolder.UseVisualStyleBackColor = true;
            this.btnSelectCustomFolder.Click += new System.EventHandler(this.btnSelectCustomFolder_Click);
            // 
            // tbCustomFolderPath
            // 
            this.tbCustomFolderPath.Enabled = false;
            this.tbCustomFolderPath.Location = new System.Drawing.Point(6, 98);
            this.tbCustomFolderPath.Name = "tbCustomFolderPath";
            this.tbCustomFolderPath.Size = new System.Drawing.Size(309, 20);
            this.tbCustomFolderPath.TabIndex = 10;
            // 
            // cbxCustomFolder
            // 
            this.cbxCustomFolder.AutoSize = true;
            this.cbxCustomFolder.Location = new System.Drawing.Point(7, 75);
            this.cbxCustomFolder.Name = "cbxCustomFolder";
            this.cbxCustomFolder.Size = new System.Drawing.Size(93, 17);
            this.cbxCustomFolder.TabIndex = 9;
            this.cbxCustomFolder.Text = "Custom Folder";
            this.cbxCustomFolder.UseVisualStyleBackColor = true;
            this.cbxCustomFolder.CheckedChanged += new System.EventHandler(this.cbxCustomFolder_CheckedChanged);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(6, 140);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(429, 23);
            this.progressBar2.TabIndex = 8;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 350);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mazda Archive Programme";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRunManual;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox cbxInteriorImages;
        private System.Windows.Forms.CheckBox cbxExteriorImages;
        private System.Windows.Forms.Button btnImageArchive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.CheckBox cbxCustomFolder;
        private System.Windows.Forms.Button btnSelectCustomFolder;
        private System.Windows.Forms.TextBox tbCustomFolderPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel lnklblExclude;
    }
}

