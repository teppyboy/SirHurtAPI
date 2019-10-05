using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirHurtAPI
{
    public class SirHurtAPI
    {
        static IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
        static CallSite<Func<CallSite, object, bool>> value1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                    {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                    }));  //SirHurtAPI.<> o__9.<> p__3
        static CallSite<Func<CallSite, object, object>> value2 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                    {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                    }));  //SirHurtAPI.<> o__9.<> p__0
        static CallSite<Func<CallSite, object, bool>> value3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                    {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                    })); //SirHurtAPI.<> o__9.<> p__2
        static CallSite<Func<CallSite, object, bool, object>> value4 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                    {
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
                    })); //SirHurtAPI.<> o__9.<> p__1
        static CallSite<Action<CallSite, Type, object, object>> value5 = CallSite<Action<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "WriteAllText", null, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                    {
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                    }));
        static CallSite<Action<CallSite, Type, object>> ara_ara = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SirHurtPipe", null, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                            {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                            }));
        static dynamic fakebool = false;
        static uint attachedID;
        [DllImport("SirHurtInjector.dll")]
        private static extern int Inject();
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static void DownloadDll()
        {
            if (!File.Exists("SirHurtInjector.dll"))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v3/SirHurtInjector.dll", "SirHurtInjector.dll");
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
                    webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v3/SirHurt.dll", "SirHurt.dll");
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
        static void SirHurtPipe(string script)
        {
            try
            {
                if (value5 == null)
                {
                    value5 = CallSite<Action<CallSite, Type, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "WriteAllText", null, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                    {
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                    }));
                }
                value5.Target(value5, typeof(File), "sirhurt.dat", script);
            }
            catch (Exception)
            {
            }
        }
        public static void Execute(string script)
        {
            if (ara_ara == null)
            {
                ara_ara = CallSite<Action<CallSite, Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "SirHurtPipe", null, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                {
                                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
                                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                }));
            }
            ara_ara.Target(ara_ara, typeof(SirHurtAPI), script);
            Console.WriteLine("[SirHurtAPI]: Executed script using SirHurt");
        }
        public static void LaunchExploit()
        {
            DownloadDll();
            if (value1 == null)
            {
                value1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                }));
            }
            Func<CallSite, object, bool> target = value1.Target;
            CallSite p__ = value1;
            if (value2 == null)
            {
                value2 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                }));
            }
            object obj = value2.Target(value2, fakebool);
            if (value3 == null)
            {
                value3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                {
                    CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
                }));
            }
            object arg;
            if (!value3.Target(value3, obj))
            {
                if (value4 == null)
                {
                    value4 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(SirHurtAPI), new CSharpArgumentInfo[]
                    {
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
                    }));
                }
                arg = value4.Target(value4, obj, intPtr != IntPtr.Zero);
            }
            else
            {
                arg = obj;
            }
            if (target(p__, arg))
            {
                if (fakebool)
                {
                    Thread.Sleep(3000);
                }
                int num = 0;
                try
                {
                    num = Inject();
                    fakebool = true;
                    Console.WriteLine("[SirHurtAPI]: Injected SirHurt.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("An error occured with injecting SirHurt: %s", ex.Message), "SirHurt V2");
                }
                if (num != 0)
                {
                    fakebool = true;
                    return;
                }
                GetWindowThreadProcessId(intPtr, out attachedID);
                fakebool = true;
            }
        }

    }
}
