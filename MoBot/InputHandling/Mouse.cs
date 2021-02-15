using MoBot.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/* 
 * Just a basic implementation of a left click
 * Right click etc. equal to this
 */

namespace MoBot.InputHandling
{
    class Mouse
    {
        public static async Task LeftClick(int x, int y)
        {
            SendMessage(Settings.RsWindowHandle, WindowsMessages.WM_LBUTTONDOWN, 0, MAKELPARAM(x, y));
            await RandomSleep(50, 150);
            SendMessage(Settings.RsWindowHandle, WindowsMessages.WM_LBUTTONUP, 0, MAKELPARAM(x, y));
            await RandomSleep(1050, 1500);
        }

        private static async Task<bool> RandomSleep(int min, int max)
        {
            await Task.Delay(new Random().Next(min, max));
            return true;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)] internal static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private static int MAKELPARAM(int p, int p_2)
        {
            return p_2 << 16 | (p & 65535);
        }
    }
}
