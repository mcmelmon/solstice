using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propel : MonoBehaviour
{
    [SerializeField] float propelForce = .2f;

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<Orb>() != null) {
            Vector3 direction = (other.transform.position - transform.position);
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * propelForce, ForceMode.Impulse);
        }   
    }
}
