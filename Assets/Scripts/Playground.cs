using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject cubePrefab;

    void Start()
    {
        // Runs CreateCube method after 2 seconds
        Invoke("CreateCube", 2f);
    }

    private void CreateCube()
    {
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
    }
}
