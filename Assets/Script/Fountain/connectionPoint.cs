using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectionPoint : MonoBehaviour
{
    public float redius = 1;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, redius);
    }
}
