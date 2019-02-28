using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class SqlConnection : MonoBehaviour {

	// Use this for initialization
	void Start () {
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

        var dk = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        var dp = Path.Combine(dk, "unity.db");

        if (File.Exists(dp))
        {
            var sqlResult = File.ReadAllText(dp);


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
