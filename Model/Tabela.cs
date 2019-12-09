using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Model
{
    public class Tabela
    {
        public int IdTabela { get; set; }
        public int Time { get; set; }
        public int Pontos { get; set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public int Empates { get; set; }
        public int GolsFeitos { get; set; }
        public int GolsSofridos { get; set; }
        public int Campeonato { get; set; }
        public int Rodada { get; set; }
        public string NomeTime { get; set; }
    }
}
