using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class KeepSerialized : MonoBehaviour
{

    [FormerlySerializedAs("moster")]
    [SerializeField]
    public GameObject moster;

    private GameObject mObj;
    public GameObject Obj { get { return mObj ?? (mObj = new GameObject()); } }

    [SerializeField]
    public GameObject Test { get; set; }

    //[SerializeField]
    //private string name;
    //public string Name
    //{
    //    get { return name; }
    //    set
    //    {
    //        Debug.Log("通过属性设置");
    //        name = value;
    //    }
    //}

    private string Name;

    // Use this for initialization
    void Start()
    {
        Name = "213123";
    }

    // Update is called once per frame
    void Update()
    {

    }
}