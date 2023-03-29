using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace пейнт
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        bool freehand = true;
        bool rectangle = false;
        bool circle = false;
        static SolidBrush brush = new SolidBrush(Color.Black);
        Pen ppap = new Pen(brush, 1);
        Point lastpoint;
        bool isMouseDown;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            lastpoint = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (lastpoint != null)
                {
                    if (freehand)
                    {
                        if (pictureBox1.Image == null)
                        {
                            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                            pictureBox1.Image = bmp;
                        }
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                ppap.Color = panel1.BackColor;
                            }
                            else if (e.Button == MouseButtons.Right)
                            {
                                ppap.Color = Color.White;
                            }
                            g.DrawLine(ppap, lastpoint, e.Location);
                            pictureBox1.Invalidate();
                        }
                    }
                }
            }
            lastpoint = e.Location;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ppap.Width = (float)numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ppap.Color = colorDialog1.Color;
                panel1.BackColor = colorDialog1.Color;
            }
        }
    }
}
