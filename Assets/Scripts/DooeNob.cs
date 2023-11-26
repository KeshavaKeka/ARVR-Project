using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class DooeNob : NetworkBehaviour
{
    public GameObject hinge;
    private bool isOpen = false;
    private float rotationSpeed = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        hinge = GameObject.Find("DoorHinge");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("crosshair"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isOpen)
                {
                    hinge.transform.Rotate(Vector3.up, rotationSpeed);
                    isOpen = !isOpen;
                }
                else
                {
                    hinge.transform.Rotate(Vector3.up, -rotationSpeed);
                    isOpen = !isOpen;
                }
            }
        }
    }
}
