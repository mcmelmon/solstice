using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenerator : MonoBehaviour
{
    public PowerMount Mount { get; set; }

    Switch Mechanism { get; set; }

    private void Awake() {
        Mechanism = GetComponentInChildren<Switch>();
        Mount = GetComponentInChildren<PowerMount>();
    }

    void Update()
    {
        ShowButton();

        if (Mount != null && Mount.Orb != null && Mechanism != null && Mechanism.Engaged) {
            Mount.Orb.Illuminate();
            Mount.Orb.UnlockInPlace();
        }
    }

    // private

    void ShowButton() {
        if (Mount == null || Mount.Orb == null || Mechanism == null || Mechanism.Engaged) {
            Mechanism.buttons[0].gameObject.SetActive(false);
        } else if (Mount.Orb != null) {
            Mechanism.buttons[0].gameObject.SetActive(true);
            if (!Mechanism.Engaged) Mount.Orb.LockInPlace();
        }
    }
}
