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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnIMC.Click += delegate
            {
                IMC imc = new IMC();
                imc.Show();
            };

            btnCEP.Click += delegate
            {
                CEP cep = new CEP();
                cep.Show();
            };

            btnTemp.Click += delegate
            {
                TEMPERATURA temp = new TEMPERATURA();
                temp.Show();
            };

            btnComb.Click += delegate
            {
                COMBUSTIVEL comb = new COMBUSTIVEL();
                comb.Show();
            };
        }

    }
}
