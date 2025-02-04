#include "pch.h"



#pragma region ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~1
HHOOK g_hHook = nullptr;
LRESULT CALLBACK fn_HookProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	if (nCode == HCBT_CREATEWND)
	{
		LPCBT_CREATEWND lpcWnd = (LPCBT_CREATEWND)lParam;
		LPCREATESTRUCTA lpcs = lpcWnd->lpcs;

		if (lpcs->lpszClass == (LPCSTR)(ATOM)32770)  // #32770 = dialog box class
		{
			RECT rcp{ };
			GetWindowRect(lpcs->hwndParent, &rcp);
			lpcs->x = rcp.left + ((rcp.right - rcp.left) - lpcs->cx) / 2;
			lpcs->y = rcp.top + ((rcp.bottom - rcp.top) - lpcs->cy) / 2;
		}
	}

	LRESULT lrs = CallNextHookEx(g_hHook, nCode, wParam, lParam);
	return lrs;
}


EXPORTED_METHOD int WINAPI fn_MessageBox(HWND hWnd, LPCSTR lpText, LPCSTR lpCaption, UINT uType)
{
	const DWORD dwThreadId = GetCurrentThreadId();
	g_hHook = SetWindowsHookExA(WH_CBT, fn_HookProc, nullptr, dwThreadId);

	int nRes = MessageBoxExA(hWnd, lpText, lpCaption, uType, 0);
	UnhookWindowsHookEx(g_hHook);

	return nRes;
}
#pragma endregion



#pragma region ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~2
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

HWND fn_GetWindowHandle(HWND hWnd)
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
	HWND hWndTarget = fn_GetWindowHandle(hWndBegin);

	WNDINFO wndInfo;
	WNDINFO* pWndInfo = &wndInfo;
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

EXPORTED_METHOD bool WINAPI fn_GetWindowInfo(HWND hWndTarget, WNDINFO* pWndInfo)
{
	pWndInfo->hInstance = (HINSTANCE)GetWindowLongA(hWndTarget, GWL_HINSTANCE);
	pWndInfo->hWnd = hWndTarget;
	GetClassNameA(
	sprintf_s(pWndInfo->lpszClassName, g_bsz256, "Win32Reka__vb");
	sprintf_s(pWndInfo->lpszProcessName, g_bsz256, "Win32Reka__vb");
	pWndInfo->dwStyle = 0x16ca0000;
	pWndInfo->dwExStyle = 0x00050108;
	sprintf_s(pWndInfo->lpszCaption, g_bsz512, "Win32Reka__vb  v1.50");
	pWndInfo->uOpacity = 255;
	pWndInfo->nLeft = 100;
	pWndInfo->nTop = 40;
	pWndInfo->nWidth = 400;
	pWndInfo->nHeight = 400;
	pWndInfo->bMinimizeBox = false;
	pWndInfo->bMaximizeBox = false;
	pWndInfo->bResizable = false;
	pWndInfo->bTopMost = false;

	//wndInfo->hWnd = hWndTarget;
	//GetClassNameA(hWndTarget, wndInfo->lpszClassName, g_bsz256);
	////GetProcessInfo
	//wndInfo->dwStyle = GetWindowLongA(hWndTarget, GWL_STYLE);
	//wndInfo->dwExStyle = GetWindowLongA(hWndTarget, GWL_EXSTYLE);
	
	//CreateWindowExA(
	//WS_BORDER
	//DWORD
	//GetWindowLongA(hWndTarget, GWL_STYLE);
	//SetWindowLongA(
	return false;
}
#pragma endregion
