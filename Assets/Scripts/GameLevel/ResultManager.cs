using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    [SerializeField]
    private Text correctCountTxt, wrongCountTxt, scoreTxt;

    public void ShowResult(int correntCount, int wrongCount, int score)
    {
        correctCountTxt.text = correntCount.ToString();
        wrongCountTxt.text = wrongCount.ToString();
        scoreTxt.text = score.ToString();
    }
}
