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
    public partial class FrmListarAluno : Form
    {
        public FrmListarAluno()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int indice;
            bool conversaoSucesso = int.TryParse(txtBuscarCod.Text, out indice);
            if (conversaoSucesso)
            {
                if (indice < 200)
                {
                    //posicao do objeto selecionado, se tem objeto cadastrado nessa posicao
                    if (Aluno._listarAluno[indice] != null)
                    {
                        Aluno alunoSelecionado = Aluno.buscarDados(indice);
                        if (alunoSelecionado != null)
                        {
                            //exibir os dados do aluno na tela, apos o click do botao buscar 
                            txtRenda.Text = alunoSelecionado.RendaFamilia.ToString();
                            txtNome.Text = alunoSelecionado.Nome;
                            txtBairro.Text = alunoSelecionado.Bairro;
                            txtCidade.Text = alunoSelecionado.Cidade;
                            txtCurso.Text = alunoSelecionado.Curso;
                            txtEmail.Text = alunoSelecionado.Email;
                            txtEstado.Text = alunoSelecionado.Estado;
                            txtEstadoCivil.Text = alunoSelecionado.EstadoCivil;
                            txtMensalidade.Text = alunoSelecionado.Mensalidade.ToString();
                            txtLogradouro.Text = alunoSelecionado.Logradouro;
                            dtpNascimento.Text = alunoSelecionado.Nascimento.ToString();
                            txtTelefone.Text = alunoSelecionado.Telefone;
                            txtPeriodo.Text = alunoSelecionado.Periodo;
                            txtCpf.Text = alunoSelecionado.Cpf;
                            txtCod.Text = alunoSelecionado.Cod.ToString();
                            if (alunoSelecionado.Sexo == 'M')
                            {
                                rb_m.Checked = true;
                            }
                            else
                            {
                                rb_f.Checked = true;
                            }
                        }
                        else
                        {
                            Mensagens.mensagemAlerta("Ocorreu umm erro ao localizar o aluno digite um codigo válido!");
                            txtBuscarCod.Text = "";
                        }
                    }
                    else
                    {
                        Mensagens.mensagemErro("Código incorreto!");
                        txtBuscarCod.Text = "";
                    }
                }
                else
                {
                    Mensagens.mensagemAlerta("Digite o código válido de um aluno!");
                    txtBuscarCod.Text = "";
                }
            }
            else
            {
                Mensagens.mensagemErro("Digite um código válido ou revise o código!");
                txtBuscarCod.Text = "";
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                int cod = Convert.ToInt32(txtCod.Text);
                this.Dispose();
                //Passar o codigo do aluno por parametro para a tela de cadastro para altera-lo
                FrmCadastroAluno alterar = new FrmCadastroAluno(cod);
                alterar.ShowDialog();
            }
            else
            {
                Mensagens.mensagemAlerta(" Selecione um Aluno e busca as informacoes antes de alterar!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                int id = Convert.ToInt32(txtCod.Text);
                this.Dispose();
                //Passar por parametro o codigo do aluno para a tela exclui
                FrmExcluirAluno tela = new FrmExcluirAluno(id);
                tela.ShowDialog();
            }
            else
            {
                Mensagens.mensagemAlerta("Selecione um Aluno e busca as informacoes antes de excluir!");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtBuscarCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}


