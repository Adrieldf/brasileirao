using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Brasileirao.Database
{
    public class DbConnection
    {
        public MySqlConnection conn { get; private set; }
        public DbConnection()
        {
            Connect();
        }

        public void Connect()
        {
            string myConnectionString;

            myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=brasileiraodb;";

            try
            {
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
