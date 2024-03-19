using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameControl_LittleGirl : MonoBehaviour
{
    public GameObject[] colliderObject;
    public static int _task = 0;

    void Update()
    {
        if (StoryLittleGirlUIControl.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StoryLittleGirlUIControl.isInteractionButtonActive = false;
                switch (StoryObjectColliderControl._nowNumber)
                {
                    case 1:                                                               //clothing
                        _task++;
                        BagController.isItemSlotAcite[StoryObjectColliderControl._nowNumber] = true;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;

                    case 2:                                                                    //hat
                        _task++;
                        BagController.isItemSlotAcite[StoryObjectColliderControl._nowNumber] = true;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;
                }
            }
        }

        if (_task >= 2)
        {
            Invoke("GoHouseScene", 1f);
        }
    }

    void GoHouseScene()
    {
        SceneManager.LoadScene(1);
        DayControl._day++;
        print(DayControl._day++);
    }
}
