#include "VRCLoader.h"
#include "Exports.h"
#include "FileManager.h"

HMODULE VRCLoader::hGameAssembly = NULL;
IL2CPPDomain* VRCLoader::mdIL2CPPDomain = NULL;
bool VRCLoader::bLoadedMods = false;

void VRCLoader::Init_Loader()
{
#if (DEBUG)
	ConsoleUtils::Log("Started VRCLoader!");
#endif
	FileManager::Initialize();
	if (!Hooking::fnLoadLibraryW)
		Hooking::fnLoadLibraryW = LoadLibraryW;
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	if (!Hooking::fnLoadLibraryW)
		return;
#if (DEBUG)
	ConsoleUtils::Log("Installing LLW hooks...");
#endif
	DetourAttach(&(LPVOID&)Hooking::fnLoadLibraryW, Hooking::_LoadLibraryW);
	DetourTransactionCommit();
}

void VRCLoader::Destroy_Loader()
{
	CLRHost::ReleaseCLR();
}

void VRCLoader::Setup()
{
	//if (FileUtils::fileExists("NET_SDK.dll"))
	//	LoadLibrary("NET_SDK.dll");
	//else
	//	ConsoleUtils::Log("Failed to find NET_SDK.dll");

	if (!VRCLoader::mdIL2CPPDomain)
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to find mono domain! Aborting...");
#endif
		return;
	}
	CLRHost::HostCLR();
}

void VRCLoader::LoadAssemblies()
{
	bLoadedMods = true;
	//ConsoleUtils::Log(("Found " + std::to_string(FileManager::CPPMods.size()) + " CPP Mods").c_str());
	//FileManager::LoadCPP(LoadCPPAssembly);
	//ConsoleUtils::Log("Successfully loaded CPP Mods");

	//ConsoleUtils::Log(("Found " + std::to_string(FileManager::NETMods.size()) + " NET Mods").c_str());
	if (CLRHost::Initialize())
	{
#if (DEBUG)
		ConsoleUtils::Log("Successfully loaded all NET Mods");
#endif
	}
	else
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to load NET Mods");
#endif
	}
}

void VRCLoader::LoadCPPAssembly(const wchar_t* file)
{
	std::wcout << "Loading CPP Mod " << file << std::endl;
	LoadLibraryW(file);
}

LoadLibraryW_t Hooking::fnLoadLibraryW = NULL;
HMODULE __stdcall Hooking::_LoadLibraryW(LPCWSTR lpLibFileName) {
	HMODULE lib = fnLoadLibraryW(lpLibFileName);
	std::wcout << "Loaded assembly W: " << lpLibFileName << std::endl;
	if (wcsstr(lpLibFileName, L"GameAssembly.dll") != 0)
	{
#if (DEBUG)
		ConsoleUtils::Log("Captured GameAssembly.dll LLW! Starting hooks...");
#endif
		VRCLoader::hGameAssembly = lib;
		Build_IL2CPP(lib);
		if (!Hooking::fnil2cpp_init)
			Hooking::fnil2cpp_init = (il2cpp_init_t)GetProcAddress(VRCLoader::hGameAssembly, "il2cpp_init");
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());
		if (!Hooking::fnil2cpp_init)
		{
#if (DEBUG)
			ConsoleUtils::Log("Installing IL2CPP hooks NOT FOUND!");
#endif
			return lib;
		}
		VRCLoader::mdIL2CPPDomain = (IL2CPPDomain*)Hooking::fnil2cpp_init;
		if (!VRCLoader::mdIL2CPPDomain)
		{
#if (DEBUG)
			ConsoleUtils::Log("Installing IL2CPP hooks DOMAIN NOT FOUND!");
#endif
			return lib;
		}
#if (DEBUG)
		ConsoleUtils::Log("Installing IL2CPP hooks...");
#endif
		VRCLoader::Setup();
		// VRCLoader::LoadAssemblies();

		//DetourAttach(&(LPVOID&)Hooking::fnil2cpp_init, _il2cpp_init);
		//DetourTransactionCommit();
	}
	if (wcsstr(lpLibFileName, L"dxgi.dll") != 0 && !VRCLoader::bLoadedMods)
	{
#if (DEBUG)
		ConsoleUtils::Log("Unity has been loaded!");
#endif
		VRCLoader::LoadAssemblies();

#if (DEBUG)
		ConsoleUtils::Log("Game has been loaded!");
#endif
		DetourTransactionBegin();
		DetourUpdateThread(GetCurrentThread());
#if (DEBUG)
		ConsoleUtils::Log("Removing LLW hooks...");
#endif
		DetourDetach(&(LPVOID&)fnLoadLibraryW, _LoadLibraryW);
		DetourTransactionCommit();
		CLRHost::OnApplicationStart();
	}
	return lib;
}
il2cpp_init_t Hooking::fnil2cpp_init = NULL;
/*
IL2CPPDomain* Hooking::_il2cpp_init(const char* name)
{
	IL2CPPDomain* domain = Hooking::fnil2cpp_init(name);
	VRCLoader::mdIL2CPPDomain = domain;
	std::cout << "Captured IL2CPPDomain with name " << name << std::endl;
	DetourTransactionBegin();
	DetourUpdateThread(GetCurrentThread());
	if (!domain)
	{
		ConsoleUtils::Log("_il2cpp_init DOMAIN NOT FOUND!!!");
		return domain;
	}
	ConsoleUtils::Log("Removing IL2CPP hooks...");
	DetourDetach(&(LPVOID&)Hooking::fnil2cpp_init, _il2cpp_init);
	DetourTransactionCommit();
	VRCLoader::Setup();
	return domain;
}
*/