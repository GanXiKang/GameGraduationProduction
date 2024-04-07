using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObjectColliderControl : MonoBehaviour
{
    public int _serialNumber;
    public static int _nowNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_serialNumber != 5)
            {
                StoryLittleGirlUIControl.isInteractionButtonActive = true;
                StoryLittleGirlUIControl._conveyColliderNumber = _serialNumber;
            }
            else
            {
                if (BagController._itemQuantity[1] >= 8)
                {
                    StoryLittleGirlUIControl.isInteractionButtonActive = true;
                    StoryLittleGirlUIControl._conveyColliderNumber = _serialNumber;
                }
            }
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _nowNumber = _serialNumber;
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
