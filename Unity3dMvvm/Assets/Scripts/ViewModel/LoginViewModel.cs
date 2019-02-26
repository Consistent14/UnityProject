using Assets.Scripts.Extension;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using uMVVM.Sources.Infrastructure;
using uMVVM.Sources.Models;
using UnityEngine;
using ProjectCore.QuickUse;
using System.Data;
using System.Reflection;
using System.IO;

namespace Assets.Scripts.ViewModel
{
    /// <summary>
    /// 登陆控制模型
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        public BindableProperty<string> AccountText = new BindableProperty<string>();

        public BindableProperty<string> PasswordText = new BindableProperty<string>();
        public void RegisterInvoke()
        {

        }
        public void LoginInvoke()
        {

        }

        //public void LoginInvoke()
        //{
        //    var conn = SqlServeHelper.GetSqlConnection("192.168.1.11", "Test");

        //    conn.Open();

        //    var blockName = "login";

        //    var sqlStatement = string.Format("select * from [{0}] where account='", blockName) + AccountText + "' and password='" + PasswordText + "'";

        //    var cmd = new SqlCommand(sqlStatement, conn);

        //    var sdr = cmd.ExecuteReader();

        //    sdr.Read();

        //    if (sdr.HasRows)
        //    {
        //        var text = "登陆成功";

        //        text.Qdebug();
        //    }
        //    else
        //    {
        //        var text = "用户名或密码输入错误";

        //        text.Qdebug();
        //    }
        //}

        //public void RegisterInvoke()
        //{         
        //    AccountText.Value.Qdebug();

        //    PasswordText.Value.Qdebug();
     
        //    var conn = SqlServeHelper.GetSqlConnection("192.168.1.11", "Test");

        //    conn.Open();

        //    var blockName = "login";

        //    var sqlStatement = string.Format("select * from [{0}] where account='", blockName) + AccountText + "' and password='" + PasswordText + "'";

        //    var cmd = new SqlCommand(sqlStatement, conn);

        //    var sdr = cmd.ExecuteReader();

        //    sdr.Read();

        //    if (sdr.HasRows)
        //    {
        //        var text = "该用户已注册，请使用其他用户名";

        //        text.Qdebug();
        //    }
        //    else
        //    {
        //        sdr.Close();

        //        var insert = string.Format("insert into [{0}] (account,password) values ({1},{2})", blockName, AccountText, PasswordText);

        //        var icmd = new SqlCommand(insert, conn);

        //        icmd.ExecuteNonQuery();

        //        icmd.Clone();

        //        conn.Dispose();

        //        var text = "注册成功";

        //        text.Qdebug();
        //    }

        //}

    }
}
