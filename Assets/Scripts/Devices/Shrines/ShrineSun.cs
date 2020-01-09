using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrineSun : MonoBehaviour
{
    public Switch Mechanism { get; set; }
    public Orb Orb { get; set; }

    private void Awake() {
        Orb = GetComponentInChildren<Orb>();
        Mechanism = GetComponentInChildren<Switch>();
    }

    private void Start() {
        Orb.Dim();
    }

    void Update()
    {
        if (Orb != null && Mechanism != null && Mechanism.Engaged) {
            Orb.UnlockInPlace();
            Orb = null;
        }
    }    
}
