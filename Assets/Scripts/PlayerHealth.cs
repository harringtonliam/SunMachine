using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int hitPoints = 20;
    [SerializeField] GameObject deathFX;


    public int HitPoints
    {
        get { return hitPoints; }
    }

    //Member varaibles
    PlayerBase playerBase;

    private void Start()
    {

        playerBase = GetComponent<PlayerBase>();
        DisplayHitPoints();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGameObject = other.gameObject;
        Enemy enemy = otherGameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(enemy);
            enemy.Die();
        }
    }

    private void TakeDamage(Enemy enemy)
    {
        

        hitPoints = hitPoints - enemy.Damage;

        DisplayHitPoints();

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void DisplayHitPoints()
    {

        if (playerBase != null)
        {
            playerBase.DisplayHealth(hitPoints);
        }
    }

    private void Die()
    {


        MakeWaypointPlaceable();

        if (deathFX != null)
        {
            var explosion = Instantiate(deathFX, transform.position, transform.rotation);
            Destroy(explosion, 1f);
        }
        if (playerBase != null)
        {
            FindObjectOfType<LevelLoader>().LoadGameOverScene();
        }
        else
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void MakeWaypointPlaceable()
    {
        Tower tower = GetComponent<Tower>();
        if (tower != null)
        {
            tower.MakeWaypointPlaceable(true);
        }
    }
}
