using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParticleStopper : MonoBehaviour
{
    private GameObject player;

    public ParticleSystem[] particulas;

    public RawImage img;

    private bool once;
    
    public AudioSource fuego;

    private GameObject cinematic;

    public TextMeshProUGUI text;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayParticles());

    }

    // Update is called once per frame
    void Update()
    {
        
            //enable CameraManager Again
    }

    IEnumerator PlayParticles()
    {
        fuego.Stop();
        for (int i = 0; i < particulas.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            particulas[i].Stop();
            
        }
        yield return new WaitForSeconds(2);
        img.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}

