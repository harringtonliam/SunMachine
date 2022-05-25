using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint;
    [SerializeField] GameObject[] enemyPrefabs;
    [Range(0.1f, 60f)]
    [Tooltip("In Seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Range(0.1f, 60f)]
    [Tooltip("In Seconds")] [SerializeField] float maxTimeBetweenSpawns = 2f;
    [SerializeField] bool spawnEnemies = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {


        while (spawnEnemies)
        {
            float timeBetweenSpawns = UnityEngine.Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        GameObject enemyPrefab = enemyPrefabs[enemyIndex];

        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        newEnemy.transform.parent = transform;
        newEnemy.transform.position = startWayPoint.transform.position;
        newEnemy.GetComponent<PathFinder>().SetStartAndEndWaypoints(startWayPoint, endWayPoint);
        newEnemy.GetComponent<EnemyMove>().StartPathFinding();
    }
}
