using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.IO;
using Assets.Scripts;

public class LoadPluginDll : MonoBehaviour
{
    void Awake()
    {
        var dllPath = typeof(LoadPluginDll).Assembly.Location;

        var d1 = new DirectoryInfo(dllPath).Parent.Parent.Parent.Parent.Parent.FullName;

        var dllName = "ProjectCore.dll";

        var d2 = Path.Combine(d1, string.Format(@"UnityProject\UnityClassLibrary\ProjectCore\bin\Debug\{0}", dllName));

        Debug.Log(d2);

        var plugin = Path.Combine(new DirectoryInfo(dllPath).Parent.Parent.Parent.FullName, GlobalPath.PluginName + dllName);

        if (File.Exists(d2))
        {
            File.Delete(plugin);

            File.Copy(d2, plugin);
        }
        else
        {
            File.Copy(d2, plugin);
        }

        if (File.Exists(plugin))
        {
            Debug.Log(plugin);
        }
    }
}
