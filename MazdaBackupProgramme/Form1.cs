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

        int totalfiles = 0;

        private void btnRunManual_Click(object sender, EventArgs e)
        {
            dgiStoreArchive();
        }


        public void dgiStoreArchive()
        {
            //Calculate what 3 months ago would be by subtracting 3 from todays date month and add newMonthFrom in case of archive over new year
            // int monthFrom = DateTime.Now.Month - 3;
            int monthFrom = 1 - 3;
            int yearFrom = DateTime.Now.Year;
            int newMonthFrom = 0;

            //Set directory for the files to come from and where to go
            string stagingFolder = @"C:\Users\grimwoodb\Desktop\Test Folder";
            string archiveFolder = @"C:\Users\grimwoodb\Desktop\Test Folder 2";

            //Create a string which will populate with the backed up folders
            List<string> movedFolders = new List<string>();
            DateTime compareDate = DateTime.Now.AddMonths(-3).Date;
            //Check through the top folders(dirflder) in the stagingFolder
            foreach (var dirflder in Directory.GetDirectories(stagingFolder))
            {
                //remove the length of StagingFolder from the full path to the top folder giving just the locale folders
                string dirflderName = dirflder.Remove(0, stagingFolder.Length);

                //Check through each folder within the stagingFolder and locale
                foreach (var flder in Directory.GetDirectories(stagingFolder + dirflderName))
                {
                    //
                    var fldName = new DirectoryInfo(flder).Name;
                    string fldD = fldName.Substring(0, 10).Replace("-","/");
                    DateTime flderDate = Convert.ToDateTime(fldD);

                    
                    DirectoryInfo flderDI = new DirectoryInfo(flder);

                    //Check if the month is lower or equal to what it would be 3 months ago and that the year is the same
                    if (flderDate < compareDate)
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

                }

            }

            //Create the Log File
            createLogFile(movedFolders);
            totalfiles = totalfiles + movedFolders.Count;

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
                dgiStoreArchive();
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


        public void assetFolderArchive(string sourceFolder)
        {
            //Archive Folder Location
            string archiveFolder = @"C:\Users\grimwoodb\Desktop\Test Folder 2";


            //Go through all directories in the source folder ad list them (interior or exterior or both folder checkox decision)
            string[] allfiles = System.IO.Directory.GetFiles(sourceFolder, "*.*", System.IO.SearchOption.AllDirectories);

            //Take all the files and add them to a list so we can remove any unwanted files
            List<string> filestocheck = new List<string>(allfiles);
            //Create a list for the list of files we want to keep
            List<string> checkedfiles = new List<string>();

            //Loop through all files in the List and add the files that are not .psds to the checkfiles list
            foreach (string f in filestocheck)
            {
                if(!f.EndsWith(".psd"))
                {
                    checkedfiles.Add(f);
                }
            }

            DateTime compareDate = DateTime.Now.AddMonths(-3);
            List<string> movedFiles = new List<string>();

            //Loop through all the collected files in the list
            foreach (string interiorFile in checkedfiles)
            {
                //Get the file information from the file loop
                FileInfo fi = new FileInfo(interiorFile);

            if (fi.LastWriteTime < compareDate)
                {
                    //ADD CREATE DIRECTORY AND FILE MOVE SCRIPT
                    string dir = interiorFile.Substring(sourceFolder.Length);
                    dir = dir.Replace(fi.Name, "");
                    string fulldir = archiveFolder + "\\Image Master" + dir;

                    new FileInfo(fulldir).Directory.Create();

                    if(File.Exists(fulldir + fi.Name))
                    {
                        File.Delete(fulldir + fi.Name);
                        File.Move(interiorFile, fulldir + fi.Name);
                        movedFiles.Add(interiorFile);
                    }
                    else if (!File.Exists(fulldir + fi.Name))
                    {
                        File.Move(interiorFile, fulldir + fi.Name);
                        movedFiles.Add(interiorFile);
                    }

                }
            }
            createLogFile(movedFiles);
            totalfiles = totalfiles + movedFiles.Count;
        }

        private void btnImageArchive_Click(object sender, EventArgs e)
        {
            //If no checkboxes checked display error message
            if (cbxExteriorImages.Checked == false && cbxInteriorImages.Checked == false)
            {
                MessageBox.Show("At least one checkbox must be ticked", "Error", MessageBoxButtons.OK);
            }
            //If interior Images checkbox checked run the archive with the interior folder
            if (cbxInteriorImages.Checked == true)
            {
                string folderToArchive = @"C:\Users\grimwoodb\Desktop\Test Folder3\Image Master";
                assetFolderArchive(folderToArchive);
            }
            //If exterior Images checkbox checked run the archive with the exterior folder
            if (cbxExteriorImages.Checked == true)
            {
                string folderToArchive = @"C:\Users\grimwoodb\Desktop\Test Folder3\HTML5";
                assetFolderArchive(folderToArchive);
            }

            
        }

        public void createLogFile(List<string> movedFolders)
        {
            //Where the log txt file will be or is to be created
            string logfilePath = @"C:\Users\grimwoodb\Desktop\Test Folder 2\archived - " + DateTime.Now.ToString("dd/MM/yyyy") + ".txt";

            logfilePath = logfilePath.Replace("/", "-");

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
            else
            {
                File.WriteAllLines(logfilePath, movedFolders);
            }

            finshedRunning();
        }

        public void finshedRunning()
        {
            MessageBox.Show(totalfiles.ToString() + " Files/Folder Groups have been archived", "Archive Complete", MessageBoxButtons.OK);
            totalfiles = 0;
        }










    }
}
