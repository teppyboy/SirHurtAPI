## This repository is ARCHIVED, if I ever use SirHurt again then I'll unarchive the project but the chances is almost none because free exploits already satisfy my needs (Krnl, Fluxus, etc..). You can still fork this project and maintain it but the code is very broken.
## Read [this issue](https://github.com/teppyboy/SirHurtAPI/issues/8#issuecomment-670091747) for more info.
# SirHurtAPI
 - An API that support SirHurt V4 for developers easier to make SirHurt V4 custom UI
 - **THIS DOSEN'T GIVE YOU ABILITY TO USE SIRHURT FOR FREE**
 - **fuck 0x59 didn't post his api so i need to update this cancer project**
 - Looking for API? [Here](https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/SirHurtAPI.dll)
 - Looking for Demo App? [Here](https://github.com/teppyboy/SirHurtAPI/raw/master/SirHurtAPI/SirHurtAPI/SirHurtAPI%20Demo%20App/bin/Debug/SirHurtAPI%20Demo%20App.exe)
## How to use this API
- References -> Add Reference -> Browse -> Choose this DLL -> Done!
## For who wants to update the API do this:
- References -> Select SirHurtAPI -> Remove (or press DEL) -> References -> Add Reference -> Browse -> Choose this DLL -> Done!
- All available function:
```
class SirHurtAPI:
+ bool LaunchExploit() - Download & Inject SirHurt V4, return true if sucess and false if not.
+ bool Execute(string script, bool Forced) - Execute a script, return true if sucess and false if not (if Forced then execute even detect SirHurt is not injected).
- Execute will throw an exception if you execute a script while its clearing sirhurt.dat. Exception text: [SirHurtAPI]Cleaning sirhurt.dat
+ bool DownloadDLL(bool DownloadSirHurtInjector) - Download SirHurt V4 dll (and SirHurtInjector if not exist + boolean is true), return true if sucess and false if not.
+ bool ExecuteFromFile(bool Forced) - Execute a script from a file, return true if sucess and false if not (if Forced then execute even detect SirHurt is not injected).
+ bool AutoInjectToggle() - Enable/Disable auto inject and return true = enabled, false = disabled.
+ bool GetAutoInject() - Get Auto inject status and return true = enabled, false = disabled.
+ bool isInjected() - Get injected status and return true = injected, false = not injected.
+ bool isNewVersionAvailable() - Check for new version of SirHurtAPI, if yes then return true, else return false
+ bool setInjectStatus(bool InjectStatus) - Set Inject status to true/false [For custom Inject method only!] [Don't use if you don't know anything or it'll break the inject status]
+ bool multipleRBXToggle() - Enable/Disable Multiple ROBLOX and return true = enabled, false = disabled.
+ bool oofRBX() - Kill all ROBLOX instance.
+ bool getMultipleRBX() - Get Multiple ROBLOX status and return true = enabled, false = disabled.
class Experimental:
+ bool GetAutoInject() - Get Auto inject status and return true = enabled, false = disabled.
+ bool AutoInjectToggle() - Enable/Disable auto inject and return true = enabled, false = disabled.
+ bool LaunchExploit() - Download & Inject SirHurt V4 using Reloaded.Injector[And FASM + FASMX64 if not exist], return true if sucess and false if not.
class Scripts:
+ bool OpenScriptHub() - Launch Intergated Script Hub (C# Form) and return true if sucess and false if failed
+ string[] DLScriptHub() - Download script hub and return all scripts in script hub name.
+ Tuple<string,string> GetScriptInfoFromName(tring ScriptName) - Get ScriptName Info (Image + Desc) and return a Tuple (Item1 = Description, Item2 = Image URL). If this failed it
ll return a empty Tuple (Item1 and Item2 is empty.)
+ bool ExecuteFromName(string ScriptName) - Execute script from ScriptName
- This part maybe somewhat hard to understand so you can read the exmpleScriptHub.cs in SirHurtAPI Demo App.
```
### Bugs (so don't judge me by not telling bugs)
- When enabled auto inject then quit RBX while injecting then the app will lag :/
- If you use isNewVersionAvailable() then u download latest SirHurtAPI.dll to replace this then your app will get error about Access is denied. To fix that you must use an external app to download and replace SirHurtAPI.dll or Wait a second using Thread.Sleep or await Task.Delay then update the dll
### Old bugs (fixed now)
- Execute(string script, true) will cause loop with revert forever that cause user might couldn't execute script. (Sorry for not notice fast bc i forgot my GitHub password XD)
- Won't auto-update sirhurt dll
- SSl/TLS issue on windows 7
- some script write/read file error due to no workspace folder
- Execute won't do if u inject SirHurt in dir1 then u execute in dir2
### Features
- Easier to make SirHurt V4 custom ui.
- Gay code but works
- super cringe api, dosent use timer (Dosen't use System.Windows.Forms except intergated SCript Hub.).
- DA WARUDOOOOOOOOOO
- No axon (go check it its open source and theres no pipe lol)
- Enterprise-sama
### Changelog
```
- v1.0.6.0 | it's been a while.
+ Updated Inject URL (from asshurthosting.pw to sirhurt.pw)
+ Updated how to download DLL (No outdated version error anymore!)
* Edited class Scripts:
<< These things below are removed. >>
+ bool OwlHub() - Execute Owl Hub and return true if sucess and false if failed
+ bool FluxBreak() - Execute FluxBreak and return true if sucess and false if failed
+ bool KiwiiDecompiler() - Execute Kiwii's Decompiler and return true if sucess and false if failed
+ bool UnNamedESP() - Execute UnNamed ESP and return true if sucess and false if failed
+ bool SirHurtScriptHub() - Execute SirHurt Script Hub and return true if sucess and false if failed
+ bool MadCityMenu() - Execute Mad City Menu and return true if sucess and false if failed
+ bool MadCityHaxx() - Execute Mad City Haxx and return true if sucess and false if failed
+ bool PhantomX() - Execute PhantomX and return true if sucess and false if failed
+ bool SteamSniper() - Execute Steam Sniper and return true if sucess and false if failed
+ bool SirHurtMultiTool() - Execute SirHurt Multi Tool and return true if sucess and false if failed
+ bool ScriptHunter() - Execute Script Hunter and return true if sucess and false if failed
+ bool SimpleESP() - Execute Simple ESP and return true if sucess and false if failed
+ bool ProjectBullDukey() - Execute Project Bull-Dukey and return true if sucess and false if failed
+ bool DarkDex() - Execute Dark Dex and return true if sucess and false if failed
+ bool R2SV3() - Execute Remote2Script V3 and return true if sucess and false if failed
+ bool KiwiiPF() - Execute Kiwii's PF and return true if sucess and false if failed
<< Added things >>
+ string[] DLScriptHub() - Download script hub and return all scripts in script hub name.
+ Tuple<string,string> GetScriptInfoFromName(tring ScriptName) - Get ScriptName Info (Image + Desc) and return a Tuple (Item1 = Description, Item2 = Image URL). If this failed it
ll return a empty Tuple (Item1 and Item2 is empty.)
+ bool ExecuteFromName(string ScriptName) - Execute script from ScriptName
- This part will be somewhat hard to understand so you can read the exmpleScriptHub.cs in SirHurtAPI Demo App.
* Edited class SirHurtAPI:
<< Added things >>
+ bool multipleRBXToggle() - Enable/Disable Multiple ROBLOX and return true = enabled, false = disabled.
+ bool oofRBX() - Kill all ROBLOX instance.
+ bool getMultipleRBX() - Get Multiple ROBLOX status and return true = enabled, false = disabled.
- v1.0.5.0
+ YAYAYAYAYAYAY MY WAIFU ENTY GAVE ME VALENTINE CHOCOLATE IN AZURU LANEEE OWOWOWOWOWOWOWO
+ YAYAYAYAYAYAY MY WAIFU ENTY GAVE ME VALENTINE CHOCOLATE IN AZURU LANEEE OWOWOWOWOWOWOWO
+ YAYAYAYAYAYAY MY WAIFU ENTY GAVE ME VALENTINE CHOCOLATE IN AZURU LANEEE OWOWOWOWOWOWOWO
+ YAYAYAYAYAYAY MY WAIFU ENTY GAVE ME VALENTINE CHOCOLATE IN AZURU LANEEE OWOWOWOWOWOWOWO
+ YAYAYAYAYAYAY MY WAIFU ENTY GAVE ME VALENTINE CHOCOLATE IN AZURU LANEEE OWOWOWOWOWOWOWO
* Added class Scripts:
+ bool OwlHub() - Execute Owl Hub and return true if sucess and false if failed
+ bool FluxBreak() - Execute FluxBreak and return true if sucess and false if failed
+ bool KiwiiDecompiler() - Execute Kiwii's Decompiler and return true if sucess and false if failed
+ bool UnNamedESP() - Execute UnNamed ESP and return true if sucess and false if failed
+ bool SirHurtScriptHub() - Execute SirHurt Script Hub and return true if sucess and false if failed
+ bool MadCityMenu() - Execute Mad City Menu and return true if sucess and false if failed
+ bool MadCityHaxx() - Execute Mad City Haxx and return true if sucess and false if failed
+ bool PhantomX() - Execute PhantomX and return true if sucess and false if failed
+ bool SteamSniper() - Execute Steam Sniper and return true if sucess and false if failed
+ bool SirHurtMultiTool() - Execute SirHurt Multi Tool and return true if sucess and false if failed
+ bool ScriptHunter() - Execute Script Hunter and return true if sucess and false if failed
+ bool SimpleESP() - Execute Simple ESP and return true if sucess and false if failed
+ bool ProjectBullDukey() - Execute Project Bull-Dukey and return true if sucess and false if failed
+ bool DarkDex() - Execute Dark Dex and return true if sucess and false if failed
+ bool R2SV3() - Execute Remote2Script V3 and return true if sucess and false if failed
+ bool KiwiiPF() - Execute Kiwii's PF and return true if sucess and false if failed
+ bool OpenScriptHub() - Launch Script Hub (C# Form) and return true if sucess and false if failed
- v1.0.4.1
+ Fixed Execute won't do if u inject SirHurt in dir1 then u execute in dir2
+ This now gives more detailed log in console.
+ chino go update ur shit, there's a bug in sirhurtapi.
- v1.0.4.0
+ Added isNewVersionAvailable()
+ Added Class Experimental:
= 
+ bool GetAutoInject() - Get Auto inject status and return true = enabled, false = disabled.
+ bool AutoInjectToggle() - Enable/Disable auto inject and return true = enabled, false = disabled.
+ bool LaunchExploit() - Download & Inject SirHurt V4 [And FASM + FASMX64 if not exist], return true if sucess and false if not.
=
+ Added setInjectStatus(bool InjectStatus)
+ Execute will throw an exception if you execute a script while its clearing sirhurt.dat. Exception text: [SirHurtAPI]Cleaning sirhurt.dat
+ Improved GetAutoInject(),AutoInjectToggle(),isInjected(),LaunchExploit()
+ vouch for i love shipgirl
- v1.0.3.4
+ Fix Execute(string script, true) will cause loop with revert forever that cause user might couldn't execute script.
- v1.0.3.3
+ Execute and Execute now have bool Forced, check all available function for more info.
- v1.0.3.2
+ DownloadDll now has option to download SirHurtInjector, DownloadDll(true) = Download SirHurtInjector + SirHurt,DownloadDll(false) = Download SirHurt only.
- v1.0.3.1
+ Fixed SSL/TLS issue on Windows 7 [Not tested XD]
+ Auto create Workspace folder when inject :P
- v1.0.3.0
+ Added isInjected()
+ i got a fever sorry so only this buggy feature
- v1.0.2.0
+ Added AutoInjectToggle()
+ Added GetAutoInject()
+ Optimized the dll.
- v1.0.1.0:
+ Added ExecuteFromFile()
+ Optimized the dll.
+ Error should now log to Console but not show message.
- v1.0.0.0:
+ Inital support SirHurt V4
- v1.0.0.0_old:
+ Inital support SirHurt V3
+ Inital release.
```
+ enjoy xd 
+ rin best waifu
+ also go watch horimiya i think its worth a try.
