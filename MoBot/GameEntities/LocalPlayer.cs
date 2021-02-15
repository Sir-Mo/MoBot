using MoBot.Helper;
using MoBot.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Basic implementation of local players coords in memory, used for the porr traversal. 
 * For future: Get whole local player struct with name looking direction etc.
 */

namespace MoBot.GameEntities
{
    class LocalPlayer
    {
        private static IntPtr coordArrayAddress;
        private static bool isInitialized = false;
        private static IntPtr hProc;

        private static void InitCoords()
        {
            hProc = MemoryAPI.OpenProcess(MemoryAPI.ProcessAccessFlags.All, false, Settings.RsClientProcess.Id);
            IntPtr modBase = MemoryAPI.GetModuleBaseAddress(Settings.RsClientProcess.Id, "rs2client.exe");

            // Offsets from Cheatengine bottom to top in list, may change on RuneScape update
            coordArrayAddress = MemoryAPI.FindDMAAddy(hProc, (IntPtr)(modBase + 0x699948), new int[] { 0x60, 0xBB8, 0x128, 0x20, 0x0 });
        }

        public static int[] GetCoords()
        {
            if (!isInitialized)
            {
                InitCoords();
                isInitialized = true;
            }
            byte[] xCoordBuffer = new byte[4];
            byte[] yCoordBuffer = new byte[4];

            MemoryAPI.ReadProcessMemory(hProc, coordArrayAddress + 0x2E8, xCoordBuffer, xCoordBuffer.Length, out _);
            MemoryAPI.ReadProcessMemory(hProc, coordArrayAddress + 0x2F0, yCoordBuffer, yCoordBuffer.Length, out _);


            return new int[] { (int)(BitConverter.ToSingle(xCoordBuffer, 0) / 512f), (int)(BitConverter.ToSingle(yCoordBuffer, 0) / 512f) };
        }
    }
}
