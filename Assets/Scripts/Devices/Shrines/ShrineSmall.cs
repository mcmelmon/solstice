using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ShrineSmall : MonoBehaviour
{
    public Socket Socket { get; set; }

    bool Transmorgified { get; set; }

    Transmorgifier Transmorgifier { get; set; }
    void Awake()
    {
        Socket = GetComponentInChildren<Socket>();
        Transmorgified = false;
        Transmorgifier = GetComponentInChildren<Transmorgifier>();
    }

    void Update()
    {
        if (Socket != null && !Transmorgified && Socket.Charged ) {
            Transmorgifier.Transmorgify();
            Transmorgified = true;
        }
    }
}
