using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroAluno
{
    public partial class FrmControle : Form
    {
        public FrmControle()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroAluno cadastro = new FrmCadastroAluno();
            cadastro.ShowDialog();
        }

        private void listarAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarAluno listarAluno = new FrmListarAluno();
            listarAluno.ShowDialog();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroMateria materia = new FrmCadastroMateria();
            materia.ShowDialog();
        }

        private void listarMatériaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarMateria tela = new FrmListarMateria();
            tela.ShowDialog();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroNotas tela = new FrmCadastroNotas();
            tela.ShowDialog();
        }

        private void listarNotasEFaltasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmListarNotasFaltas notas = new FrmListarNotasFaltas();
            notas.ShowDialog();
        }
    }
}
