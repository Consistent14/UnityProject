using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraneHoisting : MonoBehaviour
{
    public float Speed;

    public GameObject PlayerObject;

    private List<GameObject> TargetObjects;

    // Use this for initialization
    void Start()
    {
        TargetObjects = GameObject.FindGameObjectsWithTag("T").ToList();

        if (Speed == 0)
        {
            Speed = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        var x = Input.GetAxis("Horizontal");

        var y = Input.GetAxis("Vertical");

        gameObject.transform.Translate(new Vector3(0,x * Time.deltaTime * Speed, y * Time.deltaTime * Speed), Space.Self);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Achive();
        }
    }
    void Achive()
    {
        var collistionBodys = new List<Collider>();

        TargetObjects.ForEach(m =>
        {
            collistionBodys.Add(m.GetComponent<Collider>());
        });

        foreach (var bc in collistionBodys)
        {
            OnTriggerEnter(bc);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //var coll = PlayerObject.GetComponent<Collision>();

        //var higInfo1 = new RaycastHit();

        if (collider.gameObject.name == "T2")
        {
            collider.gameObject.transform.parent = transform;
        }

        //if (coll.collider.Raycast(new Ray(gameObject.transform.position, -Vector3.up), out higInfo1, 5))
        //{
        //    TargetObjects.ForEach(m =>
        //    {
        //        if (m.tag == higInfo1.transform.gameObject.tag)
        //        {
        //            Debug.Log("ok");
        //        }
        //    });
        //}
    }
}