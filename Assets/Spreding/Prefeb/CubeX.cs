using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeX : MonoBehaviour
{
    public GameObject cubeZ, cubeZ_;
    [SerializeField] float maxBlock = 0.5f;
    float i = 0;
    void Start()
    {
        StartCoroutine(spwnner());
    }
    IEnumerator spwnner()
    {
        while (i <= maxBlock)
        {
            Vector3 posToSpwanZ = new Vector3(transform.position.x, transform.position.y, transform.position.z + i);
            Vector3 posToSpwan_Z = new Vector3(transform.position.x, transform.position.y, transform.position.z - i);
            Instantiate(cubeZ, posToSpwanZ, Quaternion.identity);
            Instantiate(cubeZ_, posToSpwan_Z, Quaternion.identity);
            i += 0.095f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
