using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public Vector3 incline;
    public float degreesPerSecond = 1f;
    public float gravity = -10f;
    public Transform core;


    void Start()
    {
        transform.Rotate(incline);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0, degreesPerSecond * Time.deltaTime, 0);
    }


    // public

    
    public void Attract(Transform body)
    {
        Vector3 center = core.GetComponent< Renderer>().bounds.center;

        Debug.DrawRay(body.transform.position, (center - body.transform.position).normalized * 300f, Color.yellow);

        // Quaternion targetRotation = Quaternion.FromToRotation(body.up, (center - body.transform.position).normalized) * body.rotation;
        Quaternion targetRotation = Quaternion.FromToRotation(body.up * -1, (center - body.transform.position).normalized) * body.rotation;

        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 5f * Time.deltaTime);
        body.GetComponent<Rigidbody>().AddForce((center - body.transform.position).normalized * gravity);
    }
}
