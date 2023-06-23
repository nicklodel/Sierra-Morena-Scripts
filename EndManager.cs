using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndManager : MonoBehaviour
{
    public GameObject visible;

    public GameObject invisible;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (invisible.GetComponent<CallingEngine>().isCalled)
        {
            invisible.SetActive(false);
            visible.SetActive(true);
            StartCoroutine(ChangeScene());
        }
    }
    
    
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(5);
    }
}
