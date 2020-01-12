using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

public class Orb : MonoBehaviour
{
    [SerializeField] GameObject celestialCycle;
    [SerializeField] int secondsBeforeRise;
    [SerializeField] bool startLocked = true;

    public Light Lamp { get; set; }
    public bool Locked { get; set; }
    public Vector3 RespawnPoint { get; set; }


    private void Awake() {
        Lamp = GetComponentInChildren<Light>();
        RespawnPoint = transform.position;
        if (startLocked) LockInPlace();
    }

    private void Update() {
        if (!Locked) {
            Vector3 push = (Player.Instance.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(push * 0.5f, ForceMode.Impulse);
        }
    }

    // public
    public void AscendToHeaven() 
    {
        StartCoroutine(Ascend());
    }

    
    public void Dim() {
        Lamp.enabled = false;
    }

    public void Illuminate() {
        Lamp.enabled = true;
    }

    public void LockInPlace() {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<PlayableDirector>().Stop();
        Locked = true;
        Dim();
    }

    public void Respawn() {
        transform.position = RespawnPoint;
    }

    public void UnlockInPlace() {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Locked = false;
        Illuminate();
        GetComponent<PlayableDirector>().Play();
    }

    // private

    IEnumerator Ascend()
    {
        while (true) {
            yield return new WaitForSeconds(secondsBeforeRise);
            celestialCycle.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
