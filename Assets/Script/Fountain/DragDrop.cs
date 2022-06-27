using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragDrop : MonoBehaviour
{
    public static DragDrop DD;

    Rigidbody rb;
    private Vector3 mOffset;
    private float mZCoord;

    public bool isMoving = false;
    private void Start()
    {
        DD = this;
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