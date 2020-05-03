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
    [SerializeField]
    private Transform questionPanel;
    private GameObject[] tilesArray = new GameObject[SIZE];

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
            tilesArray[i] = tile;
        }

        InitializeTileValues();
        StartCoroutine(DoFadeCoroutine());
        Invoke("ShowQuestionPanel", 2f);
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

            tile.transform.GetChild(0).GetComponent<Text>().text = rnd.ToString();
        }
    }

    void ShowQuestionPanel()
    {
        questionPanel.GetComponent<RectTransform>().DOScale(1f, 0.3f).SetEase(Ease.OutBack);
    }
}
