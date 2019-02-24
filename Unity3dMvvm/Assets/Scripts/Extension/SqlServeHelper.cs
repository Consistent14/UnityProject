using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Assets.Scripts.Extension
{
    public static class SqlServeHelper
    {
        public static SqlConnection GetSqlConnection(string source, string catalog)
        {
            var show = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID=sa;Password=admin", source, catalog);

            return new SqlConnection(show);
        }
       
    }
}
