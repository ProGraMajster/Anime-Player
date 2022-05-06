using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AnimePlayer.HostApp
{
    static class Program
    {
        /// <summary>
        /// G��wny punkt wej�cia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Console.WriteLine("App starting...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                foreach (string a in Environment.GetCommandLineArgs())
                {
                    if(a == "-Updater")
                    {

                    }
                    else if(a == "-OpenApp")
                    {
                        Application.Run(new FormMainPlayer());
                        return;
                    }
                    else if(a == "-FormBrowser")
                    {
                        Application.Run(new FormBrowser(true));
                        return;
                    }
                    else if(a == "-OtherArgs")
                    {
                        OtherArgs.Start();
                    }
                }
                Application.Run(new FormStarter());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wyst�pi� krytyczny b��d", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.IO.File.WriteAllText("CrashAppRaport_"+DateTime.Now.ToString().Replace(":","_")+".txt", ex.ToString() + Environment.NewLine);
            }
        }
    }
}
