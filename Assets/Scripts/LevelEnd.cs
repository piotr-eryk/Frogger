using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{

    private int level;

    private const int MAXIMUM_LEVEL = 1;


    void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameSceneController.CurrentScore += 100;
    }

    public void LoadNextLevel()
    {
        level++;
        if (level <= MAXIMUM_LEVEL)
        {
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
