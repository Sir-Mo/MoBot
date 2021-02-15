using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Just placeholder for handle and process for now...
 */

namespace MoBot.Helper
{
    class Settings
    {
        public static IntPtr RsWindowHandle { get; set; }
        public static IntPtr RsJagGlWindowHandle { get; set; }
        public static Process RsLauncherProcess { get; set; }
        public static Process RsClientProcess { get; set; }
    }
}
