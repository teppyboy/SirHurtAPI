using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Threading.Tasks;

namespace SirHurtAPI
{
    public static class Scripts
    {
        /*
        public static bool OwlHub()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=owlhub.lua',true))()",true);
        }
        public static bool FluxBreak()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=fluxbreak.lua',true))()", true);
        }
        public static bool KiwiiDecompiler()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=kiwiidecompiler.lua',true))()", true);
        }
        public static bool UnNamedESP()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=unnamedesp.lua',true))()", true);
        }
        public static bool R2SV3()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=LuaURemotespy.lua',true))()", true);
        }
        public static bool SirHurtScriptHub()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=sirhurtscripthub.lua',true))()", true);
        }
        public static bool MadCityMenu()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=madcitymenu.lua',true))()", true);
        }
        public static bool MadCityHaxx()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=madcityhaxx.lua',true))()", true);
        }
        public static bool PhantomX()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=PhantomX.lua',true))()", true);
        }
        public static bool KiwiiPF()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=KiwiiPF.lua',true))()", true);
        }
        public static bool SteamSniper()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=StreamSniper.lua',true))()", true);
        }
        public static bool SirHurtMultiTool()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=multitool.lua',true))()", true);
        }
        public static bool ScriptHunter()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=scriptfinder.lua',true))()", true);
        }
        public static bool SimpleESP()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=simpleesp.lua',true))()", true);
        }
        public static bool ProjectBullDukey()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=bullshit.lua',true))()", true);
        }
        public static bool DarkDex()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=darkdex_v1.lua',true))()", true);
        }
        */
        public static bool OpenScriptHub()
        {
            try // Because i want :)
            {
                Console.WriteLine("[SirHurtAPI]YAYAYAYAY MY WAIFU ENTERPRISE SENT ME VALENTINE CHOCOLATE IN AZUR LANE OWOWOWOWOWOWO");
                new ScriptHub().ShowDialog();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[SirHurtAPI]Failed to open ScriptHub Form.\n{ex}");
                return false;
            }
        }
        private readonly static string DllName = "[SirHurtAPI]";
        private static List<JToken> list = null;
        public static string[] DLScriptHub()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    Console.WriteLine(DllName + "Starting download script list async...");
                    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(SirHurtAPI.AlwaysGoodCertificate);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var string_ = wc.DownloadString(new Uri("https://sirhurt.net/upl/UIScriptHub/fetch.php"));
                    list = JObject.Parse(string_)["scripts"].Children().Children<JToken>().ToList<JToken>();
                    var lst = new List<string>();
                    foreach (JToken jtoken in list)
                    {
                        lst.Add(jtoken["Name"].ToString());
                    }
                    Console.WriteLine(DllName + "Decode sucess, returning lst...");
                    return lst.ToArray();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DllName + "Unable to download script list...");
                Console.WriteLine(ex);
                return new List<string>().ToArray();
            }
        }
        public async static Task<Tuple<string,string>> GetScriptInfoFromName(string ScriptName)
        {
            if (list == null)
            {
                DLScriptHub();
            }
            foreach (JToken jtoken in list)
            {
                if (jtoken["Name"].ToString() == ScriptName)
                {
                    Console.WriteLine(DllName + "Correct Name!, downloading image");
                    await Task.Delay(50);
                    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(SirHurtAPI.AlwaysGoodCertificate);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    return Tuple.Create(jtoken["Desc"].ToString(), jtoken["Picture"].ToString());
                }
            }
            return Tuple.Create("", "");
        }
        public static bool ExecuteFromName(string ScriptName)
        {
            Console.WriteLine(DllName + "Script selected: " + ScriptName);
            string scriptURL = null;
            foreach (JToken jtoken in list)
            {
                if (jtoken["Name"].ToString() == ScriptName)
                {
                    scriptURL = jtoken["FileName"].ToString();
                    Console.WriteLine(DllName + "File name:" + scriptURL);
                }
            }
            if (scriptURL == null)
            {
                Console.WriteLine(DllName + "scriptURL is null, returning (prob bc invalid script name)");
                return false;
            }
            try
            {
                return SirHurtAPI.Execute("loadstring(HttpGet('https://sirhurt.net/upl/UIScriptHub/Scripts/script.php?script=" + scriptURL + "'))()", true);
            }
            catch
            {
                return false;
            }
        }
    }
}
