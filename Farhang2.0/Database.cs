using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Farhang2._0
{
    class Database
    {
        public static List<String> getDBList(String alphabet = "")
        {
            List<String> dbList = new List<string>();

            NpgsqlConnection con = new NpgsqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=dotnet;Database=postgres;Encoding=UNICODE";
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                // "Connection Error!!! Make sure you have started your PostgreSQL 8.4 instance!"
                return null;
            }

            // retrieve list of databases
            //SELECT datname FROM pg_database WHERE datistemplate = false AND datname LIKE 'farhang%';
            NpgsqlCommand selectCommand = String.IsNullOrWhiteSpace(alphabet) ? new NpgsqlCommand("SELECT datname FROM pg_database WHERE datistemplate = false AND datname LIKE 'farhang%' order by datname asc;", con) : new NpgsqlCommand("SELECT datname FROM pg_database WHERE datistemplate = false AND datname LIKE 'farhang_db_" + alphabet + "%' order by datname asc;", con);
            NpgsqlDataReader dbListDataReader = selectCommand.ExecuteReader();

            while (dbListDataReader.Read())
            {
                dbList.Add(dbListDataReader.GetString(0));
            }

            con.Close();
            return dbList;
        }
    }
}
