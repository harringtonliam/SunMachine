using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWonDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckIfGameWon();
    }

    private void CheckIfGameWon()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            if (gameSession.GameWon)
            {
                GetComponent<Text>().enabled = true;
            }
            else
            {
                GetComponent<Text>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
