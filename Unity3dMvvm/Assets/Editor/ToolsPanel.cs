using Assets.Scripts.UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor
{
    public class ToolsPanel : MonoBehaviour
    {

        [MenuItem("Tools/资源/删除所有Prefab上的Miss脚本")]
        static public void DeleteMissScript()
        {
            EditorWindow.GetWindow<DeleteMissScript>("删除所有Prefab上的Miss脚本").Show();
        }
    }
}