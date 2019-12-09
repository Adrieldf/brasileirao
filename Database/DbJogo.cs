using Brasileirao.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Database
{
    public class DbJogo
    {
        public List<Jogo> GetJogos(bool semResultado = true)
        {
            List<Jogo> jogos = new List<Jogo>() { };
            DbConnection db = new DbConnection();
            db.Connect();
            db.conn.Open();
            var stm = "SELECT JOGO.*, TIME.NOME AS CASA, T2.NOME AS FORA FROM JOGO" +
                        " LEFT JOIN TIME ON TIME.IDTIME = JOGO.TIMECASA" +
                        " LEFT JOIN TIME T2 ON T2.IDTIME = JOGO.TIMEFORA";
            if(semResultado)
                       stm = stm + " WHERE JOGO.RESULTADO IS NULL OR JOGO.RESULTADO = '' ";
            var cmd = new MySqlCommand(stm, db.conn);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Jogo j = new Jogo();
                j.IdJogo = rdr.GetInt32(0);
                j.Data = rdr.GetInt32(1);
                j.TimeCasa = rdr.GetInt32(2);
                j.TimeFora = rdr.GetInt32(3);
                j.Resultado = rdr.GetString(4);
                j.Casa = rdr.GetString(5);
                j.Fora = rdr.GetString(6);
                jogos.Add(j);
            }
            db.conn.Close();

            return jogos;
        }
        public void SaveJogo(int idJogo, string resultado)
        {
            DbConnection db = new DbConnection();
            db.Connect();
            db.conn.Open();
            var stm = $"UPDATE JOGO SET RESULTADO = '{resultado}' WHERE (IDJOGO = '{idJogo}');";
            var cmd = new MySqlCommand(stm, db.conn);

            MySqlDataReader rdr = cmd.ExecuteReader();

           
            db.conn.Close();

            return;
        }
    }
}
