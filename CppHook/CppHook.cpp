// CppHook.cpp : ���� DLL Ӧ�ó���ĵ���������
//
#include "stdafx.h"
#include "CppHook.h"

/*SetHook*/

Dll_Export HHOOK SetHook(int hookType, HOOKPROC hookproc)
{
	return SetWindowsHookEx(hookType, hookproc, instance, NULL);
}

/*UnHook*/

Dll_Export BOOL UnHook(HHOOK hook)
{
	if (hook != NULL)
		return UnhookWindowsHookEx(hook);
	else
		return 0;
}

/*CallNext*/

Dll_Export LRESULT CallNext(int nCode, WPARAM wParam, LPARAM lParam)
{
	return CallNextHookEx(NULL, nCode, wParam, lParam);
}
