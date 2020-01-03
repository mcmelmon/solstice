using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public Orb Orb { get; set; }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponentInChildren<Orb>() != null) {
            Orb = other.GetComponent<Orb>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponentInChildren<Orb>() != null) {
            Orb = null;
        }
    }
}
