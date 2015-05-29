using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HookKeyV2
{
    public class KeyHook
    {
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void WindowFunc();
        public static event WindowFunc Event_WinFunc;

        [DllImport("CppHook.dll", EntryPoint = "SetHook", CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr SetHook(int hookType, HookProc hookProc);

        [DllImport("CppHook.dll", EntryPoint = "UnHook", CallingConvention = CallingConvention.Cdecl)]
        public extern static bool UnHook(IntPtr hook);

        [DllImport("CppHook.dll", EntryPoint = "CallNext", CallingConvention = CallingConvention.Cdecl)]
        public extern static int CallNext(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        public extern static void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32")]
        public extern static byte MapVirtualKey(byte wCode, int wMap);

        public static IntPtr Hook;
        public static IntPtr GetKeyHook;
        public static int GetKeyCode = -1;

        public static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;
        private static int WM_KEYUP = 0x0101;
        private static int WM_SYSKEYDOWN = 0x0104;
        private static int WM_SYSKEYUP = 0x0105;

        private static bool flag = false;
        /// <summary>
        /// 更改按键
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int ChangeKey(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (flag)
            {
                flag = false;
                return 0;
            }
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (KeyConfig.DicKeys.ContainsKey(vkCode))
                {
                    flag = true;
                    if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
                    {
                        //lParam = (IntPtr)((Keys)KeyConfig.DicKeys[vkCode]);
                        //SendKeys.Send(((Keys)KeyConfig.HashKeys[key]).ToString());
                        keybd_event((byte)((Keys)KeyConfig.DicKeys[vkCode]), MapVirtualKey((byte)((Keys)KeyConfig.DicKeys[vkCode]), 0), 0, 0);
                    }
                    else if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                    {
                        //lParam = (IntPtr)((Keys)KeyConfig.DicKeys[vkCode]);
                        keybd_event((byte)((Keys)KeyConfig.DicKeys[vkCode]), MapVirtualKey((byte)((Keys)KeyConfig.DicKeys[vkCode]), 0), 0x2, 0);
                    }
                    CallNext(nCode, wParam, lParam);
                    return 1;//中断消息
                }

            }
            return 0;//继续
        }
        /// <summary>
        /// 获取按键
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int GetKey(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                GetKeyCode = Marshal.ReadInt32(lParam);
                if (Event_WinFunc != null)
                    Event_WinFunc();
            }
            return 0;
        }
    }
}
