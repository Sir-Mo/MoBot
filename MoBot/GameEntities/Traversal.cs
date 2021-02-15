using MoBot.InputHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoBot.GameEntities
{
    /* Poor traveling, very bot like - need rework - Uses absolute coords, bad idea */
    class Traversal
    {
        public async static Task TravelToLocation(int xValue, int yValue)
        {
            // Reset compass
            await Mouse.LeftClick(1588, 30);

            // Camera back up
            await Keyboard.HoldKey(Keys.Up, new Random().Next(3000, 3500));

            // Travel
            var xBuffer = LocalPlayer.GetCoords()[0];
            while (!(xBuffer >= (xValue - 8) && xBuffer <= (xValue + 8)) && MainWindow.detectRunning)
            {
                if (xBuffer < xValue) await Mouse.LeftClick(1590, 400);
                else await Mouse.LeftClick(160, 400);
                await Task.Delay(GetRandomNumber(4000, 6000));
                if (LocalPlayer.GetCoords()[0] == xBuffer) await Mouse.LeftClick(874, 111);
                xBuffer = LocalPlayer.GetCoords()[0];
            }
            var yBuffer = LocalPlayer.GetCoords()[1];
            while (!(yBuffer >= (yValue - 8) && yBuffer <= (yValue + 8)) && MainWindow.detectRunning)
            {
                if (yBuffer < yValue) await Mouse.LeftClick(874, 111);
                else await Mouse.LeftClick(874, 761);
                await Task.Delay(GetRandomNumber(4000, 6000));
                if (LocalPlayer.GetCoords()[1] == yBuffer) await Mouse.LeftClick(1590, 400);
                yBuffer = LocalPlayer.GetCoords()[1];
            }
        }

        private static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
