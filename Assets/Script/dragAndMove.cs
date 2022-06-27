﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragAndMove : MonoBehaviour
{
    public static dragAndMove dam;
    Rigidbody rb;
    private Vector3 mOffset;
    private float mZCoord;
    private bool isAdded = false;

    public GameObject particle;
    public Transform target;
    public float dist;
    public bool isMoving = false;
    public bool isConneced = false, particleSpwan = false;
    private void Start()
    {
        dam = this;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }
    private void Update()
    {
        if (isMoving)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
            rb.useGravity = false;
        }
        dist = Vector3.Distance(transform.position, target.position);
        if (dist <= 0.1f)
        {
            transform.position = target.position;
            if (!particleSpwan)
            {
                Destroy(Instantiate(particle,target.position,Quaternion.identity), 1);
                particleSpwan = true;
            }
            isConneced = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            if (!isAdded)
            {
                GameManager.gM.sprinklers.Add(gameObject);
                isAdded = true;
            }
        }
    }

    void OnMouseDown()
    {
        isMoving = true;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private void OnMouseUp()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
        isMoving = false;
    }


    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = mZCoord;
        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

}
