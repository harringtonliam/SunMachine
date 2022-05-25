using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGun : MonoBehaviour
{
    //Parameters
    [SerializeField] Transform turret;
    [SerializeField] float range = 10f;
    [SerializeField] List<GameObject> guns;

    //Member vairables
    Transform targetEnemy;

    void Update()
    {

        SetTargetEnemy();
        turret.LookAt(targetEnemy);
        Shoot();
    }

    private void SetTargetEnemy()
    {
        var allEnemies = FindObjectsOfType<EnemyMove>();
        if (allEnemies.Length == 0) { return; }

        Transform closestEnemy = allEnemies[0].transform;
        foreach (EnemyMove testEnemy in allEnemies)
        {
            closestEnemy = GetClosest(closestEnemy, testEnemy.transform);
        }

        targetEnemy = closestEnemy;


    }

    private Transform GetClosest(Transform closestEnemy, Transform testEnemy)
    {
        float distanceToTestEnemy = Vector3.Distance(transform.position, testEnemy.position);
        float distanceToClosetEnemy = Vector3.Distance(transform.position, closestEnemy.position);
        if (distanceToClosetEnemy <= distanceToTestEnemy)
        {
            return closestEnemy;
        }
        else
        {
            return testEnemy;
        }
    }

    private void Shoot()
    {
        if (targetEnemy == null)
        {
            return;
        }

        float distanceToEnemy = Vector3.Distance(transform.position, targetEnemy.position);
        if (distanceToEnemy <= range)
        {
            SetGunActive(true);
        }
        else
        {
            SetGunActive(false);
        }


    }

    private void SetGunActive(bool isActive)
    {
        foreach (var gun in guns)
        {
            var emmissionModule = gun.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isActive;
        }

    }

    public Transform GetTurret()
    {
        return turret.transform;
    }
}
