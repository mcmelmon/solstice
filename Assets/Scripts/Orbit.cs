using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform center;
    public GameObject body;
    public float incline = 0f;
    public float degreesPerSecond = 1f;

    private void Start() {
        transform.Rotate(new Vector3(incline, 0, 0));
    }

    void Update()
    {
        transform.Rotate (0, degreesPerSecond * Time.deltaTime, 0);
    }
}
