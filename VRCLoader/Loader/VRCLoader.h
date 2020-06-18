#pragma once

#include "..\InternalHelpers.hpp"
#include "HookTypes.h"
#include "il2cpp.h"
#include "CLRHost.h"
#include "detours/detours.h"
#include <queue>
#include <functional>

class VRCLoader
{
public:
	static HMODULE hGameAssembly;
	static IL2CPPDomain* mdIL2CPPDomain;

	static bool bLoadedMods;

	static void Init_Loader();
	static void Destroy_Loader();

	static void Setup();
	static void LoadAssemblies();

	static void LoadCPPAssembly(const wchar_t* file);
};

class Hooking
{
public:
	static LoadLibraryW_t fnLoadLibraryW;
	static HMODULE __stdcall _LoadLibraryW(LPCWSTR lpLibFileName);

	static il2cpp_init_t fnil2cpp_init;
	static IL2CPPDomain* _il2cpp_init(const char* name);
};