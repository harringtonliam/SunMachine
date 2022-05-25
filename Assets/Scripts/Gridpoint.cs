using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gridpoint : MonoBehaviour
{


    //member variables
    const int gridSize = 10;



    //Propetries
    public int GridSize
    {
        get { return gridSize; }
    }

    public Vector2Int GridPosition
    {
        get
        {
            return new Vector2Int(
               Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize));
        }
    }



}
