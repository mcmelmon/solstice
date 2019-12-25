using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Mass : MonoBehaviour
{
    public CelestialBody planet;

    private void FixedUpdate() {
        planet.Attract(transform);
    }
}
