using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRedButton : MonoBehaviour
{
    public bool engaged = false;
    public bool triggered = false;
    public bool resettable = false;
    public int sequencePosition;

    SphereCollider trigger;

    private void Awake() {
        trigger = GetComponent<SphereCollider>();
    }

    private void Update() {
        if (engaged) {
             transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 5, transform.localScale.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Player>() != null) {
            if ((!triggered && !resettable) || (triggered && resettable)) {
                engaged = !engaged;
                triggered = true;
            }
        }
    }
}
