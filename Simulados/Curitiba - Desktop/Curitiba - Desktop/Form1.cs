using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curitiba___Desktop
{
    public partial class Form1 : Form
    {
        Point? p;
        Graphics g;
        Bitmap bmp;
        List<Point> points;
        bool IsPolygon = false;
        Color color = Color.Black;
        Timer tm = new Timer();
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);

            btnPoligono.Click += delegate
            {
                points = new List<Point>();
                IsPolygon = true;
                Cursor = Cursors.Cross;

                //if(colorDialog1.ShowDialog() == DialogResult.OK){
                //    color = colorDialog1.Color;
                //}
            };

            Load += delegate
            {
                tm.Start();
            };

            tm.Interval = 25;
            tm.Tick += delegate
            {
                pictureBox1.Refresh();
            };
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        => p = e.Location;

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        => p = null;

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsPolygon == true)
            {
                Pen caneta = new Pen(color, 5);
                points.Add(new Point(e.X, e.Y));

                if(points.Count() > 1)
                {
                    label1.Text = $"{points[points.Count() - 1]} {points.Last()}";
                    g.DrawLine(caneta, points[points.Count() - 1], points.Last());
                }
            }
        }
    }
}
