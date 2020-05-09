using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private GameObject bottomRect;


    void Start()
    {
        UpdateScene();
    }

    void UpdateScene()
    {
        scoreTimePanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        catchPointsImage.GetComponent<CanvasGroup>().DOFade(1, 1f);

        topRect.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
        bottomRect.GetComponent<RectTransform>().DOLocalMoveX(0, 0.7f).SetEase(Ease.OutBack);
    }
}
