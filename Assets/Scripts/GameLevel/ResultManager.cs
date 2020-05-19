using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text correctCountTxt, wrongCountTxt, scoreTxt;

    int score, increment, scoreToPrint;

    int scoreSteps = 10;
    bool isTimeOver;

    private void Awake()
    {
        isTimeOver = true;
    }

    public void ShowResult(int correctCount, int wrongCount, int score)
    {
        this.score = score;
        increment = score / 10;

        correctCountTxt.text = correctCount.ToString();
        wrongCountTxt.text = wrongCount.ToString();
        scoreTxt.text = score.ToString();

        StartCoroutine(PrintScoreRoutine());
    }

    IEnumerator PrintScoreRoutine()
    {
        while (isTimeOver)
        {
            yield return new WaitForSeconds(.1f);

            scoreToPrint += increment;

            if (scoreToPrint >= score)
            {
                scoreTxt.text = score.ToString();
                isTimeOver = false;
            }
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
