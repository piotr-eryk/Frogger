using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D carRigidbody;
    public float carSpeed = 10f;

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);

        carRigidbody.MovePosition(carRigidbody.position + forward * Time.fixedDeltaTime * carSpeed);
    }
}
