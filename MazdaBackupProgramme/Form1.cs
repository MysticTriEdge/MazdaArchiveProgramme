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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = (1000) * (1);
            timer1.Start();
            
        }

        private void btnRunManual_Click(object sender, EventArgs e)
        {
            int hourNow = DateTime.Now.Hour;

            int minNow = DateTime.Now.Minute;

            runBackup();
        }


        public void runBackup()
        {
            int dayFrom = DateTime.Now.Day;
            int monthFrom = DateTime.Now.Month - 3;
            int yearFrom = DateTime.Now.Year;

            string stagingFolder = @"C:\Users\grimwoodb\Desktop\Test Folder";
            string archiveFolder = @"C:\Users\grimwoodb\Desktop\Test Folder 2";

            List<string> movedFolders = new List<string>();

            foreach (var dirflder in Directory.GetDirectories(stagingFolder))
            {
                string dirflderName = dirflder.Remove(0, stagingFolder.Length);

                foreach (var flder in Directory.GetDirectories(stagingFolder + dirflderName))
                {
                    var fldName = new DirectoryInfo(flder).Name;
                    int fldMonth = Convert.ToInt32(fldName.Substring(3, 2));
                    int fldYear = Convert.ToInt32(fldName.Substring(6, 4));


                    if (fldMonth <= monthFrom && fldYear == yearFrom)
                    {
                        movedFolders.Add(flder);
                        if (!Directory.Exists(archiveFolder + dirflderName + "\\" + fldName))
                        {
                            Directory.CreateDirectory(archiveFolder + dirflderName);
                            Directory.Move(flder, archiveFolder + dirflderName + "\\" + fldName);
                        }
                        else if (!Directory.Exists(archiveFolder + dirflderName + "\\" + fldName))
                        {
                            Directory.Move(flder, archiveFolder + dirflderName + "\\" + fldName + "\\" + "Copy");
                        }
                    }
                    else if (fldYear < yearFrom)
                    {
                        movedFolders.Add(flder);
                        if (!Directory.Exists(archiveFolder + dirflderName + "\\" + fldName))
                        {
                            Directory.CreateDirectory(archiveFolder + dirflderName);
                            Directory.Move(flder, archiveFolder + dirflderName + "\\" + fldName);
                        }
                        else if (!Directory.Exists(archiveFolder + dirflderName + "\\" + fldName))
                        {
                            Directory.Move(flder, archiveFolder + dirflderName + "\\" + fldName + "\\" + "Copy");
                        }
                    }

                }

            }

            string logfilePath = @"C:\Users\grimwoodb\Desktop\Test Folder 2\archieved.txt";
            movedFolders.Insert(0, DateTime.Now.ToString());

            if (File.Exists(logfilePath))
            {
                
                foreach (string line in movedFolders)
                {
                    TextWriter tsw = new StreamWriter(logfilePath, true);
                    tsw.WriteLine(line);
                    tsw.Close();
                }
                
            }
            else {
                File.WriteAllLines(logfilePath, movedFolders);
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var runTime = "21:00";
            lblRunTime.Text = runTime.ToString();

            int hourNow = DateTime.Now.Hour;

            int minNow = DateTime.Now.Minute;

            string timeNow = hourNow + ":" + minNow;

            lblNow.Text = timeNow;

            if (hourNow == 21 && minNow == 00)
            {
                runBackup();
            }

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }
    }
}
