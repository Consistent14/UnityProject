using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoticeToUnity
{
    class Program
    {
        static void Main2(string[] args)
        {
            var dk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var contents = "comming";

            if (args.Length!=0)
            {
                contents += args[0];
            }

            var dp = Path.Combine(dk, "unity.db");

            File.WriteAllText(dp, contents);
        }
    }
}
