using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject cube;

    float minAngle = 0f;
    float maxAngle = 90f;

    private void Update()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);

        cube.transform.eulerAngles = new Vector3(angle, 0, 0);
    }
}
