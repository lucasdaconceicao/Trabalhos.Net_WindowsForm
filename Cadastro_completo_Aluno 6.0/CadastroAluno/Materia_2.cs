using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAluno
{
    public partial class Materia
    {
        //cadatrar uma nova materia
        public static bool cadastrarMateria(Materia cadastro)
        {
            //verificando cada campo qual nao tem nenhum valor
            for (int i = _contMateria = 0; i < _listarMateria.Length; i++)
            {
                if (_listarMateria[i] == null)
                {
                    _listarMateria[i] = cadastro;
                    _contMateria++;
                    return true;
                }
            }
            return false;
        }

        //retornar os dados da materia
        public static Materia buscarDados(int cod)
        {
            return _listarMateria[cod];
        }

        //excluir os dados de uma materia
        public static bool excluirDadosMateria(int cod)
        {
            _listarMateria[cod] = null;
            return true;
        }
    }
}
