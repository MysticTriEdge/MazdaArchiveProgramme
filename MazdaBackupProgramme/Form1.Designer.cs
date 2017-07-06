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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNow = new System.Windows.Forms.Label();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.btnRunManual = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Programme Will Run At:";
            // 
            // lblNow
            // 
            this.lblNow.AutoSize = true;
            this.lblNow.Location = new System.Drawing.Point(185, 58);
            this.lblNow.Name = "lblNow";
            this.lblNow.Size = new System.Drawing.Size(49, 13);
            this.lblNow.TabIndex = 2;
            this.lblNow.Text = "00:00:00";
            // 
            // lblRunTime
            // 
            this.lblRunTime.AutoSize = true;
            this.lblRunTime.Location = new System.Drawing.Point(185, 100);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(49, 13);
            this.lblRunTime.TabIndex = 3;
            this.lblRunTime.Text = "99:99:99";
            // 
            // btnRunManual
            // 
            this.btnRunManual.Location = new System.Drawing.Point(344, 267);
            this.btnRunManual.Name = "btnRunManual";
            this.btnRunManual.Size = new System.Drawing.Size(75, 23);
            this.btnRunManual.TabIndex = 4;
            this.btnRunManual.Text = "Manual Run";
            this.btnRunManual.UseVisualStyleBackColor = true;
            this.btnRunManual.Click += new System.EventHandler(this.btnRunManual_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info; //Shows the info icon so the user doesn't thing there is an error.
            this.notifyIcon1.BalloonTipText = "Timer Will continue to run";
            this.notifyIcon1.BalloonTipTitle = "Mazda Backup Programme Minimized";
            this.notifyIcon1.Text = "Mazda Backup Programme";
            this.notifyIcon1.Icon = Properties.Resources.Tray;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 350);
            this.Controls.Add(this.btnRunManual);
            this.Controls.Add(this.lblRunTime);
            this.Controls.Add(this.lblNow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mazda Backup Programme";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.Button btnRunManual;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

