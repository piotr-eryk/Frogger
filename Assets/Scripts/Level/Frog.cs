using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{
    public Rigidbody2D frogRigibody;

    public Action OnStandFinishLevel;
    public Action OnStandFinishGame;

    public List<GameObject> frogSpawnPoints = new List<GameObject>();

    private bool River = false;
    private bool Log = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            frogRigibody.MovePosition(frogRigibody.position + Vector2.right);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            frogRigibody.MovePosition(frogRigibody.position + Vector2.left);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            frogRigibody.MovePosition(frogRigibody.position + Vector2.up);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            frogRigibody.MovePosition(frogRigibody.position + Vector2.down);

        if (!Log && River)
        {
            FrogIsDead();
            River = false;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        switch (true)
        {
            case true when otherCollider.GetComponent<LevelEnd>():
                OnStandFinishLevel?.Invoke();
                frogSpawnPoints.RemoveAt(0);
                break;
            case true when otherCollider.GetComponent<Car>():
                FrogIsDead();
                break;
            case true when otherCollider.GetComponent<Log>():
                Log = true;
                break;
            case true when otherCollider.GetComponent<River>():
                River = true;
                break;
            case true when otherCollider.CompareTag("ScoreObject"):
                otherCollider.enabled = false;
                GameSceneController.CurrentScore += 20f;
                break;
            case true when otherCollider.GetComponent<FinishGame>():
                OnStandFinishGame?.Invoke();
                break;
        }
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        switch (true)
        {
            case true when otherCollider.GetComponent<LevelEnd>():
                otherCollider.enabled = false;
                break;
            case true when otherCollider.GetComponent<Log>():
                Log = false;
                break;
            case true when otherCollider.GetComponent<River>():
                River = false;
                break;
        }
    }

    void FrogIsDead()
    {
        transform.position = frogSpawnPoints[0].transform.position;
        GameSceneController.CurrentScore = 0;
        GameSceneController.CurrentGameTime = GameObject.Find("SceneManager").GetComponent<GameSceneController>().gameTime;

        GetComponent<Health>().LoseLife();
    }
}