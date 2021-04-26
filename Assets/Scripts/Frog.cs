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
           // Debug.Log("Rzeka: " + River + "belka: " + Log);

            FrogIsDead();
        }

    }

    List<string> contacts = new List<string>();
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
      //  contacts.Add(otherCollider.gameObject.name);

        if (otherCollider.GetComponent<LevelEnd>() != null)
        {
            OnStandFinish?.Invoke();
            frogSpawnPoints.RemoveAt(0);
        }
        else if (otherCollider.GetComponent<Car>() != null)
        {
            FrogIsDead();
        }
        //else if (!contacts.Contains("testLog(Clone)") && contacts.Contains("River"))
        //{
        //    Debug.Log("ded³eœ bez drewienka");
        //  //  FrogIsDead();
        //}

        else if (otherCollider.GetComponent<Log>() != null)
        {
            Log = true;
      //      Debug.Log("Rzeka: " + River + "belka: " + Log);
        }
        else if (otherCollider.GetComponent<River>() != null)
        {
            River = true;
     //       Debug.Log("Rzeka: " + River + "belka: " + Log);
        }

        else if(otherCollider.CompareTag ("ScoreObject") && !receivePoints)
        {
       //     Debug.Log("More points!");
            receivePoints = true;
        }
    }

    void OnTriggerExit2D(Collider2D otherCollider)
    {
        contacts.Remove(otherCollider.gameObject.name);

        //if (!contacts.Contains("testLog(Clone)") && contacts.Contains("River"))
        //{
        //    Debug.Log(contacts);
        //    Debug.Log("ded³eœ po zejœciu z drewienka");
        //    FrogIsDead();
        //}
        if (otherCollider.CompareTag("ScoreObject") && receivePoints)
        {
          //  Debug.Log("Delete this collider");
            receivePoints = false;
        }
        else if (otherCollider.GetComponent<LevelEnd>() != null)
        {
            otherCollider.enabled = false;
        }
        else if (otherCollider.GetComponent<Log>() != null)
        {
            Log = false;
        }
        else if (otherCollider.GetComponent<River>() != null)
        {
            River = false;
        }

        if (!Log && River)
        {
            Debug.Log("ded³eœ po spadnieciu");
        }
    }

    void FrogIsDead()
    {
        transform.position = frogSpawnPoints[0].transform.position;
        GameSceneController.CurrentScore = 0;
        GetComponent<Health>().LoseLife();
    }
}
