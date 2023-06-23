using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3 && player.transform.position.x > -72 &&
            player.transform.position.x < -48 && player.transform.position.z > 580)
        {
            SceneManager.LoadScene(4);
        }
    }

public void LoadWorld()
{
    SceneManager.LoadScene(1);
}

public void LoadTest()
{
    SceneManager.LoadScene(2);
}

public void BackToMenu()
{
    SceneManager.LoadScene(0);
}

}
