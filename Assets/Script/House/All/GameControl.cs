using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    [Header("Door")]
    public Transform player;
    public Transform[] doorPoint;
    public static bool isNextPlace = false;

    public static int _day = 1;
    public static bool isOpeningContent;
    public static bool isSleepingContent;

    bool autoLoadStoryScene = false;

    void Start()
    {
        Invoke("OpeningText", 1f);
    }

    void Update()
    {
        InteractionButton();

        if (autoLoadStoryScene && !isSleepingContent)
        {
            Story_LittleGirl();
            autoLoadStoryScene = false;
        }
    }

    void OpeningText()
    {
        if (_day == 1)
        {
            isOpeningContent = true;
            UIController.isContentActive = true;
        }
        else
        {
            isOpeningContent = false;
        }
    }
    void InteractionButton()
    {
        if (UIController.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIController.isInteractionButtonActive = false;
                switch (PlayerColliderControl._nowNumber)
                {
                    case 1:                                                     //bed
                        CameraController.isFollow = false;
                        CameraController.isLookBed = true;
                        BedControl.isSleep = true;
                        if (_day == 1)
                        {
                            UIController.isContentActive = true;
                            isSleepingContent = true;
                            autoLoadStoryScene = true;
                        }
                        else
                        {
                            UIController.isChooseStoryActive = true;
                        }
                        break;

                    case 2:                                                     //workbench
                        CameraController.isFollow = false;
                        CameraController.isLookWorkbench = true;
                        break;

                    case 3:                                                     //cabinet
                        UIController.isContentActive = true;
                        UIController.isAutoCloseContent = true;
                        UIController._conveyContentTextNumber = 1;
                        break;

                    case 4:                                                     //flower
                        FlowerControl.isDestory = true;
                        BagController.isItemSlotAcite[3] = true;
                        BagController.quantity = 1;
                        break;

                    case 5:                                                     //gotoLivingroom
                        isNextPlace = true;
                        player.position = doorPoint[2].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 6:                                                     //gotoBedroom
                        player.position = doorPoint[1].position;
                        break;

                    case 7:                                                     //gotoLivingroom
                        player.position = doorPoint[4].position;
                        break;

                    case 8:                                                     //gotoOutdoor
                        player.position = doorPoint[3].position;
                        break;
                }
            }
        }
    }
    void AutoFalseisNextPlace()
    {
        isNextPlace = false;
    }

    //button
    public void Story_LittleGirl()
    {
        SceneManager.LoadScene(2);
        CameraController.isFollow = true;
        CameraController.isLookBed = false;
        UIController.isChooseStoryActive = false;
        BedControl.isSleep = false;
    }
}
