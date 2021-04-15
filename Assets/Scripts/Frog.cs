using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    public Rigidbody2D frogRigibody;

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



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score.CurrentScore = 0;
        }
    }
}
