using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] bool engaged = false;
    [SerializeField] bool triggered = false;
    [SerializeField] bool perpetual = false;
    [SerializeField] bool resettable = false;
    [SerializeField] int sequencePosition;
    [SerializeField] GameObject[] interactsWithObjects;

    public bool Engaged { get; set; }
    public GameObject LastTouchedBy { get; set; }
    public bool Triggered { get; set; }
    List<GameObject> InteractsWith { get; set; }
    Vector3 OriginalScale{ get; set; }

    private void Awake() {
        Engaged = engaged;
        InteractsWith = new List<GameObject>(interactsWithObjects);
        OriginalScale = transform.localScale;
        Triggered = triggered;
    }

    private void Update() {
        if (Engaged) {
             transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y / 5, transform.localScale.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (InteractsWith.Contains(other.gameObject)) {
            if (perpetual) {
                Triggered = true;
            } else if (!Triggered) {
                Engaged = resettable ? !Engaged : true;
                triggered = true;   // to track if the button has ever been pressed, separate from current engagement
            } else if (Triggered && resettable) {
                Engaged = false;
                Triggered = false;
            }
            LastTouchedBy = other.gameObject;
        }
    }

    public void Reset() {
        transform.localScale = OriginalScale;
    }
}
