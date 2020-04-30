using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;

    private void Start()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        // Waits 1 frame
        // yield return null;

        // Waits 3 seconds then runs the code below it.
        yield return new WaitForSeconds(3f);
        cube.SetActive(false);

        yield return new WaitForSeconds(2f);
        cube.SetActive(true);
    }
}
