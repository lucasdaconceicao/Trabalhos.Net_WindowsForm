using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAluno
{
    public partial class Notas_Faltas
    {
        //cadastrar notas e faltas
        public static bool cadastrarNotas(Notas_Faltas cadastro)
        {
            //verificando cada campo qual nao tem nenhum valor
            for (int i = _contNotas; i < _listarNotas_Faltas.Length; i++)
            {
                if (_listarNotas_Faltas[i] == null)
                {
                    _listarNotas_Faltas[i] = cadastro;
                    _contNotas++;
                    return true;
                }
            }
            return false;
        }

        //retorna os dados de notas e faltas do aluno
        public static Notas_Faltas buscarDados(int cod)
        {
            return _listarNotas_Faltas[cod];
        }

        //excluir os dados do aluno
        public static bool excluirDadosNotas(int cod)
        {
            _listarNotas_Faltas[cod] = null;
            return true;
        }
    }
}
