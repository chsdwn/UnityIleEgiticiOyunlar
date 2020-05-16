using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CirclesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] circles;

    // Start is called before the first frame update
    void Start()
    {
        InvisibleCircles();
    }

    void InvisibleCircles()
    {
        foreach (GameObject circle in circles)
        {
            circle.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }

    public void VisibleCircle(int circleIndex)
    {
        circles[circleIndex].GetComponent<RectTransform>().DOScale(1, 0.3f);

        if (circleIndex % 5 == 0)
            InvisibleCircles();
    }
}
