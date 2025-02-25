#pragma once

#define WIN32_LEAN_AND_MEAN             // 从 Windows 头文件中排除极少使用的内容
// Windows 头文件
#include <windows.h>

#pragma comment(linker, "/export:DirectInput8Create=C:\\WINDOWS\\System32\\dinput8.DirectInput8Create,@1")
#pragma comment(linker, "/export:DllCanUnloadNow=C:\\WINDOWS\\System32\\dinput8.DllCanUnloadNow,@2")
#pragma comment(linker, "/export:DllGetClassObject=C:\\WINDOWS\\System32\\dinput8.DllGetClassObject,@3")
#pragma comment(linker, "/export:DllRegisterServer=C:\\WINDOWS\\System32\\dinput8.DllRegisterServer,@4")
#pragma comment(linker, "/export:DllUnregisterServer=C:\\WINDOWS\\System32\\dinput8.DllUnregisterServer,@5")
#pragma comment(linker, "/export:GetdfDIJoystick=C:\\WINDOWS\\System32\\dinput8.GetdfDIJoystick,@6")