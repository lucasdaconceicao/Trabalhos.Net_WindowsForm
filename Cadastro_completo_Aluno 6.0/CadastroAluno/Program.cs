using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tela_login;


namespace CadastroAluno
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Frm_Login flogin = new Frm_Login();
            flogin.ShowDialog();
            if (flogin.Logado)
            {
              Application.Run(new FrmControle());
            }
        }
    }
}
