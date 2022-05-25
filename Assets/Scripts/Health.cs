using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] int bulletDamage = 1;
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitFX;

  
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        GameObject hit =  Instantiate(hitFX, transform.position, transform.rotation);
        Destroy(hit, 1f);
        hitPoints = hitPoints - bulletDamage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        AddToScore();
        var explosion = Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        Destroy(gameObject, 0.5f);
    }

    private  void AddToScore()
    {
        Enemy enemy = GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.AddToScore();
            }
     
    }
}
