using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public float spawnDelay = 0.5f;
    public GameObject carPrefab;

    public Transform[] spawnPoints;

    float nextSpawnCar = 3f;

    void Update()
    {

        if (nextSpawnCar <= Time.time)
        {
            CreateCar();
            nextSpawnCar = Time.time + spawnDelay;
        }
    }

    void CreateCar()
    {
        int randomSpawn = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawn];

        GameObject carObject = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(carObject.gameObject, 5);

    }
}
