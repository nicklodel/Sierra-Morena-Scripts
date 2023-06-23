using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CinematicScript : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject player;
    private GameObject menu;
    public Camera[] Camaras;
    public Camera EmergencyCamera;
    public Camera mainCam;
    private bool onceEmergency;
    private int index;
    private int auxIndex;

    
    void Start()
    {
        menu = GameObject.Find("MenuManager");
        menu.SetActive(false);
        index = 0;
        auxIndex = 1;
        StartCoroutine(ChangeCamera());
        onceEmergency =true;
        mainCam.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        int fruitScore = player.GetComponent<Character>().fruitScore;
        if (fruitScore == 3 && onceEmergency)
        {
            StartCoroutine(ChangeEmergencyCamera());
           onceEmergency = false;
        }
        else if (onceEmergency)
        {

            Camaras[index].transform.Translate(Vector3.forward * Time.deltaTime * 1.5f);

            if (auxIndex == index && index < Camaras.Length)
            {
                auxIndex = auxIndex + 1;
                StartCoroutine(ChangeCamera());
            }

        }
        else
        {
            EmergencyCamera.transform.Translate(Vector3.left * Time.deltaTime * 1.5f);
        }

    }



    IEnumerator ChangeCamera()
    {

        yield return new WaitForSeconds(10);
        Camaras[index].gameObject.SetActive(false);

        if (index < Camaras.Length - 1)
        {
            index = index + 1;
            Camaras[index].gameObject.SetActive(true);
        }
        else
        {
            mainCam.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            Camaras[index].gameObject.SetActive(false);
        }

        Debug.Log(index);
    }



    IEnumerator ChangeEmergencyCamera()
    {
        mainCam.gameObject.SetActive(false);
        menu.SetActive(false);
        EmergencyCamera.gameObject.SetActive(true);
        yield return new WaitForSeconds(11);
        EmergencyCamera.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
        menu.SetActive(true);
    }
}
