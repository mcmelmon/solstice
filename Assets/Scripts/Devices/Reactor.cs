using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    public Socket Socket { get; set; }

    Switch Mechanism { get; set; }

    private void Awake() {
        Mechanism = GetComponentInChildren<Switch>();
        Socket = GetComponentInChildren<Socket>();
    }

    void Update()
    {
        ShowButton();

        if (Socket != null && Socket.Orb != null && Mechanism != null && Mechanism.Engaged) {
            Socket.Orb.Illuminate();
            Socket.Orb.UnlockInPlace();
        }
    }

    // private

    void ShowButton() {
        if (Socket == null || Socket.Orb == null || Mechanism == null || Mechanism.Engaged) {
            Mechanism.buttons[0].gameObject.SetActive(false);
        } else if (Socket.Orb != null) {
            Mechanism.buttons[0].gameObject.SetActive(true);
            if (!Mechanism.Engaged) Socket.Orb.LockInPlace();
        }
    }
}
