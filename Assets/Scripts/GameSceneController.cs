using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameSceneController : MonoBehaviour
{
    public static double CurrentScore = 100;

    [Header("Game")]
    public Frog frog;
    public readonly float gameTime = 10f;

    [Header("UI")]
    public Text scoreText;
    public Text timeText;
    public Text endedGameText;

    private bool endedLevel;
    private float endGameTimer = 3f;
    public float currentGameTime = 0f;

    void Start()
    {
        endedGameText.gameObject.SetActive(false);
        frog.OnStandFinish = OnStandFinish;
        currentGameTime = gameTime;
    }

    void Update()
    {
        if (endedLevel == false)
        {
            if ((currentGameTime -= Time.deltaTime)<0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            timeText.text = "Time: " + Mathf.FloorToInt(currentGameTime) + "s";
            scoreText.text = "You score: " + CurrentScore.ToString();
        }
        else
        {
            endGameTimer -= Time.deltaTime;
            if (endGameTimer <= 0f)
            {
                LevelManager.Instance.LoadNextLevel();
            }
        }
    }

    private void OnStandFinish()
    {
        endedGameText.gameObject.SetActive(true);
        endedLevel = true;
        timeText.gameObject.SetActive(false);
        CurrentScore += Math.Round(currentGameTime/gameTime * 100);
        endedGameText.text = "You won!\nYou receive: " + Math.Round(currentGameTime / gameTime * 100) + " points";

        Debug.Log(CurrentScore);

        CurrentScore += 100;
    }
}
