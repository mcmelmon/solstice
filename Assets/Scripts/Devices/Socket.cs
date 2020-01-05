using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    public bool Deactivated { get; set; }
    public Orb Orb { get; set; }
    public Reactor Reactor { get; set; }

    private void Awake() {
        Reactor = GetComponentInParent<Reactor>();
        Deactivated = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (Orb == null && other.GetComponent<Orb>() != null && !Deactivated) {
            Orb = other.GetComponent<Orb>();
            Reactor.ShowButton();
            StartCoroutine(FloatOrb());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Orb>() != null) {
            StopCoroutine(FloatOrb());
            Orb = null;
            Reactor.HideButton();
            Reactor.Mechanism.Reset();
        }
    }

    // private

    IEnumerator FloatOrb() {
        while (true && Orb != null) {
            if (!Deactivated) {
                Vector3 center = transform.position + Vector3.up * 10f;
                Vector3 pull = (center - Orb.transform.position).normalized;
                float distance = Vector3.Distance(Orb.transform.position, center);
                Orb.gameObject.GetComponent<Rigidbody>().AddForce(pull * 70f, ForceMode.Impulse);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
