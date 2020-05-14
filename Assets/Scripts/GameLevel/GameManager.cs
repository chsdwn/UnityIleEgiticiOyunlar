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
    private GameObject catchPointsImage;
    [SerializeField]
    private GameObject topRect;
    [SerializeField]
    private Text topTxt;
    [SerializeField]
    private GameObject bottomRect;
    [SerializeField]
    private Text bottomTxt;

    TimerManager timerManager;

    private void Awake()
    {
        timerManager = Object.FindObjectOfType<TimerManager>();
    }

    void Start()
    {
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
        catchPointsImage.GetComponent<CanvasGroup>().DOFade(0, 0.2f);

        topTxt.text = "(30 + 20) - 63";
        bottomTxt.text = "(10 - 40) + 13";

        timerManager.StartTimer();
    }
}
