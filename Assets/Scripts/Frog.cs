using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{
    public Rigidbody2D frogRigibody;
    public Camera playerCamera;

    public Action OnStandFinish;

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
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<LevelEnd>() != null)
        {
            OnStandFinish?.Invoke();
        }
        else if (otherCollider.GetComponent<Car>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameSceneController.CurrentScore = 0;
        }
        else if (otherCollider.CompareTag("River"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameSceneController.CurrentScore = 0;
        }
    }
}
