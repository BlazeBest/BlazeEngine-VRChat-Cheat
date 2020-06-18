#pragma once
#include "il2cpp.h"

extern "C"
{
	__declspec(dllexport) IL2CPPDomain* __stdcall vrcloader_get_domain();
	__declspec(dllexport) void* __stdcall VRC_PInvoke(void* orig, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8, void* arg9);
	__declspec(dllexport) void __stdcall VRC_CreateHook(LPVOID pTarget, LPVOID pDetour, LPVOID *ppOrig);
	//__declspec(dllexport) size_t __stdcall vrcloader_get_net_mod_count();
	//__declspec(dllexport) const char* __stdcall vrcloader_get_net_mod(UINT index);
}