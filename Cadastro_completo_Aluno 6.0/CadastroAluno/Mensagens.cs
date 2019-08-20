using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroAluno
{
    public class Mensagens
    {
        public static void mensagemSucesso(string mensagem)
        {
            MessageBox.Show(mensagem, "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //sobrecarga
        public static void mensagemSucesso(string mensagem,string conclusao)
        {
            MessageBox.Show(mensagem, conclusao, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void mensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "INVÁLIDO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //sobrecarga
        public static void mensagemErro(string mensagem,string erro)
        {
            MessageBox.Show(mensagem, erro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void mensagemAlerta(string mensagem)
        {
            MessageBox.Show(mensagem, "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //sobrecarga
        public static void mensagemAlerta(string mensagem,string alerta)
        {
            MessageBox.Show(mensagem, alerta, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
