using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore()
    {
        Text scoreText = GetComponent<Text>();
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null && scoreText!=null)
        {
            scoreText.text = gameSession.Score.ToString();   
        }
    }
}
