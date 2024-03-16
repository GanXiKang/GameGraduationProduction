using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColliderControl : MonoBehaviour
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
                        
                        break;

                    
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("yes");
        }
    }
}
