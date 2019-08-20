using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAluno
{
    public partial class Notas_Faltas
    {
        public static Notas_Faltas[] _listarNotas_Faltas = new Notas_Faltas[200];
        public static int _contNotas = 0;
        private double _av1;
        private double _av2;
        private double _trab1;
        private double _trab2;
        private int _faltas;
        private double _cod;
        private string _aluno;

        public Notas_Faltas(string aluno)
        {
            this.Aluno = aluno;
        }

        public Notas_Faltas(string aluno, int falta)
        {
            this.Aluno = aluno;
            this.Faltas = falta;
        }
        public Notas_Faltas(string aluno, int falta,int codigo)
        {
            this.Aluno = aluno;
            this.Faltas = falta;
            this._cod = codigo;
        }

        public double Av1
        {
            get
            {
                return _av1;
            }

            set
            {
                _av1 = value;
            }
        }

        public double Av2
        {
            get
            {
                return _av2;
            }

            set
            {
                _av2 = value;
            }
        }

        public double Trab1
        {
            get
            {
                return _trab1;
            }

            set
            {
                _trab1 = value;
            }
        }

        public double Trab2
        {
            get
            {
                return _trab2;
            }

            set
            {
                _trab2 = value;
            }
        }

        public int Faltas
        {
            get
            {
                return _faltas;
            }

            set
            {
                _faltas = value;
            }
        }

        public double Cod
        {
            get
            {
                return _cod;
            }
        }

        public string Aluno
        {
            get
            {
                return _aluno;
            }

            set
            {
                _aluno = value;
            }
        }
    }
}
