#include "stdafx.h"
extern HINSTANCE instance;
Dll_Export HHOOK SetHook(int hookType, HOOKPROC hookproc);
Dll_Export BOOL UnHook(HHOOK hook);
Dll_Export LRESULT CallNext(int nCode, WPARAM wParam, LPARAM lParam);