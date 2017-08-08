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
            this.SuspendLayout();
            // 
            // lbxExcludeList
            // 
            this.lbxExcludeList.FormattingEnabled = true;
            this.lbxExcludeList.Location = new System.Drawing.Point(12, 12);
            this.lbxExcludeList.Name = "lbxExcludeList";
            this.lbxExcludeList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxExcludeList.Size = new System.Drawing.Size(120, 264);
            this.lbxExcludeList.TabIndex = 0;
            // 
            // tbExcludeItem
            // 
            this.tbExcludeItem.Location = new System.Drawing.Point(137, 31);
            this.tbExcludeItem.MaxLength = 6;
            this.tbExcludeItem.Name = "tbExcludeItem";
            this.tbExcludeItem.Size = new System.Drawing.Size(100, 20);
            this.tbExcludeItem.TabIndex = 1;
            // 
            // btnAddlbx
            // 
            this.btnAddlbx.Location = new System.Drawing.Point(137, 57);
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
            this.label1.Location = new System.Drawing.Point(138, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add .file type (i.e. .psd)";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(216, 256);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(137, 146);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 39);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove Selected Items";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 291);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddlbx);
            this.Controls.Add(this.tbExcludeItem);
            this.Controls.Add(this.lbxExcludeList);
            this.Name = "Form2";
            this.Text = "Exclude List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxExcludeList;
        private System.Windows.Forms.TextBox tbExcludeItem;
        private System.Windows.Forms.Button btnAddlbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnRemove;
    }
}