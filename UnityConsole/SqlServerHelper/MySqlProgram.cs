using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerHelper
{
    class MySqlProgram
    {
        static void Main(string[] args)
        {
            List<AD> list = new List<AD>();
            try
            {
                string sql = "select * from login ";

                using (MySqlConnection con = new MySqlConnection(DbHelperMySQL.connectionString))
                {
                    var t = con.Query<AD>(sql);

                    list = con.Query<AD>(sql).AsList();
                }
            }
            catch (Exception ex)
            {

            }
        }

        static void Main3(string[] args)
        {
            List<AD> list = new List<AD>();
            try
            {
                string sql = "select * from login ";

                using (MySqlConnection con = new MySqlConnection(DbHelperMySQL.connectionString))
                {
                    var t = con.Query<AD>(sql);

                    list = con.Query<AD>(sql).AsList();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    class AD
    {
        public string w { get; set; }
        public string e { get; set; }
    }
}
