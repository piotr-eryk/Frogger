using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    public static int CurrentScore = 100;

    [Header("Game")]
    public Frog frog;

    [Header("UI")]
    public Text scoreText;
    public Text timeText;
    public Text endedGameText;

    private bool endedLevel;
    private float gameTimer = 10f;
    private float endGameTimer = 3f;

    void Start()
    {
        endedGameText.gameObject.SetActive(false);
        frog.OnStandFinish = OnStandFinish;
    }

    void Update()
    {
        if (endedLevel == false)
        {
            if ((gameTimer -= Time.deltaTime)<0)
                gameTimer = 0;

          //  CurrentScore -= (int) gameTimer;
            timeText.text = "Time: " + Mathf.FloorToInt(gameTimer) + "s";
            scoreText.text = "You score: " + CurrentScore.ToString();
        }
        else
        {
            endGameTimer -= Time.deltaTime;
            if (endGameTimer <= 0f)
            {
                Debug.Log(endGameTimer);
                LevelManager.Instance.LoadNextLevel();
            }
        }
    }

    private void OnStandFinish()
    {
        endedGameText.gameObject.SetActive(true);
        endedLevel = true;
        timeText.gameObject.SetActive(false);
        endedGameText.text = "You won!\nYour actual score: " + Mathf.FloorToInt(CurrentScore) + " points";
    }
}
