using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwnner : MonoBehaviour
{
    public GameObject cubeX,cubeZ,cubeX_,cubeZ_;
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
            Vector3 posToSpwanX = new Vector3(transform.position.x + i, transform.position.y, transform.position.z);
            Vector3 posToSpwanZ = new Vector3(transform.position.x, transform.position.y, transform.position.z + i);
            Vector3 posToSpwan_X = new Vector3(transform.position.x - i, transform.position.y, transform.position.z);
            Vector3 posToSpwan_Z = new Vector3(transform.position.x, transform.position.y, transform.position.z - i);


            Instantiate(cubeX, posToSpwanX, Quaternion.identity);
            Instantiate(cubeZ, posToSpwanZ, Quaternion.identity);
            Instantiate(cubeX_, posToSpwan_X, Quaternion.identity);
            Instantiate(cubeZ_, posToSpwan_Z, Quaternion.identity);
            i += 0.095f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
