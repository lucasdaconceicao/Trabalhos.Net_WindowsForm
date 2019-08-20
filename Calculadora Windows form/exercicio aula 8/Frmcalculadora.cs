using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exercicio_aula_8
{
    public partial class Frmcalculadora : Form
    {
        double resultadoTela;
        string operador;

        public Frmcalculadora()
        {
            InitializeComponent();
            resultadoTela = 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string texto = txtnum.Text;
            txtnum.Text =texto+ btn.Text;
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
                resultadoTela = Convert.ToDouble(txtnum.Text);
                txtnum.Clear();
                operador = "/";
               
        }

        private void btn_vezes_Click(object sender, EventArgs e)
        {
            resultadoTela = Convert.ToDouble(txtnum.Text);
            txtnum.Clear();
            operador = "*";
        }

        private void btn_menos_Click(object sender, EventArgs e)
        {
            resultadoTela = Convert.ToDouble(txtnum.Text);
            txtnum.Clear();
            operador = "-";
        }

        private void btn_mais_Click(object sender, EventArgs e)
        {
            resultadoTela = Convert.ToDouble(txtnum.Text);
            txtnum.Clear();
            operador = "+";
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(txtnum.Text);

            switch (operador)
            {
                case "/":
                    resultadoTela /= num;
                    break;
                case "*":
                    resultadoTela *= num;
                    break;
                case "+":
                    resultadoTela += num;
                    break;
                case "-":
                    resultadoTela -= num;
                    break;
                default:
                    break;
            }
            txtnum.Text = resultadoTela.ToString();
        }

    }
}
