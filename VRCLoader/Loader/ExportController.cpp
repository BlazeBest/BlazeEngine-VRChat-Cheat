#include "Exports.h"
#include "include\MinHook.h"
#include "..\InternalHelpers.hpp"
#include "VRCLoader.h"
#include "FileManager.h"


IL2CPPDomain* vrcloader_get_domain()
{
	return VRCLoader::mdIL2CPPDomain;
}

void* VRC_PInvoke(void* orig, void* arg1, void* arg2, void* arg3, void* arg4, void* arg5, void* arg6, void* arg7, void* arg8, void* arg9)
{
    return ((void* (*) (void*, void*, void*, void*, void*, void*, void*, void*, void*))orig)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
}

void VRC_CreateHook(LPVOID pTarget, LPVOID pDetour, LPVOID *ppOrig)
{
#if (DEBUG)
	switch (MH_CreateHook(pTarget, pDetour, ppOrig)) {
    case MH_UNKNOWN:
        ConsoleUtils::Log("Patch: Unknown");
        break;
    case MH_OK:
        ConsoleUtils::Log("Patch: OK");
        MH_EnableHook(pTarget);
        break;
    case MH_ERROR_ALREADY_INITIALIZED:
        ConsoleUtils::Log("Patch: ERROR -> ALREADY INITIALIZED");
        break;
    case MH_ERROR_NOT_INITIALIZED:
        ConsoleUtils::Log("Patch: ERROR -> NOT INITIALIZED");
        break;
    case MH_ERROR_ALREADY_CREATED:
        ConsoleUtils::Log("Patch: ERROR -> ALREADY CREATED");
        break;
    case MH_ERROR_NOT_CREATED:
        ConsoleUtils::Log("Patch: ERROR -> NOT CREATED");
        break;
    case MH_ERROR_ENABLED:
        ConsoleUtils::Log("Patch: ERROR -> ENABLED");
        break;
    case MH_ERROR_DISABLED:
        ConsoleUtils::Log("Patch: ERROR -> DISABLED");
        break;
    case MH_ERROR_NOT_EXECUTABLE:
        ConsoleUtils::Log("Patch: ERROR -> NOT EXECUTABLE");
        break;
    case MH_ERROR_UNSUPPORTED_FUNCTION:
        ConsoleUtils::Log("Patch: ERROR -> UNSUPPORTED FUNCTION");
        break;
    case MH_ERROR_MEMORY_ALLOC:
        ConsoleUtils::Log("Patch: ERROR -> MEMORY ALLOC");
        break;
    case MH_ERROR_MEMORY_PROTECT:
        ConsoleUtils::Log("Patch: ERROR -> MEMORY PROTECT");
        break;
    case MH_ERROR_MODULE_NOT_FOUND:
        ConsoleUtils::Log("Patch: ERROR -> MODULE NOT FOUND");
        break;
    case MH_ERROR_FUNCTION_NOT_FOUND:
        ConsoleUtils::Log("Patch: ERROR -> FUNCTION NOT FOUND");
        break;
    }
#else
    if (MH_CreateHook(pTarget, pDetour, ppOrig) == MH_OK)
        MH_EnableHook(pTarget);
#endif
}
/*
size_t vrcloader_get_net_mod_count()
{
	return FileManager::NETMods.size();
}

const char* vrcloader_get_net_mod(UINT index)
{
	return FileManager::NETMods.at(index).c_str();
}
*/
