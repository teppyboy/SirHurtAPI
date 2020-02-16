using System;


namespace SirHurtAPI
{
    public static class Scripts
    {
        public static bool OwlHub()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=owlhub.lua',true))()",true);
        }
        public static bool FluxBreak()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=fluxbreak.lua',true))()", true);
        }
        public static bool KiwiiDecompiler()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=kiwiidecompiler.lua',true))()", true);
        }
        public static bool UnNamedESP()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=unnamedesp.lua',true))()", true);
        }
        public static bool R2SV3()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=LuaURemotespy.lua',true))()", true);
        }
        public static bool SirHurtScriptHub()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=sirhurtscripthub.lua',true))()", true);
        }
        public static bool MadCityMenu()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=madcitymenu.lua',true))()", true);
        }
        public static bool MadCityHaxx()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=madcityhaxx.lua',true))()", true);
        }
        public static bool PhantomX()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=PhantomX.lua',true))()", true);
        }
        public static bool KiwiiPF()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=KiwiiPF.lua',true))()", true);
        }
        public static bool SteamSniper()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=StreamSniper.lua',true))()", true);
        }
        public static bool SirHurtMultiTool()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=multitool.lua',true))()", true);
        }
        public static bool ScriptHunter()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=scriptfinder.lua',true))()", true);
        }
        public static bool SimpleESP()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=simpleesp.lua',true))()", true);
        }
        public static bool ProjectBullDukey()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=bullshit.lua',true))()", true);
        }
        public static bool DarkDex()
        {
            return SirHurtAPI.Execute("loadstring(HttpGet('https://asshurthosting.pw/upl/UIScriptHub/Scripts/script.php?script=darkdex_v1.lua',true))()", true);
        }
        public static bool OpenScriptHub()
        {
            try
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
    }
}
