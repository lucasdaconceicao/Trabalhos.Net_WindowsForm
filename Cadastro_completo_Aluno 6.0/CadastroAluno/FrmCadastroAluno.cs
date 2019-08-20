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
    public partial class FrmCadastroAluno : Form
    {
        private int id;
        //inicializando a tela normal para cadastrar
        public FrmCadastroAluno()
        {
            InitializeComponent();
            txtRenda.Text = " 200,20";
            txtMensalidade.Text = " 200,10";
            cbxFuncao.SelectedIndex = 0;
        }

        //Só é ativado quando aperta a tecla alterar do formulario visualizar
        public FrmCadastroAluno(int cod)
        {
            this.id = cod;
            Aluno alunoSelecionado = Aluno.buscarDados(this.id);
            InitializeComponent();
            cbxFuncao.SelectedIndex = 1;
            txtCod.Text = id.ToString();
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
            maskTelefone.Text = alunoSelecionado.Telefone;
            cbxPeriodo.Text = alunoSelecionado.Periodo;
            maskCpf.Text = alunoSelecionado.Cpf;
            if (alunoSelecionado.Sexo == 'M')
            {
                rb_m.Checked = true;
            }
            else
            {
                rb_f.Checked = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //funcao que converte para inteiro, retorna false ou true
            double numRenda;
            bool ConversaoRenda = double.TryParse(txtRenda.Text, out numRenda);
            double numMensalidade;
            bool ConversaoMensalidade = double.TryParse(txtMensalidade.Text, out numMensalidade);
            //Cadastrar ou alterar um aluno
            //Se a validacao retornou true e se renda e mensalidade retornou true vai cadastrar ou alterar 
            if (validarCampo())
            {
                if (ConversaoRenda)
                {
                    if (ConversaoMensalidade)
                    {
                        if (cbxFuncao.SelectedIndex == 0)
                        {
                            string novoNome = txtNome.Text;
                            Aluno aluno = new Aluno(novoNome, numRenda);
                            aluno.Cod = Aluno._contAluno;
                            aluno.Bairro = txtBairro.Text;
                            aluno.Cidade = txtCidade.Text;
                            aluno.Curso = txtCurso.Text;
                            aluno.Email = txtEmail.Text;
                            aluno.Estado = txtEstado.Text;
                            aluno.EstadoCivil = txtEstadoCivil.Text;
                            aluno.Mensalidade = numMensalidade;
                            aluno.Logradouro = txtLogradouro.Text;
                            aluno.Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                            aluno.Telefone = maskTelefone.Text;
                            aluno.Periodo = cbxPeriodo.Text;
                            aluno.Cpf = maskCpf.Text;
                            if (rb_m.Checked)
                            {
                                aluno.Sexo = 'M';
                            }
                            else
                            {
                                aluno.Sexo = 'F';
                            }
                            // cadastrar  
                            bool sucesso = Aluno.cadastrarAluno(aluno);
                            if (sucesso)
                            {
                                Mensagens.mensagemSucesso("O Aluno: " + aluno.Nome + " foi cadastrado com sucesso!","CONCLUIDO!");
                                Mensagens.mensagemAlerta("Guarde o seu codigo: " + aluno.Cod);
                                limparDados();
                            }
                            else
                            {
                                Mensagens.mensagemErro("Não é possivel cadastrar mais alunos a lista esta cheia, delete para liberar espaço!");
                            }
                        }
                        //Alterar dados  do aluno ja existente
                        else
                        {
                            int id = Convert.ToInt32(txtCod.Text);
                            //funcao para retornar os dados desse aluno no vetor
                            Aluno alunoBusca = Aluno.buscarDados(id);
                            if (alunoBusca != null)
                            {
                                alunoBusca.Cod = id;
                                alunoBusca.Nome = txtNome.Text;
                                alunoBusca.RendaFamilia = numRenda;
                                alunoBusca.Bairro = txtBairro.Text;
                                alunoBusca.Cidade = txtCidade.Text;
                                alunoBusca.Curso = txtCurso.Text;
                                alunoBusca.Email = txtEmail.Text;
                                alunoBusca.Estado = txtEstado.Text;
                                alunoBusca.EstadoCivil = txtEstadoCivil.Text;
                                alunoBusca.Mensalidade = numMensalidade;
                                alunoBusca.Logradouro = txtLogradouro.Text;
                                alunoBusca.Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                                alunoBusca.Telefone = maskTelefone.Text;
                                alunoBusca.Periodo = cbxPeriodo.Text;
                                alunoBusca.Cpf = maskCpf.Text;
                                if (rb_m.Checked)
                                {
                                    alunoBusca.Sexo = 'M';
                                }
                                else
                                {
                                    alunoBusca.Sexo = 'F';
                                }
                                Mensagens.mensagemSucesso("O Aluno: " + alunoBusca.Nome + " foi alterado com sucesso!", "CONCLUIDO!");
                                Aluno._listarAluno[id] = alunoBusca;
                                this.Dispose();
                            }
                            //Se o aluno nao foi encontrado no vetor
                            else
                            {
                                Mensagens.mensagemErro("Ocorreu um erro ao alterar o aluno tente novamente!", "OCORREU UM ERRO!");
                            }
                        }
                    }
                    else
                    {
                        Mensagens.mensagemErro("Forneça um valor numérico no campo da Mensalidade ou revise os dados!", "OCORREU UM ERRO!");
                    }
                }
                else
                {
                    Mensagens.mensagemErro("Forneça um valor numérico no campo da Renda ou revise os dados!","OCORREU UM ERRO!");
                }
            }
        }

        //Limpar os dados do campo
        private void limparDados()
        {
            txtNome.Clear();
            txtRenda.Text = " 200,70";
            txtMensalidade.Text = " 200,90";
            txtBairro.Clear();
            txtCidade.Clear();
            txtCurso.Clear();
            txtEmail.Clear();
            txtEstado.Clear();
            txtEstadoCivil.Clear();
            txtLogradouro.Clear();
            maskTelefone.Clear();
            cbxPeriodo.SelectedIndex = -1;
            maskCpf.Clear();
            rb_f.Checked = false;
            rb_m.Checked = false;
        }

        //validar os campo do formulario
        private bool validarCampo()
        {
            if (txtNome.Text.Trim() != "" && txtNome.Text.Length > 3)
            {
                if (txtRenda.Text.Trim() != "")
                {
                    if (txtBairro.Text.Trim() != "" && txtBairro.Text.Length > 3)
                    {
                        if (txtCidade.Text.Trim() != "" && txtCidade.Text.Length > 3)
                        {
                            if (txtCurso.Text.Trim() != "" && txtCurso.Text.Length > 3)
                            {
                                if (txtEmail.Text.Trim() != "" && txtEmail.Text.Length > 3)
                                {
                                    if (txtEstado.Text.Trim() != "" && txtEstado.Text.Length > 3)
                                    {
                                        if (txtEstadoCivil.Text.Trim() != "" && txtEstadoCivil.Text.Length > 3)
                                        {
                                            if (txtMensalidade.Text.Trim() != "")
                                            {
                                                if (txtLogradouro.Text.Trim() != "" && txtLogradouro.Text.Length > 3)
                                                {
                                                    maskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                                    if (maskTelefone.Text.Trim() != "" && maskTelefone.Text.Length >= 11)
                                                    {
                                                        if (cbxPeriodo.SelectedIndex != -1)
                                                        {
                                                            if (rb_m.Checked || rb_f.Checked)
                                                            {
                                                                maskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                                                                if (maskCpf.Text.Trim() != "" && maskCpf.Text.Length >= 11)
                                                                {
                                                                    return true;
                                                                }
                                                                else
                                                                {
                                                                    Mensagens.mensagemAlerta("Informe corretamente campo do CPF ou revise os dados!", "VERIFIQUE!");
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Mensagens.mensagemAlerta("Selecione um Sexo!", "VERIFIQUE!");
                                                                return false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Mensagens.mensagemAlerta("Selecione campo do Periodo!","VERIFIQUE!");
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Mensagens.mensagemAlerta("Informe corretamente campo do Telefone ou revise os dados!", "VERIFIQUE!");
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    Mensagens.mensagemAlerta("Informe corretamente campo do Logradouro!", "VERIFIQUE!");
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                Mensagens.mensagemAlerta("Informe corretamente campo da Mensalidade, apenas números!");
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            Mensagens.mensagemAlerta("Informe corretamente campo do Estado Civil!", "VERIFIQUE!");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        Mensagens.mensagemAlerta("Informe corretamente campo do Estado, o nome deve ser completo!", "VERIFIQUE!");
                                        return false;
                                    }
                                }
                                else
                                {
                                    Mensagens.mensagemAlerta("Informe corretamente campo do Email!", "VERIFIQUE!");
                                    return false;
                                }
                            }
                            else
                            {
                                Mensagens.mensagemAlerta("Informe corretamente campo do Curso, o nome deve ser completo!", "VERIFIQUE!");
                                return false;
                            }
                        }
                        else
                        {
                            Mensagens.mensagemAlerta("Informe corretamente campo da Cidade, o nome deve ser completo!", "VERIFIQUE!");
                            return false;
                        }
                    }
                    else
                    {
                        Mensagens.mensagemAlerta("Informe corretamente campo do Bairro!");
                        return false;
                    }
                }
                else
                {
                    Mensagens.mensagemAlerta("Informe corretamente campo da Renda utilizando apenas números!", "VERIFIQUE!");
                    return false;
                }
            }
            else
            {
                Mensagens.mensagemAlerta("Informe corretamente  Nome e Sobrenome!", "VERIFIQUE!");
                return false;
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparDados();
        }
    }
}


