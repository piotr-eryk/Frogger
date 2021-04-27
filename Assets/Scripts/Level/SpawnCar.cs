using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public float spawnDelay = 0.5f;
    public GameObject carPrefab;

    public Transform[] carSpawnPoints;

    float firstSpawnCar = 0.1f;

    void Update()
    {
        if (firstSpawnCar <= Time.time)
        {
            CreateCar();
            firstSpawnCar = Time.time + spawnDelay;
        }
    }

    void CreateCar()
    {
        int randomSpawn = Random.Range(0, carSpawnPoints.Length);
        Transform carSpawnPoint = carSpawnPoints[randomSpawn];

        GameObject carObject = Instantiate(carPrefab, carSpawnPoint.position, carSpawnPoint.rotation);
        Destroy(carObject.gameObject, 5);
    }
}
