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
using System.Text.RegularExpressions;

namespace MazdaBackupProgramme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker2.WorkerReportsProgress = true;
        }

        int totalfiles = 0;
        string typeMoved = "";

        private void btnRunManual_Click(object sender, EventArgs e)
        {
            //Run digiStoreArchive in bgworker
            btnImageArchive.Enabled = false;
            btnRunManual.Enabled = false;
            
            backgroundWorker1.RunWorkerAsync();
        }


        public void dgiStoreArchive(string stagingFolder)
        {
            totalfiles = 0;
            //Get it to try the below code and if an error occurs using the catch give a message box with the error
            try
            {
                //Set directory for the archive folder
                string archiveFolder = @"C:\Users\grimwoodb\Desktop\Test Folder 2";

                //Create a string which will populate with the backed up folders
                List<string> movedFolders = new List<string>();
                //Create todays date 3 months ago
                DateTime compareDate = DateTime.Now.AddMonths(-3).Date;
                //Check through the top folders(dirflder) in the stagingFolder
                string[] dirsToCheck = Directory.GetDirectories(stagingFolder, "*", SearchOption.AllDirectories);

                //Create list for the checked directories to go to
                List<string> dirsChecked = new List<string>();

                //Set a regular expression to find a speectic format. In this case ##-##-###
                Regex rgx = new Regex(@"\d{2}-\d{2}-\d{4}");

                //Loop through all the files needed to be checked
                foreach (string dirChecking in dirsToCheck)
                {
                    //Find directories that have a date in their fodler name if not will be empty
                    Match dirMatch = rgx.Match(dirChecking);

                    //if the Match is not empty then it has found a date and the folder is correct for backup
                    if (dirMatch.Length > 0)
                    {
                        //Take the folder name and change it to a date format for comparrison
                        DateTime flderDate = Convert.ToDateTime(dirMatch.ToString().Replace("-", "/"));

                        //See if the folderdate is older then the compareDate
                        if (flderDate < compareDate)
                        {
                            //Add to the checked directories list where the folders to be archived are stored
                            dirsChecked.Add(dirChecking);
                        }



                    }

                }
                int fldercount = 0;

                //Loop through the folders that need archiving
                foreach (string flder in dirsChecked)
                {
                    //Get info on the original directory 
                    DirectoryInfo dirInfo = new DirectoryInfo(flder);

                    //Get the original directory and remove its original folder
                    string removeCameFrom = flder.Substring(stagingFolder.Length);
                    //Add the archove folder to the path
                    string fullDir = archiveFolder + removeCameFrom;


                    //If the folder already exists delete the old one and move the new one
                    if (Directory.Exists(fullDir))
                    {
                        Directory.Delete(fullDir, true);
                        Directory.Move(flder, fullDir);

                    }
                    //If the folder does not exist create up to the folder to add in and then move the folder
                    else if (!Directory.Exists(fullDir))
                    {

                        string toCreate = fullDir.Substring(0, fullDir.Length - dirInfo.Name.Length);
                        Directory.CreateDirectory(toCreate);
                        Directory.Move(flder, fullDir);
                    }
                    //Add the folder to the list of moved folders
                    fldercount++;
                    int bgpbpercentage = fldercount * 100 / dirsChecked.Count;
                    backgroundWorker1.ReportProgress(bgpbpercentage);
                    movedFolders.Add(flder);
                }

                //Update the number of total files by the number of movedfiles
                totalfiles = totalfiles + movedFolders.Count;
                //Update the type moved for the finishing message to display
                typeMoved = "folders";
                //Run the createLogFile function
                createLogFile(movedFolders);
            }
            catch (Exception e)
            {
                //If the above parts break display an error message of the problem
                if (e.ToString().Contains("Cross-thread"))
                {

                }
                else
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK);
                }
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

            totalfiles = 0;
            try { 
            //Archive Folder Location
            string archiveFolder = @"C:\Users\grimwoodb\Desktop\Test Folder 2";


            //Go through all directories in the source folder ad list them (interior or exterior or both folder checkox decision)
            string[] allfiles = System.IO.Directory.GetFiles(sourceFolder, "*.*", System.IO.SearchOption.AllDirectories);

            //Take all the files and add them to a list so we can remove any unwanted files
            List<string> filestocheck = new List<string>(allfiles);
            //Create a list for the list of files we want to keep
            List<string> checkedfiles = new List<string>();

                string[] excludes = { ".psd", ".aep" };

            //Loop through all files in the List and add the files that are not .psds to the checkfiles list
            foreach (string f in filestocheck)
            {
                    foreach (string exclude in excludes)
                        { 
                         if (!f.EndsWith(exclude))
                        {
                            checkedfiles.Add(f);
                        }
                    }
            }

            //Create a day to compare against
            DateTime compareDate = DateTime.Now.AddMonths(-3);
            //Create a list to be populated by the moved files
            List<string> movedFiles = new List<string>();

                int filecount = 0;
            //Loop through all the collected files in the list
            foreach (string interiorFile in checkedfiles)
            {
                //Get the file information from the file loop
                FileInfo fi = new FileInfo(interiorFile);

            if (fi.LastWriteTime < compareDate)
                {
                    //Get the parent of the current folder so that up to that can be removed and replaced
                    string dirToRemove = Directory.GetParent(sourceFolder).FullName;
                        
                    //Create a string of the folder path while removing the original folder it came from
                    string dir = interiorFile.Substring(dirToRemove.Length);
                    dir = dir.Replace(fi.Name, "");
                    //Add the archive folder to the new path and then add the next folder and the rest of the path
                    string fulldir = archiveFolder + dir;
                    
                    //Create the directory
                    new FileInfo(fulldir).Directory.Create();
                    
                    //If the file exists delete the original and then move the new one
                    if(File.Exists(fulldir + fi.Name))
                    {
                        File.Delete(fulldir + fi.Name);
                        File.Move(interiorFile, fulldir + fi.Name);
                        movedFiles.Add(interiorFile);
                    }
                    //If the file does not exist move the file
                    else if (!File.Exists(fulldir + fi.Name))
                    {
                        File.Move(interiorFile, fulldir + fi.Name);
                        movedFiles.Add(interiorFile);
                    }

                }

                    filecount++;
                    int percentage = filecount * 100 / checkedfiles.Count;
                    backgroundWorker2.ReportProgress(percentage);

            }
            //Update the total files with the amount of files moved
            totalfiles = totalfiles + movedFiles.Count;
            //Change the type moved to files for the finished message
            typeMoved = "files";
            //Run the createLogFile function
            createLogFile(movedFiles);

            }
            //If any errors display an error message with the error given
            catch (Exception e)
            {
                if (e.ToString().Contains("Cross-thread"))
                {

                }
                else
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void btnImageArchive_Click(object sender, EventArgs e)
        {
            btnImageArchive.Enabled = false;
            btnRunManual.Enabled = false;
            //Run image archiver in bgworker2
            backgroundWorker2.RunWorkerAsync();
          
        }

        public void createLogFile(List<string> movedFolders)
        {
            //Try the below code and if failure then catch the error and display
            try
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

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK);
            }

        }

        public void finshedRunning()
        {
            MessageBox.Show(totalfiles.ToString() + " " + typeMoved + " have been archived", "Archive Complete", MessageBoxButtons.OK);
            btnImageArchive.BeginInvoke((Action)delegate () { btnImageArchive.Enabled = true; });
            btnRunManual.BeginInvoke((Action)delegate () { btnRunManual.Enabled = true; });
            tbCustomFolderPath.BeginInvoke((Action)delegate () { tbCustomFolderPath.Text = ""; });
            progressBar1.BeginInvoke((Action)delegate () { progressBar1.Value = 0; });
            progressBar2.BeginInvoke((Action)delegate () { progressBar2.Value = 0; });
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string stagingFolder = @"C:\Users\grimwoodb\Desktop\Test Folder";
            dgiStoreArchive(stagingFolder);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            //If no checkboxes checked display error message
            if (cbxExteriorImages.Checked == false && cbxInteriorImages.Checked == false && cbxCustomFolder.Checked == false)
            {
                MessageBox.Show("At least one checkbox must be ticked", "Error", MessageBoxButtons.OK);
            }
            //If the customfolder checkbox is checked but the folder path is empty
           

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

            if (String.IsNullOrEmpty(tbCustomFolderPath.Text))
            {
                MessageBox.Show("The file path is empty please choose a folder", "Error", MessageBoxButtons.OK);
            }

            if (cbxCustomFolder.Checked == true && !String.IsNullOrEmpty(tbCustomFolderPath.Text))
            {
                DialogResult dialogresult = MessageBox.Show("This will archive all files 3 months and older for the selected folder. Is this ok?", "Confirm", MessageBoxButtons.YesNo);
                if(dialogresult == DialogResult.Yes)
                {
                    string folderToArchive = tbCustomFolderPath.Text;
                    customArchive(folderToArchive);
                }          
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void cbxCustomFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCustomFolder.Checked == true)
            {
                btnSelectCustomFolder.Enabled = true;
            }
            if (cbxCustomFolder.Checked == false)
            {
                btnSelectCustomFolder.Enabled = false;
            }
        }

        private void btnSelectCustomFolder_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbCustomFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            finshedRunning();
        }

        public void customArchive(string stagingFolder)
        {
            try { 
            int filecount = 0;
            totalfiles = 0;
            //Set directory for the archive folder
            string archiveFolder = @"C:\Users\grimwoodb\Desktop\Test Folder 2";

            List<string> filestoCheck = new List<string>(Directory.GetFiles(stagingFolder, "*.*", SearchOption.AllDirectories));
            List<string> directories = new List<string>();
            List<string> movedFiles = new List<string>();
            //Create todays date 3 months ago
            DateTime compareDate = DateTime.Now.AddMonths(-3).Date;

            foreach (string check in filestoCheck)
            {
                FileInfo checkFile = new FileInfo(check);

                if (checkFile.LastWriteTime < compareDate)
                {
                    string path = checkFile.FullName.ToString().Remove(checkFile.FullName.Length - checkFile.Name.Length);

                    path = path.Replace(stagingFolder, "");

                    path = archiveFolder + "\\" + path;



                    if (Directory.Exists(path))
                    {
                        if (File.Exists(checkFile.ToString()))
                        {
                            File.Move(checkFile.ToString(), path + "\\" + checkFile.Name);
                            movedFiles.Add(check);
                        }
                    }

                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo diCreate = Directory.CreateDirectory(path);
                        File.Move(checkFile.ToString(), path + "\\" + checkFile.Name);
                        movedFiles.Add(check);

                    }
                    filecount++;
                    int percentage = filecount * 100 / filestoCheck.Count;
                    backgroundWorker2.ReportProgress(percentage);

                }


            }
            //Update the total files with the amount of files moved
            totalfiles = totalfiles + filecount;
            //Change the type moved to files for the finished message
            typeMoved = "files";
            //Run the createLogFile function
            createLogFile(movedFiles);
        }
            //If any errors display an error message with the error given
            catch (Exception e)
            {
                if (e.ToString().Contains("Cross-thread"))
                {

                }
                else
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK);
                }
            }

        }

        private void lnklblExclude_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
