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

    // Start is called before the first frame update
    void Start()
    {
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
}
