using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SqlServerHelper
{
    class NoticeProgram
    {
        static void Main(string[] args)
        {
            // D:\Git\UnityProject\UnityConsole\NoticeToUnity\bin\Debug\NoticeToUnity.exe

            var cmd = new Process();

            var info = cmd.StartInfo;

            info.FileName = @"D:\Git\UnityProject\UnityConsole\NoticeToUnity\bin\Debug\NoticeToUnity.exe";

            info.Arguments = "123";

            info.UseShellExecute = false;

            info.RedirectStandardInput = true;

            info.RedirectStandardOutput = true;

            info.WindowStyle = ProcessWindowStyle.Hidden;

            info.CreateNoWindow = false;

            cmd.Start();

            var result = cmd.StandardOutput;

            cmd.WaitForExit();

            cmd.Close();

            cmd.Dispose();
        }
    }
}
