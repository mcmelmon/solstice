using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] forms;
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
        if (IsGrounded()) {
            foreach (MeshRenderer renderer in forms[0].GetComponentsInChildren<MeshRenderer>()) {
                renderer.enabled = true;
            }
            forms[1].GetComponent<MeshRenderer>().enabled = false;

            forms[0].GetComponent<Rigidbody>().drag = 0.1f;
            forms[1].GetComponent<MeshCollider>().enabled = false;
        } else {
            foreach (MeshRenderer renderer in forms[0].GetComponentsInChildren<MeshRenderer>()) {
                renderer.enabled = false;
            }
            forms[1].GetComponent<MeshRenderer>().enabled = true;

            forms[0].GetComponent<Rigidbody>().drag = 2f;
            forms[1].GetComponent<MeshCollider>().enabled = true;
        }
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

    public void Jump() {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, speed * 10, 0), ForceMode.Impulse);
    }

    public void Look() {
        if (Input.GetMouseButtonDown(0)) {
            viewport.Priority = 20;
        }
        
        if (Input.GetMouseButtonUp(0)) {
            viewport.Priority = 1;
        }
    }

    public void Move() {
        // We're just using FixedUpdate for movement...
    }

    // private


    bool IsGrounded() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)) {
            if (hit.distance > 5) return false;
        }
        return true;
    }
}
