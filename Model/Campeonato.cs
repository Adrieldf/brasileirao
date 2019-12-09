using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Model
{
    public class Campeonato
    {
        public int IdCampeonato { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int DataInicial { get; set; }
        public int DataFinal { get; set; }
    }
}
