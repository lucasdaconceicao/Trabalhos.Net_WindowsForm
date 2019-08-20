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
    public partial class FrmExcluirNotas_Faltas : Form
    {
        private int id;
        public FrmExcluirNotas_Faltas()
        {
            InitializeComponent();
        }

        public FrmExcluirNotas_Faltas(int id)
        {
            this.id = id;
            //buscar dados do aluno atraves do seu codigo
            Notas_Faltas nota_faltaSelecionado = Notas_Faltas.buscarDados(this.id);
            InitializeComponent();
            txtNome.Text = nota_faltaSelecionado.Aluno;
            txtCod.Text = nota_faltaSelecionado.Cod.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmListarNotasFaltas tela = new FrmListarNotasFaltas();
            tela.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice = Convert.ToInt32(txtCod.Text);
            Notas_Faltas NotasFaltas = Notas_Faltas.buscarDados(indice);
            //o aluno vai ser excluido na posicao do codigo
            bool sucesso = Notas_Faltas.excluirDadosNotas(indice);
            if (sucesso)
            {
                Mensagens.mensagemSucesso("O Aluno " + NotasFaltas.Aluno+ " e suas notas foram foi excluido!");
                txtNome.Text = "";
                txtCod.Text = "";
                btnExcluir.Enabled = false;
            }
            else
            {
                Mensagens.mensagemErro("Ocorreu um erro ao excluir a nota do aluno!");
            }
        }
    }
}
