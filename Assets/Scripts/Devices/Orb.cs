using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public int secondsBeforeRise;
    public GameObject celestialCycle;

    public Light Lamp { get; set; }
    public Vector3 RespawnPoint { get; set; }

    private void Awake() {
        Lamp = GetComponentInChildren<Light>();
        RespawnPoint = transform.position;
    }
    public void AscendToHeaven() 
    {
        StartCoroutine(Ascend());
    }
    public IEnumerator Ascend()
    {
        while (true) {
            yield return new WaitForSeconds(secondsBeforeRise);
            celestialCycle.SetActive(true);
            Destroy(this.gameObject);
        }
    }
    
    public void Dim() {
        Lamp.enabled = false;
    }

    public void Illuminate() {
        Lamp.enabled = true;
    }

    public void LockInPlace() {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Respawn() {
        transform.position = RespawnPoint;
    }

    public void UnlockInPlace() {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
