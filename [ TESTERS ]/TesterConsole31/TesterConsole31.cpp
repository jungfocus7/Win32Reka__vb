#pragma once
#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>
//#include <memory.h>
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
	BYTE uOpacity;
	INT nLeft;
	INT nTop;
	INT nWidth;
	INT nHeight;
	BOOL bMinimizeBox;
	BOOL bMaximizeBox;
	BOOL bResizable;
	BOOL bTopMost;
};
struct WNDINFO_tt
{
	HINSTANCE hInstance;
	HWND hWnd;
	CHAR lpszClassName[g_bsz256];
	CHAR lpszProcessName[g_bsz256];
	DWORD dwStyle;
	DWORD dwExStyle;
	CHAR lpszCaption[g_bsz512];
	BYTE uOpacity;
	INT nLeft;
	INT nTop;
	INT nWidth;
	INT nHeight;
	BOOL bMinimizeBox;
	BOOL bMaximizeBox;
	BOOL bResizable;
	BOOL bTopMost;
};

HWND fn_FindWindowHandle(HWND hWnd)
{
	if (hWnd == nullptr) return nullptr;

	HWND hWndParent = nullptr;
	HWND hWndTemp = hWnd;
	while (true)
	{
		hWndTemp = GetParent(hWndTemp);
		if (hWndTemp == nullptr)
		{
			break;
		}
		else
		{
			hWndParent = hWndTemp;
		}
	}

	return hWndParent;
}

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

bool fn_GetOpacityValue(HWND hWnd, WNDINFO* pWndInfo)
{
	LONG dwExStyle = GetWindowLongA(hWnd, GWL_EXSTYLE);
	if ((dwExStyle & WS_EX_LAYERED) != WS_EX_LAYERED)
	{
		LONG dwNewExStyle = dwExStyle | WS_EX_LAYERED;
		SetWindowLongA(hWnd, GWL_EXSTYLE, dwNewExStyle);
	}

	COLORREF crKey{ }; BYTE btAlpha{ }; DWORD dwFlags{ };
	bool bResult = GetLayeredWindowAttributes(hWnd, &crKey, &btAlpha, &dwFlags);
	if (bResult)
	{
		pWndInfo->uOpacity = btAlpha;
		return true;
	}
	else
	{
		return false;
	}
}

bool fn_GetWindowRect(HWND hWnd, WNDINFO* pWndInfo)
{
	RECT rt{ };
	bool bResult = GetWindowRect(hWnd, &rt);
	if (bResult)
	{
		pWndInfo->nLeft = rt.left;
		pWndInfo->nTop = rt.top;
		pWndInfo->nWidth = rt.right - rt.left;
		pWndInfo->nHeight = rt.bottom - rt.top;
		return true;
	}

	return false;
}

bool fn_GetOtherInfo(HWND hWnd, WNDINFO* pWndInfo)
{
	DWORD dwStyle = pWndInfo->dwStyle;
	DWORD dwExStyle = pWndInfo->dwExStyle;

	pWndInfo->bMinimizeBox = (dwStyle & WS_MINIMIZEBOX) == WS_MINIMIZEBOX;
	pWndInfo->bMaximizeBox = (dwStyle & WS_MAXIMIZEBOX) == WS_MAXIMIZEBOX;
	pWndInfo->bResizable = (dwStyle & WS_THICKFRAME) == WS_THICKFRAME;
	pWndInfo->bTopMost = (dwExStyle & WS_EX_TOPMOST) == WS_EX_TOPMOST;

	return true;
}

void fn_WorkRoll(HWND hWndBegin)
{
	HWND hWndTarget = fn_FindWindowHandle(hWndBegin);

	WNDINFO wndInfo;
	WNDINFO* pWndInfo = &wndInfo;
	auto x0 = sizeof(wndInfo);
	auto x1 = sizeof(WNDINFO);
	memset(pWndInfo, 0, sizeof(wndInfo));

	pWndInfo->hInstance = (HINSTANCE)GetWindowLongA(hWndTarget, GWL_HINSTANCE);
	pWndInfo->hWnd = hWndTarget;
	GetClassNameA(hWndTarget, pWndInfo->lpszClassName, g_bsz256);
	fn_GetProcessName(hWndTarget, pWndInfo);
	pWndInfo->dwStyle = GetWindowLongA(hWndTarget, GWL_STYLE);
	pWndInfo->dwExStyle = GetWindowLongA(hWndTarget, GWL_EXSTYLE);
	fn_GetCaptionText(hWndTarget, pWndInfo);
	fn_GetOpacityValue(hWndTarget, pWndInfo);
	fn_GetWindowRect(hWndTarget, pWndInfo);
	fn_GetOtherInfo(hWndTarget, pWndInfo);
}

int main()
{
	/*
	HWND hWndBegin = (HWND)0x00160572;
	fn_WorkRoll(hWndBegin);

	auto x0 = sizeof(WORD);
	auto x1 = sizeof(BYTE);
	*/
	auto x0 = sizeof(WNDINFO_tt);//1076

	printf("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
}