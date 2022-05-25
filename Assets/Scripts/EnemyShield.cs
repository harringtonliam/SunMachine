using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{

    //Member variables
    Transform nearestGunTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetNearestGunTower();
        transform.LookAt(nearestGunTower);
    }

    private void SetNearestGunTower()
    {
        var allGunTowers = FindObjectsOfType<TowerGun>();
        if (allGunTowers.Length == 0) { return; }

        TowerGun closestGunTower = allGunTowers[0];
        foreach (TowerGun testEnemy in allGunTowers)
        {
            closestGunTower = GetClosest(closestGunTower, testEnemy);
        }

        

        nearestGunTower = closestGunTower.GetTurret() ;


    }

    private TowerGun GetClosest(TowerGun closestGun, TowerGun testGun)
    {
        float distanceToTestEnemy = Vector3.Distance(transform.position, testGun.transform.position);
        float distanceToClosetEnemy = Vector3.Distance(transform.position, closestGun.transform.position);
        if (distanceToClosetEnemy <= distanceToTestEnemy)
        {
            return closestGun;
        }
        else
        {
            return testGun;
        }
    }
}
