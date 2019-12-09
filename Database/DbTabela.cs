using Brasileirao.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Database
{
    public class DbTabela
    {
        public List<Tabela> GetTabelas(int id)
        {
            List<Tabela> tabelas = new List<Tabela>() { };
            DbConnection db = new DbConnection();
            db.Connect();
            db.conn.Open();
            var stm = "SELECT TABELA.*, TIME.NOME AS NOMETIME FROM TABELA " +
                        " LEFT JOIN TIME ON TIME.IDTIME = TABELA.TIME ";
            if (id != 0)
                stm = stm + $" WHERE ('IDTABELA' = '{id}')";
            var cmd = new MySqlCommand(stm, db.conn);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Tabela t = new Tabela();
                t.IdTabela = rdr.GetInt32(0);
                t.Time = rdr.GetInt32(1);
                t.Pontos = rdr.GetInt32(2);
                t.Vitorias = rdr.GetInt32(3);
                t.Derrotas = rdr.GetInt32(4);
                t.Empates = rdr.GetInt32(5);
                t.GolsFeitos = rdr.GetInt32(6);
                t.GolsSofridos = rdr.GetInt32(7);
                t.Campeonato = rdr.GetInt32(8);
                t.Rodada = rdr.GetInt32(9);
                t.NomeTime = rdr.GetString(10);
                tabelas.Add(t);
            }
            db.conn.Close();

            return tabelas;
        }
        public List<Tabela> GetTabelasPorTime(int id)
        {
            List<Tabela> tabelas = new List<Tabela>() { };
            DbConnection db = new DbConnection();
            db.Connect();
            db.conn.Open();
            var stm = "SELECT * FROM TABELA";
            if (id != 0)
                stm = stm + $" WHERE (TIME = '{id}')";
            var cmd = new MySqlCommand(stm, db.conn);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Tabela t = new Tabela();
                t.IdTabela = rdr.GetInt32(0);
                t.Time = rdr.GetInt32(1);
                t.Pontos = rdr.GetInt32(2);
                t.Vitorias = rdr.GetInt32(3);
                t.Derrotas = rdr.GetInt32(4);
                t.Empates = rdr.GetInt32(5);
                t.GolsFeitos = rdr.GetInt32(6);
                t.GolsSofridos = rdr.GetInt32(7);
                t.Campeonato = rdr.GetInt32(8);
                t.Rodada = rdr.GetInt32(9);
                tabelas.Add(t);
            }
            db.conn.Close();

            return tabelas;
        }
        public void SaveTabela(Tabela tabela)
        {
            DbConnection db = new DbConnection();
            db.Connect();
            db.conn.Open();
            string sql = $"INSERT INTO TABELA(IDTABELA,TIME,PONTOS,VITORIAS,DERROTAS,EMPATES,GOLSFEITOS,GOLSSOFRIDOS,CAMPEONATO,RODADA)" +
              $" VALUES ({tabela.IdTabela}, {tabela.Time}, {tabela.Pontos}, {tabela.Vitorias}, {tabela.Derrotas}, {tabela.Empates}, {tabela.GolsFeitos}, {tabela.GolsSofridos}, {tabela.Campeonato},{tabela.Rodada})" +
              $" ON DUPLICATE KEY UPDATE PONTOS = {tabela.Pontos},VITORIAS = {tabela.Vitorias},DERROTAS = {tabela.Derrotas},EMPATES = {tabela.Empates},GOLSFEITOS = {tabela.GolsFeitos},GOLSSOFRIDOS = {tabela.GolsSofridos},RODADA = {tabela.Rodada}; ";

            var cmd = new MySqlCommand(sql, db.conn);

            MySqlDataReader rdr = cmd.ExecuteReader();


            db.conn.Close();


        }
    }
}
