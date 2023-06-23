using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barrier;
    public GameObject barrier2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PickingEngine>().isTurnedOff)
        {
            barrier.GetComponent<BoxCollider>().enabled = false;
            barrier.GetComponent<AudioSource>().Play();
        }

        if (gameObject.GetComponent<PickingEngine>().isTurnedOff2)
        {
            barrier2.GetComponent<BoxCollider>().enabled = false;
            barrier2.GetComponent<AudioSource>().Play();
        }
    }
}
