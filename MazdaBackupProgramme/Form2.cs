using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazdaBackupProgramme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        List<string> excludes = new List<string>();

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
            

            foreach (string item in lbxExcludeList.Items)
            {
                excludes.Add(item);
            }
        }
    }
}
