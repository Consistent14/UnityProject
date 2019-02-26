using Assets.Scripts.MVVM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Extension;
using System.Data.SqlClient;

namespace Assets.Scripts.UI
{
    public class CameraControl : MonoBehaviour
    {
        public LoginView _loginView;

        // Use this for initialization
        void Start()
        {
            _loginView.BindingContext = new LoginViewModel();
        }

        // Update is called once per frame
        void Update()
        {
            //Verfiy();
        }

        bool Verfiy()
        {
            var accountInput = _loginView.AccountInput;

            var passwordInput = _loginView.PasswordInput;

            var blockName = "login";

            var conn = SqlServeHelper.GetSqlConnection("192.168.1.105", "abc");

            conn.Open();

            var sqlStatement = string.Format("select * from [{0}] where account='", blockName) + accountInput.text + "' and password='" + passwordInput.text + "'";

            var cmd = new SqlCommand(sqlStatement, conn);

            var sdr = cmd.ExecuteReader();

            sdr.Read();

            var hintText = _loginView.HintText;

            var hintPanel = _loginView.HintPanel;

            if (sdr.HasRows)
            {
                if (hintPanel != null && !hintPanel.isActiveAndEnabled)
                {
                    hintPanel.gameObject.SetActive(true);
                }

                hintText.text = "登陆成功";

                return true;
            }
            else
            {
                if (hintPanel != null && !hintPanel.isActiveAndEnabled)
                {
                    hintPanel.gameObject.SetActive(true);
                }

                hintText.text = "用户名或密码输入错误！！！";

                return false;
            }
        }

        bool RegisterData()
        {
            var accountInput = _loginView.AccountInput;

            var passwordInput = _loginView.PasswordInput;

            var blockName = "login";

            var conn = SqlServeHelper.GetSqlConnection("192.168.1.105", "abc");

            conn.Open();

            var sqlStatement = string.Format("select * from [{0}] where account='", blockName) + accountInput.text + "' and password='" + passwordInput.text + "'";

            var cmd = new SqlCommand(sqlStatement, conn);

            var sdr = cmd.ExecuteReader();

            sdr.Read();

            var hintText = _loginView.HintText;

            var hintPanel = _loginView.HintPanel;

            if (sdr.HasRows)
            {
                if (hintPanel != null && !hintPanel.isActiveAndEnabled)
                {
                    hintPanel.gameObject.SetActive(true);
                }

                hintText.text = "该用户已注册，请使用其他用户名";

                return true;
            }
            else
            {
                sdr.Close();

                var insert = string.Format("insert into [{0}] (account,password) values ({1},{2})", blockName, accountInput.text, passwordInput.text);

                var icmd = new SqlCommand(insert, conn);

                icmd.ExecuteNonQuery();

                icmd.Clone();

                conn.Dispose();

                hintText.text = "注册成功";

                return true;
            }


        }

        public void Test()
        {
            Verfiy();
        }
        public void Use2()
        {
            RegisterData();
        }
    }
}