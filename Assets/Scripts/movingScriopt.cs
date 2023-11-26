using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class movingScriopt : NetworkBehaviour
{
    public GameObject crosshair;
    private bool isHeld = false;
    private float rotateAngle = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isHeld)
        {
            transform.SetParent(crosshair.transform);
            if(Input.GetKey(KeyCode.O))
            {
                Debug.Log("Moving");
                transform.Rotate(Vector3.forward, rotateAngle * Time.deltaTime);
            }
            if(Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Moving");
                transform.Rotate(Vector3.forward, -rotateAngle);

            }
        }
        else
        {
            transform.SetParent(null);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("crosshair"))
        {
            Debug.Log("Collided with crosshair");
            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("Held");
                isHeld = true;
            }
            if(Input.GetKeyDown(KeyCode.L))
            {
                Debug.Log("Left");
                isHeld = false;
            }    
        }
    }
}
