using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu_Fomulario
{
    public partial class Cadastro_Pacientes : Form
    {
        public Cadastro_Pacientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (VerificarCampo())
            {
                try
                {
                    List<Pacientes> salvarPaciente = new List<Pacientes>();
                    string arquivo = @"C:\\aula arquivo texto\Cadastro pacientes.txt";
                    StreamWriter sw = new StreamWriter(arquivo, true);
                    Pacientes Paciente = new Pacientes();
                    Paciente.Nome = txtNome.Text;
                    Paciente.Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                    Paciente.Estado = cbxEstado.SelectedItem.ToString();
                    Paciente.Endereco = txtEndereco.Text;
                    Paciente.Cpf = txtCpf.Text;
                    Paciente.Celular = txtCelular.Text;
                    Paciente.Sexo = rbF.Checked ? 'f' : 'm';

                    sw.WriteLine("Nome: " + Paciente.Nome + "/ Cpf: " + Paciente.Cpf + "/ Data Nascimento: " +
                        Paciente.Nascimento + "/ Sexo: " + Paciente.Sexo + "/ Estado: " + Paciente.Estado);
                    sw.WriteLine("");
                    sw.Dispose();
                    MessageBox.Show("Cadastrado!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Pacientes.cadastrarPacientes(salvarPaciente, Paciente);
                    Limpartela();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Limpartela()
        {
            txtNome.Text = "";
            cbxEstado.SelectedIndex = -1;
            txtEndereco.Text = "";
            txtCpf.Text = "";
            txtCelular.Text = "";
            rbF.Checked = false;
            rbM.Checked = false;
        }
        private bool VerificarCampo()
        {

            if (rbF.Checked || rbM.Checked)
            {
                if (txtCelular.Text.Trim() != "")
                {
                    if (txtCpf.Text.Trim() != "")
                    {
                        if (txtEndereco.Text.Trim() != "")
                        {
                            if (cbxEstado.SelectedIndex != -1)
                            {
                                if (txtNome.Text.Trim() != "")
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Informe corretamente campo do Nome", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Escolha um estado", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cbxEstado.Text = "";
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Informe corretamente campo endereco", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Informe corretamente campo CPf", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Informe corretamente campo do celular", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Selecione um sexo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void txtCelular_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCpf_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}

