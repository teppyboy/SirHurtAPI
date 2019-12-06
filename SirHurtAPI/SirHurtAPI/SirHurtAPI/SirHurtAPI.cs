using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SirHurtAPI
{
    public class SirHurtAPI
    {
        public static bool Injected = false;
        public static bool firstLaunch = true;

        [DllImport("SirHurtInjector.dll")]
        private static extern int Inject();
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        private static uint _injectionResult;
        public static void DownloadDll()
        {
            if (!File.Exists("SirHurtInjector.dll"))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v4/SirHurtInjector.dll", "SirHurtInjector.dll");
                    } // Code from SirHurt Bootstrapper.
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
                    MessageBox.Show("Couldn't download SirHurtInjector.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                }
            }
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v4/SirHurt.dll", "SirHurt.dll");
                } // Code from SirHurt Bootstrapper.
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
                    reason = "Unknown, please give log.";
                }
                MessageBox.Show("Couldn't download SirHurt.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
            }
        }
        public static void LaunchExploit() //Why LaunchExploit? because some ppl are used to make exploit using weareretarded api so yea.
        {
            if (!Injected)
            {
                DownloadDll();
                IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
                if (Injected || intPtr == IntPtr.Zero)
                {
                    return;
                }
                int num = 0;
                try
                {
                    num = Inject();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("An error occured with injecting SirHurt: %s", ex.Message), "SirHurtAPI");
                }
                if (num != 0)
                {
                    Injected = true;
                }
                GetWindowThreadProcessId(intPtr, out _injectionResult);
                Injected = true;
                if (firstLaunch)
                {
                    injectionCheckerThreadHandler();
                    firstLaunch = false;
                }
            }
        }

        private static void injectionCheckerThreadHandler()
        {
            for (; ; )
            {
                Application.DoEvents();
                Thread.Sleep(100);
                IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
                uint num = 0U;
                GetWindowThreadProcessId(intPtr, out num);
                if ((intPtr == IntPtr.Zero && Injected) || (_injectionResult != 0U && num != _injectionResult))
                {
                    Injected = false;
                    Execute("");
                }
            }
        }

        public static void Execute(string script)
        {
            try
            {
                File.WriteAllText("sirhurt.dat", script);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "SirHurtAPI");
            }
        }
    }
}
