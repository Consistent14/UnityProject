using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SqlServerHelper
{

    class Log4netProgram
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

<<<<<<< HEAD:UnityConsole/SqlServerHelper/Log4netProgram.cs
        static void Log4netMain(string[] args)
=======
        static void Main2(string[] args)
>>>>>>> 2a4c6fa485c37a86e4b144d053548c9a66bda594:UnityConsole/SqlServerHelper/Log4netProgram.cs
        {
            //Application.Run(new MainForm());
            //创建日志记录组件实例
            //ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //记录错误日志
            log.Error("error", new Exception("发生了一个异常"));
            //记录严重错误
            log.Fatal("fatal", new Exception("发生了一个致命错误"));
            //记录一般信息
            log.Info("info");
            //记录调试信息
            log.Debug("debug");
            //记录警告信息
            log.Warn("warn");
            Console.WriteLine("日志记录完毕。");
            Console.Read();
        }

        static void Main2(string[] args)
        {
            //初始化日志文件 
            string state = ConfigurationManager.AppSettings["IsWriteLog"];
            //判断是否开启日志记录
            if (state == "1")
            {
                LogHelper.Loginfo.Info("123");

                var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                           ConfigurationManager.AppSettings["log4net"];

                if (File.Exists(path))
                {

                }
                var fi = new System.IO.FileInfo(path);
                log4net.Config.XmlConfigurator.Configure(fi);
            }

            LogHelper.WriteLog("holle world213421");

            try
            {

                string a = null;
                a.Remove(1);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("报错了234321", ex);
            }
        }
    }
}