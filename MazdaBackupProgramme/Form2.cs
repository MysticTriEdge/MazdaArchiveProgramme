using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MazdaBackupProgramme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (Exclusions.fileexcludes.Count > 0)
            {
                foreach (FileInfo l in Exclusions.fileexcludes)
                {
                    lbxExcludeFile.Items.Add(l.Name);
                    Exclusions.fileexcludes = null;
                }
                

            }
            if (Exclusions.excludes.Count > 0)
            {
                foreach(string l in Exclusions.excludes)
                {
                    lbxExcludeList.Items.Add(l);
                    Exclusions.excludes = null;
                }
               
            }

        }

        

        private void btnAddlbx_Click(object sender, EventArgs e)
        {
            if (tbExcludeItem.Text.Length > 2 && tbExcludeItem.Text.Contains("."))
            {
                //addItem Function
                addItemToList(tbExcludeItem.Text.ToLower().ToString());
            }
            else if (!tbExcludeItem.Text.Contains("."))
            {
                MessageBox.Show("Text does not include the . for a file extension", "Error", MessageBoxButtons.OK);
            }
            else if (tbExcludeItem.Text.Length <= 2)
            {
                MessageBox.Show("File extension seems too short", "Error", MessageBoxButtons.OK);
            }
        }

        public void addItemToList(string addItem)
        {
            if (!lbxExcludeList.Items.Contains(addItem))
            {
                lbxExcludeList.Items.Add(addItem);
                tbExcludeItem.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("List already contains that item", "Error", MessageBoxButtons.OK);
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = lbxExcludeList.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lbxExcludeList.Items.RemoveAt(lbxExcludeList.SelectedIndices[i]);
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            
            if (lbxExcludeList.Items.Count > 0)
            { 
            foreach (string item in lbxExcludeList.Items)
            {
                Exclusions.excludes.Add(item);
            }
            }
            this.Hide();



        }

        private void btnAddExcludeFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true

               
                               
                foreach(string addfile in arrAllFiles)
                {
                    FileInfo fi = new FileInfo(addfile);
                    lbxExcludeFile.Items.Add(fi.Name);
                    Exclusions.fileexcludes.Add(fi);
                    
                }

            }


        }

        private void btnRmvExcludeFile_Click(object sender, EventArgs e)
        {
            for (int i = lbxExcludeFile.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lbxExcludeFile.Items.RemoveAt(lbxExcludeFile.SelectedIndices[i]);
            }
        }
    }
}
