using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SirHurtAPI
{
    public class SirHurtAPI
    {
        private static bool Injected = false;
        private static bool autoInject = false;
        private static bool isCleaning = false;
        private static bool isCheckingDetachDone = false;
        private static bool firstLaunch = true;
        private readonly static string ver = "1.0.4.0"; //Later because im lazy
        private readonly static string DllName = "[SirHurtAPI]";
        internal static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        [DllImport("SirHurtInjector.dll")]
        private static extern int Inject();
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        internal static uint _injectionResult;
        public static bool isNewVersionAvailable()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var latestver = wc.DownloadString("https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/version.txt");
                    wc.Dispose();
                    if (latestver == "")
                    {
                        Console.WriteLine(DllName + "Unable to check for new version...");
                        return false;
                    }
                    else if (latestver != ver)
                    {
                        Console.WriteLine(DllName + "New version found.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine(DllName + "No new version found.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DllName + "Unable to check for new version...");
                Console.WriteLine(ex);
                return false;
            }
        }
        public static bool DownloadDll(bool DownloadSirHurtInjector) // Why? because i will use this in my UI, TsuSploit.
        {
            bool returnval;
            if ((!File.Exists("SirHurtInjector.dll") || new FileInfo("SirHurtInjector.dll").Length == 0) && DownloadSirHurtInjector)
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v4/SirHurtInjector.dll", "SirHurtInjector.dll");
                        Console.WriteLine(DllName + "Downloaded SirHurtInjector.dll");
                    } // Code from SirHurt Bootstrapper.
                    if (File.Exists("SirHurtInjector.dll") && new FileInfo("SirHurtInjector.dll").Length != 0)
                        returnval = true;
                    else
                        return false;
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
                    Console.WriteLine(DllName + "Couldn't download SirHurtInjector.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                    return false;
                }
            }
            else
                returnval = true;
            if (File.Exists("sirh.dat"))
            {
                if (File.Exists(File.ReadAllText("sirh.dat")))
                {
                    File.Delete(File.ReadAllText("sirh.dat"));
                }
                File.Delete("sirh.dat");
            }
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v4/SirHurt.dll", "SirHurt.dll");
                    Console.WriteLine(DllName + "Downloaded SirHurt.dll");
                } // Code from SirHurt Bootstrapper.
                if (File.Exists("SirHurt.dll") && new FileInfo("SirHurt.dll").Length != 0)
                    returnval = true;
                else
                    return false;
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
                Console.WriteLine(DllName + "Couldn't download SirHurt.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                return false;
            }
            return returnval;
        }

        public static bool LaunchExploit() //Why LaunchExploit? because some ppl are used to make exploit using weareretarded api so yea.
        {
            bool returnval;
            if (!isInjected())
            {
                IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
                if (intPtr == IntPtr.Zero)
                {
                    setInjectStatus(false);
                    return false;
                }
                int num = 0;
                try
                {
                    if (DownloadDll(true))
                    {
                        num = Inject();
                        returnval = true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DllName+"An error occured with injecting SirHurt: "+ ex.Message);
                    setInjectStatus(false);
                    return false;
                }
                if (num != 0)
                {
                    Console.WriteLine(DllName + "Sucessfully injected SirHurt V4.");
                    setInjectStatus(true);
                    returnval = true;
                }
                else
                {
                    Console.WriteLine(DllName + "Failed to inject SirHurt V4");
                    setInjectStatus(false);
                    return false;
                }
                GetWindowThreadProcessId(intPtr, out _injectionResult);
                setInjectStatus(true);
                returnval = true;
                isCheckingDetachDone = false;
                injectionCheckerThreadHandler();
            }
            else
                return false;
            return returnval;
        }
        public static bool GetAutoInject()
        {
            try
            {
                var a = Registry.CurrentUser.OpenSubKey("SirHurtAPI");
                autoInject = Convert.ToBoolean(a.GetValue("AutoIJ"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(DllName + "Cannot read auto inject status from registry, setting to false");
                setAutoIJStatus(false);
                Console.WriteLine(ex);
            }
            return autoInject;
        }
        public static bool setInjectStatus(bool InjectStatus)
        {
            try
            {
                var a = Registry.CurrentUser.CreateSubKey("SirHurtAPI");
                a.SetValue("InjectedValue", InjectStatus);
                Injected = InjectStatus;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DllName + "Cannot write inject status to registry");
                Console.WriteLine(ex);
                return false;
            }
        }
        private static bool setAutoIJStatus(bool AutoInjectStatus)
        {
            try
            {
                var a = Registry.CurrentUser.CreateSubKey("SirHurtAPI");
                a.SetValue("AutoIJ", AutoInjectStatus);
                autoInject = AutoInjectStatus;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DllName + "Cannot write auto inject status to registry");
                Console.WriteLine(ex);
                return false;
            }
        }
        public static bool isInjected()
        {
            try
            {
                var a = Registry.CurrentUser.OpenSubKey("SirHurtAPI");
                Injected = Convert.ToBoolean(a.GetValue("InjectedValue"));
                if (firstLaunch && Injected && !isCheckingDetachDone)
                {
                    firstLaunch = false;
                    injectionCheckerThreadHandler();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DllName + "Cannot read inject status from registry, setting to false");
                setInjectStatus(false);
                Console.WriteLine(ex);
            }
            return Injected;
        }
        public static bool AutoInjectToggle() //Why does everyone asking for this shit function ._.
        {
            if (!GetAutoInject())
            {
                setAutoIJStatus(true);
                autoIJ();
                Console.WriteLine(DllName + "Enabled auto-inject");
            }
            else
            {
                setAutoIJStatus(false);
                Console.WriteLine(DllName + "Disabled auto-inject");
            }
            return GetAutoInject();
        }

        private static async Task autoIJ()
        {
            while (GetAutoInject())
            {
                await Task.Delay(100);
                IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
                if (isInjected() || intPtr == IntPtr.Zero)
                {
                    Console.WriteLine(DllName + "Injected or ROBLOX isn't running...");
                }
                else
                {
                    Console.WriteLine(DllName + "ROBLOX Found. Injecting...");
                    LaunchExploit();
                }
            }
        }

        private static async Task injectionCheckerThreadHandler()
        {
            while (!isCheckingDetachDone)
            {
                Application.DoEvents();
                Task.Delay(100);
                IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
                uint num = 0U;
                GetWindowThreadProcessId(intPtr, out num);
                if ((intPtr == IntPtr.Zero && isInjected()) || (_injectionResult != 0U && num != _injectionResult))
                {
                    Execute("", true);
                    setInjectStatus(false);
                    if (GetAutoInject())
                    {
                        autoIJ();
                    }
                    isCheckingDetachDone = true;
                }
            }
        }
        private static async void revert()
        {
            isCleaning = true;
            await Task.Delay(100);
            Execute("", true);
            isCleaning = false;
        }

        public static bool Execute(string script, bool Forced)
        {
            if ((isInjected() || Forced) && !isCleaning)
            {
                Directory.CreateDirectory("Workspace");
                try
                {
                    File.WriteAllText("sirhurt.dat", script);
                    if (Forced && script != "")
                    {
                        Console.WriteLine(DllName + "Forced detected, will clear sirhurt.dat in 0.1s");
                        revert();
                    }
                    Console.WriteLine(DllName + "Sucessfully write to sirhurt.dat");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DllName + "Cannot write to sirhurt.dat: " + ex);
                    return false;
                }
            }
            else
            {
                if (isCleaning)
                {
                    return false;
                    throw new Exception(DllName + "Cleaning sirhurt.dat");
                }
                return false;
            }
        }
        public static bool ExecuteFromFile(bool Forced) //@am ikea#1337 as you wish :|
        {
            var FileDg = new OpenFileDialog();
            FileDg.Filter = "txt (*.txt)|*.txt|lua (*.lua)|*.lua|All files (*.*)|*.*";
            FileDg.InitialDirectory = Environment.CurrentDirectory;
            FileDg.Title = "SirHurtAPI File Executor";
            if (FileDg.ShowDialog() == DialogResult.OK)
            {
                string file;
                try
                {
                    using (StreamReader reader = new StreamReader(FileDg.OpenFile()))
                    {
                        file = reader.ReadToEnd();
                    }
                    Console.WriteLine(DllName + "Sucessfully read " + Path.GetFullPath(FileDg.FileName));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(DllName+"Failed to read file.\nLog:", ex);
                    return false;
                }
                if (Execute(file, Forced))
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
