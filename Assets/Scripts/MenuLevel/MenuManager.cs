using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform head;
    [SerializeField]
    private Transform startBtn;

    // Start is called before the first frame update
    void Start()
    {
        head.transform.GetComponent<RectTransform>().DOLocalMoveX(0f, 1f).SetEase(Ease.OutBack);
        startBtn.transform.GetComponent<RectTransform>().DOLocalMoveY(-270f, 1f).SetEase(Ease.OutBack);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
