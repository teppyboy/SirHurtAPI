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

            if (!File.Exists("SirHurtAPI.dll"))
            {
                var wc = new WebClient();
                try
                {
                    wc.DownloadFile("https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/SirHurtAPI.dll","SirHurtAPI.dll");
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
            } else
            {
                // Update check

                bool updateCheck()
                {
                    var updateClient = new WebClient();
                    try
                    {
                        updateClient.DownloadFile("https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/SirHurtAPI.dll", "SirHurtAPI.temp");
                        updateClient.Dispose();
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
                    using (var md5 = MD5.Create())
                    {
                        using (var tempFile = File.OpenRead("SirHurtAPI.temp"))
                        using (var currentFile = File.OpenRead("SirHurtAPI.dll"))
                        {
                            var tempHashString = BitConverter.ToString(md5.ComputeHash(tempFile)).Replace("-", "").ToLowerInvariant();
                            var currentHashString = BitConverter.ToString(md5.ComputeHash(currentFile)).Replace("-", "").ToLowerInvariant();
                            return (!(tempHashString == currentHashString));
                        }
                    }
                }

                if (updateCheck()) {
                    File.Delete("SirHurtAPI.dll");
                    File.Move("SirHurtAPI.temp", "SirHurtAPI.dll");
                    Console.WriteLine("Updating SirHurt API");
                } else
                {
                    File.Delete("SirHurtAPI.temp");
                }
                Application.Run(new MainForm());
            }
        }
    }
}
