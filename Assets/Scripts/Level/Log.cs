using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    enum Operator { Add, Substract };
    enum LessOrMore { Less, More };

    [Header("Movement")]
    public Rigidbody2D logRigidbody;
    public float logSpeed = 2f;

    [Header("Log Sinking")]
    public float minTimeToSink = 0.1f;
    public float maxTimeToSink = 0.5f;
    public float sinkSpeed = 2f;
    public Collider2D logCollider;
    public float surfaceTime = 10f;

    private float logWaitTime = 1f;

    void Start()
    {
        logWaitTime = Random.Range(minTimeToSink, maxTimeToSink);
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);

        logRigidbody.MovePosition(logRigidbody.position + forward * Time.fixedDeltaTime * logSpeed);

        StartCoroutine(SinkOrSurfaceLog(Operator.Substract, LessOrMore.More, logWaitTime));
        StartCoroutine(SinkOrSurfaceLog(Operator.Add, LessOrMore.Less, logWaitTime + surfaceTime + sinkSpeed));
    }

    IEnumerator SinkOrSurfaceLog(Operator op, LessOrMore lom, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        Color color = GetComponent<SpriteRenderer>().material.color;

        if (op == Operator.Add)
        {
            color.a += Time.deltaTime * 5f;
        }
        else if(op == Operator.Substract)
        {
            color.a -= Time.deltaTime * sinkSpeed;
        }

        color.a = Mathf.Clamp(color.a, 0, 1);
        GetComponent<SpriteRenderer>().material.color = color;
        logCollider = GetComponent<Collider2D>();

        if (lom == LessOrMore.More && color.a <= 0)
        {
            logCollider.enabled = false;
        }
        else if (lom == LessOrMore.Less && color.a > 0)
        {
             logCollider.enabled = true;
        }
    }
}
