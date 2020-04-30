using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject cube;

    float min = -1.0f;
    float max = 1.0f;
    float t = 0f;

    private void Update()
    {
        cube.transform.position = new Vector3(Mathf.Lerp(min, max, t), 0, 0);
        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = max;
            max = min;
            min = temp;
            t = 0f;
        }

        // a = Mathf.Lerp(0f, 100f, 0.5f);
        // Debug.Log(a); // 50, 75, 87.5, 93.75 ...
    }
}
