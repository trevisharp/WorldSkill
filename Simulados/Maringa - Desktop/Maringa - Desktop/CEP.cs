using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.WebSockets;
using System.Text.RegularExpressions;
using System.IO;

namespace Maringa___Desktop
{
    public partial class CEP : Form
    {
        public CEP()
        {
            InitializeComponent();
            render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpWebRequest r = (HttpWebRequest)WebRequest.Create("https://viacep.com.br/ws/" + txbCep.Text + "/json/");
            r.AllowAutoRedirect = false;
            HttpWebResponse checa = (HttpWebResponse)r.GetResponse();

            if (checa.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show("Server indisponivel");
            }
            else
            {
                using(Stream webstream = r.GetRequestStream())
                {
                    if(webstream != null)
                    {
                        using(StreamReader reader = new StreamReader(webstream))
                        {
                            string responde = reader.ReadToEnd();
                            responde = Regex.Replace(responde, "[{},]", string.Empty);
                            responde = responde.Replace("\"", "");
                            String[] substring = responde.Split('\n');

                            string endereco = "";
                            int cont = 0;

                            foreach(var sub in substring)
                            {
                                if(cont == 2) //Rua
                                {
                                    string[] valor =sub.Split(":".ToCharArray());
                                    endereco = valor[1];
                                }
                                if(cont == 5) //Cidade
                                {
                                    string[] valor = sub.Split(":".ToCharArray());
                                    endereco = valor[1];
                                }
                                cont++;
                            }

                            provaMEntities context = new provaMEntities();

                            context.tbCEP.Add(new tbCEP
                            {
                                nome = txbNome.Text,
                                cep = txbCep.Text,
                                endereco = endereco
                            });

                            context.SaveChanges();
                            context.Dispose();
                        }
                    }
                }
                render();
            }
        }

        private void render()
        {
            provaMEntities context = new provaMEntities();
            dataGridView1.Rows.Clear();
            foreach(var item in context.tbCEP)
            {
                dataGridView1.Rows.Add(item.nome, item.cep, item.endereco);
            }

            context.Dispose();
        }
    }
}
