using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform center;
    public Transform body;
    public float degreesPerSecond = 1f;
    public Light lamp;

    GameObject plane;
    private void Start() {
    }

    void Update()
    {
        transform.Rotate (0, degreesPerSecond * Time.deltaTime, 0);
        if (lamp != null) lamp.transform.LookAt(center.position);
    }

    private void OnDrawGizmos() {
        float radius = Vector3.Distance(center.position, transform.position);
        Debug.DrawRay(body.transform.position, (center.position - body.transform.position) * radius, Color.green);
    }
}
