using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2.Data;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace GDocBackup
{
    static class Program
    {
        /// <summary>
        /// Application entry point!
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            // Connect with Oauth2 Ask user for permission
            String CLIENT_ID = "363720865617-54cf693mpj3h4g50snclba0laogvcqcs.apps.googleusercontent.com";
            String CLIENT_SECRET = "NDmluNfTgUk6wgmy7cFo64RV";
            // DriveService service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, Environment.UserName);


            // connect with a Service Account
            string ServiceAccountEmail = "363720865617-54cf693mpj3h4g50snclba0laogvcqcs@developer.gserviceaccount.com";
            string serviceAccountkeyFile = @"D:\DevAcount\GDocBackup-d0b07ce41d82.p12";
            DriveService service = Authentication.AuthenticateServiceAccount(ServiceAccountEmail, serviceAccountkeyFile);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<string> argList = new List<string>(args);

            MainForm mf = new MainForm();
            mf.AutoStart = argList.Contains("-autostart");
            mf.DebugMode = argList.Contains("-debugmode");
            Application.Run(mf);
        }


        /// <summary>
        /// Handles exceptions from (sub)threads
        /// </summary>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            BuildAndSendFeedBack("Application_ThreadException", e.Exception);
            Application.Exit();
        }


        /// <summary>
        /// Handles exceptions from main thread (of appdomain)
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            BuildAndSendFeedBack("CurrentDomain_UnhandledException", e.ExceptionObject);
            Application.Exit();
        }


        /// <summary>
        /// ...
        /// </summary>
        private static void BuildAndSendFeedBack(string mainEx, object subEx)
        {

            // Build feedback data
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(mainEx);
            sb.AppendLine(new String('-', 40));
            if (subEx != null)
            {
                sb.AppendLine(subEx.ToString());
                sb.AppendLine(new String('-', 40));
            }

            // Show SendFeedback window
            using (SendFeedbackForm sf = new SendFeedbackForm())
            {
                sf.DataTitle = "GDocBackup encountered an unexpected error!";
                sf.DataBody = sb.ToString();
                sf.ShowDialog();
            }
        }

    }
}