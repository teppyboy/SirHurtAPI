using System;
using Microsoft.Win32;
using System.Threading.Tasks;
using Reloaded.Injector;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Security;

namespace SirHurtAPI
{
    public class Experimental
    {
        private readonly static string DllName = "[SirHurtAPI]";
        private static bool autoInject;
        private static bool isCheckingDetachDone = false;
        public static bool GetAutoInject()
        {
            try
            {
                var a = Registry.CurrentUser.OpenSubKey("SirHurtAPI");
                autoInject = Convert.ToBoolean(a.GetValue("ExAutoIJ"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(DllName + "Cannot read auto inject status from registry, setting to false");
                setAutoIJStatus(false);
                Console.WriteLine(ex);
            }
            return autoInject;
        }
        private static bool setAutoIJStatus(bool AutoInjectStatus)
        {
            try
            {
                var a = Registry.CurrentUser.CreateSubKey("SirHurtAPI");
                a.SetValue("ExAutoIJ", AutoInjectStatus);
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
        private static bool dlFASM()
        {
            bool returnval;
            if ((!File.Exists("FASM.dll") || new FileInfo("FASM.dll").Length == 0))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(SirHurtAPI.AlwaysGoodCertificate);
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        webClient.DownloadFile("https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/FASM.DLL", "FASM.dll");
                        Console.WriteLine(DllName + "Downloaded FASM.dll");
                    } // Code from SirHurt Bootstrapper.
                    if (File.Exists("FASM.dll") && new FileInfo("FASM.dll").Length != 0)
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
                    Console.WriteLine(DllName + "Couldn't download FSAM.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                    return false;
                }
            }
            else
                returnval = true;
            if ((!File.Exists("FASMX64.dll") || new FileInfo("FASMX64.dll").Length == 0))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(SirHurtAPI.AlwaysGoodCertificate);
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        webClient.DownloadFile("https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/FASMX64.DLL", "FASMX64.dll");
                        Console.WriteLine(DllName + "Downloaded FASMX64.dll");
                    } // Code from SirHurt Bootstrapper.
                    if (File.Exists("FASMX64.dll") && new FileInfo("FASMX64.dll").Length != 0)
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
                    Console.WriteLine(DllName + "Couldn't download FASMX64.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                    return false;
                }
            }
            else
                returnval = true;
            return returnval;
        }
        public static bool AutoInjectToggle() //Why does everyone asking for this shit function ._.
        {
            if (!GetAutoInject())
            {
                setAutoIJStatus(true);
                Task.Run(async () =>
                {
                    await autoIJ();
                }); ;
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
                IntPtr intPtr = SirHurtAPI.FindWindowA("WINDOWSCLIENT", "Roblox");
                if (SirHurtAPI.isInjected() || intPtr == IntPtr.Zero)
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

        public static bool LaunchExploit()
        {
            bool returnval;
            if (!SirHurtAPI.isInjected())
            {
                IntPtr intPtr = SirHurtAPI.FindWindowA("WINDOWSCLIENT", "Roblox");
                if (intPtr == IntPtr.Zero)
                {
                    SirHurtAPI.setInjectStatus(false);
                    return false;
                }
                long num = 0;
                try
                {
                    if (SirHurtAPI.DownloadDll(false) && dlFASM())
                    { 
                        returnval = true;
                        Thread.Sleep(250);
                        foreach (Process rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            var a = new Injector(rbx);
                            num = a.Inject(AppDomain.CurrentDomain.BaseDirectory + "SirHurt.dll");
                            Thread.Sleep(100);
                        }
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DllName + "An error occured with injecting SirHurt: " + ex.Message);
                    SirHurtAPI.setInjectStatus(false);
                    return false;
                }
                if (num != 0)
                {
                    Console.WriteLine(DllName + "Sucessfully injected SirHurt V4.");
                    SirHurtAPI.setInjectStatus(true);
                    returnval = true;
                    var a = Registry.CurrentUser.CreateSubKey("SirHurtAPI");
                    SirHurtAPI.SHdatPath = AppDomain.CurrentDomain.BaseDirectory + "sirhurt.dat";
                    a.SetValue("SHDatPath", SirHurtAPI.SHdatPath);
                    SirHurtAPI.GetWindowThreadProcessId(intPtr, out SirHurtAPI._injectionResult);
                    SirHurtAPI.setInjectStatus(true);
                    isCheckingDetachDone = false;
                    Task.Run(async () =>
                    {
                        await injectionCheckerThreadHandler();
                    });
                }
                else
                {
                    Console.WriteLine(DllName + "Failed to inject SirHurt V4");
                    SirHurtAPI.setInjectStatus(false);
                    return false;
                }
            }
            else
                return false;
            return returnval;
        }

        internal static async Task injectionCheckerThreadHandler()
        {
            while (!isCheckingDetachDone)
            {
                Application.DoEvents();
                await Task.Delay(100);
                IntPtr intPtr = SirHurtAPI.FindWindowA("WINDOWSCLIENT", "Roblox");
                uint num = 0U;
                SirHurtAPI.GetWindowThreadProcessId(intPtr, out num);
                if ((intPtr == IntPtr.Zero && SirHurtAPI.isInjected()) || (SirHurtAPI._injectionResult != 0U && num != SirHurtAPI._injectionResult))
                {
                    SirHurtAPI.Execute("", true);
                    SirHurtAPI.setInjectStatus(false);
                    if (GetAutoInject())
                    {
                        await Task.Run(async () =>
                        {
                            await autoIJ();
                        });
                    }
                    isCheckingDetachDone = true;
                }
            }
        }
    }
}
