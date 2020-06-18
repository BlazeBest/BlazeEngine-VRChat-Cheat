#include "CLRHost.h"
bool CLRHost::clrRunning = false;

ICLRMetaHost* CLRHost::clrInstance = NULL;
ICLRRuntimeInfo* CLRHost::runtimeInfo = NULL;
ICLRRuntimeHost* CLRHost::runtimeHost = NULL;
ICLRControl* CLRHost::clrControl = NULL;

INetDomain* CLRHost::netDomain = NULL;

bool CLRHost::HostCLR()
{
#if (DEBUG)
	ConsoleUtils::Log("Setting up CLR host...");

	ConsoleUtils::Log("Getting CLR meta host...");
#endif
	if (CLRCreateInstance(CLSID_CLRMetaHost, IID_ICLRMetaHost, (LPVOID*)& clrInstance) != S_OK)
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to create meta host instance!");
#endif
		return false;
	}
#if (DEBUG)
	ConsoleUtils::Log("Getting CLR runtime information...");
#endif
	if (clrInstance->GetRuntime(L"v4.0.30319", IID_ICLRRuntimeInfo, (LPVOID*)& runtimeInfo) != S_OK)
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to get runtime information!");
#endif
		return false;
	}
#if (DEBUG)
	ConsoleUtils::Log("Getting CLR runtime host...");
#endif
	if (runtimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_ICLRRuntimeHost, (LPVOID*)& runtimeHost) != S_OK)
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to get runtime host interface!");
#endif
		return false;
	}
#if (DEBUG)
	ConsoleUtils::Log("Creating custom CLR IHostControl...");
#endif
	NetHostControl* hostControl = new NetHostControl();
	if (runtimeHost->SetHostControl((IHostControl*)hostControl) != S_OK)
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to create custom CLR IHostControl!");
#endif
		delete hostControl;
		return false;
	}
#if (DEBUG)
	ConsoleUtils::Log("Grabbing CLR controller...");
#endif
	if (runtimeHost->GetCLRControl(&clrControl) != S_OK)
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to grab CLR controller!");
#endif
		return false;
	}
#if (DEBUG)
	ConsoleUtils::Log("Setting custom AppDomain manager...");
#endif
	if (clrControl->SetAppDomainManagerType(L"BlazeSDK", L"BlazeSDK.Domain.DomainManager") != S_OK)
	{
#if (DEBUG)
		ConsoleUtils::Log("Failed to set custom AppDomain manager!");
#endif
		return false;
	}
#if (DEBUG)
	ConsoleUtils::Log("Starting CLR host...");
#endif
	if (runtimeHost->Start() != S_OK) {
#if (DEBUG)
		ConsoleUtils::Log("Failed to start CLR host!");
#endif
		return false;
	}

#if (DEBUG)
	ConsoleUtils::Log("Saving CLR interface reference...");
#endif
	netDomain = hostControl->GetINetDomain();

#if (DEBUG)
	ConsoleUtils::Log("CLR host up and running! We have .NET :)");
#endif
	clrRunning = true;
	return true;
}

void CLRHost::ReleaseCLR()
{
	if (!clrRunning)
		return;
	runtimeHost->Stop();
	runtimeHost->Release();
	runtimeInfo->Release();
	clrInstance->Release();
}

bool CLRHost::Initialize()
{
	if (!clrRunning)
		return false;
	return (netDomain->Initialize() == S_OK);
}

bool CLRHost::OnApplicationStart()
{
	if (!clrRunning)
		return false;
	return (netDomain->OnApplicationStart() == S_OK);
}