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
    public partial class Frmprincipal : Form
    {
        public Frmprincipal()
        {
            InitializeComponent();
        }

        private void btnclick_Click(object sender, EventArgs e)
        {
            int num1 = 8;
            int num2;
            num2 = Convert.ToInt32(txtnum.Text);

            trocarnumero(  num1, num2);
            MessageBox.Show(num1.ToString());
            MessageBox.Show(num2.ToString());

        }

        public void trocarnumero(  int num1, int num2)
        {
            num1 += 45;

            MessageBox.Show(num1.ToString());
            MessageBox.Show(num2.ToString());
        }

        private void Frmprincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
