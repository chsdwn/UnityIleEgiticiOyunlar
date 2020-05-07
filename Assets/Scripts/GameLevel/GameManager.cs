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

    [SerializeField]
    private Sprite[] tileSprites;

    List<int> divisionValues = new List<int>();
    int divisor;
    int dividend;
    int result;

    int heartsCount;

    string difficult;

    HeartsManager heartsManager;
    ScoreManager scoreManager;
    GameObject pressedTile;

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
            tile.transform.GetChild(1).GetComponent<Image>().sprite = tileSprites[Random.Range(0, tileSprites.Length)];
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

            pressedTile = UnityEngine
                .EventSystems
                .EventSystem
                .current
                .currentSelectedGameObject;

            CheckAnswer();
        }
    }

    void CheckAnswer()
    {
        if (tileValue == result)
        {
            pressedTile.transform.GetChild(1).GetComponent<Image>().enabled = true;
            pressedTile.transform.GetChild(0).GetComponent<Text>().text = "";
            pressedTile.transform.GetComponent<Button>().interactable = false;

            scoreManager.IncreaseScore(difficult);

            divisionValues.RemoveAt(questionIndex);

            if (divisionValues.Count > 0)
                ShowQuestionPanel();
            else
                GameOver();
        }
        else
        {
            heartsCount--;
            heartsManager.CheckHearts(heartsCount);
        }

        if (heartsCount <= 0)
            GameOver();
    }

    void GameOver()
    {
        Debug.Log("Game Over");
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
