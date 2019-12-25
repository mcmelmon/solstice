using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 3f;

    // properties

    public static Player Instance { get; set; }

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("More than one player");
            Destroy(this);
            return;
        }
        Instance = this;
    }


    private void Start() {
    }

    private void Update() {

    }

    private void FixedUpdate() {

    }


    public void Move() {
        
    }
}
