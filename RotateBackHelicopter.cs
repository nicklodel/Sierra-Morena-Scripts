using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackHelicopter : MonoBehaviour
{
    private float speed = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left* Time.deltaTime * speed);
    }
}
