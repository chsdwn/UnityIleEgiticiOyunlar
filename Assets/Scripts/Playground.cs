using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject cube;

    [SerializeField]
    private int width = 1;
    [SerializeField]
    private float speed = 0.1f;

    private void Update()
    {
        float x = Mathf.Cos(Time.time * speed) * width;
        float y = Mathf.Sin(Time.time * speed) * width;
        float z = transform.position.z;

        cube.transform.position = new Vector3(x, y, z);
    }
}
