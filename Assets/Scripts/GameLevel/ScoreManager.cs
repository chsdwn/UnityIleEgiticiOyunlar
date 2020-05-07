using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    private int score;
    private int scoreIncrement;

    // Start is called before the first frame update
    void Start()
    {
        WriteScore();
    }

    public void IncreaseScore(string difficult)
    {
        switch (difficult)
        {
            case "easy":
                scoreIncrement = 5;
                break;
            case "normal":
                scoreIncrement = 10;
                break;
            case "hard":
                scoreIncrement = 15;
                break;
        }

        score += scoreIncrement;
        WriteScore();
    }

    private void WriteScore()
    {
        scoreText.text = score.ToString();
    }
}
