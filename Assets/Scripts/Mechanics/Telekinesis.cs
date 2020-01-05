using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    [SerializeField] float initialForce = .3f;

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
            Vector3 pull = (transform.position - other.transform.position).normalized;
            Vector3 push = (other.transform.position - transform.position).normalized;
            Vector3 left = Vector3.Cross(pull, Vector3.up).normalized;
            float distance = Vector3.Distance(other.transform.position, transform.position);

            // Fiddle with the force and size of the player's sphere collider trigger to tune the
            // telekinesis effect

            if (distance > 3f) {
                other.gameObject.GetComponent<Rigidbody>().AddForce((left + pull) * initialForce, ForceMode.Impulse);
            } else {
                other.gameObject.GetComponent<Rigidbody>().AddForce(push * initialForce, ForceMode.Impulse);
            }
        }   
    }

    // public

    public void PushIt() {
        if (Orb != null) {
            Vector3 push = (Orb.transform.position - transform.position).normalized;
            Orb.GetComponent<Rigidbody>().AddForce(push * initialForce * 20f, ForceMode.Impulse);
        }

    }
}
