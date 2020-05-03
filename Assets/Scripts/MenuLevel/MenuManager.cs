using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, exitBtn;

    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGameLevel()
    {
        SceneManager.LoadScene("GameLevel");
    }

    private void FadeOut()
    {
        startBtn.GetComponent<CanvasGroup>().DOFade(1f, 0.8f);
        exitBtn.GetComponent<CanvasGroup>().DOFade(1f, 0.8f).SetDelay(0.5f);
    }
}
