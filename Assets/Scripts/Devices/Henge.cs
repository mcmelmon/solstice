using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Henge : MonoBehaviour
{
    public PlayableDirector cutSceneDirector;
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
            cutSceneDirector.Play();
            orb.AscendToHeaven();
        }
        mechanism.Reset();
    }
}
