using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Freez : MonoBehaviour
{
    Rigidbody rb;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //transform.position = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (dragAndMove.dam.isConneced)
        {
            transform.position = target.position;
            rb.useGravity = true;
        }
    }
}
