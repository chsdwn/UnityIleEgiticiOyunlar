using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject cube;
    public GameObject target;

    float speed = 10f;

    private void Update()
    {
        cube.transform.position = Vector3.MoveTowards(cube.transform.position, target.transform.position, Time.deltaTime * speed);
    }
}
