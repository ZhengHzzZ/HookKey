using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HookKey
{
    public class KeyHook
    {
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("CppHook.dll")]
        public extern static IntPtr SetHook(int hookType, HookProc hookProc);

        [DllImport("CppHook.dll")]
        public extern static bool UnHook(IntPtr hook);

        [DllImport("CppHook.dll")]
        public extern static int CallNext(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        public extern static void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32")]
        public extern static byte MapVirtualKey(byte wCode, int wMap);

        public static IntPtr Hook;

        private static int WM_KEYDOWN = 0x0100;
        private static int WM_KEYUP = 0x0101;
        private static int WM_SYSKEYDOWN = 0x0104;
        private static int WM_SYSKEYUP = 0x0105;

        /// <summary>
        /// 更改按键
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static int ChangeKey(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                if (KeyConfig.HashKeys.Contains(key))
                {
                    if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
                    {
                        //lParam = (IntPtr)((Keys)KeyConfig.HashKeys[key]);
                        //SendKeys.Send(((Keys)KeyConfig.HashKeys[key]).ToString());
                        keybd_event((byte)((Keys)KeyConfig.HashKeys[key]), MapVirtualKey((byte)((Keys)KeyConfig.HashKeys[key]), 0), 0, 0);
                    }
                    else if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                    {
                        keybd_event((byte)((Keys)KeyConfig.HashKeys[key]), MapVirtualKey((byte)((Keys)KeyConfig.HashKeys[key]), 0), 0x2, 0);
                    }
                    CallNext(nCode, wParam, lParam);
                    return 1;//中断消息
                }

            }
            return 0;//继续
        }
    }
}
