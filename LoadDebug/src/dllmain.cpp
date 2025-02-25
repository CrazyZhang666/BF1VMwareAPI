// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "framework.h"

// 内存补丁
void MemPath(__int64 patch, BYTE value)
{
	DWORD oldProtect;
	BYTE* lpAddress;

	lpAddress = (BYTE*)patch;
	VirtualProtect(lpAddress, 1, PAGE_EXECUTE_READWRITE, &oldProtect);
	*lpAddress = value;
	VirtualProtect(lpAddress, 1, oldProtect, &oldProtect);
}

// 核心方法
void Core()
{
	// 绕过EAAC启动限制
	HMODULE user32Ptr = GetModuleHandle(L"user32.dll");
	if (user32Ptr != nullptr)
		MemPath((DWORD_PTR)GetProcAddress(user32Ptr, "MessageBoxTimeoutA"), 0xC3);

	HMODULE kernelbasePtr = GetModuleHandle(L"kernelbase.dll");
	if (kernelbasePtr != nullptr)
		MemPath((DWORD_PTR)GetProcAddress(kernelbasePtr, "TerminateProcess"), 0xC3);

	//////////////////////////////////////////////////////////////////////////////////

	//// 关闭显卡驱动检测
	//MemPath(0x1410365CC, 0x90);
	//MemPath(0x1410365CD, 0x90);
	//MemPath(0x1410365D2, 0x90);
	//MemPath(0x1410365D3, 0x90);
	//MemPath(0x14031CDA1, 0x84);

	//// 解锁完整命令控制台
	//MemPath(0x1403396F1, 0x90);
	//MemPath(0x1403396F2, 0x90);
	//MemPath(0x1403396F3, 0x90);
	//MemPath(0x1403396F4, 0x90);
	//MemPath(0x1403396F5, 0x90);
	//MemPath(0x1403396F6, 0x90);
}

// Dll主线程
DWORD WINAPI MainThread(LPVOID lpThreadParameter)
{
	// 核心方法
	Core();

	return TRUE;
}

// Dll加载入口
BOOL APIENTRY DllMain(HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		DisableThreadLibraryCalls(hModule);
		if (HANDLE handle = CreateThread(NULL, NULL, (LPTHREAD_START_ROUTINE)MainThread, hModule, NULL, NULL))
			CloseHandle(handle);
		break;
	case DLL_THREAD_ATTACH:
		break;
	case DLL_THREAD_DETACH:
		break;
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}