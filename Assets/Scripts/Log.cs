using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D logRigidbody;
    public float minSpeed = 4f;
    public float maxSpeed = 6f;

    [Header("Fading")]
    public float minTimeToDip = 0.1f;
    public float maxTimeToDip = 0.5f;
    public float fadeSpeed = 2f;
    public Collider2D logCollider;
    public float surfaceTime = 1f;

    private float logWaitTime = 1f;
    private float logSpeed = 1f;

    void Start()
    {
        logSpeed = Random.Range(minSpeed, maxSpeed);
        logWaitTime = Random.Range(minTimeToDip, maxTimeToDip);
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);

        logRigidbody.MovePosition(logRigidbody.position + forward * Time.fixedDeltaTime * logSpeed);

        Invoke(nameof(DipLog), logWaitTime);
        Debug.Log(logWaitTime);
        Invoke(nameof(DipLog2), logWaitTime+surfaceTime+fadeSpeed);
        Debug.Log(logWaitTime);
    }

    void DipLog()
    {
        Color color = GetComponent<SpriteRenderer>().material.color;
        color.a -= Time.deltaTime * fadeSpeed;
        GetComponent<SpriteRenderer>().material.color = color;
        logCollider = GetComponent<Collider2D>();

        //when gameobject is faded do this
        logCollider.enabled = !logCollider.enabled;
    }

    void DipLog2()
    {
        Color color = GetComponent<SpriteRenderer>().material.color;
        color.a += Time.deltaTime * 5f;
        if (color.a > 1)
            color.a = 1;

        GetComponent<SpriteRenderer>().material.color = color;
        logCollider = GetComponent<Collider2D>();
        logCollider.enabled = !logCollider.enabled;
    }

}
