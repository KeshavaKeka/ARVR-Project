using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class Light : NetworkBehaviour
{
    public GameObject spotLight;
    private bool switchOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
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
                switchOn = !switchOn;
                spotLight.SetActive(switchOn);
            }
        }
    }
}