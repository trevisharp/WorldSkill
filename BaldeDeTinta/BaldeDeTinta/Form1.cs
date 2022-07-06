using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BaldeDeTinta
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += (o, e) =>
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
                {
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawImage(Clipboard.GetImage(), Point.Empty);
                    g.Dispose();
                    pb.Refresh();
                }
            };

            Load += delegate
            {
                bmp = new Bitmap(pb.Width, pb.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                g.DrawEllipse(Pens.Black, pb.Width / 4, pb.Height / 4, pb.Width / 2, pb.Height / 2);
                pb.Image = bmp;

                //if(colorDialog1.ShowDialog() == DialogResult.OK);
                //pb.BackColor = colorDialog1.Color;
            };

            pb.MouseDown += (s, e) =>
            {
                BitmapData data = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

                byte[] img = new byte[data.Height * data.Stride];
                Marshal.Copy(data.Scan0, img, 0, img.Length);


                //for (int j = 0; j < data.Height; j++)
                //{
                //    for(int i = 0; i < data.Width; i++)
                //    {
                //        // ARGB EH AO CONTRARIO!!!!!!! ou seja eh bgra
                //        int index = j * data.Stride + 4 * i;
                //        //img[index] = (byte)(i * 4 * j * 3 % 255);
                //        //img[index + 1] = (byte)(i * 4 * j * 3 % 255);
                //        //img[index + 2] = (byte)(i * 4 * j * 3 % 255);
                //        img[index + 3] = 255;

                //        if (img[index] == 0 && img[index + 3] == 255) // transforma tudo oq estiver preto em vermelho
                //            img[index + 2] = 255;
                //    }
                //}

                int x = e.Location.X,
                    y = e.Location.Y;
                int clickindex = y * data.Stride + 4 * x;
                int b = img[clickindex],
                    g = img[clickindex + 1],
                    r = img[clickindex + 2],
                    a = img[clickindex + 3];

                if (b == 255 && g == 255 && r == 0 && a == 255)
                    goto end;

                Stack<int> stack = new Stack<int>();
                stack.Push(clickindex);

                while (stack.Count > 0)
                {
                    int i = stack.Pop();

                    //if (b == 255 && g == 255 && r == 0 && a == 255) //isso funciona!!!
                    //    continue;
                    if (i < 0 || i >= img.Length)
                        continue;
                    if (img[i] != b || img[i + 1] != g || img[i + 2] != r || img[i + 3] != a)
                        continue;

                    img[i] = 255;
                    img[i + 1] = 255;
                    img[i + 2] = 0;
                    img[i + 3] = 255;

                    if ((i + 4) % data.Stride != 0)
                        stack.Push(i + 4);
                    if (i % data.Stride != 0) // j * stride + 4 * i mas 4 * i == 0
                        stack.Push(i - 4);
                    stack.Push(i + data.Stride);
                    stack.Push(i - data.Stride);
                }

                //  recursao nao funfa 🤣
                //void balde(int i) // indice i
                //{
                //    if (i < 0 || i > img.Length)
                //        return;
                //    if (img[i] != b || img[i + 1] != g || img[i + 2] != r || img[i + 3] != a) 
                //        return;

                //    img[i] = 255;
                //    img[i + 1] = 255;
                //    img[i + 2] = 0;
                //    img[i + 3] = 255;

                //    if((i + 4) % data.Stride != 0)
                //        balde(i + 4);
                //    if(i % data.Stride != 0) // j * stride + 4 * i mas 4 * i == 0
                //        balde(i - 4);
                //    balde(i + data.Stride);
                //    balde(i - data.Stride);
                //}

                Marshal.Copy(img, 0, data.Scan0, img.Length);
            end:
                bmp.UnlockBits(data);
                pb.Refresh();
            };

            btnSalvar.Click += delegate
            {
                bmp.Save("aaaaa.png");
            };

            Teste teste = new Teste();
            teste.Valor = 65 + 256 * 66 + 256 * 256 * 67 + 256 * 256 * 256 * 68;
            teste.OtoValor = "oto valo";
            teste.Listinha = new List<int> { 78, 70, 98 };
            teste.bmp = bmp;
            BinaryFormatter formatter = new BinaryFormatter();

            //MemoryStream ms = new MemoryStream();
            //StreamWriter writer = new StreamWriter(@"C:\Users\Aluno\Desktop\repos\WorldSkill\prj.edjarma");
            //writer.WriteLine(string.Concat(ms.GetBuffer().Select(b => (char)b)));
            //writer.Close();
            //ms.Close();

            Stream stream = new FileStream(@"C:\Users\Aluno\Desktop\repos\WorldSkill\prj.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, teste);
            stream.Close();

            stream = new FileStream(@"C:\Users\Aluno\Desktop\repos\WorldSkill\prj.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            Teste obj = (Teste)formatter.Deserialize(stream);

            stream.Close();

            MessageBox.Show($"{obj.Valor} {obj.OtoValor} {obj.bmp}");
            
        }
    }
}

[Serializable]
public class Teste
{
    public int Valor { get; set; }
    public string OtoValor { get; set; }
    public List<int> Listinha { get; set; }
    public Bitmap bmp { get; set; }

}