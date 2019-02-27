//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using System.IO;
//using MySql.Data.MySqlClient;
//using Dapper;
//using log4net;
//using System.Configuration;

//namespace SqlServerHelper
//{
//    class Program
//    {
       

//        static void Main(string[] args)
//        {
//            //初始化日志文件 
//            string state = ConfigurationManager.AppSettings["IsWriteLog"];
//            //判断是否开启日志记录
//            if (state == "1")
//            {
//                LogHelper.Loginfo.Info("123");

//                var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
//                           ConfigurationManager.AppSettings["log4net"];

//                if (File.Exists(path))
//                {

//                }
//                var fi = new System.IO.FileInfo(path);
//                log4net.Config.XmlConfigurator.Configure(fi);
//            }

//            LogHelper.WriteLog("holle world213421");

//            try
//            {

//            string a = null;
//            a.Remove(1);
//            }
//            catch (Exception ex)
//            {
//                LogHelper.WriteLog("报错了234321", ex);
//            }
//        }

//        static void Main2(string[] args)
//        {
//            var host = "server = localhost;database = abc;user =sa;password =admin";

//            var conn = new SqlConnection(host);

//            conn.Open();

//            var cmd = new SqlCommand("select * from [login] where account = '93'", conn);

//            var rd = cmd.ExecuteReader();

//            rd.Read();

//            var dk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

//            var dp = Path.Combine(dk, "js.json");


//            if (rd.HasRows)
//            {
//                {
//                    File.WriteAllText(dp, "have");
//                }
//            }
//            else
//            {
//                File.WriteAllText(dp, "nothing");

//            }
//        }

//        static void Main3(string[] args)
//        {
//            List<AD> list = new List<AD>();
//            try
//            {
//                string sql = "select * from login ";

//                using (MySqlConnection con = new MySqlConnection(DbHelperMySQL.connectionString))
//                {
//                    list = con.Query<AD>(sql).AsList();
//                }
//            }
//            catch (Exception ex)
//            {

//            }                            
//        }

//    }
//    class AD
//    {
//        public string account { get; set; }
//        public string password { get; set; }
//    }
//}
