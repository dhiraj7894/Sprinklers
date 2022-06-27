using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class endPipeDragAndDrop : MonoBehaviour
{
    public static endPipeDragAndDrop ePDaD;
    public pipeData pD;

    Rigidbody rb;
    private Vector3 mOffset;
    private float mZCoord;

    public GameObject pipeCoonnect;
    public bool isMoving = false, isConnected = false;
    private void Start()
    {
        isConnected = true;
        ePDaD = this;
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

    [SerializeField]
    float dis = 0;
    void pipeConnection()
    {
        dis = Vector3.Distance(transform.position, pipeCoonnect.transform.position);

        if (dis < 0.05f)
        {
            isConnected = true;
        }
        else
        {
            isConnected = false;
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