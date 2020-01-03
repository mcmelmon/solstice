using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Henge : MonoBehaviour
{
    public PlayableDirector cutSceneDirector;

    Switch Mechanism { get; set; }
    bool ascending = false;
    private void Awake() {
        Mechanism = GetComponentInChildren<Switch>();
    }

    void Update()
    {
        if (!ascending && Mechanism != null && Mechanism.Engaged && Mechanism.LastTouchedBy != null) {
            ascending = true;
            Ascend();
        }
    }


    // private

    private void Ascend() {
        Orb orb = Mechanism.LastTouchedBy.GetComponent<Orb>();
        if (orb != null) {
            cutSceneDirector.Play();
            orb.AscendToHeaven();
        }
        Mechanism.Reset();
    }
}
