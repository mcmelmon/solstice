using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purgatory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Orb>() != null) {
            other.gameObject.GetComponent<Orb>().Respawn();
        } else if (other.gameObject.GetComponent<Player>() != null) {
            other.gameObject.GetComponent<Player>().Respawn();
        }
    }
}
