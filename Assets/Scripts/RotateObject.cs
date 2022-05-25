using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //Params
    [SerializeField] float rotateSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateContiniously();
    }

    private void RotateContiniously()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
