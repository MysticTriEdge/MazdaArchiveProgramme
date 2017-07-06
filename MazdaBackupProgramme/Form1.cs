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
            //Set timer interval of 1 second and start
            timer1.Interval = (1000) * (1);
            timer1.Start();
            
        }

        private void btnRunManual_Click(object sender, EventArgs e)
        {
            dgiStoreBackup();
        }


        public void dgiStoreBackup()
        {
            //Calculate what 3 months ago would be by subtracting 3 from todays date month
            int monthFrom = DateTime.Now.Month - 3;
            int yearFrom = DateTime.Now.Year;

            //Set directory for the files to come from and where to go
            string stagingFolder = @"C:\Users\grimwoodb\Desktop\Test Folder";
            string archiveFolder = @"C:\Users\grimwoodb\Desktop\Test Folder 2";

            //Create a string which will populate with the backed up folders
            List<string> movedFolders = new List<string>();

            //Check through the top folders(dirflder) in the stagingFolder
            foreach (var dirflder in Directory.GetDirectories(stagingFolder))
            {
                //remove the length of StagingFolder from the full path to the top folder giving just the locale folders
                string dirflderName = dirflder.Remove(0, stagingFolder.Length);

                //Check through each folder within the stagingFolder and locale
                foreach (var flder in Directory.GetDirectories(stagingFolder + dirflderName))
                {
                    //Take the name, month and year from the name of the folder in stagingFolder and locale
                    var fldName = new DirectoryInfo(flder).Name;
                    int fldMonth = Convert.ToInt32(fldName.Substring(3, 2));
                    int fldYear = Convert.ToInt32(fldName.Substring(6, 4));

                    //Check if the month is lower or equal to what it would be 3 months ago and that the year is the same
                    if (fldMonth <= monthFrom && fldYear == yearFrom)
                    {
                        //Add the path of the folder to a list of backedup folders
                        movedFolders.Add(flder);

                        //Check if the archive folder and locale exist and then create if not
                        if (!Directory.Exists(archiveFolder + dirflderName + "\\" + fldName))
                        {
                            Directory.CreateDirectory(archiveFolder + dirflderName);
                            Directory.Move(flder, archiveFolder + dirflderName + "\\" + fldName);
                        }
                        //If the backup date folder has the same create a duplicate with Copy on the end of the folder name
                        else if (!Directory.Exists(archiveFolder + dirflderName + "\\" + fldName))
                        {
                            Directory.Move(flder, archiveFolder + dirflderName + "\\" + fldName + "\\" + "Copy");
                        }
                    }
                    //If the date is a previous year to this year also back up (to fix issues with backups going over 3 months into previous year)
                    else if (fldYear < yearFrom)
                    {
                        //Add the path of the folder to a list of backedup folders
                        movedFolders.Add(flder);

                        //Repeat of same code above (if possible consolidate)
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

            //Where the log txt file will be or is to be created
            string logfilePath = @"C:\Users\grimwoodb\Desktop\Test Folder 2\archived.txt";

            //Add todays date above the list of archived folders
            movedFolders.Insert(0, DateTime.Now.ToString());

            //Check if the log file exists and if so add the newest list to the end
            if (File.Exists(logfilePath))
            {
                //Loop through each string in the list of archived folders and write to each line of the file
                foreach (string line in movedFolders)
                {
                    TextWriter tsw = new StreamWriter(logfilePath, true);
                    tsw.WriteLine(line);
                    tsw.Close();
                }
                
            }

            //Otherwise create the file with the list
            else {
                File.WriteAllLines(logfilePath, movedFolders);
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Set time we want the programme to auto run
            var runTime = "21:00";
            //Update the label with the time
            lblRunTime.Text = runTime.ToString();

            //Get the current hour
            int hourNow = DateTime.Now.Hour;

            //Get the current minute
            int minNow = DateTime.Now.Minute;

            //Combine both minute and hour into a HH:MM format
            string timeNow = hourNow + ":" + minNow;

            //Update the label with the current hour and minute
            lblNow.Text = timeNow;

            //If the current time is 21:00 then run the digiStoreBackup
            if (timeNow == "21:00")
            {
                dgiStoreBackup();
            }

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            //When the systemtray item is clicked return the form to normal
            this.WindowState = FormWindowState.Normal;
            //Put the form back on the windows taskbar
            this.ShowInTaskbar = true;
            //Remove the system tray icon
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //Show the system tray icon
                notifyIcon1.Visible = true;
                //Show the message that it has been put to the system tray for 2 seconds
                notifyIcon1.ShowBalloonTip(2000);
                //Remove the form from the windows taskbar
                this.ShowInTaskbar = false;
            }
        }
    }
}
