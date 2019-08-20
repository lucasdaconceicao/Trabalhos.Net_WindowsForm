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
    public partial class FrmExcluirAluno : Form
    {
        private int id;
        //iniciando a tela normal
        public FrmExcluirAluno()
        {
            InitializeComponent();
        }

        //carrega as informacoes do aluno na tela atraves do seu codigo que foi passado por parametro
        public FrmExcluirAluno(int id)
        {
            this.id = id;
            //buscar os dados do aluno atraves do seu codigo
            Aluno alunoSelecionado = Aluno.buscarDados(this.id);
            InitializeComponent();
            txtNome.Text = alunoSelecionado.Nome;
            txtCod.Text = alunoSelecionado.Cod.ToString();
        }

        //voltar para a tela de visualizar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmListarAluno tela = new FrmListarAluno();
            tela.ShowDialog();
        }

        //para excluir um objeto
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //pega o código do objeto selecionado
            //busca os dados  dele
            int indice = Convert.ToInt32(txtCod.Text);
            Aluno aluno = Aluno.buscarDados(indice);
            //o aluno vai ser excluido na posicao do codigo
            bool sucesso = Aluno.excluirDadosAluno(indice);
            if (sucesso)
            {
                Mensagens.mensagemSucesso("O Aluno " + aluno.Nome + " foi excluido!");
                txtNome.Text = "";
                txtCod.Text = "";
                btnExcluir.Enabled = false;
            }
            else
            {
                Mensagens.mensagemErro("Ocorreu um erro ao excluir o aluno!");
            }
        }
    }
}
