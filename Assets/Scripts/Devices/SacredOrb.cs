using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredOrb : MonoBehaviour
{
    public int secondsBeforeRise;
    public GameObject celestialCycle;

    public Light Lamp { get; set; }

    private void Awake() {
        Lamp = GetComponentInChildren<Light>();
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

    public void UnlockInPlace() {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
