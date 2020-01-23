using System;
using Microsoft.Win32;
using System.Threading.Tasks;
using Reloaded.Injector;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace SirHurtAPI
{
    public class Experimental
    {
        private readonly static string DllName = "[SirHurtAPI]";
        private static bool autoInject;
        private static bool firstLaunch = true;
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
                    if (SirHurtAPI.DownloadDll(false))
                    {
                        returnval = true;
                        foreach (Process rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            var a = new Injector(rbx);
                            num = a.Inject("SirHurt.dll");
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
                }
                else
                {
                    Console.WriteLine(DllName + "Failed to inject SirHurt V4");
                    SirHurtAPI.setInjectStatus(false);
                    return false;
                }
                SirHurtAPI.GetWindowThreadProcessId(intPtr, out SirHurtAPI._injectionResult);
                SirHurtAPI.setInjectStatus(true);
                returnval = true;
                if (firstLaunch)
                {
                    injectionCheckerThreadHandler();
                    firstLaunch = false;
                }
            }
            else
                return false;
            return returnval;
        }

        internal static async Task injectionCheckerThreadHandler()
        {
            for (; ; )
            {
                Application.DoEvents();
                Thread.Sleep(100);
                IntPtr intPtr = SirHurtAPI.FindWindowA("WINDOWSCLIENT", "Roblox");
                uint num = 0U;
                SirHurtAPI.GetWindowThreadProcessId(intPtr, out num);
                if ((intPtr == IntPtr.Zero && SirHurtAPI.isInjected()) || (SirHurtAPI._injectionResult != 0U && num != SirHurtAPI._injectionResult))
                {
                    SirHurtAPI.Execute("", true);
                    SirHurtAPI.setInjectStatus(false);
                    if (GetAutoInject())
                    {
                        autoIJ();
                    }
                }
            }
        }
    }
}
