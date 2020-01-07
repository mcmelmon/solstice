using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    public Orb Orb { get; set; }

    private void Awake() {
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Orb>() != null) {
            Orb = other.gameObject.GetComponent<Orb>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<Orb>() != null) {
            Orb = null;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Orb>() != null) {
            Vector3 push = (other.transform.position - transform.position).normalized;
            Vector3 left = Vector3.Cross(push, Vector3.up).normalized;

            other.gameObject.GetComponent<Rigidbody>().AddForce((push + left) * 0.5f, ForceMode.Impulse);
        }   
    }

    // public

    public void PushIt() {
        if (Orb != null) {
            Vector3 push = (Orb.transform.position - transform.position).normalized;
            Orb.GetComponent<Rigidbody>().AddForce(push * 0.5f * 20f, ForceMode.Impulse);
        }

    }
}
