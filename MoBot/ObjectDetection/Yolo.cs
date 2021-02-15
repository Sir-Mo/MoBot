using Alturos.Yolo;
using Alturos.Yolo.Model;
using MoBot.InputHandling;
using MoBot.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Object detection using Alturos.Yolo
 * https://github.com/AlturosDestinations/Alturos.Yolo
 */

namespace MoBot.ObjectDetection
{
    class Yolo
    {
        public static async Task<string> YoloDetectClick(string type, double threshold = 0.9)
        {
            //var configurationDetector = new ConfigurationDetector();
            //var config = configurationDetector.Detect();
            //var yolo = new YoloWrapper(config);

            // These files must be in the output folder
            var yolo = new YoloWrapper("yolov3-tiny.cfg", "yolov3-tiny_finalnew.weights", "obj.names");
            var memoryStream = new MemoryStream();

            Bitmap bm = Screenshot.TakeHandleScreenShot(Settings.RsWindowHandle);
            bm.Save(memoryStream, ImageFormat.Png);
            var _items = yolo.Detect(memoryStream.ToArray()).ToList();

            return await AddDetailsToBoxAndClick(_items, bm, type, threshold);
        }

        private static async Task<string> AddDetailsToBoxAndClick(List<YoloItem> items, Bitmap bm, string searchType, double threshold)
        {
            var clicked = false;

            if (Settings.RsWindowHandle != IntPtr.Zero)
            {
                var img = new Bitmap(bm.Width, bm.Height); ;
                var font = new Font("Arial", 18, FontStyle.Bold);
                var brush = new SolidBrush(Color.Red);
                var graphics = Graphics.FromImage(img);
                graphics.DrawImage(bm, 0, 0);

                foreach (var item in items)
                {
                    var rect = new Rectangle(item.X, item.Y, item.Width, item.Height);
                    var pen = new Pen(Color.LightGreen, 6);
                    var point = new Point(item.X, item.Y);

                    // Draw every item in bitmap
                    graphics.DrawRectangle(pen, rect);
                    graphics.DrawString(item.Type + ", " + item.Confidence + ", " + item.X + ", " + item.Y, font, brush, point);

                    if (item.Type == searchType && !clicked)
                    {
                        // If drawn type is searched type and confidence is greater than threshold click
                        if (!clicked && item.Confidence > threshold)
                        {
                            if (item.Type != "invfull") await Mouse.LeftClick(item.X + (item.Width / 2), item.Y + (item.Height / 2));
                            clicked = true;
                        }
                    }
                }
                MainWindow.previewBox.Image = img;
            }
            return clicked ? "successful" : "unsuccessful";
        }
    }
}
