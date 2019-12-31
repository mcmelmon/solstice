using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredAlcove : MonoBehaviour
{
    public Switch Mechanism { get; set; }
    public SacredOrb Orb { get; set; }

    private void Awake() {
        Orb = GetComponentInChildren<SacredOrb>();
        Mechanism = GetComponentInChildren<Switch>();
    }

    private void Start() {
        Orb.Dim();
    }

    void Update()
    {
        if (Orb != null && Mechanism != null && Mechanism.Engaged) {
            Orb.GetComponent<Rigidbody>().useGravity = true;
            Orb = null;
        }
    }

    // private

    // IEnumerator SwingSpotlight()
    // {
    //     TODO: Use Timeline animation for this
    
    //     Vector3 originalRotation = spotlight.transform.rotation.eulerAngles;
    //     int accumulator = 0;

    //     while(true) {
    //         accumulator += 1;
    //         if (accumulator > 360) accumulator = 0;
    //         float radians = accumulator * Mathf.PI / 180f;
    //         float adjustment = Mathf.Sin(radians) * 90f;

    //         spotlight.transform.eulerAngles = new Vector3(originalRotation.x, originalRotation.y + adjustment, originalRotation.z);
    //         // This produces a different-but-also-interesting rotation...
    //         // spotlight.transform.Rotate(0, adjustment, 0, Space.World);
            
    //         yield return new WaitForSeconds(.05f);
    //     }
    // }    
}
