using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform panel1, panel2;

    public void Move()
    {
        panel1.DOAnchorPos3D(new Vector3(480, 0, 0), 0.5f).SetEase(Ease.InBack);
        panel2.DOAnchorPos3D(Vector3.zero, 0.5f).SetEase(Ease.OutBack).SetDelay(0.5f);
    }
}
