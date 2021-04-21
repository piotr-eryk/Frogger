using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public Rigidbody2D logRigidbody;
    public float minSpeed = 4f;
    public float maxSpeed = 6f;
 //   public GameObject River;

    float logSpeed = 1f;

    void Start()
    {
        logSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);

        logRigidbody.MovePosition(logRigidbody.position + forward * Time.fixedDeltaTime * logSpeed);
    }
}
