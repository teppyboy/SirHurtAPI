# SirHurtAPI
 - An API that support SirHurt V4 for developers easier to make SirHurt V4 custom UI
 - Looking for API? [Here](https://raw.githubusercontent.com/teppyboy/SirHurtAPI/master/SirHurtAPI/SirHurtAPI/SirHurtAPI/bin/Debug/SirHurtAPI.dll)
 - Looking for Demo App? [Here](https://github.com/teppyboy/SirHurtAPI/raw/master/SirHurtAPI/SirHurtAPI/SirHurtAPI%20Demo%20App/bin/Debug/SirHurtAPI%20Demo%20App.exe)
## How to use this API
- References -> Add Reference -> Browse -> Choose this DLL -> Done!
## For who wants to update the API do this:
- References -> Select SirHurtAPI -> Remove (or press DEL) -> References -> Add Reference -> Browse -> Choose this DLL -> Done!
- All available function:
```
bool LaunchExploit() - Download & Inject SirHurt V4, return true if sucess and false if not.
bool Execute(string script) - Execute a script, return true if sucess and false if not.
bool DownloadDLL() - Download SirHurt V4 dll (and SirHurtInjector if not exist), return true if sucess and false if not.
bool ExecuteFromFile() - Execute a script from a file, return true if sucess and false if not.
bool AutoInjectToggle() - Enable/Disable auto inject and return true = enabled, false = disabled.
bool GetAutoInject() - Get Auto inject status and return true = enabled, false = disabled.
bool isInjected() - Get injected status and return true = injected, false = not injected.
```
### Bugs (so don't judge me by not telling bugs)
- Nothing (for now) 

### Old bugs (fixed now)
- Won't auto-update sirhurt dll

### Features
- Easier to make SirHurt V4 custom ui.
- Gay code but works
- DA WARUDOOOOOOOOOO
- No axon (go check it its open source lol)

### Changelog
```
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
