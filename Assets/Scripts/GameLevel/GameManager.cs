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

    TimerManager timerManager;

    int questionCounter;
    int questionIndex;
    int topValue;
    int bottomValue;
    int largeInt;
    int btnValue;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
    }

    void Start()
    {
        questionCounter = 0;
        questionIndex = 0;

        topTxt.text = "";
        bottomTxt.text = "";

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
            questionIndex = 1;

        switch (questionIndex)
        {
            case 1:
                FirstQuestion();
                break;
        }
    }

    void FirstQuestion()
    {
        int rnd = Random.Range(0, 50);

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

        topTxt.text = topValue.ToString();
        bottomTxt.text = bottomValue.ToString();
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
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }
    }
}
