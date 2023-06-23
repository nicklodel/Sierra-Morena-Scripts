using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CallingEngine : MonoBehaviour
{
    public GameObject visible;

    public GameObject invisible;

    public bool isCalled;
    
    // Start is called before the first frame update
    public GameObject phone;
    void Start()
    {
        isCalled = false;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F) && phone.GetComponent<PhoneDetector>().isSeen)
        {
            isCalled = true;
        }


        IEnumerator ChangeScene()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(5);
        }
    }
}
