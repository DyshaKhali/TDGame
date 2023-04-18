using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    void Awake(){instance=this;}

    public List<GameObject> prefabs;
    public List<Transform> spawnPoints;
    public float spawnInterval=2f;

    public void StartSpawning()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        int randomPrefabID = Random.Range(0,prefabs.Count);
        int randomSpawnPointID = Random.Range(0,spawnPoints.Count);
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID],spawnPoints[randomSpawnPointID]);        
    }
}
