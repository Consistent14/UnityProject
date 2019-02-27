using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using Assets.Scripts.EqualityComparer;

namespace Assets.Scripts.UnityEditor
{
    public class DeleteMissScript : EditorWindow
    {
        Vector2 scrollPos = Vector2.zero;
        List<string> pathList = new List<string>();
        List<GameObject> missObj = new List<GameObject>();

        private void CleanupMissingScripts()
        {
            foreach (GameObject obj in missObj)
            {
                var components = obj.GetComponents<Component>();
                var serializedObject = new SerializedObject(obj);
                var prop = serializedObject.FindProperty("m_Component");
                int r = 0;
                for (int j = 0; j < components.Length; j++)
                {
                    if (components[j] == null)
                    {
                        prop.DeleteArrayElementAtIndex(j - r);
                        r++;
                    }
                }
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(obj);
            }
        }

        private void CheckMissingScripts()
        {
            List<string> withoutExtensions = new List<string>() { ".prefab" };
            string[] files = Directory.GetFiles(Application.dataPath + "/GameRes/UIPrefab", "*.*", SearchOption.AllDirectories)
                .Where(s => withoutExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();

            int count = 0;
            foreach (string fileName in files)
            {
                count++;
                EditorUtility.DisplayProgressBar("Processing...", "搜寻所有Prefab....", count / files.Length);
                string fixedFileName = fileName.Replace("\\", "/");
                int index = fixedFileName.IndexOf("Assets");
                fixedFileName = fixedFileName.Substring(index);
                pathList.Add(fixedFileName);
            }
            EditorUtility.ClearProgressBar();

            int count2 = 0;
            foreach (string path in pathList)
            {
                count2++;
                EditorUtility.DisplayProgressBar("Processing...", "遍历丢失脚本Prefab中....", count / pathList.Count);
                GameObject obj = (GameObject)AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));
                getAllChild(obj);
                GameObject[] childArr = obj.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();

                if (childArr.Length != 0)
                {
                    if (childArr.Contains(obj, new GameobjectEqualityComparer()))
                    {
                        var newChildArr = childArr.ToList();

                        newChildArr.Remove(obj);

                        childArr = newChildArr.ToArray();
                    }
                }
            }
            EditorUtility.ClearProgressBar();
        }

        void getAllChild(GameObject obj)
        {
            GameObject[] childArr = obj.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToArray();

            if (childArr.Length != 0)
            {
                if (childArr.Contains(obj, new GameobjectEqualityComparer()))
                {
                    var newChildArr = childArr.ToList();

                    newChildArr.Remove(obj);

                    childArr = newChildArr.ToArray();
                }
            }

            foreach (GameObject child in childArr)
            {
                var components = child.GetComponents<Component>();
                var serializedObject = new SerializedObject(child);
                var prop = serializedObject.FindProperty("m_Component");

                for (int j = 0; j < components.Length; j++)
                {
                    if (components[j] == null)
                    {
                        missObj.Add(child);
                    }
                }

                getAllChild(child);
            }
        }

        void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

            if (GUILayout.Button("[删除所有Prefab上的Miss脚本]", GUILayout.Width(300)))
            {
                CleanupMissingScripts();
            }

            if (GUILayout.Button("[检查Prefab脚本Miss情况]", GUILayout.Width(300)))
            {
                pathList = new List<string>();
                missObj = new List<GameObject>();
                CheckMissingScripts();
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            foreach (GameObject obj in missObj)
            {
                EditorGUILayout.ObjectField(obj, typeof(GameObject), false);
            }


            EditorGUILayout.EndScrollView();
        }
    }
}
