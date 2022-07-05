using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curitibatemaimagem
{
    public partial class Form1 : Form
    {
        Point? p;
        Bitmap img;
        Bitmap bmp;
        Graphics g;
        Timer tm = new Timer();
        Rectangle rec = new Rectangle(50, 50, 100, 100);
        public Form1()
        {
            InitializeComponent();
            img = Image.FromFile(@"C:\Users\Aluno\Desktop\repositrio\WorldSkill\Trevisan.png") as Bitmap;
            Load += delegate
            {
                bmp = new Bitmap(pb.Width, pb.Height);
                pb.Image = bmp;
                g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                tm.Start();
            };

            tm.Interval = 25;
            tm.Tick += delegate
            {
                g.Clear(Color.White);
                g.DrawImage(img, rec);
                drawRec(rec.X, rec.Y);
                drawRec(rec.X + rec.Width, rec.Y + rec.Height);
                drawRec(rec.X + rec.Width, rec.Y);
                drawRec(rec.X, rec.Y + rec.Height);
                pb.Refresh();

                void drawRec(int x, int y)
                {
                    g.FillRectangle(Brushes.White, x - 3, y - 3, 6, 6);
                    g.DrawRectangle(Pens.Black, x - 2, y - 3, 6, 6);
                }
            };
        }

        private void pb_MouseDown(object sender, MouseEventArgs e)
            => p = e.Location;

        private void pb_MouseUp(object sender, MouseEventArgs e)
            => p = null;

        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (contains(rec.X + rec.Width, rec.Y + rec.Height))
            {
                Cursor = Cursors.SizeNWSE;
            }
            else if (contains(rec.X + rec.Width, rec.Y))
            {
                Cursor = Cursors.SizeNESW;
            }
            else if (contains(rec.X, rec.Y + rec.Height))
            {
                Cursor = Cursors.SizeNESW;
            }
            else if (contains(rec.X, rec.Y))
            {
                Cursor = Cursors.SizeNWSE;
            }
            else
            {
                Cursor = Cursors.Arrow;
            }

            if (p == null)
                return;

            mouseMove(p.Value, e.Location);
            p = e.Location;

            bool contains(int x, int y)
            {
                return new Rectangle(x - 3, y - 3, 6, 6)
                    .Contains(e.Location);
            }
        }

        private void mouseMove(Point p, Point q)
        {
            if (!rec.Contains(p))
                return;

            int dx = q.X - p.X,
                dy = q.Y - p.Y;

            if (contains(rec.X + rec.Width, rec.Y + rec.Height))
            {
                rec = new Rectangle(rec.X, rec.Y, rec.Width + dx, rec.Height + dy);
            }
            else if(contains(rec.X + rec.Width, rec.Y))
            {
                rec = new Rectangle(rec.X, rec.Y + dy, rec.Width + dx, rec.Height - dy);
            }
            else if (contains(rec.X, rec.Y + rec.Height))
            {
                rec = new Rectangle(rec.X + dx, rec.Y, rec.Width - dx, rec.Height + dy);
            }
            else if (contains(rec.X, rec.Y))
            {
                rec = new Rectangle(rec.X + dx, rec.Y + dy, rec.Width - dx, rec.Height - dy);
            }
            else
            {
                rec = new Rectangle(rec.X + dx, rec.Y + dy, rec.Width, rec.Height);
            }

            bool contains(int x, int y)
            {
                return new Rectangle(x - 3, y - 3, 6, 6)
                    .Contains(p);
            }
        }
    }
}
