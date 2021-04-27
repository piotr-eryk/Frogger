using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject[] hearts;
    private int lifeNumber;
    private bool isDead;

    void Start()
    {
        lifeNumber = hearts.Length;
    }

    void Update()
    {
        if (isDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoseLife()
    {
        if (lifeNumber>= 1)
        {
            lifeNumber -= 1;
            Destroy(hearts[lifeNumber].gameObject);

            if (lifeNumber < 1)
                isDead = true; 
        }
    }
}
