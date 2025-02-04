#pragma once
#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>
#include <memory.h>
//#include <stdint.h>
//#include <string.h>
//#include <tlhelp32.h>
#include <shlwapi.h>
#pragma comment(lib, "shlwapi")

constexpr size_t g_bsz256 = 256;
constexpr size_t g_bsz512 = 512;
struct WNDINFO
{
	HINSTANCE hInstance;
	HWND hWnd;
	CHAR lpszClassName[g_bsz256];
	CHAR lpszProcessName[g_bsz256];
	DWORD dwStyle;
	DWORD dwExStyle;
	CHAR lpszCaption[g_bsz512];
	WORD uOpacity;
	INT nLeft;
	INT nTop;
	INT nWidth;
	INT nHeight;
	BOOL bMinimizeBox;
	BOOL bMaximizeBox;
	BOOL bResizable;
	BOOL bTopMost;
};
bool fn_GetProcessName(HWND hWnd, WNDINFO* pWndInfo)
{
	DWORD dwProcessId;
	DWORD dwResult = GetWindowThreadProcessId(hWnd, &dwProcessId);
	if (dwResult == 0)
	{
		return false;
	}

	HANDLE hProcess = OpenProcess(PROCESS_QUERY_INFORMATION, FALSE, dwProcessId);
	if (hProcess == nullptr)
	{
		return false;
	}

	LPSTR lpExeName = pWndInfo->lpszProcessName;
	DWORD dwSize = g_bsz256;
	bool bOk = QueryFullProcessImageNameA(hProcess, 0, lpExeName, &dwSize);
	bool bResult = false;
	if (bOk)
	{
		LPSTR lps1 = PathFindFileNameA(lpExeName);
		strcpy_s(lpExeName, g_bsz256, lps1);
		bResult = true;
	}

	CloseHandle(hProcess);
	return bResult;
}
bool fn_GetCaptionText(HWND hWnd, WNDINFO* pWndInfo)
{
	int nLen = GetWindowTextLengthA(hWnd);
	if (nLen > 0)
	{
		GetWindowTextA(hWnd, pWndInfo->lpszCaption, g_bsz512);
		return true;
	}

	return false;
}
int main()
{
	//WNDINFO wndInfo{ };
	//wndInfo.hInstance = (HINSTANCE)0x001d0000;
	//wndInfo.hWnd = (HWND)0x00450646;
	//sprintf_s(wndInfo.lpszClassName, g_bsz256, "Win32Reka__vb");
	//sprintf_s(wndInfo.lpszProcessName, g_bsz256, "Win32Reka__vb");
	//wndInfo.dwStyle = 0x16ca0000;
	//wndInfo.dwExStyle = 0x00050108;
	//sprintf_s(wndInfo.lpszCaption, g_bsz512, "Win32Reka__vb  v1.50");
	//wndInfo.uOpacity = 255;
	//wndInfo.nLeft = 100;
	//wndInfo.nTop = 40;
	//wndInfo.nWidth = 400;
	//wndInfo.nHeight = 400;
	//wndInfo.bMinimizeBox = false;
	//wndInfo.bMaximizeBox = false;
	//wndInfo.bResizable = false;
	//wndInfo.bTopMost = false;

	HWND hWndTarget = (HWND)0x00450646;	

	WNDINFO wndInfo;
	WNDINFO* pWndInfo = &wndInfo;
	memset(pWndInfo, 0, sizeof(wndInfo));

	pWndInfo->hInstance = (HINSTANCE)GetWindowLongA(hWndTarget, GWL_HINSTANCE);
	pWndInfo->hWnd = hWndTarget;
	GetClassNameA(hWndTarget, pWndInfo->lpszClassName, g_bsz256);
	fn_GetProcessName(hWndTarget, pWndInfo);
	pWndInfo->dwStyle = GetWindowLongA(hWndTarget, GWL_STYLE);
	pWndInfo->dwExStyle = GetWindowLongA(hWndTarget, GWL_EXSTYLE);
	//sprintf_s(pWndInfo->lpszCaption, g_bsz512, "Win32Reka__vb  v1.50");
	fn_GetCaptionText(hWndTarget, pWndInfo);
	pWndInfo->uOpacity = 255;
	pWndInfo->nLeft = 100;
	pWndInfo->nTop = 40;
	pWndInfo->nWidth = 400;
	pWndInfo->nHeight = 400;
	pWndInfo->bMinimizeBox = false;
	pWndInfo->bMaximizeBox = false;
	pWndInfo->bResizable = false;
	pWndInfo->bTopMost = false;

	printf("~~~~~~~~~~");
}