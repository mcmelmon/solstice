using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class Transmorgifier : MonoBehaviour
{   
    [SerializeField] List<Transmorgification> transmorgifications;
    [SerializeField] float delay = 1f;

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
        Debug.Log("Transmorg");
        if (Phases != null && Phases.Count > 0) StartCoroutine(AnimateTransmorgifySequence());
    }

    // private

    IEnumerator AnimateTransmorgifySequence() {
        int currentPhase = 0;
        while (currentPhase < Phases.Count) {
            foreach (GameObject element in transmorgifications.Where(t => t.phase == currentPhase).Select(t => t.element).ToList()) {
                Debug.Log("Element: " + element);
                Debug.Log("Phase: " + currentPhase);
                PlayableDirector director = element.GetComponent<PlayableDirector>();
                if (director != null) director.Play();
            }
            currentPhase++;
            yield return new WaitForSeconds(delay);
        }
    }
}
