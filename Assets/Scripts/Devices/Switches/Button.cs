using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool engaged = false;
    public bool triggered = false;
    public bool perpetual = false;
    public bool resettable = false;
    public int sequencePosition;
    public GameObject[] interactsWithObjects;

    public GameObject LastTouchedBy { get; set; }
    List<GameObject> InteractsWith { get; set; }

    private void Awake() {
     InteractsWith = new List<GameObject>(interactsWithObjects);
    }

    private void Update() {
        if (engaged) {
             transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 5, transform.localScale.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (InteractsWith.Contains(other.gameObject)) {
            if (perpetual) {
                triggered = true;
            } else if (!triggered) {
                engaged = resettable ? !engaged : true;
                triggered = true;   // to track if the button has ever been pressed, separate from current engagement
            } else if (triggered && resettable) {
                engaged = false;
                triggered = false;
            }
            LastTouchedBy = other.gameObject;
        }
    }
}
