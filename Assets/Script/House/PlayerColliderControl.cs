using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderControl : MonoBehaviour
{
    public int _serialNumber;
    public static int _nowNumber;

    void Update()
    {
        if (UIController.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIController.isInteractionButtonActive = false;
                switch (_nowNumber)
                {
                    case 1:
                        print("one");
                        break;

                    case 2:
                        CameraController.isFollow = false;
                        CameraController.isLookWorkbench = true;
                        break;

                    case 3:
                        CameraController.isFollow = false;
                        CameraController.isLookBed = true;
                        break;
                }
            }
        }
    }

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
        _nowNumber = _serialNumber;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIController.isInteractionButtonActive = false;
        }
    }
}
