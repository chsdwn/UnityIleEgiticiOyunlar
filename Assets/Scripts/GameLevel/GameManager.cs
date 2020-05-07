using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private const int SIZE = 25;

    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Transform tiles;
    private GameObject[] tilesArray = new GameObject[SIZE];
    int tileValue;
    bool isQuestionAsked;

    [SerializeField]
    private Transform questionPanel;
    [SerializeField]
    private Text questionText;
    int questionIndex;

    List<int> divisionValues = new List<int>();
    int divisor;
    int dividend;
    int result;

    int heartsCount;

    string difficult;

    HeartsManager heartsManager;
    ScoreManager scoreManager;

    private void Awake()
    {
        heartsCount = 3;

        heartsManager = Object.FindObjectOfType<HeartsManager>();
        heartsManager.CheckHearts(heartsCount);

        scoreManager = Object.FindObjectOfType<ScoreManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        questionPanel.GetComponent<RectTransform>().localScale = Vector3.zero;

        CreateTiles();
    }

    public void CreateTiles()
    {
        for (int i = 0; i < SIZE; i++)
        {
            GameObject tile = Instantiate(tilePrefab, tiles);
            tile.transform.GetComponent<Button>().onClick.AddListener(() => TilePressed());
            tilesArray[i] = tile;
        }

        InitializeTileValues();
        StartCoroutine(DoFadeCoroutine());
        Invoke("ShowQuestionPanel", 2f);
    }

    void TilePressed()
    {
        if (isQuestionAsked)
        {
            tileValue = int.Parse(
                UnityEngine
                .EventSystems
                .EventSystem
                .current
                .currentSelectedGameObject
                .transform
                .GetChild(0)
                .GetComponent<Text>()
                .text
            );

            CheckAnswer();
        }
    }

    void CheckAnswer()
    {
        if (tileValue == result)
            scoreManager.IncreaseScore(difficult);
        else
        {
            heartsCount--;
            heartsManager.CheckHearts(heartsCount);
        }
    }

    IEnumerator DoFadeCoroutine()
    {
        foreach (var tile in tilesArray)
        {
            tile.GetComponent<CanvasGroup>().DOFade(1, 0.07f);

            yield return new WaitForSeconds(0.07f);
        }
    }

    void InitializeTileValues()
    {
        foreach (var tile in tilesArray)
        {
            int rnd = Random.Range(1, 13);
            divisionValues.Add(rnd);

            tile.transform.GetChild(0).GetComponent<Text>().text = rnd.ToString();
        }
    }

    void ShowQuestionPanel()
    {
        AskQuestion();
        isQuestionAsked = true;
        questionPanel.GetComponent<RectTransform>().DOScale(1f, 0.3f).SetEase(Ease.OutBack);
    }

    void AskQuestion()
    {
        divisor = Random.Range(2, 11);

        questionIndex = Random.Range(0, divisionValues.Count);
        result = divisionValues[questionIndex];
        dividend = divisor * result;

        if (dividend <= 40)
            difficult = "easy";
        else if (dividend > 40 && dividend <= 80)
            difficult = "normal";
        else
            difficult = "hard";

        questionText.text = $"{dividend.ToString()} : {divisor.ToString()}";
    }
}
