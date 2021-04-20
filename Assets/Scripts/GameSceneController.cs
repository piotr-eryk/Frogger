using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameSceneController : MonoBehaviour
{
    public static double CurrentScore = 0f;
    public readonly float gameTime = 10f;

    [Header("Game")]
    public Frog frog;

    [Header("Camera")]
    public float cameraMoveSpeed = 3f;
    public Camera mainCamera;

    [Header("UI")]
    public Text scoreText;
    public Text timeText;
    public Text endedGameText;

    private bool endedLevel = false;
    private float endGameTimer = 1f;
    private float currentGameTime = 0f;
    public Vector3 nextCameraPosition;


    void Start()
    {
        endedGameText.gameObject.SetActive(false);
        frog.OnStandFinish = OnStandFinish;
        currentGameTime = gameTime;
        nextCameraPosition = mainCamera.transform.localPosition;
        nextCameraPosition.y = 9f; //TODO assign a position of GameObject Finish
    }

    void Update()
    {
        scoreText.text = "You score: " + CurrentScore.ToString();
        currentGameTime -= Time.deltaTime;
        timeText.text = "Time: " + Mathf.FloorToInt(currentGameTime) + "s";

        if (endedLevel == false)
        {
            if (currentGameTime < 0)
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
                endedGameText.gameObject.SetActive(false);
                endedLevel = false;
                nextCameraPosition.y += 9f;
                endGameTimer = 1f;
            }
        }
    }

    private void OnStandFinish()
    {
        endedGameText.gameObject.SetActive(true);
        endedLevel = true;
        CurrentScore += Math.Round(currentGameTime/gameTime * 100);
        endedGameText.text = "You receive: " + Math.Round(currentGameTime / gameTime * 100) + " points";
        currentGameTime = gameTime;
    }
}
