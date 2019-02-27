using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraneHoisting : MonoBehaviour
{
    public float Speed;

    public GameObject PlayerObject;

    private GameObject ChildObject;

    private List<GameObject> TargetObjects;

    // Use this for initialization
    void Start()
    {
        TargetObjects = GameObject.FindGameObjectsWithTag("T").ToList();

        if (Speed == 0)
        {
            Speed = 5;
        }

        if (PlayerObject != null)
        {
            ChildObject = GameObject.Find("c");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        var y = Input.GetAxisRaw("Vertical");

        gameObject.transform.Translate(new Vector3(0, x * Time.deltaTime * Speed, y * Time.deltaTime * Speed), Space.Self);

        if (ChildObject != null)
        {
            //ChildObject.transform.Rotate(Vector3.up * 20 * Time.deltaTime, Space.Self);
        }

        Achive();
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
        var gb = PlayerObject.gameObject;

        var info = new RaycastHit();

        if (collider.Raycast(new Ray(gb.transform.position, -Vector3.up), out info, 1))
        {
            if (info.collider.gameObject.name == "T2")
            {
                collider.gameObject.transform.parent = PlayerObject.transform;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PlayerObject.transform.DetachChildren();

                    var rb = collider.gameObject.GetComponent<Rigidbody>();

                    rb.useGravity = true;
                }
            }
        }

        var info2 = new RaycastHit();

        if (collider.Raycast(new Ray(collider.transform.position, -Vector3.up), out info2, 1))
        {
            if (info2.collider.gameObject.name == "X")
            {
                var rb = collider.gameObject.GetComponent<Rigidbody>();

       

                rb.useGravity = false;
            }
        }
    }
}