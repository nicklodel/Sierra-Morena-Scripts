using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    private GameObject player;

    public ParticleSystem[] particulas;

    private bool once;

    public GameObject cameraMan;

    public AudioSource fuego;

    private GameObject cinematic;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        once = true;

        cinematic = GameObject.Find("Cameras");

    }

    // Update is called once per frame
    void Update()
    {
        int fruitScore = 0 ;
  
        fruitScore = player.GetComponent<Character>().fruitScore;
        

        if (fruitScore == 3 && once)
        {
            StartCoroutine(PlayParticles());
            once = false;
            //enable CameraManager Again
            cameraMan.SetActive(true);
        }
    }

    IEnumerator PlayParticles()
    {
        fuego.Play();
        for (int i = 0; i < particulas.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log(i);
            particulas[i].Play();
            
        }
    }
}
