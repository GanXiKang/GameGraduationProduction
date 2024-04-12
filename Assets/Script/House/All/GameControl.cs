using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int _day = 1;
    bool autoLoadStoryScene = false;

    [Header("Object")]
    public GameObject[] colliderObject;

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
    public static bool isFinishSweaterContent;


    bool isFullScreen;

    void Start()
    {
        DayStart();
    }

    void Update()
    {
        InteractionButton();

        if (autoLoadStoryScene && !isSleepingContent)
        {
            Story_LittleGirl();
            autoLoadStoryScene = false;
        }

        if (Input.GetKeyDown(KeyCode.F11))                  //暫時放這 未來做setting系統在移
        {
            isFullScreen = !isFullScreen;
            Screen.fullScreen = isFullScreen;
        }
    }

    void DayStart()
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
                colliderObject[1].SetActive(true);
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
                        switch (_day)
                        {
                            case 1:
                                UIController.isContentActive = true;
                                TextControl.textCount = 2;
                                isSleepingContent = true;
                                autoLoadStoryScene = true;
                                break;

                            case 2:
                                UIController.isContentActive = true;
                                TextControl.textCount = 8;
                                isSleepingContent = true;
                                autoLoadStoryScene = true;
                                break;
                        }
                        if(!autoLoadStoryScene)
                        { 
                            UIController.isChooseStoryActive = true;
                        }
                        break;

                    case 2:                                                     //workbench
                        CameraController.isFollow = false;
                        CameraController.isLookWorkbench = true;
                        if (_day == 2 && isFirstOpenWorkbench)
                        {
                            UIController.isContentActive = true;
                            TextControl.textCount = 6;
                            isFirstOpenWorkbench = false;
                            isOpenWorkbenchContent = true;
                        }
                        break;

                    case 3:                                                     //cabinet
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

                    case 9:                                                     //storybook_crystal
                        Destroy(colliderObject[1]);
                        BagController.isItemSlotAcite[21] = true;
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
