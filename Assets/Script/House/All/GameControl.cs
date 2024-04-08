using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int _day = 1;
    bool autoLoadStoryScene = false;

    [Header("Door")]
    public Transform player;
    public Transform[] doorPoint;
    public static bool isNextPlace = false;

    //Content
    public static bool isOpeningStopMove;
    public static bool isOpeningContent;
    public static bool isSleepingContent;
    public static bool isFirstOpenBag = true;
    public static bool isOpenBagContent;
    public static bool isFirstOpenWorkbench = true;
    public static bool isOpenWorkbenchContent;

    void Start()
    {
        DayStartContent();
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

    void DayStartContent()
    {
        isOpeningStopMove = true;
        switch (_day)
        {
            case 1:
                Invoke("OpeningText", 1f);
                break;

            case 2:
                Invoke("OpeningText", 1f);
                TextControl.textCount = 3;
                break;

            case 3:
                Invoke("OpeningText", 1f);
                TextControl.textCount = 9;
                break;
        }
    }
    void OpeningText()
    {
        isOpeningStopMove = false;
        isOpeningContent = true;
        UIController.isContentActive = true;
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
                            TextControl.textCount = 2;
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
                        if (_day == 2 && isFirstOpenWorkbench)
                        {
                            isFirstOpenWorkbench = false;
                            GameControl.isOpenWorkbenchContent = true;
                            TextControl.textCount = 6;
                            UIController.isContentActive = true;
                        }
                        break;

                    case 3:                                                     //cabinet
                        UIController.isContentActive = true;
                        UIController.isAutoCloseContent = true;
                        UIController._conveyContentTextNumber = 1;
                        break;

                    case 4:                                                     //flower
                        FlowerControl.isDestory = true;
                        BagController.isItemSlotAcite[25] = true;
                        break;

                    case 5:                                                     //gotoLivingroom
                        isNextPlace = true;
                        player.position = doorPoint[2].position;                //前往對面的位置
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 6:                                                     //gotoBedroom
                        isNextPlace = true;
                        player.position = doorPoint[1].position;                
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 7:                                                     //gotoLivingroom
                        isNextPlace = true;
                        player.position = doorPoint[4].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 8:                                                     //gotoOutdoor
                        isNextPlace = true;
                        player.position = doorPoint[3].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
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
        BedControl.isNight = false;
    }
}
