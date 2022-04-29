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

        private void CreateRects(object sender, EventArgs e)
        {
            Bitmap bmp = GetSreenshot();
            if (checkBoxRight.Checked) GetColRight(ref bmp);
            if(checkBoxLeft.Checked) GetColLeft(ref bmp);
            if(checkBoxTop.Checked) GetRowTop(ref bmp);
            if(checkBoxBottom.Checked) GetRowBottom(ref bmp);
            pictureBox1.Image = bmp;
        }

        private void Start(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                button2.Text = "Start";
            }
            else
            {
                timer1.Start();
                button2.Text = "Stop";
            }
        }

        private void GetColLeft(ref Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);

            int length = Screen.PrimaryScreen.Bounds.Height / numHeight;

            for (int i = 0; i < Screen.PrimaryScreen.Bounds.Height; i += length)
            {
                int R = 0;
                int G = 0;
                int B = 0;

                for (int x = i; x < i + length && x < bmp.Height; x++)
                {
                    var px = bmp.GetPixel(0, x);
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
        }

        private void GetColRight(ref Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);

            int length = Screen.PrimaryScreen.Bounds.Height / numHeight;
            int max = Screen.PrimaryScreen.Bounds.Width - 1;

            for (int i = 0; i < Screen.PrimaryScreen.Bounds.Height; i += length)
            {
                int R = 0;
                int G = 0;
                int B = 0;

                for (int x = i; x < i + length && x < bmp.Height; x++)
                {
                    var px = bmp.GetPixel(max, x);
                    R += px.R;
                    G += px.G;
                    B += px.B;
                }

                R /= length;
                G /= length;
                B /= length;

                SolidBrush br = new SolidBrush(Color.FromArgb(R, G, B));
                Rectangle rect = new Rectangle(max - length, i, length, length);
                g.FillRectangle(br, rect);

            }
        }

        private void GetRowTop(ref Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);

            int length = Screen.PrimaryScreen.Bounds.Width / numWidth;

            for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i += length)
            {
                int R = 0;
                int G = 0;
                int B = 0;

                for (int x = i; x < i + length && x < bmp.Width; x++)
                {
                    var px = bmp.GetPixel(x, 0);
                    R += px.R;
                    G += px.G;
                    B += px.B;
                }

                R /= length;
                G /= length;
                B /= length;

                SolidBrush br = new SolidBrush(Color.FromArgb(R, G, B));
                Rectangle rect = new Rectangle(i, 0, length, length);
                g.FillRectangle(br, rect);

            }
        }

        private void GetRowBottom(ref Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);

            int length = Screen.PrimaryScreen.Bounds.Width / numWidth;
            int max = Screen.PrimaryScreen.Bounds.Height - 1;

            for (int i = 0; i < Screen.PrimaryScreen.Bounds.Width; i += length)
            {
                int R = 0;
                int G = 0;
                int B = 0;

                for (int x = i; x < i + length && x < bmp.Width; x++)
                {
                    var px = bmp.GetPixel(x, max - length);
                    R += px.R;
                    G += px.G;
                    B += px.B;
                }

                R /= length;
                G /= length;
                B /= length;

                SolidBrush br = new SolidBrush(Color.FromArgb(R, G, B));
                Rectangle rect = new Rectangle(i, max - length, length, length);
                g.FillRectangle(br, rect);

            }
        }

        private void numericWidth_ValueChanged(object sender, EventArgs e)
        {
            numWidth = ((int)numericWidth.Value);
        }

        private void numericHeight_ValueChanged(object sender, EventArgs e)
        {
            numHeight = ((int)numericHeight.Value);
        }
    }
}
