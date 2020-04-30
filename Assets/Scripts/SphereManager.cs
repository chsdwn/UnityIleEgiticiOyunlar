using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    public CubeManager cubeManager;

    // Start is called before the first frame update
    void Start()
    {
        cubeManager = Object.FindObjectOfType<CubeManager>();
        // cubeManager = GameObject.Find("Cube").GetComponent<CubeManager>();
        Debug.Log(cubeManager.volume);
        cubeManager.PrintEdge();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
