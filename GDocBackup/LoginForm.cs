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
using System.Diagnostics;
using Microsoft.Win32.TaskScheduler;
using GDocBackupLib;


namespace GDocBackup
{
    public partial class LoginForm : Form
    {

        private Properties.Settings conf = Properties.Settings.Default;
        public string UserName { get { return this.UsernameTB.Text; } set { this.UsernameTB.Text = value; } }
        public string Password { get { return this.PasswordTB.Text; } }
        public string BackupDir { get { return this.BackupDirTB.Text; } set { this.BackupDirTB.Text = value; } }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Logo;
            UsernameTB.Text = conf.UserName;
            PasswordTB.Text = String.IsNullOrEmpty(conf.Password) ? null : Utility.UnprotectData(conf.Password);
             BackupDirTB.Text = conf.BackupDir;
        }

        private void Login_Click(object sender, EventArgs e)
        {
           
                //do something else
                conf.UserName = UsernameTB.Text;
                conf.Password = Utility.ProtectData(PasswordTB.Text);
                conf.BackupDir = BackupDirTB.Text;
                conf.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void PasswordTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                conf.UserName = UsernameTB.Text;
                conf.Password = Utility.ProtectData(PasswordTB.Text);
                conf.BackupDir = BackupDirTB.Text;
                conf.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = BackupDirTB.Text;
            if (fbd.ShowDialog() == DialogResult.OK)
                BackupDirTB.Text = fbd.SelectedPath;
        }

        private void CbStorePassword_CheckedChanged(object sender, EventArgs e)
        {
            this.PasswordTB.ReadOnly = CbStorePassword.Checked;
        }

     

    }
    
  
}