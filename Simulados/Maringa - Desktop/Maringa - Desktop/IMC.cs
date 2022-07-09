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
    public partial class IMC : Form
    {
        public IMC()
        {
            InitializeComponent();
            render();
        }

        private void render()
        {   
            dataGridView1.Rows.Clear();
            provaMEntities context = new provaMEntities();
            foreach(var item in context.tbIMC)
            {
                dataGridView1.Rows.Add(item.nome, item.peso, item.altura, item.imc, item.classificacao);
            }

            context.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float n;
            if (txbAltura.Text.Contains('.') || txbPeso.Text.Contains('.'))
            {
                MessageBox.Show("Por favor, utilize virgulas e nao pontos!");
                txbAltura.Text = null;
                txbPeso.Text = null;
            }
            else if (float.TryParse(txbAltura.Text, out n) && float.TryParse(txbPeso.Text, out n))
            {
                string classi = "";
                double peso = Math.Round(float.Parse(txbPeso.Text), 2);
                double altura = Math.Round(float.Parse(txbAltura.Text), 2);
                double imc = Math.Round(peso / Math.Pow(altura, 2), 2);

                if(imc < 18)
                {
                    classi = "Abaixo do peso";
                }
                else if(imc >= 18 && imc < 25)
                {
                    classi = "Peso Normal";
                }
                else if (imc >= 25 && imc < 30)
                {
                    classi = "Excesso de Peso";
                }
                else if (imc >= 30 && imc < 35)
                {
                    classi = "Obesidade";
                }
                else if (imc >= 35)
                {
                    classi = "Obesidade extrema";
                }

                provaMEntities context = new provaMEntities();
                context.tbIMC.Add(new tbIMC
                {
                    nome = txbNome.Text,
                    altura = altura,
                    peso = peso,
                    imc = imc,
                    classificacao = classi
                });

                context.SaveChanges();
                context.Dispose();
                render();
            }
            else
            {
                MessageBox.Show("Por favor digite apenas valores validos!");
                txbAltura.Text = null;
                txbPeso.Text = null;
            }
        }
    }
}
