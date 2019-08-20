using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Fomulario
{
    class Pacientes:Pessoas
    {
        public static void cadastrarPacientes(List<Pacientes> cadastro, Pacientes paciente)
        {
            cadastro.Add(paciente);
        }

    }
}
