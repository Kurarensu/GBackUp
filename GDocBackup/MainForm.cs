/*
   Copyright 2009-2012  Fabrizio Accatino

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Net;
using System.Diagnostics;
using Google.Documents;
using GDocBackupLib;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
using Microsoft.Win32.TaskScheduler;
using System.Management;
using System.Globalization;


namespace GDocBackup
{
    
    public partial class MainForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Properties.Settings conf = Properties.Settings.Default;
        private Thread _workingThread;
        public string useraccount { get { return this.lblAccount.Text; } set { this.lblAccount.Text = value; } }
        public string logmsg;
        public string[] Logs = null;
        /// <summary>
        /// Log data
        /// </summary>
        //private List<string> _logsX = null;
        //public void AddLogEntry(string msg)
        //{
        //    if (_logsX != null)
        //    {
        //        if (_logsX.Count > (20000 + 100))
        //        {
        //            _logsX.RemoveRange(0, 100);
        //        }
        //        _logsX.Add(msg);
        //    }
        //}


        private MySimpleLog _mySimpleLog = null;


        /// <summary>
        /// Autostart flag
        /// </summary>
        public bool AutoStart = false;
        public string account = "";

        /// <summary>
        /// Autostart flag
        /// </summary>
        // public bool WriteLog = false;


        /// <summary>
        /// Debugmode flag
        /// </summary>
        private bool _debugMode = false;
        public bool DebugMode
        {
            get
            {
                return _debugMode;
            }
            set
            {
                _debugMode = value;
                this.debugModeToolStripMenuItem.Checked = _debugMode;
            }
        }

        
        /// <summary>
        /// [Constructor]
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            PopulateDriveList();
        }


        /// <summary>
        /// Form load event
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {


            /*
            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem();
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");*/

            // Create columns for the items and subitems. 
            // Width of -2 indicates auto-size.
           

            //Add the items to the ListView.
            //listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            /*
            // Create two ImageList objects.
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();

            
            // Initialize the ImageList objects with bitmaps.
            imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage1.bmp"));
            imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage2.bmp"));
            imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage1.bmp"));
            imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage2.bmp"));

            //Assign the ImageList objects to the ListView.
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;
            */
            // Add the ListView to the control collection. 
            //this.Controls.Add(listView1);

            lblAccount.Text = conf.UserName;
            lbllastBackup.Text = conf.LastBackup;
            this.Icon = Properties.Resources.Logo;

            //this.Text += " - Ver. " + gdocbakcupVersion;

//            this.StoreLogMsgInfo(-1, "FORM_LOAD: " + this.Text);

            if (Properties.Settings.Default.CallUpgrade)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.CallUpgrade = false;
                Properties.Settings.Default.Save();
            }

            //this.ExecCheckUpdates();

            if (String.IsNullOrEmpty(Properties.Settings.Default.BackupDir))
            {
                using (LoginForm cf = new LoginForm())
                {
                    cf.ShowDialog();
                }
            }
            if (String.IsNullOrEmpty(Properties.Settings.Default.UserName))
            {
                using (LoginForm cf = new LoginForm())
                {
                    cf.ShowDialog();
                }
            }
            if (String.IsNullOrEmpty(Properties.Settings.Default.Password))
            {
                using (LoginForm cf = new LoginForm())
                {
                    cf.ShowDialog();
                }
            }

        }


        /// <summary>
        /// Form Shown event
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (AutoStart)
                this.ExecBackUp(false);
        }


       


        /// <summary>
        /// Add log message to list and file
        /// </summary>
        /// <param name="s"></param>
        private void StoreLogMsgInfo(int percent, string s)
        {
            string msg = DateTime.Now.ToString() + " - " + percent.ToString("000") + " > " + s;

            if (_mySimpleLog != null)
                _mySimpleLog.Add(msg, _debugMode);
        }


        #region  ---- User click on Buttons, Menu items & C.  ----

        private void BtnExec_Click(object sender, EventArgs e)
        {
            if (this.BtnExec.Text != "STOP")
                this.ExecBackUp(false);
            else
                if (_workingThread != null && _workingThread.IsAlive)
                    _workingThread.Abort();
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.BtnExec.Text != "STOP")
                this.ExecBackUp(false);
        }

        private void downloadAllagainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.BtnExec.Text != "STOP")
            {
                if (MessageBox.Show(
                        "GDocBackup will donwload again ALL documents from Google Docs. Are you sure?",
                        "GDocBackup",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning) == DialogResult.OK)
                    this.ExecBackUp(true);
            }
        }

        private void debugModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DebugMode = !this.DebugMode;
        }

        private void configToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (ConfigForm cf = new ConfigForm())
            {
                cf.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm af = new AboutForm())
                af.ShowDialog();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LogsForm logsform = new LogsForm())
            {
                if (_mySimpleLog != null)
                    logsform.Logs = _mySimpleLog.DumpToStrArray();
                logsform.ShowDialog();
            }
        }

        private void techDocListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string userName = Properties.Settings.Default.UserName;
                string password =
                    String.IsNullOrEmpty(Properties.Settings.Default.Password) ?
                    String.Empty :
                    Utility.UnprotectData(Properties.Settings.Default.Password);

                if (String.IsNullOrEmpty(userName))
                {
                    SimpleInputBox sib = new SimpleInputBox();
                    sib.Title = "Username";
                    sib.MaskInput = false;
                    if (sib.ShowDialog() != DialogResult.OK)
                        return;
                    userName = sib.TextValue;
                }

                if (String.IsNullOrEmpty(password))
                {
                    SimpleInputBox sib = new SimpleInputBox();
                    sib.Title = "Password";
                    sib.MaskInput = true;
                    if (sib.ShowDialog() != DialogResult.OK)
                        return;
                    password = sib.TextValue;
                }

                MessageBox.Show("Starting");

                TechSupport.ExportDocList(fbd.SelectedPath, userName, password);

                MessageBox.Show("Done");
            }
        }


        #endregion --------------------------------



        #region ---- Backup thread ----

        /// <summary>
        /// Start backup in a separate (background) thread
        /// </summary>
        private void ExecBackUp(bool downloadAll)
        {
            log.Info("Backup Starting");
            string userName = Properties.Settings.Default.UserName;
            string password =
                String.IsNullOrEmpty(Properties.Settings.Default.Password) ?
                String.Empty : Utility.UnprotectData(Properties.Settings.Default.Password);
            string backupDir = Properties.Settings.Default.BackupDir;

            if (Properties.Settings.Default.AppsMode == false)
            {
                if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(backupDir))
                {
                    LoginForm login = new LoginForm();
                    login.UserName = userName;
                    login.BackupDir = backupDir;
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        userName = login.UserName;
                        password = login.Password;
                        backupDir = login.BackupDir;
                    }
                    else
                        return;
                }
            }

            _mySimpleLog = new MySimpleLog(_debugMode);

            
            this.BtnExec.Text = "STOP";
            this.Cursor = Cursors.WaitCursor;
            this.listView1.Cursor = Cursors.WaitCursor;

            // Start working thread
            _workingThread = new Thread(ExecBackupThread);
            _workingThread.IsBackground = true;
            _workingThread.Name = "BackupExecThread";
            _workingThread.Start(new string[] { userName, password, backupDir, downloadAll ? "ALL" : "" });
        }


        /// <summary>
        /// Exec backup (new thread "body")
        /// </summary>
        private void ExecBackupThread(object data)
        {
            String[] parameters = data as String[];

            Properties.Settings conf = Properties.Settings.Default;

            IWebProxy webproxy = Utility.GetProxy(conf.ProxyExplicit, conf.ProxyDirectConnection, conf.ProxyHostPortSource, conf.ProxyHost, conf.ProxyPort, conf.ProxyAuthMode, conf.ProxyUsername, conf.ProxyPassword);

            Config config = new Config(
                parameters[0],
                parameters[1],
                parameters[2],
                parameters[3] == "ALL",
                Utility.DecodeDownloadTypeArray(conf.DocumentExportFormat).ToArray(),
                Utility.DecodeDownloadTypeArray(conf.SpreadsheetExportFormat).ToArray(),
                Utility.DecodeDownloadTypeArray(conf.PresentationExportFormat).ToArray(),
                Utility.DecodeDownloadTypeArray(conf.DrawingExportFormat).ToArray(),
                webproxy,
                conf.BypassCertificateChecks,
                this.DebugMode,
                conf.DateDelta,
                conf.AppsMode,
                conf.AppsDomain,
                String.IsNullOrEmpty(conf.AppsOAuthSecretEncrypted) ? null : Utility.UnprotectData(conf.AppsOAuthSecretEncrypted),
                conf.AppsOAuthOnly);

            Backup b = new Backup(config);
            b.Feedback += new EventHandler<FeedbackEventArgs>(Backup_Feedback);
            bool result = b.Exec();
            this.BeginInvoke((MethodInvoker)delegate() { EndDownload(result, b.DuplicatedDocNames, b.LastException); });
           
        }


        /// <summary>
        /// Backup feedback event handler
        /// </summary>
        private void Backup_Feedback(object sender, FeedbackEventArgs e)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new EventHandler<FeedbackEventArgs>(Backup_Feedback), sender, e);
            else
            {
                int percent = (int)(e.PerCent * 100);
                this.progressBar1.Value = percent;

                if (!String.IsNullOrEmpty(e.Message))
                    this.StoreLogMsgInfo(percent, e.Message);

                if (e.FeedbackObj != null)
                {
                    this.StoreLogMsgInfo(percent, "FO> " + e.FeedbackObj.ToString());

                    string[] row = { e.FeedbackObj.FileName,e.FeedbackObj.DocType, e.FeedbackObj.RemoteDateTime.ToString() };

                    var listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);

                    
                   /* this.dataGV.Rows.Add(
                        new object[] { 
                            e.FeedbackObj.FileName, 
                            e.FeedbackObj.DocType, 
                            e.FeedbackObj.ExportFormat.ToUpper(),
                            e.FeedbackObj.Action,
                            e.FeedbackObj.RemoteDateTime.ToString() });*/
                }
            }
        }


        /// <summary>
        /// End download event handler
        /// </summary>
        private void EndDownload(bool isOK, List<string> duplicatedDocNames, Exception ex)
        {
            this.progressBar1.Value = 0;
            this.Cursor = Cursors.Default;
            this.listView1.Cursor = Cursors.Default;    // Need to set it (perhaps a bug of DataGridView...)
            this.BtnExec.Enabled = true;
            this.BtnExec.Text = "Save";

            if (duplicatedDocNames != null && duplicatedDocNames.Count > 0 && Properties.Settings.Default.DisableDuplicatedItemWarnings == false)
            {
                int totDupDocs = duplicatedDocNames.Count;
                if (totDupDocs > 20)
                {
                    duplicatedDocNames = duplicatedDocNames.GetRange(0, 20);
                    duplicatedDocNames.Add("...(list truncated)");
                }

                string msg =
                    "Warning: there are " + totDupDocs + " items with the same name in the same folder. " + Environment.NewLine +
                    ((totDupDocs > 20) ? ("First 20 items: " + Environment.NewLine) : ("")) +
                    String.Join(Environment.NewLine, duplicatedDocNames.ToArray());
                MessageBox.Show(msg, "GDocBackup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (isOK)
            {
                if (AutoStart)
                {
                    Application.Exit();
                    return;   // Win does not requires it. Mono on Ubuntu, yes!  Is a Mono bug???   ... TO BE MORE TESTED  :(
                }
                else


               
                MessageBox.Show("Backup completed.", "GDocBackup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conf.LastBackup = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                conf.Save();
                lblCompleteBackup.Text = conf.LastBackup;
                this.lblCopied.Text = this.listView1.Items.Count.ToString();
                logmsg = "Backup completed Total Files Backup " + this.lblCopied.Text + " Files/Folders";
                log.Info(logmsg);
                
            }
            else
            {
                string msg = "Backup completed. There are errors! " + Environment.NewLine + Environment.NewLine +
                   "Please review Logs for details. (Menu 'Action' --> 'View Logs')";
                if (ex != null)
                {
                    
                    this.StoreLogMsgInfo(-1, "############### EXCEPTION ###############");
                    this.StoreLogMsgInfo(-1, ex.ToString());
                    this.StoreLogMsgInfo(-1, "#########################################");
                    msg += Environment.NewLine + Environment.NewLine +
                        "[ERROR: " + ex.GetType().Name + " : " + ex.Message + "]";
                    log.Error("[ERROR: " + ex.GetType().Name + " : " + ex.Message + "]");
                }
               
                MessageBox.Show(msg, "GDocBackup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion ----------------------------

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        
        //////////////////////////////////////////////////////////////////////////////////////////
        //This procedure populate the TreeView with the Drive list
        private void PopulateDriveList()
        {
            TreeNode nodeTreeNode;
            int imageIndex = 0;
            int selectIndex = 0;

            const int Removable = 2;
            const int LocalDisk = 3;
            const int Network = 4;
            const int CD = 5;
            //const int RAMDrive = 6;

            this.Cursor = Cursors.WaitCursor;
            //clear TreeView
            trvFolders.Nodes.Clear();
            nodeTreeNode = new TreeNode("My Computer", 0, 0);
            trvFolders.Nodes.Add(nodeTreeNode);

            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;

            //Get Drive list
            ManagementObjectCollection queryCollection = getDrives();
            foreach (ManagementObject mo in queryCollection)
            {

                switch (int.Parse(mo["DriveType"].ToString()))
                {
                    case Removable:			//removable drives
                        imageIndex = 5;
                        selectIndex = 5;
                        break;
                    case LocalDisk:			//Local drives
                        imageIndex = 6;
                        selectIndex = 6;
                        break;
                    case CD:				//CD rom drives
                        imageIndex = 7;
                        selectIndex = 7;
                        break;
                    case Network:			//Network drives
                        imageIndex = 8;
                        selectIndex = 8;
                        break;
                    default:				//defalut to folder
                        imageIndex = 2;
                        selectIndex = 3;
                        break;
                }
                //create new drive node
                nodeTreeNode = new TreeNode(mo["Name"].ToString() + "\\", imageIndex, selectIndex);

                //add new node
                nodeCollection.Add(nodeTreeNode);

            }


            //Init files ListView
            InitListView();

            this.Cursor = Cursors.Default;

        }

        private void tvFolders_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;

            //get current selected drive or folder
            TreeNode nodeCurrent = e.Node;

            //clear all sub-folders
            nodeCurrent.Nodes.Clear();

            if (nodeCurrent.SelectedImageIndex == 0)
            {
                //Selected My Computer - repopulate drive list
                PopulateDriveList();
            }
            else
            {
                //populate sub-folders and folder files
                PopulateDirectory(nodeCurrent, nodeCurrent.Nodes);
            }
            this.Cursor = Cursors.Default;
        }

        protected void InitListView()
        {
            //init ListView control
            listView1.Clear();		//clear control
            //create column header for ListView
            listView1.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Type", 75, System.Windows.Forms.HorizontalAlignment.Right);
            listView1.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);

        }

        protected void PopulateDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection)
        {
            TreeNode nodeDir;
            int imageIndex = 2;		//unselected image index
            int selectIndex = 3;	//selected image index

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                //populate treeview with folders
                try
                {
                    //check path
                    if (Directory.Exists(getFullPath(nodeCurrent.FullPath)) == false)
                    {
                        MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                    }
                    else
                    {
                        //populate files
                        PopulateFiles(nodeCurrent);

                        string[] stringDirectories = Directory.GetDirectories(getFullPath(nodeCurrent.FullPath));
                        string stringFullPath = "";
                        string stringPathName = "";

                        //loop throught all directories
                        foreach (string stringDir in stringDirectories)
                        {
                            stringFullPath = stringDir;
                            stringPathName = GetPathName(stringFullPath);

                            //create node for directories
                            nodeDir = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
                            nodeCurrentCollection.Add(nodeDir);
                        }
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error: Drive not ready or directory does not exist.");
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Error: Drive or directory access denided.");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }

        protected string GetPathName(string stringPath)
        {
            //Get Name of folder
            string[] stringSplit = stringPath.Split('\\');
            int _maxIndex = stringSplit.Length;
            return stringSplit[_maxIndex - 1];
        }

        protected void PopulateFiles(TreeNode nodeCurrent)
        {
            //Populate listview with files
            string[] lvData = new string[4];

            //clear list
            InitListView();

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                //check path
                if (Directory.Exists((string)getFullPath(nodeCurrent.FullPath)) == false)
                {
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                }
                else
                {
                    try
                    {
                        string[] stringFiles = Directory.GetFiles(getFullPath(nodeCurrent.FullPath));
                        string stringFileName = "";
                        DateTime dtCreateDate, dtModifyDate;
                        Int64 lFileSize = 0;

                        //loop throught all files
                        foreach (string stringFile in stringFiles)
                        {
                            stringFileName = stringFile;
                            FileInfo objFileSize = new FileInfo(stringFileName);
                            lFileSize = objFileSize.Length;
                            dtCreateDate = objFileSize.CreationTime; //GetCreationTime(stringFileName);
                            dtModifyDate = objFileSize.LastWriteTime; //GetLastWriteTime(stringFileName);

                            //create listview data
                            lvData[0] = GetPathName(stringFileName);
                            lvData[1] = formatSize(lFileSize);

                            //check if file is in local current day light saving time
                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false)
                            {
                                //not in day light saving time adjust time
                                lvData[2] = formatDate(dtCreateDate.AddHours(1));
                            }
                            else
                            {
                                //is in day light saving time adjust time
                                lvData[2] = formatDate(dtCreateDate);
                            }

                            //check if file is in local current day light saving time
                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false)
                            {
                                //not in day light saving time adjust time
                                lvData[3] = formatDate(dtModifyDate.AddHours(1));
                            }
                            else
                            {
                                //not in day light saving time adjust time
                                lvData[3] = formatDate(dtModifyDate);
                            }


                            //Create actual list item
                            ListViewItem lvItem = new ListViewItem(lvData, 0);
                            listView1.Items.Add(lvItem);


                        }
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show("Error: Drive not ready or directory does not exist.");
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        MessageBox.Show("Error: Drive or directory access denided.");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error: " + e);
                    }
                }
            }
        }

        protected string getFullPath(string stringPath)
        {
            //Get Full path
            string stringParse = "";
            //remove My Computer from path.
            stringParse = stringPath.Replace("My Computer\\", "");

            return stringParse;
        }

        protected ManagementObjectCollection getDrives()
        {
            //get drive collection
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
            ManagementObjectCollection queryCollection = query.Get();

            return queryCollection;
        }

        protected string formatDate(DateTime dtDate)
        {
            //Get date and time in short format
            string stringDate = "";

            stringDate = dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();

            return stringDate;
        }

        protected string formatSize(Int64 lSize)
        {
            //Format number to KB
            string stringSize = "";
            NumberFormatInfo myNfi = new NumberFormatInfo();

            Int64 lKBSize = 0;

            if (lSize < 1024)
            {
                if (lSize == 0)
                {
                    //zero byte
                    stringSize = "0";
                }
                else
                {
                    //less than 1K but not zero byte
                    stringSize = "1";
                }
            }
            else
            {
                //convert to KB
                lKBSize = lSize / 1024;
                //format number with default format
                stringSize = lKBSize.ToString("n", myNfi);
                //remove decimal
                stringSize = stringSize.Replace(".00", "");
            }

            return stringSize + " KB";

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to create a Schedule Task", "GDocBackup", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                using (TaskService ts = new TaskService())
                {

                    // Create a new task definition and assign properties
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Description = "GDoc Backup";

                    // Create a trigger that will fire the task at this time every other day
                    DailyTrigger daily = new DailyTrigger();
                    daily.StartBoundary = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 16:30:00");
                    daily.DaysInterval = 1;
                    td.Triggers.Add(daily);
                    string appinfo = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
                    // Create an action that will launch Notepad whenever the trigger fires
                    td.Actions.Add(new ExecAction(appinfo, null, null));

                    // Register the task in the root folder
                    ts.RootFolder.RegisterTaskDefinition(@"GDocBackup", td);

                    // Remove the task we just created
                    //ts.RootFolder.DeleteTask("GDoc Backup");
                }

                Process.Start("C:\\Windows\\system32\\taskschd.msc");
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }
            
        }

        
    }
}