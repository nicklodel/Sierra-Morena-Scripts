using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody fruitRb;
    public ParticleSystem particulas;
    public AudioSource cogido;
    void Start()
    {
        fruitRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       fruitRb.AddTorque(Vector3.up * 0.05f,ForceMode.Impulse);
    }


    private void OnCollisionEnter(Collision collision)
    {
        particulas.Play();
        cogido.Play();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        if (this.gameObject.CompareTag("Fruit"))
        {
            StartCoroutine(FruitCoroutine());
        }

        if (this.gameObject.CompareTag("Pizza"))
        {
            StartCoroutine(PizzaCoroutine());
        }

    }
    
    
    IEnumerator FruitCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    
    
    IEnumerator PizzaCoroutine()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }
}
