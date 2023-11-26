using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class CamMovement : NetworkBehaviour
{
    public float horizontalInput;
    private Animator playerAnim;
    public float verticalInput;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public Transform playerCamera;
    private float rotationX = 0;
    [SerializeField]
    private Camera cam;

    //public GameObject tube;
    private Vector3 lastValidPosition;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if(base.IsOwner)
        {
            cam = Camera.main;
            if(cam==null)
            {
                Debug.Log("Main cam not assigned");
            }
            cam.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            cam.transform.SetParent(transform);
        }
        else
        {
            gameObject.GetComponent<CamMovement>().enabled = false;
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lastValidPosition = transform.position;
        playerCamera = cam.transform;
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * 10 * Time.deltaTime);
        }
        transform.Translate(Vector3.right * horizontalInput * 10 * Time.deltaTime);
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}