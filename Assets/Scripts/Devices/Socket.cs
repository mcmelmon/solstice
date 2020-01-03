using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public Orb Orb { get; set; }
    public Reactor Reactor { get; set; }

    private void Awake() {
        Reactor = GetComponent<Reactor>();
    }

    private void OnTriggerEnter(Collider other) {
        if (Orb == null && other.GetComponentInChildren<Orb>() != null) {
            Orb = other.GetComponent<Orb>();
            Orb.LockInPlace();
            Reactor.ShowButton();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponentInChildren<Orb>() != null) {
            Orb = null;
            Reactor.HideButton();
            Reactor.Mechanism.Reset();
        }
    }
}
