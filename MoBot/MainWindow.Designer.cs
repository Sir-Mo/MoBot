
namespace MoBot
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.launchRS = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.screenshot = new System.Windows.Forms.Button();
            this.showDebug = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DetectTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.startscript = new System.Windows.Forms.Button();
            this.stopscript = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // launchRS
            // 
            this.launchRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchRS.Location = new System.Drawing.Point(700, 395);
            this.launchRS.Name = "launchRS";
            this.launchRS.Size = new System.Drawing.Size(375, 61);
            this.launchRS.TabIndex = 0;
            this.launchRS.Text = "Launch RuneScape";
            this.launchRS.UseVisualStyleBackColor = true;
            this.launchRS.Click += new System.EventHandler(this.LaunchRsButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.panel1.Controls.Add(this.launchRS);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1776, 852);
            this.panel1.TabIndex = 1;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "LauncherPID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(130, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ClientPID";
            // 
            // exit
            // 
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(1763, 5);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(25, 25);
            this.exit.TabIndex = 4;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // screenshot
            // 
            this.screenshot.Location = new System.Drawing.Point(1520, 6);
            this.screenshot.Name = "screenshot";
            this.screenshot.Size = new System.Drawing.Size(75, 23);
            this.screenshot.TabIndex = 5;
            this.screenshot.Text = "Screenshot";
            this.screenshot.UseVisualStyleBackColor = true;
            this.screenshot.Click += new System.EventHandler(this.ScreenshotButton_Click);
            // 
            // showDebug
            // 
            this.showDebug.Location = new System.Drawing.Point(1682, 6);
            this.showDebug.Name = "showDebug";
            this.showDebug.Size = new System.Drawing.Size(75, 23);
            this.showDebug.TabIndex = 9;
            this.showDebug.Text = "ShowDebug";
            this.showDebug.UseVisualStyleBackColor = true;
            this.showDebug.Click += new System.EventHandler(this.ShowDebugButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Test Mem";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MemTestButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(409, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mem placeholder";
            // 
            // DetectTest
            // 
            this.DetectTest.Location = new System.Drawing.Point(1601, 6);
            this.DetectTest.Name = "DetectTest";
            this.DetectTest.Size = new System.Drawing.Size(75, 23);
            this.DetectTest.TabIndex = 13;
            this.DetectTest.Text = "DetectTest";
            this.DetectTest.UseVisualStyleBackColor = true;
            this.DetectTest.Click += new System.EventHandler(this.DetectTestButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(230, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "MouseCoords";
            // 
            // startscript
            // 
            this.startscript.Location = new System.Drawing.Point(806, 6);
            this.startscript.Name = "startscript";
            this.startscript.Size = new System.Drawing.Size(75, 23);
            this.startscript.TabIndex = 15;
            this.startscript.Text = "Start Script";
            this.startscript.UseVisualStyleBackColor = true;
            this.startscript.Click += new System.EventHandler(this.StartScriptButton_Click);
            // 
            // stopscript
            // 
            this.stopscript.Location = new System.Drawing.Point(895, 6);
            this.stopscript.Name = "stopscript";
            this.stopscript.Size = new System.Drawing.Size(75, 23);
            this.stopscript.TabIndex = 16;
            this.stopscript.Text = "Stop Script";
            this.stopscript.UseVisualStyleBackColor = true;
            this.stopscript.Click += new System.EventHandler(this.StopScriptButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(985, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1031, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Unknown";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1800, 900);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.stopscript);
            this.Controls.Add(this.startscript);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DetectTest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.showDebug);
            this.Controls.Add(this.screenshot);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.LaunchRsButton_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchRS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button screenshot;
        private System.Windows.Forms.Button showDebug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button DetectTest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button startscript;
        private System.Windows.Forms.Button stopscript;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

