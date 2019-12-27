using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredAlcove : MonoBehaviour
{
    public Switch mechanism;
    public GameObject sacredOrb;

    void Update()
    {
        if (sacredOrb != null && mechanism != null && mechanism.Triggered) {
            Debug.Log("triggered");
            sacredOrb.GetComponent<Rigidbody>().useGravity = true;
            sacredOrb = null;
        }
    }
}
