using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Fomulario
{
    class Dentistas:Pessoas
    {
        public static void cadastrarDentistas(List<Dentistas>cadastro,Dentistas dentista)
        {
            cadastro.Add(dentista);
        }


    }
}
