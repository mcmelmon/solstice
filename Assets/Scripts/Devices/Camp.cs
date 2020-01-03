using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camp : MonoBehaviour
{
    [SerializeField] Transform respawn;

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.GetComponent<Orb>() != null) {
            other.gameObject.GetComponent<Orb>().RespawnPoint = respawn.position;
        }
    }
}
