using MoBot.Helper;
using MoBot.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Basic implementation of div xp in memory. 
 * For future: Get whole array to get xp from every skill.
 */

namespace MoBot.GameEntities
{
    class Skills
    {
        private static IntPtr divXpAddress;
        private static bool isInitialized = false;
        private static IntPtr hProc;
        private static void InitDivinationXP()
        {
            hProc = MemoryAPI.OpenProcess(MemoryAPI.ProcessAccessFlags.All, false, Settings.RsClientProcess.Id);
            IntPtr modBase = MemoryAPI.GetModuleBaseAddress(Settings.RsClientProcess.Id, "rs2client.exe");

            // Offsets from Cheatengine bottom to top in list, may change after RuneScape update
            divXpAddress = MemoryAPI.FindDMAAddy(hProc, (IntPtr)(modBase + 0x6A6FD8), new int[] { 0x30, 0xB38, 0x20, 0xE8, 0x10, 0x258 });
            //Console.WriteLine("XpAddre: " + "0x" + xpAddr.ToString("X"));
        }

        public static int GetDivinationXp()
        {
            if (!isInitialized)
            {
                InitDivinationXP();
                isInitialized = true;
            }
            byte[] xpBuffer = new byte[4];
            // 0xC is from write scan
            MemoryAPI.ReadProcessMemory(hProc, divXpAddress + 0xC, xpBuffer, xpBuffer.Length, out _);
            return BitConverter.ToInt32(xpBuffer, 0);
        }
    }
}
