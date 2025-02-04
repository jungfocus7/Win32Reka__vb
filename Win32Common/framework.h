#pragma once

// 거의 사용되지 않는 내용을 Windows 헤더에서 제외합니다.
#define WIN32_LEAN_AND_MEAN
#define no_init_all deprecated


//~~~~ Windows 헤더 파일
#include <Windows.h>
//#include <atlstr.h>
#include <shlwapi.h>
#pragma comment(lib, "shlwapi")

//~~~~ C언어
#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
//#include <string.h>
//#include <memory.h>
//#include <wchar.h>
//#include <time.h>


//~~~~ STL
//#include <sstream>
//#include <string>
//#include <iomanip>
//#include <vector>


//~~~~
//typedef std::wostringstream c_woss;
//typedef std::wstring c_wstr;


//~~~~
#define EXPORTED_METHOD extern "C" __declspec(dllexport)