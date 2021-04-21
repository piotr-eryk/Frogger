using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLog : MonoBehaviour
{
    public float spawnDelay = 0.5f;
    public GameObject logPrefab;

    public Transform[] logSpawnPoints;

    float nextSpawnLog = 3f;

    void Update()
    {

        if (nextSpawnLog <= Time.time)
        {
            CreateLog();
            nextSpawnLog = Time.time + spawnDelay;
        }
    }

    void CreateLog()
    {
        int randomSpawn = Random.Range(0, logSpawnPoints.Length);
        Transform logSpawnPoint = logSpawnPoints[randomSpawn];

        GameObject logObject = Instantiate(logPrefab, logSpawnPoint.position, logSpawnPoint.rotation);
        Destroy(logObject.gameObject, 5);

    }
}
