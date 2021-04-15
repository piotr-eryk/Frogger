using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int CurrentScore = 0;

    public Text ScoreText;

    void Start()
    {
        ScoreText.text = CurrentScore.ToString();
    }
}
