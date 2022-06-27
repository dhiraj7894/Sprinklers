using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipePos : MonoBehaviour
{
    [SerializeField]
    Transform[] pos_1, pos_2;

    void Start()
    {
        pos_2[0].position = pos_1[0].position;
        pos_2[1].position = pos_1[1].position;
        pos_2[2].position = pos_1[2].position;
    }
    
}
