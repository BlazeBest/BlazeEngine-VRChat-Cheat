#pragma once

#include "..\InternalHelpers.hpp"
#include <Unknwn.h>

#define INETDomain_GUID "E86B87C8-5FC2-442E-A2AB-EAB2E594FEAE"

struct __declspec(uuid(INETDomain_GUID)) INetDomain;

struct INetDomain : IUnknown
{
	virtual HRESULT __stdcall Initialize() = 0;
	virtual HRESULT __stdcall OnApplicationStart() = 0;
};