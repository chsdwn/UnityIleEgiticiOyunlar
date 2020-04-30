using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject cube;

    float min = -1f;
    float max = 1f;
    float time = 0f;

    private void Update()
    {
        float x = Mathf.Sin(time * 5f);
        float xPos = Mathf.Clamp(x, min, max);

        cube.transform.position = new Vector3(xPos, 0, 0);

        time += Time.deltaTime;
    }
}
