using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Frog : MonoBehaviour
{
    public Rigidbody2D frogRigibody;

    public Action OnStandFinish;

    private bool receivePoints = false;

    public List<GameObject> objectsForScore = new List<GameObject>();


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

    List<string> contacts = new List<string>();
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        contacts.Add(otherCollider.gameObject.name);

        if (otherCollider.GetComponent<LevelEnd>() != null)
        {
            OnStandFinish?.Invoke();
        }
        else if (otherCollider.GetComponent<Car>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameSceneController.CurrentScore = 0;
        }
        else if (!contacts.Contains("testLog(Clone)") && contacts.Contains("River"))
        {
            Debug.Log("ded�e� bez drewienka");
          //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //   GameSceneController.CurrentScore = 0;
        }
        else if(otherCollider.CompareTag ("ScoreObject") && !receivePoints)
        {
            Debug.Log("More points!");
            receivePoints = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        contacts.Remove(otherCollider.gameObject.name);

        if (contacts.Contains("River"))
        {
            Debug.Log("ded�e� po zej�ciu z drewienka");
        }
        else if (otherCollider.CompareTag("ScoreObject") && receivePoints)
        {
            Debug.Log("Delete this collider");
            receivePoints = false;
        }

    }
}
