using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SirHurtAPI_Demo_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileInfo fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            DateTime lastModified = fileInfo.LastWriteTime;
            Console.Title = "SirHurtAPI Demo App Launcher";
            Console.WriteLine("SirHurtAPI Demo App Launcher");
            Console.WriteLine("Build: " + lastModified.ToShortDateString().Replace("/", ""));
            Console.WriteLine("Build date: " + lastModified.ToString());
            Console.WriteLine("======================================");
            Console.WriteLine("Checking for required DLL...");

            if (File.Exists("SirHurtAPI.dll"))
            {
                // Update check
                if (SirHurtAPI.SirHurtAPI.isNewVersionAvailable())
                {
                    File.Delete("SirHurtAPI.dll");
                    Console.WriteLine("Updating SirHurt API");
                    var wc = new WebClient();
                    try
                    {
                        wc.DownloadFile("https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/SirHurtAPI.dll", "SirHurtAPI.dll");
                        wc.Dispose();
                    }
                    catch (Exception ex)
                    {
                        string reason;
                        if (ex.ToString().Contains("Timed out"))
                        {
                            reason = "Connection timed out.";
                        }
                        else
                        {
                            reason = "Unknown, please give log and create a issue in SirHurtAPI Github.";
                        }
                        MessageBox.Show("Couldn't download SirHurtAPI.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Downloaded.");
                    Console.WriteLine("======================================");
                }
                Console.WriteLine("Please keep this console open, if close then the UI will be closed too.");
                Application.Run(new MainForm());
            }
            else
            {
                Console.WriteLine("SirHurt API Missing, Downloading now...");
                var wc = new WebClient();
                try
                {
                    wc.DownloadFile("https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/SirHurtAPI.dll", "SirHurtAPI.dll");
                    wc.Dispose();
                    Console.WriteLine("Downloaded.");
                    Console.WriteLine("======================================");
                    Console.WriteLine("Please keep this console open, if close then the UI will be closed too.");
                    Application.Run(new MainForm());
                }
                catch (Exception ex)
                {
                    string reason;
                    if (ex.ToString().Contains("Timed out"))
                    {
                        reason = "Connection timed out.";
                    }
                    else
                    {
                        reason = "Unknown, please give log and create a issue in SirHurtAPI Github.";
                    }
                    MessageBox.Show("Couldn't download SirHurtAPI.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                    Environment.Exit(0);
                }
            }
        }
    }
}
