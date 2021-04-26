using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLog : MonoBehaviour
{
    public float nextSpawnDelay = 0.5f;
    public float firstSpawnDelay = 15f;
    public GameObject logPrefab;

    public Transform[] logSpawnPoints;



    void FixedUpdate()
    {
        if (firstSpawnDelay <= Time.time)
        {
            CreateLog();
            firstSpawnDelay = Time.time + nextSpawnDelay;
        }
    }

    void CreateLog()
    {
        for (int i=0; i< logSpawnPoints.Length; i++)
        {
            Debug.Log(i);
            Transform logSpawnPoint = logSpawnPoints[i];

            GameObject logObject = Instantiate(logPrefab, logSpawnPoint.position, logSpawnPoint.rotation);
            Destroy(logObject.gameObject, nextSpawnDelay);
        }


    }
}