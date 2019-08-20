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
    public partial class FrmListarMateria : Form
    {
        public FrmListarMateria()
        {
            InitializeComponent();
        }

        //Quando clica no botao buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int indice;
            //Verifica se o código fornecido é um número válido
            bool ConversaoSucesso = int.TryParse(txtBuscarCod.Text, out indice);
            if (ConversaoSucesso)
            {
                if (indice < 200)
                {
                    if (Materia._listarMateria[indice] != null)
                    {
                        Materia materiaSelecionada = Materia.buscarDados(indice);
                        if (materiaSelecionada != null)
                        {
                            //exibir os dados da materia na tela, apos o click do botao buscar 
                            txtProf.Text = materiaSelecionada.Professor;
                            txtDisciplina.Text = materiaSelecionada.Disciplina;
                            txtAluno.Text = materiaSelecionada.Aluno;
                            txtCarga.Text = materiaSelecionada.Carga.ToString();
                            txtCod.Text = materiaSelecionada.Cod.ToString();
                            txtCurso.Text = materiaSelecionada.Curso;
                            txtAulas.Text = materiaSelecionada.Aulas.ToString();
                            txtMatricula.Text = materiaSelecionada.Matricula.ToString();
                            txtTurma.Text = materiaSelecionada.Turma;
                            dtpMatricula.Text = materiaSelecionada.Data_matricula.ToString();
                        }
                        //Alterar
                        else
                        {
                            Mensagens.mensagemAlerta("Ocorreu umm erro ao localizar a materia");
                        }
                    }
                    else
                    {
                        Mensagens.mensagemAlerta("Digite um código válido");
                    }
                }
                else
                {
                    Mensagens.mensagemAlerta("Digite um código para busca as informações");
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                int cod = Convert.ToInt32(txtCod.Text);
                this.Dispose();
                //passar o codigo do aluno por parametro para a tela de cadastro para altera-lo
                FrmCadastroMateria alterar = new FrmCadastroMateria(cod);
                alterar.ShowDialog();
            }
            else
            {
                Mensagens.mensagemAlerta(" Selecione uma matéria e busca as informacoes antes de alterar!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                int id = Convert.ToInt32(txtCod.Text);
                this.Dispose();
                //passar por paramtro o codigo do aluno para a tela exclusao 
                FrmExcluirMateria tela = new FrmExcluirMateria(id);
                tela.ShowDialog();
            }
            else
            {
                Mensagens.mensagemAlerta("Selecione uma matéria e busca as informacoes antes de excluir!");
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
