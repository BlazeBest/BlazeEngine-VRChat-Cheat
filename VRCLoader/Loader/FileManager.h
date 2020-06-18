#pragma once

#include "..\InternalHelpers.hpp"
#include <fstream>
#include <iostream>
#include <experimental/filesystem>


class FileManager
{
public:
	static std::string ModsDir;
	//static std::vector<std::experimental::filesystem::path> CPPMods;
	//static std::vector<std::string> NETMods;

	static void Initialize();
	//static void LoadCPP(void (*fn)(const wchar_t*));

	//static DWORD GetActualAddressFromRVA(IMAGE_SECTION_HEADER* pSectionHeader, IMAGE_NT_HEADERS* pNTHeaders, DWORD dwRVA);
};