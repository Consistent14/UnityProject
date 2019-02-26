using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ProjectCore.QuickUse
{
    static public class DebugHelper
    {
        static public void Qdebug(this string mes)
        {
            Debug.Log(mes);
        }
    }
}
