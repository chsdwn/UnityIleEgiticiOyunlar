using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlphaPanel : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CanvasGroup>().DOFade(0, 2f);
    }
}
