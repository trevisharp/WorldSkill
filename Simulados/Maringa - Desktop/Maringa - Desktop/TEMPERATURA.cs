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
            if(double.TryParse(txbTemp.Text, out double temp) || !string.IsNullOrWhiteSpace(txbNome.Text))
            {
                temp = Math.Round(temp, 2);
                double tempNova = 0;

                if (radioButton3.Checked)
                {
                    tempNova = Math.Round(temp * 1.8 + 32, 2);
                    insere(temp, tempNova);
                }
                else if (radioButton4.Checked)
                {
                    tempNova = Math.Round(temp + 273, 2);
                    insere(temp, tempNova);
                }
                else
                {
                    MessageBox.Show("Por favor, selecione uma opcao");
                }
            }
            else
            {
                MessageBox.Show("Por favor insira um valor valido");
            }

            void insere(double t, double tn){
                provaMEntities context = new provaMEntities();
                context.tbTempetura.Add(new tbTempetura
                {
                    nome = txbNome.Text,
                    temperatura = t,
                    temperatura_convertida = tn
                }) ;

                context.SaveChanges();
                context.Dispose();
            }
            render();
        }

        public void render()
        {
            dataGridView1.Rows.Clear();
            provaMEntities context = new provaMEntities();

            foreach(var item in context.tbTempetura)
            {
                dataGridView1.Rows.Add(item.nome, item.temperatura, item.temperatura_convertida);
            }

            context.Dispose();
        }
    }
}