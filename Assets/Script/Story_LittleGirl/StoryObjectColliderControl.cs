using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObjectColliderControl : MonoBehaviour
{
    public GameObject target;
    public int _serialNumber;

    void Update()
    {
        if (StoryLittleGirlUIControl.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StoryLittleGirlUIControl.isInteractionButtonActive = false;
                switch (_serialNumber)
                {
                    case 1:                                                     //clothing
                        Destroy(target);
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StoryLittleGirlUIControl.isInteractionButtonActive = true;
            StoryLittleGirlUIControl._conveyColliderNumber = _serialNumber;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StoryLittleGirlUIControl.isInteractionButtonActive = false;
        }
    }
}
