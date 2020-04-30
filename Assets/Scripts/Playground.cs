using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject cube;

    private int value = -5;

    private void Start()
    {
        Debug.Log(Mathf.Abs(value));
        Debug.Log(Mathf.Abs(10 - 20));
        Debug.Log(Mathf.Abs(20 - 10));
    }
}
