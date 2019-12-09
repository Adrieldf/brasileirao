using Brasileirao.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brasileirao.Database
{
    public class DbTime
    {
        public List<Time> GetTimes()
        {
            List<Time> times = new List<Time>() { };
            DbConnection db = new DbConnection();
            db.Connect();
            db.conn.Open();
            var stm = "SELECT * FROM TIME";
            var cmd = new MySqlCommand(stm, db.conn);

            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Time t = new Time();
                t.IdTime = rdr.GetInt32(0);
                t.Nome = rdr.GetString(1);
                times.Add(t);
            }
            db.conn.Close();

            return times;
        }
    }
}
