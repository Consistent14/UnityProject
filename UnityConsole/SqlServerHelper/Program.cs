using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace SqlServerHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "server = localhost;database = abc;user =sa;password =admin";

            var conn = new SqlConnection(host);

            conn.Open();

            var cmd = new SqlCommand("select * from [login] where account = '93'", conn);

            var rd = cmd.ExecuteReader();

            rd.Read();

            var dk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var dp = Path.Combine(dk, "js.json");


            if (rd.HasRows)
            {
                {
               
                        File.WriteAllText(dp, "have");
                }
            }
            else
            {
                File.WriteAllText(dp, "nothing");

            }
        }
    }
}
