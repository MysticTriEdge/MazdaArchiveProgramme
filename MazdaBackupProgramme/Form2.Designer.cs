namespace MazdaBackupProgramme
{
    partial class Form2
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
            this.lbxExcludeList = new System.Windows.Forms.ListBox();
            this.tbExcludeItem = new System.Windows.Forms.TextBox();
            this.btnAddlbx = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbxExcludeFile = new System.Windows.Forms.ListBox();
            this.btnAddExcludeFile = new System.Windows.Forms.Button();
            this.btnRmvExcludeFile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxExcludeList
            // 
            this.lbxExcludeList.FormattingEnabled = true;
            this.lbxExcludeList.Location = new System.Drawing.Point(4, 33);
            this.lbxExcludeList.Name = "lbxExcludeList";
            this.lbxExcludeList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxExcludeList.Size = new System.Drawing.Size(120, 264);
            this.lbxExcludeList.TabIndex = 0;
            // 
            // tbExcludeItem
            // 
            this.tbExcludeItem.Location = new System.Drawing.Point(129, 52);
            this.tbExcludeItem.MaxLength = 6;
            this.tbExcludeItem.Name = "tbExcludeItem";
            this.tbExcludeItem.Size = new System.Drawing.Size(100, 20);
            this.tbExcludeItem.TabIndex = 1;
            // 
            // btnAddlbx
            // 
            this.btnAddlbx.Location = new System.Drawing.Point(129, 78);
            this.btnAddlbx.Name = "btnAddlbx";
            this.btnAddlbx.Size = new System.Drawing.Size(75, 23);
            this.btnAddlbx.TabIndex = 2;
            this.btnAddlbx.Text = "Add";
            this.btnAddlbx.UseVisualStyleBackColor = true;
            this.btnAddlbx.Click += new System.EventHandler(this.btnAddlbx_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add .file type (i.e. .psd)";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(473, 352);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(129, 167);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 39);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Selected Items";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddlbx);
            this.groupBox1.Controls.Add(this.tbExcludeItem);
            this.groupBox1.Controls.Add(this.lbxExcludeList);
            this.groupBox1.Location = new System.Drawing.Point(8, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 313);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exclude File Types";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRmvExcludeFile);
            this.groupBox2.Controls.Add(this.btnAddExcludeFile);
            this.groupBox2.Controls.Add(this.lbxExcludeFile);
            this.groupBox2.Location = new System.Drawing.Point(292, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 312);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exclude Files";
            // 
            // lbxExcludeFile
            // 
            this.lbxExcludeFile.FormattingEnabled = true;
            this.lbxExcludeFile.Location = new System.Drawing.Point(11, 32);
            this.lbxExcludeFile.Name = "lbxExcludeFile";
            this.lbxExcludeFile.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxExcludeFile.Size = new System.Drawing.Size(218, 225);
            this.lbxExcludeFile.TabIndex = 0;
            // 
            // btnAddExcludeFile
            // 
            this.btnAddExcludeFile.Location = new System.Drawing.Point(11, 274);
            this.btnAddExcludeFile.Name = "btnAddExcludeFile";
            this.btnAddExcludeFile.Size = new System.Drawing.Size(75, 23);
            this.btnAddExcludeFile.TabIndex = 1;
            this.btnAddExcludeFile.Text = "Add file(s)";
            this.btnAddExcludeFile.UseVisualStyleBackColor = true;
            this.btnAddExcludeFile.Click += new System.EventHandler(this.btnAddExcludeFile_Click);
            // 
            // btnRmvExcludeFile
            // 
            this.btnRmvExcludeFile.Location = new System.Drawing.Point(163, 265);
            this.btnRmvExcludeFile.Name = "btnRmvExcludeFile";
            this.btnRmvExcludeFile.Size = new System.Drawing.Size(87, 41);
            this.btnRmvExcludeFile.TabIndex = 2;
            this.btnRmvExcludeFile.Text = "Remove Selected File(s)";
            this.btnRmvExcludeFile.UseVisualStyleBackColor = true;
            this.btnRmvExcludeFile.Click += new System.EventHandler(this.btnRmvExcludeFile_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 387);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDone);
            this.Name = "Form2";
            this.Text = "Exclude List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxExcludeList;
        private System.Windows.Forms.TextBox tbExcludeItem;
        private System.Windows.Forms.Button btnAddlbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRmvExcludeFile;
        private System.Windows.Forms.Button btnAddExcludeFile;
        private System.Windows.Forms.ListBox lbxExcludeFile;
    }
}