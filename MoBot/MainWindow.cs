using MoBot.InputHandling;
using MoBot.GameEntities;
using MoBot.Helper;
using MoBot.ObjectDetection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoBot
{
    public partial class MainWindow : Form
    {

        private const int GWL_SYTLE = -16;
        private const int WS_VISIBLE = 0x10000000;

        public static PictureBox previewBox;

        // Vars for dragging/moving window
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        // Set to true if script running
        public static bool detectRunning = false;

        DebugWindow debugWindow;

        public MainWindow()
        {
            InitializeComponent();
            debugWindow = new DebugWindow();
            previewBox = debugWindow.DebugBox;
        }

        // Implementation of user32
        [DllImport("user32.dll")] static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")] static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")] static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll")] static extern bool MoveWindow(IntPtr Handle, int x, int y, int w, int h, bool repaint);

        // Implementation of buttons
        private void LaunchRsButton_Click(object sender, EventArgs e)
        {
            if (Settings.RsLauncherProcess == null || Settings.RsLauncherProcess.HasExited)
            {
                Settings.RsLauncherProcess = Process.Start("rs-launch://www.runescape.com/k=5/l=0/jav_config.ws");
                label1.Text = "LauncherPID: " + Settings.RsLauncherProcess.Id.ToString();
                bool finish = false;
                while (!finish)
                {
                    Process[] localByName = Process.GetProcessesByName("rs2client");
                    foreach (Process pro in localByName)
                    {
                        try
                        {
                            if (Settings.RsLauncherProcess.HasExited) throw new Exception();
                            if (ProcessFinder.Parent(pro).Id == Settings.RsLauncherProcess.Id)
                            {
                                Settings.RsClientProcess = pro;
                                while (pro.MainWindowHandle == IntPtr.Zero)
                                {
                                    Thread.Sleep(50);
                                    pro.Refresh();
                                }
                                Thread.Sleep(100);

                                // Set window handles
                                Settings.RsJagGlWindowHandle = pro.MainWindowHandle;
                                Settings.RsWindowHandle = FindWindowEx(pro.MainWindowHandle, IntPtr.Zero, "JagOpenGLView", null);

                                // Set window to panel
                                SetParent(pro.MainWindowHandle, panel1.Handle);
                                MoveWindow(pro.MainWindowHandle, 0, 0, panel1.Width, panel1.Height, true);
                                SetWindowLong(pro.MainWindowHandle, GWL_SYTLE, WS_VISIBLE);

                                // Set rs2client pid
                                label2.Text = "ClientPID: " + pro.Id.ToString();
                                finish = true;
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            if (Settings.RsLauncherProcess != null && !Settings.RsLauncherProcess.HasExited) Settings.RsLauncherProcess.Kill();
                            if (Settings.RsClientProcess != null && !Settings.RsClientProcess.HasExited) Settings.RsClientProcess.Kill();
                            Settings.RsLauncherProcess = null;
                            Settings.RsClientProcess = null;
                            finish = true;
                            break;
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("RuneScape already opened!");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("Are you sure you want to really exit ? ",
                             "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (x == DialogResult.Yes)
            {
                if (Settings.RsLauncherProcess != null && !Settings.RsLauncherProcess.HasExited) Settings.RsLauncherProcess.Kill();
                if (Settings.RsClientProcess != null && !Settings.RsClientProcess.HasExited) Settings.RsClientProcess.Kill();
                Application.Exit();
            }
        }

        private void MemTestButton_Click(object sender, EventArgs e)
        {
            int[] coords = LocalPlayer.GetCoords();
            label3.Text = "X: " + coords[0] + "; Y: " + coords[1] + "; Div Xp: " + Skills.GetDivinationXp().ToString();
        }

        private async void StartScriptButton_Click(object sender, EventArgs e)
        {
            // Anything u need do do to run ur script
            if (!detectRunning)
            {
                detectRunning = true;
                while (detectRunning)
                {
                    // Update xp and coords
                    int[] coords = LocalPlayer.GetCoords();
                    label3.Text = "X: " + coords[0] + "; Y: " + coords[1] + "; Div Xp: " + Skills.GetDivinationXp().ToString();

                    // Click a pos
                    label6.Text = "Left Click - Test";
                    await Mouse.LeftClick(100, 100);

                    await Task.Delay(new Random().Next(1000, 5000));

                    // Sending a keystroke
                    label6.Text = "Hold right arrow key - Test";
                    await Keyboard.HoldKey(Keys.Right, 300);

                    await Task.Delay(new Random().Next(1000, 5000));

                    // Traveling to postition; example is vibrant rift
                    label6.Text = "Travelling - Test";
                    await Traversal.TravelToLocation(2421, 2861);

                    await Task.Delay(new Random().Next(1000, 5000));

                    // Click object with threshold for confidence
                    label6.Text = "Detect and click wisp - Test";
                    await Yolo.YoloDetectClick("wisp", 0.9);

                    await Task.Delay(new Random().Next(1000, 5000));
                }
            }
        }

        private void StopScriptButton_Click(object sender, EventArgs e)
        {
            // If needed make sure ur script exiting clean
            detectRunning = false;
        }

        private void ScreenshotButton_Click(object sender, EventArgs e)
        {
            Bitmap bm2 = Screenshot.TakeHandleScreenShot(Settings.RsJagGlWindowHandle);
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var res = new string(Enumerable.Repeat(chars, 12).Select(s => s[random.Next(s.Length)]).ToArray());
            Screenshot.SaveBitmapAsPng(bm2, res);
        }

        private void ShowDebugButton_Click(object sender, EventArgs e)
        {
            debugWindow.Show();
            debugWindow.BringToFront();
        }

        private async void DetectTestButton_Click(object sender, EventArgs e)
        {
            await Yolo.YoloDetectClick("", 0.5);
        }


        // Implementation for coord tracking (abosulte mouse clicks) - need improvment
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = "Coords: " + e.Location.X + ":" + e.Location.Y;
        }

        // Implementation of window dragging
        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void MainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
