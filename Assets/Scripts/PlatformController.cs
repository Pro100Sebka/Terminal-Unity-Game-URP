using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        if (3.8 > transform.position.y) //-10<x<10
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * (Time.deltaTime * speed));
            }
        }

        if (transform.position.y > -3.8)
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * (Time.deltaTime * speed));
            }
        }
    }
}   
