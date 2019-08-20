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
    public partial class FrmListarNotasFaltas : Form
    {
        public FrmListarNotasFaltas()
        {
            InitializeComponent();
        }

        //Quando clicar no botao buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int indice;
            bool ConversaoSucesso = int.TryParse(txtBuscarCod.Text, out indice);
            if (ConversaoSucesso)
            {
                if (indice < 200)
                {
                    //posicao do objeto selecionado
                    if (Notas_Faltas._listarNotas_Faltas[indice] != null)
                    {
                        Notas_Faltas nota_faltaSelecionado = Notas_Faltas.buscarDados(indice);
                        if (nota_faltaSelecionado != null)
                        {
                            txtAluno.Text = nota_faltaSelecionado.Aluno;
                            txtAv1.Text = nota_faltaSelecionado.Av1.ToString();
                            txtAv2.Text = nota_faltaSelecionado.Av2.ToString();
                            txtCod.Text = nota_faltaSelecionado.Cod.ToString();
                            txtFaltas.Text = nota_faltaSelecionado.Faltas.ToString();
                            txtTrab1.Text = nota_faltaSelecionado.Trab1.ToString();
                            txtTrab2.Text = nota_faltaSelecionado.Trab2.ToString();
                        }
                        else
                        {
                            Mensagens.mensagemAlerta("Ocorreu umm erro ao localizar a nota e faltas digite um codigo válido");
                            txtBuscarCod.Text = "";
                        }
                    }
                    else
                    {
                        Mensagens.mensagemErro("Digite um código válido");
                        txtBuscarCod.Text = "";
                    }
                }
                else
                {
                    Mensagens.mensagemAlerta("Digite o código válido");
                    txtBuscarCod.Text = "";
                }
            }
            else
            {
                Mensagens.mensagemAlerta("Digite um numero corespondente ao seu cadastro");
                txtBuscarCod.Text = "";
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                int cod = Convert.ToInt32(txtCod.Text);
                this.Dispose();
                //passar o cod do aluno por parametro para a tela de cadastro para altera-lo
                FrmCadastroNotas alterar = new FrmCadastroNotas(cod);
                alterar.ShowDialog();
            }
            else
            {
                Mensagens.mensagemAlerta(" Digite um codigo e busca as informacoes antes de alterar!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCod.Text != "")
            {
                int id = Convert.ToInt32(txtCod.Text);
                this.Dispose();
                //passar por parametro o codigo do aluno para a tela exclusao 
                FrmExcluirNotas_Faltas tela = new FrmExcluirNotas_Faltas(id);
                tela.ShowDialog();
            }
            else
            {
                Mensagens.mensagemAlerta("Digite uma nota e busca as informacoes antes de excluir!");
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
