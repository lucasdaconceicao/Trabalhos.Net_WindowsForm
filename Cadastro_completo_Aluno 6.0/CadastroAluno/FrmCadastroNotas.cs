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
    public partial class FrmCadastroNotas : Form
    {
        private int id;
        //Inicializando tela  normal de cadastro
        public FrmCadastroNotas()
        {
            InitializeComponent();
            cbxFuncao.SelectedIndex = 0;
            listaNomeAlunos();
        }

        //Quando vem da tela visualizar
        public FrmCadastroNotas(int id)
        {
            this.id = id;
            Notas_Faltas notaSelecionado = Notas_Faltas.buscarDados(this.id);
            InitializeComponent();
            cbxFuncao.SelectedIndex = 1;
            txtCod.Text = id.ToString();
            txtAv1.Text = notaSelecionado.Av1.ToString();
            txtAv2.Text = notaSelecionado.Av2.ToString();
            txtFaltas.Text = notaSelecionado.Faltas.ToString();
            txtTrab1.Text = notaSelecionado.Trab1.ToString();
            txtTrab2.Text = notaSelecionado.Trab2.ToString();
            listaNomeAlunos();
        }

        //Quando clico em salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //funcao para converter para inteiro ou double
            double numAv1;
            bool ConversaoAv1 = double.TryParse(txtAv1.Text, out numAv1);
            double numAv2;
            bool ConversaoAv2 = double.TryParse(txtAv2.Text, out numAv2);
            int numFaltas;
            bool ConversaoFalta = int.TryParse(txtFaltas.Text, out numFaltas);
            double numTrab1;
            bool ConversaoTrab1 = double.TryParse(txtTrab1.Text, out numTrab1);
            double numTrab2;
            bool ConversaoTrab2 = double.TryParse(txtTrab2.Text, out numTrab2);

            if (validarCampo())
            {
                if (ConversaoAv1)
                {
                    if (ConversaoAv2)
                    {
                        if (ConversaoFalta)
                        {
                            if (ConversaoTrab1)
                            {
                                if (ConversaoTrab2)
                                {
                                    if (cbxFuncao.SelectedIndex == 0)
                                    {
                                        string aluno = cbxAluno.Text;
                                        int id= Notas_Faltas._contNotas;
                                        Notas_Faltas nota = new Notas_Faltas(aluno, numFaltas,id);
                                        nota.Av1 = numAv1;
                                        nota.Av2 = numAv2;
                                        nota.Trab1 = numTrab1;
                                        nota.Trab2 = numTrab2;
                                        //funcao para cadastro
                                        bool sucesso = Notas_Faltas.cadastrarNotas(nota);
                                        if (sucesso)
                                        {
                                            Mensagens.mensagemSucesso("A nota e falta foram cadastrado com sucesso!");
                                            Mensagens.mensagemAlerta("Guarde o seu codigo: " + nota.Cod);
                                            limparDados();
                                        }
                                        else
                                        {
                                            Mensagens.mensagemErro("Não é possivel cadastrar mais notas e falas a lista esta cheia, delete para liberar espaço!");
                                        }
                                    }
                                    else
                                    {
                                        //Alterar
                                        int id = Convert.ToInt32(txtCod.Text);
                                        Notas_Faltas notaBusca = Notas_Faltas.buscarDados(id);
                                        if (notaBusca != null)
                                        {
                                            notaBusca.Aluno = cbxAluno.Text;
                                            notaBusca.Av1 = numAv1;
                                            notaBusca.Av2 = numAv2;
                                            notaBusca.Faltas = numFaltas;
                                            notaBusca.Trab1 = numTrab1;
                                            notaBusca.Trab2 = numTrab2;
                                            Mensagens.mensagemSucesso(" Foi alterado com sucesso!");
                                            Notas_Faltas._listarNotas_Faltas[id] = notaBusca;
                                            this.Dispose();
                                        }
                                        else
                                        {
                                            Mensagens.mensagemErro("Ocorreu um erro ao alterar tente novamente!");
                                        }
                                    }
                                }
                                else
                                {
                                    Mensagens.mensagemErro("Forneça um valor numérico no campo do Trabalho 2 ou revise as informações!");
                                }
                            }
                            else
                            {
                                Mensagens.mensagemErro("Forneça um valor numérico no campo do Trabalho 1 ou revise as informações!");
                            }
                        }
                        else
                        {
                            Mensagens.mensagemErro("Forneça um valor numérico no campo da falta ou revise as informações!");
                        }
                    }
                    else
                    {
                        Mensagens.mensagemErro("Forneça um valor numérico no campo da avaliação 2 ou revise as informações!");
                    }
                }
                else
                {
                    Mensagens.mensagemErro("Forneça um valor numérico no campo da avaliação 1 ou revise as informações!");
                }
            }
        }
        //limpar os dados
        private void limparDados()
        {
            txtAv1.Clear();
            txtAv2.Clear();
            txtFaltas.Clear();
            txtTrab1.Clear();
            txtTrab2.Clear();
            cbxAluno.SelectedIndex = -1;
        }

        private bool validarCampo()
        {
            if (cbxAluno.SelectedIndex != -1)
            {
                if (txtAv1.Text.Trim() != "")
                {
                    if (txtAv2.Text.Trim() != "")
                    {
                        if (txtFaltas.Text.Trim() != "")
                        {
                            if (txtTrab1.Text.Trim() != "")
                            {
                                if (txtTrab2.Text.Trim() != "")
                                {
                                    return true;
                                }
                                else
                                {
                                    Mensagens.mensagemAlerta("Informe corretamente campo do Trabalho 2!");
                                    return false;
                                }
                            }
                            else
                            {
                                Mensagens.mensagemAlerta("Informe corretamente campo do Trabalho 1!");
                                return false;
                            }
                        }
                        else
                        {
                            Mensagens.mensagemAlerta("Informe corretamente campo da Falta!");
                            return false;
                        }
                    }
                    else
                    {
                        Mensagens.mensagemAlerta("Informe corretamente campo da Avaliação 2!");
                        return false;
                    }
                }
                else
                {
                    Mensagens.mensagemAlerta("Informe corretamente campo da Av1");
                    return false;
                }
            }
            else
            {
                Mensagens.mensagemAlerta("Selecione um Aluno ou cadastre um!");
                return false;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparDados();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void listaNomeAlunos()
        {
            foreach (var aluno in Aluno._listarAluno)
            {
                if (aluno != null)
                {
                    cbxAluno.Items.Add(aluno.Nome);
                }
            }
        }

    }
}





