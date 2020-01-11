using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ShrineSmall : MonoBehaviour
{
    [SerializeField] List<ShrineSmall> prerequisites = new List<ShrineSmall>();
    public Socket Socket { get; set; }

    public Transmorgifier Transmorgifier { get; set; }
    bool PrerequisitesMet { get; set; }
    void Awake()
    {
        Socket = GetComponentInChildren<Socket>();
        if (prerequisites.Count > 0) {
            Socket.gameObject.SetActive(false);
            PrerequisitesMet = false;
            StartCoroutine(CheckPrerequisites());
        } else {
            Socket.gameObject.SetActive(true);
            PrerequisitesMet = true;
        }
        Transmorgifier = GetComponentInChildren<Transmorgifier>();
    }

    // public

    public void Transforgify() {
        if (Transmorgifier != null) Transmorgifier.Transmorgify();
    }

    // private

    IEnumerator CheckPrerequisites() {
        while (!PrerequisitesMet) {
            foreach (var preq in prerequisites) {
                if (preq.Socket != null) { // a shrine's socket might not get set before another shrine's awake runs
                    PrerequisitesMet = preq.Socket.Charged;
                    if (!PrerequisitesMet) continue;
                }
            }
            yield return new WaitForSeconds(1);
        }
        Socket.gameObject.SetActive(true);
    }
}
