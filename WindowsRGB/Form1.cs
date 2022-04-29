using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsRGB
{
    public partial class Form1 : Form
    {
        int numWidth = 16;
        int numHeight = 8;
        public Form1()
        {
            InitializeComponent();
        }

        public Bitmap GetSreenshot()
        {
            Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bm);
            g.CopyFromScreen(0, 0, 0, 0, bm.Size);
            return bm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = GetSreenshot();
            Graphics g = Graphics.FromImage(bmp);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            int length = Screen.PrimaryScreen.Bounds.Height / numHeight;
            for (int i = 0; i < Screen.PrimaryScreen.Bounds.Height; i += length)
            {
                int R = 0;
                int G = 0;
                int B = 0;

                for (int x = i; x < i + length; x++)
                {
                        var px = bmp.GetPixel(x, x);
                        R += px.R;
                        G += px.G;
                        B += px.B;
                }

                R /= length;
                G /= length;
                B /= length;

                SolidBrush br = new SolidBrush(Color.FromArgb(R, G, B));
                Rectangle rect = new Rectangle(0, i, length, length);
                g.FillRectangle(br, rect);

            }

            stopwatch.Stop();

            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                timer1.Stop();
                button2.Text = "Start";
            } else
            {
                timer1.Start();
                button2.Text = "Stop";
            }
        }
    }
}
