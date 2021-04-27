using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class GameSceneController : MonoBehaviour
{
    public static double CurrentScore = 0f;
    public static float CurrentGameTime = 0f;

    [Header("Cheats")]
    public CheatCodes cheats;
    [Header("Game")]
    public float gameTime = 30f;
    public Frog frog;

    [Header("Camera")]
    public float cameraMoveSpeed = 3f;
    public Camera mainCamera;

    [Header("UI")]
    public Text scoreText;
    public Text timeText;
    public Text endedGameText;


    private bool endedLevel = false;
    private bool endedGame = false;
    private float endGameTimer = 1f;
    private float endFinishTimer = 3f;
    private Vector3 nextCameraPosition;
    private int finishNumber = 1;

    void Start()
    {
        Initialization();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        scoreText.text = "You score: " + CurrentScore.ToString();
        CurrentGameTime -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.FloorToInt(CurrentGameTime) + "s";

        if (endedLevel == false)
        {
            if (CurrentGameTime < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                CurrentScore = 0;
            }
        }
        else
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, nextCameraPosition, Time.deltaTime * cameraMoveSpeed);
            endGameTimer -= Time.deltaTime;
            if (endGameTimer <= 0f)
            {
                NextLevelPart();
            }
        }
        if (endedGame == true)
        {
            endFinishTimer -= Time.deltaTime;
            if (endFinishTimer <= 0f)
            {
                LevelManager.Instance.LoadNextLevel();
            }
        }
    }

    private void OnStandFinishLevel()
    {
        endedGameText.gameObject.SetActive(true);
        endedLevel = true;
        CurrentScore += Math.Round(CurrentGameTime/gameTime * 100);
        endedGameText.text = "You receive: " + Math.Round(CurrentGameTime / gameTime * 100) + " points";
        CurrentGameTime = gameTime;
    }
    private void OnStandFinishGame()
    {
        endedGameText.gameObject.SetActive(true);
        endedGame = true;
        CurrentScore += Math.Round(CurrentGameTime / gameTime * 100);
        endedGameText.text = "You won! Your points: " + CurrentScore;
    }
    private void NextLevelPart()
    {
        finishNumber++;
        endedGameText.gameObject.SetActive(false);
        endedLevel = !endedLevel;
        if (finishNumber < 3)
        {
            nextCameraPosition.y = GameObject.Find("Finish" + finishNumber).transform.position.y + mainCamera.orthographicSize;
        }
        endGameTimer = 1f;
    }
    private void Initialization()
    {
        frog.OnStandFinishLevel = OnStandFinishLevel;
        frog.OnStandFinishGame = OnStandFinishGame;
        cheats.OnStandFinishGame = OnStandFinishGame;
        nextCameraPosition = mainCamera.transform.localPosition;
        nextCameraPosition.y = GameObject.Find("Finish" + finishNumber).transform.position.y + mainCamera.orthographicSize; 

        endedGameText.gameObject.SetActive(false);
        CurrentGameTime = gameTime;
    }
}
