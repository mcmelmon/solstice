using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Mass : MonoBehaviour
{
    public CelestialBody planet;

    private void Start() {
        if (planet != null) { 
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    private void FixedUpdate() {
        if (planet != null) {
            planet.Attract(transform);
        }
    }
}
