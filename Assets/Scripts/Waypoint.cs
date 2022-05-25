using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gridpoint))]
public class Waypoint : MonoBehaviour
{
    //Parameters
    [SerializeField] public bool IsPlaceable = true;

   //Properties
    public bool IsExplored 
    {
        get { return isExplored; }
        set { isExplored = value; } 
    }
    public Waypoint ExploredFrom { get; set; }



    //member variables
    int gridSize = 10;
    private bool isExplored = false;
    Gridpoint gridpoint;


    private void Awake()
    {
        gridpoint = GetComponent<Gridpoint>();
        gridSize = gridpoint.GridSize;

    }


    //Propetries
    public int GridSize
    { 
        get { return gridSize; }
    }

    public Vector2Int GridPosition
    {
        get { return gridpoint.GridPosition; 
        }
    }


    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();

        }

    }

    private void PlaceTower()
    {
        Towers towers = FindObjectOfType<Towers>();
        if (towers != null)
        {
            towers.PlaceTower(this);
        }
    }
}
