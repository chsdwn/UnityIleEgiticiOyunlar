using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void Exit()
    {
        SceneManager.LoadScene("MenuLevel");
    }
}
