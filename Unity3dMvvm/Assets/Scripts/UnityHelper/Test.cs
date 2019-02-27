using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    [SerializeField]
    private string name;

    public string Name
    {
        get
        {
            Debug.Log("通过属性get设置");
            return name;
        }
        set
        {
            Debug.Log("通过属性set设置");
            name = value;
        }
    }
}