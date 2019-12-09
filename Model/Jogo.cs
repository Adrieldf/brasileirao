using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Model
{
    public class Jogo
    {
        public int IdJogo { get; set; }
        public int Data { get; set; }
        public int TimeCasa { get; set; }
        public int TimeFora { get; set; }
        public string Resultado { get; set; }
        public string Casa { get; set; }
        public string Fora { get; set; }
    }
}
