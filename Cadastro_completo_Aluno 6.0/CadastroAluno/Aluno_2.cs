using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAluno
{
    public partial class Aluno
    {
        //Funcao para cadatrar um novo aluno
        public static bool cadastrarAluno(Aluno cadastro)
        {
            //verificando cada campo qual nao tem nenhum valor
            for (int i = _contAluno; i < _listarAluno.Length; i++)
            {
                if (_listarAluno[i] == null)
                {
                    _listarAluno[i] = cadastro;
                    _contAluno++;
                    return true;
                }
            }
            return false;
        }

        //buscar dados do aluno na posicao do codigo passado
        public static Aluno buscarDados(int cod)
        {
            return _listarAluno[cod];
        }

        //remover um aluno, verifica qual posicao do vetor tem o mesmo valor do codigo passado 
        public static bool excluirDadosAluno(int cod)
        {
            _listarAluno[cod] = null;
            return true;
        }
    }
}
