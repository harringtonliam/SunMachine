using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    //Properties
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    [SerializeField] int ignoreTowersChance = 10;
    [SerializeField] int targetTowersChance = 20;

    //member variables
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Dictionary<Vector2Int, Waypoint> exploredWaypoints = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions1 = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
    Vector2Int[] directions2 = { Vector2Int.right, Vector2Int.left, Vector2Int.down, Vector2Int.up };
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool endPointNotFound = true;
    Waypoint searchPoint;
    List<Waypoint> path = new List<Waypoint>();
    bool ignoreTowersOnPath = false; 

    private void Awake()
    {
        RandomChanceToIgnoreTowers();
    }

    private void RandomChanceToIgnoreTowers()
    {
        int ignoreTowers = UnityEngine.Random.Range(1, 100);
        if (ignoreTowers < ignoreTowersChance)
        {
            ignoreTowersOnPath = true;
        }
    }

    public void SetStartAndEndWaypoints(Waypoint newStartWayPoint, Waypoint newEndWayPoint)
    {
        startWayPoint = newStartWayPoint;
        endWayPoint = newEndWayPoint;
    }

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculateThePath();
        }

        return path;
    }

    private void CalculateThePath()
    {
        LoadBlocks();
        //ColorStartAndEnd();
        RandomChanceToTargetTower();
        PathFind();        
        if (endPointNotFound)
        {
            grid.Clear();
            exploredWaypoints.Clear();
            ignoreTowersOnPath = true;
            LoadBlocks();
            PathFind();
        }
        BuildThePath();
    }

    private void RandomChanceToTargetTower()
    {
        int targetTower = UnityEngine.Random.Range(1, 100);
        if (targetTower < targetTowersChance)
        {
            endWayPoint = SetTargetTower();
        }
    }

    private void PathFind()
    {
        queue.Enqueue(startWayPoint);

        while (queue.Count > 0 && endPointNotFound)
        {
            searchPoint = queue.Dequeue();
            if (!exploredWaypoints.ContainsKey(searchPoint.GridPosition))
            {
                exploredWaypoints.Add(searchPoint.GridPosition, searchPoint);
            }
            if (!CheckEndPointFound())
            {
                ExploreNeighbours();
            }
        }
    }

    private void BuildThePath()
    {
        var wayPoint = endWayPoint;

        while (wayPoint != startWayPoint)
        {
            SetAsPath(wayPoint);
            wayPoint = wayPoint.ExploredFrom;
        }
        SetAsPath(wayPoint);
        path.Reverse();
    }

    private void SetAsPath(Waypoint wayPoint)
    {
        path.Add(wayPoint);
    }

    private bool CheckEndPointFound()
    {
        if (searchPoint == endWayPoint)
        {
            grid.Clear();
            exploredWaypoints.Clear();
            endPointNotFound = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ExploreNeighbours()
    {
        Vector2Int[] directionsToUse;
        int directionsToUseRand = UnityEngine.Random.Range(0, 10);
        if (directionsToUseRand <= 6)
        {
            directionsToUse = directions1;
        }
        else
        {
            directionsToUse = directions2;
        }


        foreach (Vector2Int direction in directionsToUse)
        {
            Vector2Int explorationCoord = searchPoint.GridPosition + direction;
            if (grid.ContainsKey(explorationCoord))
            {
                QueueNewNeighbour(explorationCoord);
            }

        }
    }

    private void QueueNewNeighbour(Vector2Int explorationCoord)
    {
        Waypoint neighbour = grid[explorationCoord];

        if (ignoreTowersOnPath)
        {
            if (!queue.Contains(neighbour) && !exploredWaypoints.ContainsKey(neighbour.GridPosition))
            {
                queue.Enqueue(neighbour);
                neighbour.ExploredFrom = searchPoint;
            }
        }
        else
        {
            if (!queue.Contains(neighbour) && !exploredWaypoints.ContainsKey(neighbour.GridPosition) && neighbour.IsPlaceable)
            {
                queue.Enqueue(neighbour);
                neighbour.ExploredFrom = searchPoint;
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint wayPoint in wayPoints)
        {
            bool isOverlapping = grid.ContainsKey(wayPoint.GridPosition);
            if (isOverlapping)
            {
                Debug.LogWarning("Skipping Overlapping Block " + wayPoint);
            }
            else
            {
                grid.Add(wayPoint.GridPosition, wayPoint);

            }
        }

    }

    private Waypoint SetTargetTower()
    {
        var allTowers = FindObjectsOfType<Tower>();
        if (allTowers.Length == 0) { return endWayPoint; }  //There are no towers so just return the original End Way Point

        Tower closestTower = allTowers[0];
        foreach (Tower testTower in allTowers)
        {
            closestTower = GetClosestTower(closestTower, testTower);
        }

        Waypoint targetWayPoint = closestTower.PlacedWaypoint;

        return targetWayPoint;
    }

    private Tower GetClosestTower(Tower closestTower, Tower testTower)
    {
        float distanceToTestEnemy = Vector3.Distance(transform.position, testTower.transform.position);
        float distanceToClosetEnemy = Vector3.Distance(transform.position, closestTower.transform.position);
        if (distanceToClosetEnemy <= distanceToTestEnemy)
        {
            return closestTower;
        }
        else
        {
            return testTower;
        }
    }



}
