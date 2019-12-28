using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredOrb : MonoBehaviour
{
    public int secondsBeforeRise;
    public GameObject celestialCycle;

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
}
