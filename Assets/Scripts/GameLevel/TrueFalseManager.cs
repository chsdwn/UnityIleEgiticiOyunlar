using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;

    // Start is called before the first frame update
    void Start()
    {
        InvisibleIcons();
    }

    public void VisibleIcon(bool isAnswerTrue)
    {
        if (isAnswerTrue)
            trueIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);
        else
            falseIcon.GetComponent<RectTransform>().DOScale(1, 0.2f);

        Invoke("InvisibleIcons", 0.4f);
    }

    void InvisibleIcons()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
