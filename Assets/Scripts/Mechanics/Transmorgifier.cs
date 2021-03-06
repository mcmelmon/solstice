﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class Transmorgifier : MonoBehaviour
{   
    [SerializeField] List<Transmorgification> transmorgifications;
    [SerializeField] float delay = 1f;
    [SerializeField] PlayableDirector cutSceneDirector;


    [System.Serializable]
    struct Transmorgification {
        public int phase;
        public GameObject element;
    }
    List<int> Phases { get; set; }
    List<GameObject> Sequence { get; set; }

    private void Awake() {
        Phases = transmorgifications
            .OrderBy(t => t.phase)
            .Select(t => t.phase)
            .Distinct()
            .ToList();
    }

    // public

    public void Transmorgify() {
        if (Phases != null && Phases.Count > 0) StartCoroutine(AnimateTransmorgifySequence());
        cutSceneDirector.Play();
    }

    // private

    IEnumerator AnimateTransmorgifySequence() {
        int currentPhase = 0;
        while (currentPhase < Phases.Count) {
            foreach (GameObject element in transmorgifications.Where(t => t.phase == currentPhase).Select(t => t.element).ToList()) {
                PlayableDirector director = element.GetComponent<PlayableDirector>();
                if (director != null) director.Play();
            }
            currentPhase++;
            yield return new WaitForSeconds(delay);
        }
    }
}
