using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class rotation : MonoBehaviour {

    public float speed = 16f;


    void Start()
    {


    }


    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 0.4f * Time.deltaTime);
    }
}
