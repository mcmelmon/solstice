using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switch : MonoBehaviour
{
    public Button[] buttons;
    public bool sequential = false;
    public bool resettable = false;
    public int resetInSeconds = 0;
    
    public GameObject LastTouchedBy { get; set; }
    public bool Engaged { get; set; }
    
    private void Awake() {
        StartCoroutine(ResetAfterDelay());
    }

    void Update()
    {
        // TODO: handle sequences

        foreach (var button in buttons) {
            Engaged = button.Engaged;
            if (!Engaged) break;
        }
        
        if (Engaged) {
            var pressedButtons = buttons.Where(button => button.LastTouchedBy != null);
            LastTouchedBy = pressedButtons.Any() ? pressedButtons.First().LastTouchedBy : null;
        }
    }

    // public

    public void Reset() {
        foreach (var button in buttons) {
            button.Engaged = button.Triggered = false;
            button.LastTouchedBy = null;
            button.Reset();
        }
        LastTouchedBy = null;
    }

    // private

    IEnumerator ResetAfterDelay() {
        while (resettable && resetInSeconds > 0) {
            yield return new WaitForSeconds(resetInSeconds);
            Reset();
        }
    }
}
