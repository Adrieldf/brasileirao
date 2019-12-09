using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Model
{
    public class Rodada
    {
        public int IdRodada { get; set; }
        public int Numero { get; set; }
        public int Jogo { get; set; }
        public int Campeonato { get; set; }
        public int Data { get; set; }
    }
}
