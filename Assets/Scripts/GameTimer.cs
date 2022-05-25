using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    [Tooltip("In Seconds")][SerializeField] float levelTime = 60f;


    //member variables
    bool levelOver = false;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            if (!levelOver)
            {
                levelOver = true;
                CalcEndOfLevelScore();
                if (FindObjectOfType<LevelLoader>().IsFinalLevel())
                {
                    FindObjectOfType<GameSession>().GameWon = true;
                }
                FindObjectOfType<LevelLoader>().LoadNextLevel();
            }
        }
    }

    private static void CalcEndOfLevelScore()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        PlayerBase playerBase = FindObjectOfType<PlayerBase>();
        if (playerBase != null && gameSession != null)
        {
            gameSession.AddToScore(playerBase.Energy);
            gameSession.AddToScore(playerBase.GetHealth());
        }
    }
}
