using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int score = 1;

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }


    public void Die()
    {
        GetComponent<Health>().Die();
    }

    public void AddToScore()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.AddToScore(score);
        }
    }
}
