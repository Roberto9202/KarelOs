using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace MiLibreria
{
    public class Utilerias
    {
        public static DataSet Ejecutar(string cmd)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=altair;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            DataSet dt = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd, databaseConnection);

            da.Fill(dt);

            databaseConnection.Close();

            return dt;
        }

        public static DataTable LlenarGrid(string cmd)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=altair;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd, databaseConnection);

            da.Fill(dt);

            databaseConnection.Close();

            return dt;
        }
    }
}
