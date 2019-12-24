using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public float incline = 0f;
    public float degreesPerSecond = 1f;

    void Start()
    {
        transform.Rotate(new Vector3(incline, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0, degreesPerSecond * Time.deltaTime, 0);
    }
}
