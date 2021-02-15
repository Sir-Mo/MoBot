using MoBot.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * Just a basic implementation of a holding keys
 */

namespace MoBot.InputHandling
{
    class Keyboard
    {
		[DllImport("user32.dll", CharSet = CharSet.Auto)] private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, Keys wParam, int lParam);
		public static async Task HoldKey(Keys key, int ms)
		{
			SendKey(key, WindowsMessages.WM_KEYDOWN);
			await Task.Delay(ms);
			SendKey(key, WindowsMessages.WM_KEYUP);
		}

		internal static void SendKey(Keys key, int msg)
		{
			SendMessage(Settings.RsWindowHandle, msg, key, 0);
		}
	}
}
