using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public static Collector col;
    public Transform grounded;
    public Material mat;
    private void Start()
    {
        col = this;
    }
    public List<GameObject> colliderList = new List<GameObject>();
}
