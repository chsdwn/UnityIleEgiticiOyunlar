using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreTimePanel;
    [SerializeField]
    private GameObject catchPointsImage, selectBiggerNumberImage;
    [SerializeField]
    private GameObject topRect;
    [SerializeField]
    private Text topTxt;
    [SerializeField]
    private GameObject bottomRect;
    [SerializeField]
    private Text bottomTxt;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private Text scoreTxt;

    CirclesManager circlesManager;
    ResultManager resultManager;
    TimerManager timerManager;
    TrueFalseManager trueFalseManager;

    int questionCounter;
    int questionIndex;
    int topValue;
    int bottomValue;
    int largeInt;
    int btnValue;
    int score = 0;
    int scoreIncrement;
    int correctCount;
    int wrongCount;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip startSound, gameOverSound, wrongSound, correctSound;

    private void Awake()
    {
        circlesManager = Object.FindObjectOfType<CirclesManager>();
        timerManager = Object.FindObjectOfType<TimerManager>();
        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();

        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.PlayOneShot(startSound);

        questionCounter = 0;
        questionIndex = 0;

        topTxt.text = "";
        bottomTxt.text = "";
        scoreTxt.text = "0";

        UpdateScene();
    }

    void UpdateScene()
    {
        scoreTimePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        catchPointsImage.GetComponent<CanvasGroup>().DOFade(1, 1f);

        topRect.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        bottomRect.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
    }

    public void StartGame()
    {
        catchPointsImage.GetComponent<CanvasGroup>().DOFade(0, 1f);
        selectBiggerNumberImage.GetComponent<CanvasGroup>().DOFade(1, 1f);

        PrintQuestion();

        timerManager.StartTimer();
    }

    void PrintQuestion()
    {
        if (questionCounter < 5)
        {
            questionIndex = 1;
            scoreIncrement = 25;
        }
        else if (questionCounter >= 5 && questionCounter < 10)
        {
            questionIndex = 2;
            scoreIncrement = 50;
        }
        else if (questionCounter >= 10 && questionCounter < 15)
        {
            questionIndex = 3;
            scoreIncrement = 75;
        }
        else if (questionCounter >= 15 && questionCounter < 20)
        {
            questionIndex = 4;
            scoreIncrement = 100;
        }
        else if (questionCounter >= 20 && questionCounter < 25)
        {
            questionIndex = 5;
            scoreIncrement = 125;
        }
        else
        {
            questionIndex = Random.Range(1, 6);
            scoreIncrement = 150;
        }

        switch (questionIndex)
        {
            case 1:
                FirstQuestion();
                break;
            case 2:
                SecondQuestion();
                break;
            case 3:
                ThirdQuestion();
                break;
            case 4:
                FourthQuestion();
                break;
            case 5:
                FifthQuestion();
                break;
        }
    }

    void FirstQuestion()
    {
        int rnd = Random.Range(1, 50);

        if (rnd <= 25)
        {
            topValue = Random.Range(2, 50);
            bottomValue = topValue + Random.Range(1, 10);
        }
        else
        {
            topValue = Random.Range(2, 50);
            bottomValue = Mathf.Abs(topValue - Random.Range(1, 10));
        }

        if (topValue > bottomValue)
            largeInt = topValue;
        else
            largeInt = bottomValue;

        if (topValue == bottomValue)
        {
            FirstQuestion();
            return;
        }

        topTxt.text = topValue.ToString();
        bottomTxt.text = bottomValue.ToString();
    }

    void SecondQuestion()
    {
        int first = Random.Range(1, 10);
        int second = Random.Range(1, 20);
        int third = Random.Range(1, 10);
        int fourth = Random.Range(1, 20);

        topValue = first + second;
        bottomValue = third + fourth;

        if (topValue > bottomValue)
            largeInt = topValue;
        else if (bottomValue > topValue)
            largeInt = bottomValue;

        if (topValue == bottomValue)
        {
            SecondQuestion();
            return;
        }

        topTxt.text = first + " + " + second;
        bottomTxt.text = third + " + " + fourth;
    }

    void ThirdQuestion()
    {
        int first = Random.Range(11, 30);
        int second = Random.Range(1, 11);
        int third = Random.Range(11, 40);
        int fourth = Random.Range(1, 11);

        topValue = first - second;
        bottomValue = third - fourth;

        if (topValue > bottomValue)
            largeInt = topValue;
        else if (bottomValue > topValue)
            largeInt = bottomValue;

        if (topValue == bottomValue)
        {
            ThirdQuestion();
            return;
        }

        topTxt.text = first + " - " + second;
        bottomTxt.text = third + " - " + fourth;
    }

    void FourthQuestion()
    {
        int first = Random.Range(1, 10);
        int second = Random.Range(1, 10);
        int third = Random.Range(1, 10);
        int fourth = Random.Range(1, 10);

        topValue = first * second;
        bottomValue = third * fourth;

        if (topValue > bottomValue)
            largeInt = topValue;
        else if (bottomValue > topValue)
            largeInt = bottomValue;

        if (topValue == bottomValue)
        {
            FourthQuestion();
            return;
        }

        topTxt.text = first + " * " + second;
        bottomTxt.text = third + " * " + fourth;
    }

    void FifthQuestion()
    {
        int divider1 = Random.Range(2, 10);
        topValue = Random.Range(2, 10);
        int dividend1 = topValue * divider1;

        int divider2 = Random.Range(2, 10);
        bottomValue = Random.Range(2, 10);
        int dividend2 = bottomValue * divider2;

        if (topValue > bottomValue)
            largeInt = topValue;
        else if (bottomValue > topValue)
            largeInt = bottomValue;

        if (topValue == bottomValue)
        {
            FifthQuestion();
            return;
        }

        topTxt.text = dividend1 + " / " + divider1;
        bottomTxt.text = dividend2 + " / " + divider2;
    }

    public void SelectAnswer(string btnName)
    {
        if (btnName == "topBtn")
        {
            btnValue = topValue;
        }
        else if (btnName == "bottomBtn")
        {
            btnValue = bottomValue;
        }

        if (btnValue == largeInt)
        {
            trueFalseManager.VisibleIcon(true);

            circlesManager.VisibleCircle(questionCounter % 5);
            questionCounter++;

            score += scoreIncrement;

            scoreTxt.text = score.ToString();

            correctCount++;

            audioSource.PlayOneShot(correctSound);

            PrintQuestion();
        }
        else
        {
            trueFalseManager.VisibleIcon(false);

            wrongCount++;

            audioSource.PlayOneShot(wrongSound);

            OnWrongAnswer();
            PrintQuestion();
        }
    }

    void OnWrongAnswer()
    {
        questionCounter -= (questionCounter % 5 + 5);

        if (questionCounter < 0)
            questionCounter = 0;

        circlesManager.InvisibleCircles();
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void GameOver()
    {
        resultPanel.SetActive(true);

        audioSource.PlayOneShot(gameOverSound);

        resultManager = Object.FindObjectOfType<ResultManager>();
        resultManager.ShowResult(correctCount, wrongCount, score);
    }
}
