#include "pch.h"



#pragma region ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~1
HHOOK g_hHook = nullptr;
LRESULT CALLBACK fn_HookProc(int nCode, WPARAM wParam, LPARAM lParam)
{
	if (nCode == HCBT_CREATEWND)
	{
		LPCBT_CREATEWNDA lpcWnd = (LPCBT_CREATEWNDA)lParam;
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

constexpr BYTE g_uMaxOpacity = 30;


HWND fn_FindWindowHandle(HWND hWnd)
{
	if (hWnd == nullptr) return nullptr;

	const DWORD dwCheck = WS_CAPTION | WS_BORDER | WS_DLGFRAME | WS_SYSMENU;
	DWORD dwStyle;

	HWND hWndCurrent = hWnd;
	HWND hWndNext = nullptr;
	while (true)
	{
		dwStyle = GetWindowLongA(hWndCurrent, GWL_STYLE);
		if ((dwStyle & dwCheck) == dwCheck)
		{
			break;
		}

		hWndNext = GetParent(hWndCurrent);
		if (hWndNext == nullptr)
		{
			break;
		}
		else
		{
			hWndCurrent = hWndNext;
		}
	}

	//Last window check
	dwStyle = GetWindowLongA(hWndCurrent, GWL_STYLE);
	if ((dwStyle & dwCheck) != dwCheck)
	{
		hWndCurrent = nullptr;
	}

	return hWndCurrent;
}

bool fn_GetProcessName(HWND hWnd, WNDINFO* pWndInfo)
{
	DWORD dwProcessId;
	DWORD dwResult = GetWindowThreadProcessId(hWnd, &dwProcessId);
	if (dwResult == 0)
	{
		return false;
	}

	HANDLE hProcess = OpenProcess(PROCESS_QUERY_INFORMATION, false, dwProcessId);
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

bool fn_GetTwoStyles(HWND hWnd, WNDINFO* pWndInfo)
{
	pWndInfo->dwStyle = GetWindowLongA(hWnd, GWL_STYLE);	
	DWORD dwExStyle = GetWindowLongA(hWnd, GWL_EXSTYLE);
	if ((dwExStyle & WS_EX_LAYERED) != WS_EX_LAYERED)
	{
		LONG dwNewExStyle = dwExStyle | WS_EX_LAYERED;
		SetWindowLongA(hWnd, GWL_EXSTYLE, dwNewExStyle);
		dwExStyle = dwNewExStyle;
	}
	pWndInfo->dwExStyle = dwExStyle;

	return true;
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

bool fn_SetCaptionText(HWND hWnd, WNDINFO* pWndInfo)
{
	bool bResult = SetWindowTextA(hWnd, pWndInfo->lpszCaption);
	return bResult;
}

bool fn_GetOpacityValue(HWND hWnd, WNDINFO* pWndInfo)
{
	COLORREF crKey{ }; BYTE btAlpha{ }; DWORD dwFlags{ };
	bool bResult = GetLayeredWindowAttributes(hWnd, &crKey, &btAlpha, &dwFlags);
	if (bResult)
	{
		if (btAlpha < g_uMaxOpacity)
		{
			btAlpha = 255;
		}
		pWndInfo->uOpacity = btAlpha;
		return true;
	}
	else
	{
		return false;
	}
}

bool fn_SetOpacityValue(HWND hWnd, WNDINFO* pWndInfo)
{
	COLORREF crKey{ }; BYTE btAlpha{ pWndInfo->uOpacity }; DWORD dwFlags{ LWA_ALPHA };
	if (btAlpha < g_uMaxOpacity)
	{
		btAlpha = g_uMaxOpacity;
	}
	bool bResult = SetLayeredWindowAttributes(hWnd, crKey, btAlpha, LWA_ALPHA);
	return bResult;
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

bool fn_SetWindowRect(HWND hWnd, WNDINFO* pWndInfo)
{
	//bool bResult = SetWindowPos(hWnd, 0,
	//	pWndInfo->nLeft, pWndInfo->nTop,
	//	pWndInfo->nWidth, pWndInfo->nHeight, SWP_NOZORDER);
	bool bResult = MoveWindow(hWnd,
			pWndInfo->nLeft, pWndInfo->nTop,
			pWndInfo->nWidth, pWndInfo->nHeight, true);
	return bResult;
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

void fn_SetOtherInfo(HWND hWnd, WNDINFO* pWndInfo)
{
	DWORD dwStyle = GetWindowLongA(hWnd, GWL_STYLE);
	DWORD dwExStyle = GetWindowLongA(hWnd, GWL_EXSTYLE);

	if (pWndInfo->bMinimizeBox)
	{
		dwStyle |= WS_MINIMIZEBOX;
	}
	else
	{
		dwStyle &= ~WS_MINIMIZEBOX;
	}

	if (pWndInfo->bMaximizeBox)
	{
		dwStyle |= WS_MAXIMIZEBOX;
	}
	else
	{
		dwStyle &= ~WS_MAXIMIZEBOX;
	}

	if (pWndInfo->bResizable)
	{
		dwStyle |= WS_THICKFRAME;
	}
	else
	{
		dwStyle &= ~WS_THICKFRAME;
	}

	bool bChangedTopMost = pWndInfo->bTopMost != ((dwExStyle & WS_EX_TOPMOST) == WS_EX_TOPMOST);
	if (bChangedTopMost)
	{
		if (pWndInfo->bTopMost)
		{
			dwExStyle |= WS_EX_TOPMOST;
		}
		else
		{
			dwExStyle &= ~WS_EX_TOPMOST;
		}
	}

	SetWindowLongA(hWnd, GWL_STYLE, dwStyle);
	SetWindowLongA(hWnd, GWL_EXSTYLE, dwExStyle);
	if (bChangedTopMost)
	{
		if (pWndInfo->bTopMost)
		{
			SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
		}
		else
		{
			SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
		}
	}

	pWndInfo->dwStyle = dwStyle;
	pWndInfo->dwExStyle = dwExStyle;
}

void fn_WorkCore(HWND hWndTarget, WNDINFO* pWndInfo)
{
	memset(pWndInfo, 0, sizeof(WNDINFO));
	pWndInfo->hInstance = (HINSTANCE)GetWindowLongA(hWndTarget, GWL_HINSTANCE);
	pWndInfo->hWnd = hWndTarget;
	GetClassNameA(hWndTarget, pWndInfo->lpszClassName, g_bsz256);
	fn_GetProcessName(hWndTarget, pWndInfo);
	fn_GetTwoStyles(hWndTarget, pWndInfo);
	fn_GetCaptionText(hWndTarget, pWndInfo);
	fn_GetOpacityValue(hWndTarget, pWndInfo);
	fn_GetWindowRect(hWndTarget, pWndInfo);
	fn_GetOtherInfo(hWndTarget, pWndInfo);
}

EXPORTED_METHOD bool WINAPI fn_WorkRoll(LONG nx, LONG ny, WNDINFO* pWndInfo)
{
	POINT pt{ nx, ny };
	HWND hWndBegin = WindowFromPoint(pt);
	HWND hWndTarget = fn_FindWindowHandle(hWndBegin);
	if (hWndTarget == nullptr)
	{
		return false;
	}
	else
	{
		fn_WorkCore(hWndTarget, pWndInfo);
		return true;
	}
}

EXPORTED_METHOD bool WINAPI fn_UpdateRoll(HWND hWndTarget, WNDINFO* pWndInfo)
{
	if (hWndTarget == nullptr)
	{
		return false;
	}
	else
	{
		fn_WorkCore(hWndTarget, pWndInfo);
		return true;
	}
}

EXPORTED_METHOD bool WINAPI fn_ApplyRoll(HWND hWndTarget, WNDINFO* pWndInfo)
{
	fn_SetCaptionText(hWndTarget, pWndInfo);
	fn_SetOpacityValue(hWndTarget, pWndInfo);
	fn_SetWindowRect(hWndTarget, pWndInfo);
	fn_SetOtherInfo(hWndTarget, pWndInfo);

	return true;
}
#pragma endregion
