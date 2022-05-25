using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{ 
    [SerializeField] Tower towerPrefab;
    [SerializeField] AudioClip placeSFX;

    public Tower TowerPrefab
    {
        get { return towerPrefab; }
        set { towerPrefab = value; }
    }

    public Transform TowerParent
    {
        get { return this.transform; }
    }

    public void PlaceTower(Waypoint waypoint)
    {
        PlayerBase playerBase = FindObjectOfType<PlayerBase>();

        if (waypoint.IsPlaceable && towerPrefab.Cost <= playerBase.Energy )
        {
            if (placeSFX != null)
            {
                Debug.Log("playing audio clip");
                AudioSource.PlayClipAtPoint(placeSFX, Camera.main.transform.position);
            }
            var newTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
            newTower.PlacedWaypoint = waypoint;
            newTower.transform.parent = gameObject.transform;
            waypoint.IsPlaceable = false;
            playerBase.DecreaseEnergy(towerPrefab.Cost);
        }
    }
}
