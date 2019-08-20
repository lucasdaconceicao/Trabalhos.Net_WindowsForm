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
    public partial class FrmCadastroMateria : Form
    {
        private int id;
        //iniciando a tela normal
        public FrmCadastroMateria()
        {
            InitializeComponent();
            listaNomeAlunosCursos();
            cbxFuncao.SelectedIndex = 0;
        }

        //Quando vem da tela visualizar 
        public FrmCadastroMateria(int cod)
        {
            this.id = cod;
            InitializeComponent();
            cbxFuncao.SelectedIndex = 1;
            Materia materiaSelecionada = Materia.buscarDados(this.id);
            txtProf.Text = materiaSelecionada.Professor;
            txtDisciplina.Text = materiaSelecionada.Disciplina; ;
            txtCarga.Text = materiaSelecionada.Carga.ToString();
            txtCod.Text = materiaSelecionada.Cod.ToString();
            txtAulas.Text = materiaSelecionada.Aulas.ToString();
            txtMatricula.Text = materiaSelecionada.Matricula.ToString();
            dtpMatricula.Text = materiaSelecionada.Data_matricula.ToString();
            listaNomeAlunosCursos();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            //Conversao para inteiro retorna true ou false
            int numMatricula;
            bool ConversaoMatricula = int.TryParse(txtMatricula.Text, out numMatricula);
            int numCarga;
            bool ConversaoCarga = int.TryParse(txtCarga.Text, out numCarga);
            int numAula;
            bool ConversaoAula = int.TryParse(txtAulas.Text, out numAula);

            if (validarCampo())
            {
                if (ConversaoMatricula)
                {
                    if (ConversaoCarga)
                    {
                        if (ConversaoAula)
                        {
                            if (cbxFuncao.SelectedIndex == 0)
                            {
                                string novoDisciplina = txtDisciplina.Text;
                                string novoProf = txtProf.Text;
                                int id = Materia._contMateria;
                                Materia materia = new Materia(novoDisciplina, novoProf,id);
                                materia.Aluno = cbxAluno.SelectedItem.ToString();
                                materia.Carga = numCarga;
                                materia.Curso = cbxCurso.SelectedItem.ToString();
                                materia.Aulas = numAula;
                                materia.Matricula = numMatricula;
                                materia.Turma = cbxTurma.SelectedItem.ToString();
                                materia.Data_matricula = Convert.ToDateTime(dtpMatricula.Text);
                                //Funcao para cadastrar materia
                                bool sucesso = Materia.cadastrarMateria(materia);
                                if (sucesso)
                                {
                                    Mensagens.mensagemSucesso("A materia: " + materia.Disciplina + " foi cadastrado com sucesso!");
                                    Mensagens.mensagemAlerta("Guarde o seu codigo: " + materia.Cod);
                                    limparDados();
                                }
                                else
                                {
                                    Mensagens.mensagemErro("Não é possivel cadastrar Materias a lista esta cheia, delete para liberar espaço!");
                                }
                            }
                            else
                            {
                                //Alterar
                                int id = Convert.ToInt32(txtCod.Text);
                                Materia materiaBusca = Materia.buscarDados(id);
                                if (materiaBusca != null)
                                {
                                    materiaBusca.Professor = txtProf.Text;
                                    materiaBusca.Disciplina = txtDisciplina.Text;
                                    materiaBusca.Aluno = cbxAluno.SelectedItem.ToString();
                                    materiaBusca.Carga = numCarga;
                                    materiaBusca.Curso = cbxCurso.SelectedItem.ToString();
                                    materiaBusca.Aulas = numAula;
                                    materiaBusca.Matricula = numMatricula;
                                    materiaBusca.Turma = cbxTurma.SelectedItem.ToString();
                                    materiaBusca.Data_matricula = Convert.ToDateTime(dtpMatricula.Text);
                                    Mensagens.mensagemSucesso("A materia: " + materiaBusca.Disciplina + " foi alterado com sucesso!");
                                    Materia._listarMateria[id] = materiaBusca;
                                    this.Dispose();
                                }
                                else
                                {
                                    Mensagens.mensagemErro("Ocorreu um erro ao alterar a materia tente novamente!");
                                }
                            }
                        }
                        else
                        {
                            Mensagens.mensagemErro("Forneça um valor numérico ou revise as informações no campo total de aulas!");
                        }
                    }
                    else
                    {
                        Mensagens.mensagemErro("Forneça um valor numérico ou revise as informações no campo da carga horária!");
                    }
                }
                else
                {
                    Mensagens.mensagemErro("Forneça um valor numérico ou revise as informações no campo da matrícula!");
                }
            }
        }

        //Limpar campos
        private void limparDados()
        {
            txtAulas.Text = "";
            txtCarga.Text = "";
            txtDisciplina.Text = "";
            txtMatricula.Text = "";
            txtProf.Text = "";
            cbxTurma.SelectedIndex = -1;
            cbxAluno.SelectedIndex = -1;
            cbxCurso.SelectedIndex = -1;
        }

        private bool validarCampo()
        {
            if (txtMatricula.Text.Trim() != "" && txtMatricula.Text.Length >= 3)
            {
                if (txtDisciplina.Text.Trim() != "" && txtDisciplina.Text.Length > 3)
                {
                    if (cbxTurma.SelectedIndex != -1)
                    {
                        if (txtProf.Text.Trim() != "" && txtProf.Text.Length > 3)
                        {
                            if (txtCarga.Text.Trim() != "")
                            {
                                if (txtAulas.Text.Trim() != "")
                                {
                                    if (cbxCurso.SelectedIndex != -1)
                                    {
                                        if (cbxAluno.SelectedIndex != -1)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            Mensagens.mensagemAlerta("Selecione um Aluno ou cadastre um!");
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        Mensagens.mensagemAlerta("Selecione um Curso!");
                                        return false;
                                    }
                                }
                                else
                                {
                                    Mensagens.mensagemAlerta("Informe corretamente o total de aulas!");
                                    return false;
                                }
                            }
                            else
                            {
                                Mensagens.mensagemAlerta("Informe corretamente total de carga horária!");
                                return false;
                            }
                        }
                        else
                        {
                            Mensagens.mensagemAlerta("Informe corretamente o nome do professor!");
                            return false;
                        }
                    }
                    else
                    {
                        Mensagens.mensagemAlerta("Selecione uma turma!");
                        return false;
                    }
                }
                else
                {
                    Mensagens.mensagemAlerta("Informe corretamente o nome da disciplina!");
                    return false;
                }
            }
            else
            {
                Mensagens.mensagemAlerta("Informe corretamente o campo da matrícula");
                return false;
            }
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            limparDados();
        }

        private void listaNomeAlunosCursos()
        {
            foreach (var aluno in Aluno._listarAluno)
            {
                if (aluno != null)
                {
                    cbxAluno.Items.Add(aluno.Nome);
                    cbxCurso.Items.Add(aluno.Curso);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }

}


