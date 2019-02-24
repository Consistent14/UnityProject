using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace console.test
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = @"G:\Git\UnityProject\UnityClassLibrary\ProjectCore\bin\Debug\ProjectCore.dll";

            var b = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\ProjectCore.dll";

            if (File.Exists(b))
            {
                File.Delete(b);

                File.Copy(a, b);
            }
            else
            {
                File.Copy(a, b);
            }
        }
    }
}
