using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAluno
{
    public partial class Materia
    {
        public static Materia[] _listarMateria = new Materia[200];
        public static int _contMateria = 0;
        private int _cod;
        private int _matricula;
        private string _professor;
        private string _disciplina;
        private string _curso;
        private int _aulas;
        private int _carga;
        private string _turma;
        private string _aluno;
        private DateTime _data_matricula;

        public Materia()
        {
        }

        public Materia(string disciplina, string professor)
        {
            this.Disciplina = disciplina;
            this.Professor = professor;
        }

        public Materia(string disciplina, string professor, int codigo)
        {
            this.Disciplina = disciplina;
            this.Professor = professor;
            this._cod = codigo;
        }

        public int Matricula
        {
            get
            {
                return _matricula;
            }

            set
            {
                _matricula = value;
            }
        }

        public string Professor
        {
            get
            {
                return _professor;
            }

            set
            {
                _professor = value;
            }
        }

        public string Disciplina
        {
            get
            {
                return _disciplina;
            }

            set
            {
                _disciplina = value;
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

        public int Aulas
        {
            get
            {
                return _aulas;
            }

            set
            {
                _aulas = value;
            }
        }

        public int Carga
        {
            get
            {
                return _carga;
            }

            set
            {
                _carga = value;
            }
        }

        public string Turma
        {
            get
            {
                return _turma;
            }

            set
            {
                _turma = value;
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

        public int Cod
        {
            get
            {
                return _cod;
            }
        }

        public DateTime Data_matricula
        {
            get
            {
                return _data_matricula;
            }

            set
            {
                _data_matricula = value;
            }
        }
    }
}
