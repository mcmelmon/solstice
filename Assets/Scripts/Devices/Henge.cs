using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Henge : MonoBehaviour
{
    public Switch mechanism;

    bool ascending = false;
    private void Awake() {
    }

    void Update()
    {
        if (!ascending && mechanism != null && mechanism.Engaged && mechanism.LastTouchedBy != null) {
            ascending = true;
            Ascend();
        }
    }


    // private

    private void Ascend() {
        SacredOrb orb = mechanism.LastTouchedBy.GetComponent<SacredOrb>();
        if (orb != null) {
            orb.AscendToHeaven();
        }
        mechanism.Reset();
    }
}
