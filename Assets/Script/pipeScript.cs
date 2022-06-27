using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeScript : MonoBehaviour
{
    public GameObject start, end;
    public dragAndMovePipe damPT;

    public float distance = 0;
    public float limit = 1.2f;
    public bool stop = false;

    Rigidbody endRB;

    private void Start()
    {
        endRB = end.GetComponent<Rigidbody>();
    }
    private void Update()
    {

        distance = Vector3.Distance(start.transform.position, end.transform.position);
        if (distance >= limit + 0.22f)
        {
            stop = true;
        }
        else
        {
            stop = false;
        }

        if(distance >= limit + 0.2f)
        {
            endRB.useGravity = true;
            endRB.isKinematic = false;
        }
        else if (damPT.limitCrossed)
        {
            endRB.useGravity = true;
            endRB.isKinematic = false;
        }
        if (endPipeDragAndDrop.ePDaD.isConnected)
        {
            endRB.useGravity = false;
            endRB.isKinematic = true;
        }
    }
}
