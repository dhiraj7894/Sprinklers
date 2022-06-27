using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateform : MonoBehaviour
{
    public float speed = 1.5f;
    private void Update()
    {
        if(transform.position.x <= 10)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        
    }
}
