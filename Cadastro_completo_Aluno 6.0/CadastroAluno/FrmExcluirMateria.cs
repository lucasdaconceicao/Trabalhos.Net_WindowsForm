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
    public partial class FrmExcluirMateria : Form
    {
        private int id;
        public FrmExcluirMateria()
        {
            InitializeComponent();
        }

        public FrmExcluirMateria(int id)
        {
            this.id = id;
            //buscar dados da materia atraves do seu codigo
            Materia materiaSelecionado = Materia.buscarDados(this.id);
            InitializeComponent();
            txtDisciplina.Text = materiaSelecionado.Disciplina;
            txtCod.Text = materiaSelecionado.Cod.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = Convert.ToInt32(txtCod.Text);
            Materia materiaExcluir = Materia.buscarDados(indice);
            //A materia vai ser excluido na posicao do codigo
            bool sucesso = Materia.excluirDadosMateria(indice);
            if (sucesso)
            {
                Mensagens.mensagemSucesso("A materia " + materiaExcluir.Disciplina + " foi excluido!");
                txtDisciplina.Text = "";
                txtCod.Text = "";
                btnExcluir.Enabled = false;
            }
            else
            {
                Mensagens.mensagemErro("Ocorreu um erro ao excluir a matéria!");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmListarMateria tela = new FrmListarMateria();
            tela.ShowDialog();
        }
    }
}

