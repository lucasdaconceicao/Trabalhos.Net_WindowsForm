using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAluno
{
    public partial class Aluno
    {
        public static Aluno[] _listarAluno = new Aluno[200];
        public static int _contAluno = 0;
        private int _cod;
        private string _nome;
        private DateTime _nascimento;
        private string _periodo;
        private string _curso;
        private string _telefone;
        private string _bairro;
        private string _logradouro;
        private string _cpf;
        private double _rendaFamilia;
        private string _estadoCivil;
        private string _email;
        private string _cidade;
        private double _mensalidade;
        private string _estado;
        private char _sexo;

        public Aluno(string nomeReal)
        {
            this.Nome = nomeReal;
        }

        public Aluno(string nomeReal, double renda)
        {
            this.Nome = nomeReal;
            this.RendaFamilia = renda;
        }

        public Aluno(string nomeReal, double renda, string novoCpf)
        {
            this.Nome = nomeReal;
            this.RendaFamilia = renda;
            this.Cpf = novoCpf;
        }

        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }

        public DateTime Nascimento
        {
            get
            {
                return _nascimento;
            }

            set
            {
                _nascimento = value;
            }
        }

        public string Periodo
        {
            get
            {
                return _periodo;
            }

            set
            {
                _periodo = value;
            }
        }

        public string Curso
        {
            get
            {
                return _curso;
            }

            set
            {
                _curso = value;
            }
        }

        public string Telefone
        {
            get
            {
                return _telefone;
            }

            set
            {
                _telefone = value;
            }
        }

        public string Bairro
        {
            get
            {
                return _bairro;
            }

            set
            {
                _bairro = value;
            }
        }

        public string Logradouro
        {
            get
            {
                return _logradouro;
            }

            set
            {
                _logradouro = value;
            }
        }

        public string Cpf
        {
            get
            {
                return _cpf;
            }

            set
            {
                _cpf = value;
            }
        }

        public double RendaFamilia
        {
            get
            {
                return _rendaFamilia;
            }

            set
            {
                _rendaFamilia = value;
            }
        }

        public string EstadoCivil
        {
            get
            {
                return _estadoCivil;
            }

            set
            {
                _estadoCivil = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Cidade
        {
            get
            {
                return _cidade;
            }

            set
            {
                _cidade = value;
            }
        }

        public double Mensalidade
        {
            get
            {
                return _mensalidade;
            }

            set
            {
                _mensalidade = value;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public char Sexo
        {
            get
            {
                return _sexo;
            }

            set
            {
                _sexo = value;
            }
        }

        public int Cod
        {
            get
            {
                return _cod;
            }

            set
            {
                _cod = value;
            }
        }
    }
}
