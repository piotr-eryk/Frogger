using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D carRigidbody;
    public float minSpeed = 8f;
    public float maxSpeed = 12f;


    float carSpeed = 1f;

    void Start()
    {
        carSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);

        carRigidbody.MovePosition(carRigidbody.position + forward * Time.fixedDeltaTime * carSpeed);
    }
}
