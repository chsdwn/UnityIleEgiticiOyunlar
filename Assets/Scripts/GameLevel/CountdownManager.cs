using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CountdownManager : MonoBehaviour
{
    [SerializeField]
    private GameObject countdownObj;
    [SerializeField]
    private Text countdownTxt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownTxt.text = i.ToString();
            yield return new WaitForSeconds(0.5f);

            countdownObj.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
            yield return new WaitForSeconds(1f);

            countdownObj.GetComponent<RectTransform>().DOScale(0, 0.5f).SetEase(Ease.InBack);
            yield return new WaitForSeconds(0.6f);
        }

        StopAllCoroutines();
    }
}
