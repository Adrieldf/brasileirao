using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brasileirao.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Brasileirao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tabela : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            //DbTime db = new DbTime();
            //db.GetTimes();
            DbTabela t = new DbTabela();
            string json = JsonConvert.SerializeObject(t.GetTabelas(0));
            return json;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            DbTabela t = new DbTabela();
            string[] param = value.Split("|");//timecasa | gols casa | time fora | gols fora
            Model.Tabela tabelaTimeCasa = new Model.Tabela();
            Model.Tabela tabelaTimeFora = new Model.Tabela();
            tabelaTimeCasa = t.GetTabelasPorTime(int.Parse(param[0])).FirstOrDefault();
            tabelaTimeFora = t.GetTabelasPorTime(int.Parse(param[2])).FirstOrDefault();
            #region Cria registro nas tabelas
            //se é a primeira vez nao tem registro na tabela entao tem que criar 
            if (tabelaTimeCasa == null)
            {
                tabelaTimeCasa = new Model.Tabela();
                tabelaTimeCasa.IdTabela = int.Parse(param[0]);
                tabelaTimeCasa.Time = int.Parse(param[0]);
                tabelaTimeCasa.Pontos = 0;
                tabelaTimeCasa.Vitorias = 0;
                tabelaTimeCasa.Derrotas = 0;
                tabelaTimeCasa.Empates = 0;
                tabelaTimeCasa.GolsFeitos = 0;
                tabelaTimeCasa.GolsSofridos = 0;
                tabelaTimeCasa.Campeonato = 1; //ver qual campeonato está selecionado e pegar dele depois
                tabelaTimeCasa.Rodada = 0;
            }
            if (tabelaTimeFora == null)
            {
                tabelaTimeFora = new Model.Tabela();
                tabelaTimeFora.IdTabela = int.Parse(param[2]);
                tabelaTimeFora.Time = int.Parse(param[2]);
                tabelaTimeFora.Pontos = 0;
                tabelaTimeFora.Vitorias = 0;
                tabelaTimeFora.Derrotas = 0;
                tabelaTimeFora.Empates = 0;
                tabelaTimeFora.GolsFeitos = 0;
                tabelaTimeFora.GolsSofridos = 0;
                tabelaTimeFora.Campeonato = 1;//mesma coisa de ali de cima
                tabelaTimeFora.Rodada = 0;
            }
            #endregion

            int golsCasa, golsFora;
            golsCasa = int.Parse(param[1]);
            golsFora = int.Parse(param[3]);
            if (golsCasa > golsFora)//vitoria time da casa
            {
                tabelaTimeCasa.Pontos += 3;
                tabelaTimeCasa.Vitorias += 1;

                tabelaTimeFora.Derrotas += 1;

            }
            else if (golsCasa < golsFora)//vitoria do time de fora
            {
                tabelaTimeFora.Pontos += 3;
                tabelaTimeFora.Vitorias += 1;

                tabelaTimeCasa.Derrotas += 1;
            }
            else //empate
            {
                tabelaTimeCasa.Pontos += 1;
                tabelaTimeCasa.Empates += 1;

                tabelaTimeFora.Pontos += 1;
                tabelaTimeFora.Empates += 1;
            }

            tabelaTimeCasa.GolsFeitos += golsCasa;
            tabelaTimeCasa.GolsSofridos += golsFora;
            tabelaTimeCasa.Rodada += 1;

            tabelaTimeFora.GolsFeitos += golsFora;
            tabelaTimeFora.GolsSofridos += golsCasa;
            tabelaTimeFora.Rodada += 1;

            t.SaveTabela(tabelaTimeCasa);
            t.SaveTabela(tabelaTimeFora);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
