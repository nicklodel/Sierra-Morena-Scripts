using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHelicopter : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 500.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up* Time.deltaTime * speed);
    }
}
