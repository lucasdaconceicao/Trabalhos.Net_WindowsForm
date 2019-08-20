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
    public partial class Cadastro_Dentista : Form
    {
        public Cadastro_Dentista()
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
                    List<Dentistas> salvarDentista = new List<Dentistas>();
                    string arquivo = @"C:\\aula arquivo texto\Cadastro dentista.txt";
                    StreamWriter sw = new StreamWriter(arquivo, true);
                    Dentistas dentista = new Dentistas();
                    dentista.Nome = txtNome.Text;
                    dentista.Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                    dentista.Estado = cbxEstado.SelectedItem.ToString();
                    dentista.Endereco = txtEndereco.Text;
                    dentista.Cpf =txtCpf.Text;
                    dentista.Celular =txtCelular.Text;
                    dentista.Sexo = rbF.Checked ? 'f' : 'm';

                    sw.WriteLine("Nome: " + dentista.Nome + "/ Cpf: " + dentista.Cpf + "/ Data Nascimento: " +
                        dentista.Nascimento + "/ Sexo: " + dentista.Sexo + "/ Estado: " + dentista.Estado);
                    sw.WriteLine("");
                    sw.Dispose();
                    MessageBox.Show("Cadastrado!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dentistas.cadastrarDentistas(salvarDentista, dentista);
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
                                cbxEstado.Text= "";
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

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
