using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maringa___Desktop
{
    public partial class TEMPERATURA : Form
    {
        public TEMPERATURA()
        {
            InitializeComponent();
            render();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (float.TryParse(txbTemp.Text, out float n))
            {
                if (radioButton3.Checked)
                {
                    double temp = Math.Round(double.Parse(txbTemp.Text), 2);
                    double tempNova = temp * 1.8 + 32;

                    provaMEntities context = new provaMEntities();

                    context.tbTempetura.Add(new tbTempetura
                    {
                        nome = txbNome.Text,
                        temperatura = temp,
                        temperatura_convertida = tempNova
                    });

                    context.SaveChanges();
                    context.Dispose();
                }
                else if (radioButton4.Checked)
                {
                    double temp = Math.Round(double.Parse(txbTemp.Text), 2);
                    double tempNova = temp + 273;

                    provaMEntities context = new provaMEntities();

                    context.tbTempetura.Add(new tbTempetura
                    {
                        nome = txbNome.Text,
                        temperatura = temp,
                        temperatura_convertida = tempNova
                    });

                    context.SaveChanges();
                    context.Dispose();
                }
                else
                {
                    MessageBox.Show("Selecione uma opcao!");
                }
            }
            else
            {
                MessageBox.Show("Digite um valor valido!");
            }
            render();
            
        }

        public void render()
        {
            provaMEntities context = new provaMEntities();
            dataGridView1.Rows.Clear();
            foreach(var item in context.tbTempetura)
            {
                dataGridView1.Rows.Add(item.nome, item.temperatura, item.temperatura_convertida);
            }
            context.Dispose();
        }
    }
}
