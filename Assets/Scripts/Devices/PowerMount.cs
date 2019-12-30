using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMount : MonoBehaviour
{
    public SacredOrb Orb { get; set; }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponentInChildren<SacredOrb>() != null) {
            Orb = other.GetComponent<SacredOrb>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponentInChildren<SacredOrb>() != null) {
            Orb = null;
        }
    }
}
