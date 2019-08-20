using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Fomulario
{
    public partial class Menu_formulario : Form
    {
        public Menu_formulario()
        {
            InitializeComponent();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void nOVOCADASTROToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_Pacientes form_paciente = new Cadastro_Pacientes();
            form_paciente.ShowDialog();
        }

        private void nOVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_Dentista form_dentista = new Cadastro_Dentista();
            form_dentista.ShowDialog();
        }
    }
}
