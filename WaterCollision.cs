using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollision : MonoBehaviour
{
    private Collision water;
    private bool colliding;
    private bool needed;
    private Vector3 safe;

    private void Start()
    {
        colliding = false;
        needed = false;
        safe = transform.position;
    }

    private void Update()
    {
        if (!colliding)
        {
            NeedPos();
            if (needed)
            {
                StartCoroutine(PosBackUp());
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("water"))
            transform.position = safe;
            colliding = true;
            Debug.Log("In");
            needed = false;
            StartCoroutine(NeedPos());
    }

    private void OnCollisionExit(Collision other)
    {
        colliding = false;
    }
    
    IEnumerator PosBackUp()
    {
        
        yield return new WaitForSeconds(3);
        safe = transform.position;

    }
    
        
    IEnumerator NeedPos()
    {
        
        yield return new WaitForSeconds(6);
        needed = true;

    }
}

