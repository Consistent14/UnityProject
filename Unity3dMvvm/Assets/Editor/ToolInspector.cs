using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolInspector : Editor
{
    Test model;
    public override void OnInspectorGUI()
    {
        model = target as Test;
        string name = EditorGUILayout.TextField("名字", model.name);
        if (model.Name != name)
        {
            model.Name = name;
        }

        base.DrawDefaultInspector();
    }

}