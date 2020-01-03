using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reactor : MonoBehaviour
{
    public Switch Mechanism { get; set; }
    public Socket Socket { get; set; }

    private void Awake() {
        Mechanism = GetComponentInChildren<Switch>();
        Socket = GetComponent<Socket>();
    }

    void Update()
    {
        if (Socket != null && Socket.Orb != null && Mechanism != null && Mechanism.Engaged) {
            Socket.Orb.Illuminate();
            Socket.Orb.UnlockInPlace();
        }
    }

    // public

    public void HideButton() {
        Mechanism.buttons[0].gameObject.SetActive(false);
    }
    public void ShowButton() {
        Mechanism.buttons[0].gameObject.SetActive(true);
    }
}
