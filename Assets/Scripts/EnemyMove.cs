using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;


    //Member variables
    List<Waypoint> path;
    int waypointIndex = 0;

    void Start()
    {

    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        if (path != null)
        {
            MoveAlongPath();
        }
    }

    public void StartPathFinding()
    {
        PathFinder pathFinder = GetComponent<PathFinder>();
        path = pathFinder.GetPath();
    }

    private void  MoveAlongPath()
    {
        if (waypointIndex <= path.Count - 1)
        {
            var targetPosition = path[waypointIndex].transform.position;
            transform.LookAt(targetPosition);
            var movementthisFrame = moveSpeed* Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementthisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
    }








}
