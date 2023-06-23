using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    private GameObject player;
    private int score;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        player = GameObject.Find("Character");
        score = player.GetComponent<Character>().fruitScore;
    }

    // Update is called once per frame
    void Update()
    {
        
            score = player.GetComponent<Character>().fruitScore;
        if (score != 3) {
            updateText();
        }

        else
        {
            EmergencyText();
        }
    }
    
    public void updateText()
    {
        scoreText.text = "Recoge frutas en el bosque: " + score + "/3";
    }
    
    public void EmergencyText()
    {
        scoreText.text = "¡Apaga ese fuego!";
    }
}
