using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickingEngine : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickedObject;
        public GameObject pickedPos;
        public bool isPicked;
        public GameObject water;
        public GameObject filling;
        public GameObject bucket;
        public TextMeshProUGUI pressF;
        public bool isFilled;
        public ParticleSystem fire;
        public ParticleSystem fire2;
        public ParticleSystem fire3;
        public bool isTurnedOff;
        public bool isTurnedOff2;
        void Start()
    {
        isPicked = false;
        isFilled = false;
        isTurnedOff = false;
        isTurnedOff2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked)
        {
            pickedPosition();
        }

        if (Input.GetKeyDown(KeyCode.F) && pickedObject.GetComponent<CameraDetector>().isSeen && !isFilled && !isPicked)
        {
            isPicked = true;
            
            pickedObject.GetComponent<CameraDetector>().enabled = false;
            pickedObject.GetComponent<MeshCollider>().enabled = false;
            bucket.GetComponent<MeshCollider>().enabled = false;
            pressF.text = "";
        }

        if (Input.GetKeyDown(KeyCode.F) && water.GetComponent<CameraDetector>().isSeen)
        {
            filling.SetActive(true);
            pickedObject.GetComponent<CameraDetector>().enabled = false;
            pickedObject.GetComponent<MeshCollider>().enabled = false;
            bucket.GetComponent<MeshCollider>().enabled = false;
            isFilled = true;
            bucket.GetComponent<AudioSource>().Play();
            pressF.text = "";
        }
        
        if (Input.GetKeyDown(KeyCode.F) && fire.GetComponent<CameraDetector>().isSeen && isPicked && isFilled)
        {
            filling.SetActive(false);
            pickedObject.GetComponent<CameraDetector>().enabled = false;
            pickedObject.GetComponent<MeshCollider>().enabled = false;
            bucket.GetComponent<MeshCollider>().enabled = false;
            isFilled = false;
            fire.Stop();
            pressF.text = "";
            isTurnedOff = true;
        }
        
        
        if (Input.GetKeyDown(KeyCode.F) && fire2.GetComponent<CameraDetector>().isSeen && isPicked && isFilled)
        {
            filling.SetActive(false);
            pickedObject.GetComponent<CameraDetector>().enabled = false;
            pickedObject.GetComponent<MeshCollider>().enabled = false;
            bucket.GetComponent<MeshCollider>().enabled = false;
            isFilled = false;
            fire2.Stop();
            pressF.text = "";
            isTurnedOff2 = true;
        }
        
        if (Input.GetKeyDown(KeyCode.F) && fire3.GetComponent<CameraDetector>().isSeen && isPicked && isFilled)
                {
                    fire3.Stop();
                    filling.SetActive(false);
                    pickedObject.GetComponent<CameraDetector>().enabled = false;
                    pickedObject.GetComponent<MeshCollider>().enabled = false;
                    bucket.GetComponent<MeshCollider>().enabled = false;
                    isFilled = false;
                    
                    pressF.text = "";
                }
    }
    
    
    private void pickedPosition()
    {
        
            pickedObject.transform.position = pickedPos.transform.position;
    }
    
}
