using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] forms;
    public float speed = 3f;
    public float turnSpeed = 75f;

    Vector2 movement;
    List<CinemachineVirtualCamera> cutCameras = new List<CinemachineVirtualCamera>();

    // properties

    public static Player Instance { get; set; }

    CinemachineFreeLook FreeLook { get; set; }
    Vector3 RespawnPoint { get; set; }

    // Unity

    private void Awake()
    {
        if (Instance != null) {
            Debug.LogError("More than one player");
            Destroy(this);
            return;
        }
        Instance = this;
        FreeLook = GameObject.Find("CM FreeLook1 - Player").GetComponent<CinemachineFreeLook>();
        RespawnPoint = transform.position;
    }


    private void Start() {
        cutCameras.AddRange(FindObjectsOfType<CinemachineVirtualCamera>());
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
        float strafe = Input.GetAxis("Strafe") * speed * Time.deltaTime;
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (!Mathf.Approximately(translation, 0) || !Mathf.Approximately(strafe, 0) || !Mathf.Approximately(rotation, 0)) {
            transform.Translate(strafe, 0, translation);
            transform.Rotate(0, rotation, 0);
        }

        if (!Mathf.Approximately(Input.GetAxis("Jump"), 0)) {
            Jump();
        }
    }


    // public

    public void Jump() {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, speed * 2, 0), ForceMode.Impulse);
    }

    public void Look() {
        if (Input.GetMouseButtonDown(0)) {
            FreeLook.Priority = 20;
        }
        
        if (Input.GetMouseButtonUp(0)) {
            FreeLook.Priority = 1;
        }
    }

    public void Move() {
        // Here for the fancy new input controller, but currently handling movement in FixedUpdate
    }

    public void Respawn() {
        transform.position = RespawnPoint;
    }

    // private

    bool IsGrounded() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)) {
            if (hit.distance > 5) return false;
        } else {
            return false;
        }
        return true;
    }


    void ResetCameras() {
        foreach (var camera in cutCameras) {
            camera.m_Priority = 1;
        }
    }
}
