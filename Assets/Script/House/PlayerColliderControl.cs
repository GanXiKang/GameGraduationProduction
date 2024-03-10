using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderControl : MonoBehaviour
{
    public int _serialNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.isActive = false;
        }
    }
}
