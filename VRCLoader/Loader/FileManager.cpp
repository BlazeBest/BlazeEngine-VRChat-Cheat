#include "FileManager.h"
#include "include\MinHook.h"
#include <tchar.h>
#include <cstdio>
#include <atlfile.h>

std::string FileManager::ModsDir = ".\\Mods";
//std::vector<std::experimental::filesystem::path> FileManager::CPPMods;
//std::vector<std::string> FileManager::NETMods;

void FileManager::Initialize()
{
	if (!FileUtils::dirExists(ModsDir.c_str()))
		CreateDirectoryA(ModsDir.c_str(), NULL);

	MH_Initialize();
	/*
	for (const auto& file : std::experimental::filesystem::directory_iterator(ModsDir.c_str()))
	{
		if (file.path().extension() == std::string(".dll"))
		{
			TCHAR filepath[MAX_PATH] = { 0 };
			LPTSTR imagename = (LPTSTR)file.path().string().c_str();
			HANDLE filehandle = CreateFileA(imagename, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
			if (filehandle != INVALID_HANDLE_VALUE)
			{
				HANDLE filemappinghandle = CreateFileMappingA(filehandle, NULL, PAGE_READONLY, 0, 0, NULL);
				if (filemappinghandle != INVALID_HANDLE_VALUE)
				{
					BYTE* baseaddr = (BYTE*)MapViewOfFile(filemappinghandle, FILE_MAP_READ, 0, 0, 0);
					if (baseaddr)
					{
						IMAGE_DOS_HEADER* dos_header = (IMAGE_DOS_HEADER*)baseaddr;
						IMAGE_NT_HEADERS* nt_headers = (IMAGE_NT_HEADERS*)((BYTE*)dos_header + dos_header->e_lfanew);
						if (nt_headers->Signature == IMAGE_NT_SIGNATURE)
						{
							DWORD cor20_header_loc = nt_headers->OptionalHeader.DataDirectory[IMAGE_DIRECTORY_ENTRY_COM_DESCRIPTOR].VirtualAddress;
							if (cor20_header_loc)
							{
								IMAGE_SECTION_HEADER* section_header = (IMAGE_SECTION_HEADER*)((BYTE*)nt_headers + sizeof(IMAGE_NT_HEADERS));
								IMAGE_COR20_HEADER* cor20_header = (IMAGE_COR20_HEADER*)((BYTE*)dos_header + GetActualAddressFromRVA(section_header, nt_headers, cor20_header_loc));
								if (cor20_header)
									NETMods.push_back(file.path().string());
								else
									CPPMods.push_back(file.path());
							}
							else
								CPPMods.push_back(file.path());
						}
						UnmapViewOfFile(baseaddr);
					}
					CloseHandle(filemappinghandle);
				}
				CloseHandle(filehandle);
			}
		}
	}
	*/
}

/*
void FileManager::LoadCPP(void (*fn)(const wchar_t*))
{
	if (!CPPMods.empty())
		for (const auto& file : CPPMods)
			(*fn)(file.c_str());
			
}

DWORD FileManager::GetActualAddressFromRVA(IMAGE_SECTION_HEADER* pSectionHeader, IMAGE_NT_HEADERS* pNTHeaders, DWORD dwRVA)
{
	DWORD dwRet = 0;
	for (int j = 0; j < pNTHeaders->FileHeader.NumberOfSections; j++, pSectionHeader++)
	{
		DWORD cbMaxOnDisk = min(pSectionHeader->Misc.VirtualSize, pSectionHeader->SizeOfRawData);
		DWORD startSectRVA, endSectRVA;
		startSectRVA = pSectionHeader->VirtualAddress;
		endSectRVA = startSectRVA + cbMaxOnDisk;
		if ((dwRVA >= startSectRVA) && (dwRVA < endSectRVA))
		{
			dwRet = (pSectionHeader->PointerToRawData) + (dwRVA - startSectRVA);
			break;
		}
	}
	return dwRet;
}
*/