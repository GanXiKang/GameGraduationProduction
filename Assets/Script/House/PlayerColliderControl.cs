using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderControl : MonoBehaviour
{
    public int _serialNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.isInteractionButtonActive = true;
            UIController._conveyColliderNumber = _serialNumber;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIController.isInteractionButtonActive = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.isInteractionButtonActive = false;
        }
    }
}
