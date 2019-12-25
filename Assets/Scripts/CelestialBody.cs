using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public Vector3 incline;
    public float degreesPerSecond = 1f;
    public float gravity = -10f;

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
        Vector3 toPlanetCore = (body.position - transform.position).normalized;
        Vector3 toSky = body.up;

        body.rotation = Quaternion.FromToRotation(toSky, toPlanetCore) * body.rotation;
        body.GetComponent<Rigidbody>().AddForce(toPlanetCore * gravity);
    }
}
