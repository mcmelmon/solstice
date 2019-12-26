using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 3f;
    public float turnSpeed = 75f;

    public CinemachineFreeLook viewport;

    Vector2 movement;

    // properties

    public static Player Instance { get; set; }

    // Unity

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
        float rotation = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        if (!Mathf.Approximately(translation, 0) || !Mathf.Approximately(rotation, 0)) {
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }
    }


    // public


    public void Move() {
        // We're just using FixedUpdate for movement...
    }


    public void Look() {
        if (Input.GetMouseButtonDown(0)) {
            viewport.Priority = 20;
        }
        
        if (Input.GetMouseButtonUp(0)) {
            viewport.Priority = 1;
        }
    }
}
