using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using Google.Documents;

namespace GDocBackup
{
    public partial class AboutForm : Form
    {
  


        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            Version googleVer = typeof(Document).Assembly.GetName().Version;
            string googleLibVersion = googleVer.Major + "." + googleVer.Minor + "." + googleVer.Build + "   (subversion revision " + googleVer.Revision + ")";
            string gdocbakcupVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.Icon = Properties.Resources.Logo;
            LblVersion.Text += gdocbakcupVersion;
            LblGoogleVer.Text = "google-gdata ver. " + googleLibVersion;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // note: Process.Start crashes on some systems (issue 17)
            try { System.Diagnostics.Process.Start((sender as LinkLabel).Text); }
            catch (Exception) { }
        }


    }
}