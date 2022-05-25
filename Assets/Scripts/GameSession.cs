using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{


    private static GameSession _instance;



    //propetries
    public int Score
    {
        get { return score; }

    }

    public bool GameWon
    {
        get { return gameWon; }
        set { gameWon = value; }
    }

    //member vaiavles
    private int score = 0;
    private bool gameWon = false;

    private void Awake()
    {
        //Make the music player a singletom
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }


    }

    private void Start()
    {
        DisplayScore();
    }


    public void ResetGame()
    {
        gameWon = false;
        score = 0;
        DisplayScore();

    }

    public void AddToScore(int newscore)
    {
        score = score + newscore;
        DisplayScore();
    }

    public void DisplayScore()
    {
        ScoreBoard scoreBoard = FindObjectOfType<ScoreBoard>();
        if (scoreBoard != null)
        {
            scoreBoard.DisplayScore();
        }
    }
}
