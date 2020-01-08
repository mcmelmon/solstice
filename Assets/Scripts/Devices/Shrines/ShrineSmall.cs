using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ShrineSmall : MonoBehaviour
{
    public Socket Socket { get; set; }

    bool Transmorgified { get; set; }
    void Awake()
    {
        Socket = GetComponentInChildren<Socket>();
        Transmorgified = false;
    }

    private void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (Socket != null && !Transmorgified && Socket.Charged) {
            GetComponentInChildren<PlayableDirector>().Play();
            Transmorgified = true;
        }
    }
}
