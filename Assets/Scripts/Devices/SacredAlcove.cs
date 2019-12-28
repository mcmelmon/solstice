using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacredAlcove : MonoBehaviour
{
    public Switch mechanism;
    public GameObject sacredOrb;
    public Light spotlight;

    private void Awake() {
        if (spotlight != null) StartCoroutine(SwingSpotlight());
    }

    void Update()
    {
        if (sacredOrb != null && mechanism != null && mechanism.Engaged) {
            sacredOrb.GetComponent<Rigidbody>().useGravity = true;
            sacredOrb = null;
            StopCoroutine(SwingSpotlight());
            spotlight.enabled = false;
        }
    }

    // private

    IEnumerator SwingSpotlight()
    {
        Vector3 originalRotation = spotlight.transform.rotation.eulerAngles;
        int accumulator = 0;

        while(true) {
            accumulator += 1;
            if (accumulator > 360) accumulator = 0;
            float radians = accumulator * Mathf.PI / 180f;
            float adjustment = Mathf.Sin(radians) * 90f;

            spotlight.transform.eulerAngles = new Vector3(originalRotation.x, originalRotation.y + adjustment, originalRotation.z);
            // This produces a different-but-also-interesting rotation...
            // spotlight.transform.Rotate(0, adjustment, 0, Space.World);
            
            yield return new WaitForSeconds(.05f);
        }
    }    
}
