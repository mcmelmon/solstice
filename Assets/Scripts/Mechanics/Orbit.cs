using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform center;
    public Transform body;
    public float degreesPerSecond = 1f;

    GameObject plane;
    private void Start() {
    }

    void Update()
    {
        transform.Rotate (0, degreesPerSecond * Time.deltaTime, 0);
    }

    private void OnDrawGizmos() {
        float radius = Vector3.Distance(center.position, transform.position);
        // if (plane == null) {
        //     plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //     plane.transform.parent = this.gameObject.transform;
        // }
        Debug.DrawRay(body.transform.position, (center.position - body.transform.position) * radius, Color.green);
    }
}
