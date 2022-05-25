using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Parameters
    [SerializeField] int cost = 1;
    [SerializeField] Waypoint placedWaypoint;




    public Waypoint PlacedWaypoint
    {
           get {return placedWaypoint; }
           set { placedWaypoint = value; } 
    }

    public int Cost {
        get { return cost; }
        }


    public void MakeWaypointPlaceable(bool isPlaceable)
    {
        if (placedWaypoint != null)
        {
            placedWaypoint.IsPlaceable = isPlaceable;
        }
    }

}
