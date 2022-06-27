using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeData : MonoBehaviour
{
    public GameObject start, end;
    public dragAndMovePipe damPT;

    public float distance = 0;
    public float limit = 1.2f;
    public bool disconnected = false;

    Rigidbody endRB;

    public void Start()
    {
        endRB = end.GetComponent<Rigidbody>();
    }
    public void Update()
    {

        distance = Vector3.Distance(start.transform.position, end.transform.position);
        if (distance >= limit + 0.22f)
        {
            disconnected = true;
        }

        if (distance >= limit + 0.2f)
        {
            endRB.useGravity = true;
            endRB.isKinematic = false;
        }
        else if (damPT.limitCrossed)
        {
            endRB.useGravity = true;
            endRB.isKinematic = false;
        }
    }
}
