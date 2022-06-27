using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public float speedZ;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speedY > 0) 
        {
            angle += Time.deltaTime * speedY;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
        }
        if (speedZ > 0 )
        {
            angle += Time.deltaTime * speedZ;
            transform.localRotation = Quaternion.Euler(90,0, angle);
        }
        if (speedX > 0 )
        {
            angle += Time.deltaTime * speedX;
            transform.localRotation = Quaternion.Euler(angle, 0, 0);
        }
        
    }
}
