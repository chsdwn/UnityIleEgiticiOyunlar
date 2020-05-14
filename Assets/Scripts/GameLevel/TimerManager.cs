using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text timerTxt;

    int timer;
    bool isTimerRun;

    // Start is called before the first frame update
    void Start()
    {
        timer = 90;
        isTimerRun = true;

        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (isTimerRun)
        {
            yield return new WaitForSeconds(1f);

            if (timer < 10)
                timerTxt.text = "0" + timer.ToString();
            else
                timerTxt.text = timer.ToString();

            if (timer == 0)
            {
                isTimerRun = false;
                timerTxt.text = "00";
            }

            timer--;
        }
    }
}
