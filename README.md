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
class Experimental:
+ bool GetAutoInject() - Get Auto inject status and return true = enabled, false = disabled.
+ bool AutoInjectToggle() - Enable/Disable auto inject and return true = enabled, false = disabled.
+ bool LaunchExploit() - Download & Inject SirHurt V4 [And FASM + FASMX64 if not exist], return true if sucess and false if not.
```
### Bugs (so don't judge me by not telling bugs)
- When enabled auto inject then quit RBX while injecting then the app will lag :/

### Old bugs (fixed now)
- Execute(string script, true) will cause loop with revert forever that cause user might couldn't execute script. (Sorry for not notice fast bc i forgot my GitHub password XD)
- Won't auto-update sirhurt dll
- SSl/TLS issue on windows 7
- some script write/read file error due to no workspace folder

### Features
- Easier to make SirHurt V4 custom ui.
- Gay code but works
- super cringe api, dosent use timer.
- DA WARUDOOOOOOOOOO
- No axon (go check it its open source and theres no pipe lol)

### Changelog
```
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
enjoy xd 
