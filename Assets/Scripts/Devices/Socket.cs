using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socket : MonoBehaviour
{
    [SerializeField] Transform point;
    public bool Charged { get; set; }
    public Orb Orb { get; set; }

    ShrineSmall Shrine { get; set; }

    private void Awake() {
        Charged = false;
        Shrine = GetComponentInParent<ShrineSmall>();
    }

    private void OnTriggerEnter(Collider other) {
        if (Orb == null && other.GetComponent<Orb>() != null && !Charged) {
            Orb = other.GetComponent<Orb>();
            StartCoroutine(Charge());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Orb>() != null) {
            StopCoroutine(Charge());
            Orb = null;
        }
    }

    // private

    IEnumerator Charge() {
        int charge = 0;
        System.DateTime startTime = System.DateTime.Now;

        while (!Charged && Orb != null && ((System.DateTime.Now - startTime).TotalSeconds < 10f)) {
            Orb.LockInPlace();
            float step =  3f * Time.deltaTime; // calculate distance to move
            Orb.transform.position = Vector3.MoveTowards(Orb.transform.position, point.position, step);

            if (Vector3.Distance(Orb.transform.position, point.position) < 0.001f) {
                charge++;
            }

            yield return null;
        }
        Charged = true;
        Orb.UnlockInPlace();
        Shrine.Transforgify();
    }
}
