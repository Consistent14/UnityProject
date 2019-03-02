using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace NoticeToUnity
{
    class SqlProgram
    {
        static void Main(string[] args)
        {
            //写法一："Data Source=服务器名; Initial Catalog=数据库; User ID =用户名; Password=密码; Charset=UTF8; "

            //写法二："Server=服务器名; Database=数据库; uid=用户名; Password=密码;Charser=UTF8"

            //var appsetting = "server=192.168.1.105;Initial Catalog = abc; Integrated Security = True";

            //appsetting = "server = 192.168.1.105; Initial Catalog = Person; uid = sa; Password = admin; Integrated Security = True";

            //using (var connentcion = new SqlConnection(appsetting))
            //{
            //    connentcion.Open();

            //    var sqlContents = "select * from [login]";

            //    var cmd = new SqlCommand(sqlContents, connentcion);

            //    var reader = cmd.ExecuteReader();

            //    reader.Read();

            //    if (reader.HasRows)
            //    {

            //    }
            //}

            //var s = SqlserverHelper.connstr;

            string SqlStr = ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;

            var ds = SQLHelper.Search("select * from login where id = 1");

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                var dt = ds.Tables[i];

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    var row = dt.Rows[j];

                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        Console.Write(row[k]+"\t");
                    }

                    Console.WriteLine("============");
                }
            }

            Console.ReadKey();

            //第一种方式：
            //foreach (DataRow item in dt.Rows)
            //{
            //    for (int i = 0; i < dt.Columns.Count; i++)
            //    {
            //        Console.Write(item[i].ToString() + "\t");
            //    }
            //    Console.WriteLine();
            //}
        }
    }


    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class SQLHelper
    {
        //private static string connStr = "server = 192.168.1.105; Initial Catalog = Person; uid = sa; Password = admin; Integrated Security = True";

        private static string connStr = ConfigurationManager.ConnectionStrings["SqlConnString"].ConnectionString;



        //定义对象
        private static SqlConnection conn = null;
        private static SqlCommand cmd = null;
        private static SqlDataAdapter sda = null;
        private static DataSet ds = null;

        /// <summary>
        /// 查询多行多列
        /// </summary>
        public static DataSet Search(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    foreach (SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    sda = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    sda.Fill(ds);

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 查询单行单列
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    foreach (SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    object obj = cmd.ExecuteScalar();

                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 查询单行单列(增删改查)
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    foreach (SqlParameter p in parameters)
                    {
                        cmd.Parameters.Add(p);
                    }
                    int row = cmd.ExecuteNonQuery();

                    return row;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}


