using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryObjectColliderControl : MonoBehaviour
{
    public int _serialNumber;
    public static int _nowNumber;

    void Update()
    {
        if (StoryLittleGirlUIControl.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StoryLittleGirlUIControl.isInteractionButtonActive = false;
                switch (_nowNumber)
                {
                    case 1:                                                     //clothing
                        Destroy(this.gameObject);
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
    
    private void OnTriggerStay(Collider other)
    {
        _nowNumber = _serialNumber;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StoryLittleGirlUIControl.isInteractionButtonActive = false;
        }
    }
}
