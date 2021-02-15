using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoBot
{
    public partial class DebugWindow : Form
    {
        // Vars for dragging/moving window
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public DebugWindow()
        {
            InitializeComponent();
        }

        public PictureBox DebugBox
        {
            get
            {
                return pictureBox1;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void GuiMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void GuiMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void GuiMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
