using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int _day = 1;
    public static bool isGotoStroy;
    int _whichStory;
    bool autoLoadStoryScene = false;
    bool isFullScreen;


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
    public static bool isCheckStoryBookContent = false;
    public static bool isFindStoryBookContent;

    void Start()
    {
        DayStart();
        isGotoStroy = false;
        _whichStory = 0;
    }

    void Update()
    {
        InteractionButton();

        if (autoLoadStoryScene && !isSleepingContent)           //只有第一天會自動進去故事裏
        {
            Story_LittleGirl();
            autoLoadStoryScene = false;
        }

        if (isGotoStroy)
        {
            SceneManager.LoadScene(_whichStory);
            isGotoStroy = false;
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
                                autoLoadStoryScene = true;
                                break;

                            case 2:
                                Invoke("ChooseStoryBook", 1.5f);        
                                break;

                            case 3:
                                Invoke("ChooseStoryBook", 1.5f);
                                break;
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
                            TaskController._taskNumber = 4;
                        }
                        break;

                    case 3:                                                     //cabinet
                        if (_day == 3 && !isCheckStoryBookContent)
                        {
                            isCheckStoryBookContent = true;
                            UIController.isContentActive = true;
                            TextControl.textCount = 10;
                        }
                        break;

                    case 4:                                                     //storybook_crystal
                        isFindStoryBookContent = true;
                        UIController.isContentActive = true;
                        TextControl.textCount = 11;
                        Destroy(colliderObject[1]);
                        BagController.isItemSlotAcite[18] = true;
                        BedControl.isNight = true;
                        TaskController._taskNumber = 11;
                        break;

                    case 5:                                                     //gotoLivingroom
                        isNextPlace = true;
                        DoorControl.isLivingRoom = true;
                        DoorControl.isBedroom = false;
                        player.position = doorPoint[2].position;                
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 6:                                                     //gotoBedroom
                        isNextPlace = true;
                        DoorControl.isBedroom = true;
                        DoorControl.isLivingRoom = false;
                        player.position = doorPoint[1].position;                
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 7:                                                     //gotoLivingroom
                        isNextPlace = true;
                        DoorControl.isOutDoor = false;
                        player.position = doorPoint[4].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 8:                                                     //gotoOutdoor
                        isNextPlace = true;
                        DoorControl.isOutDoor = true;
                        player.position = doorPoint[3].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 9:                                                     //GradenA
                        GardenControl.isGardenA = false;
                        FlowerControl.isDestory = true;
                        if (_day == 2)
                        {
                            BagController.isItemSlotAcite[22] = true;
                            TaskController._taskNumber = 5;
                        }
                        break;

                    case 10:                                                    //GradenB
                        GardenControl.isGardenB = false;
                        FlowerControl.isDestory = true;
                        break;
                }
            }
        }
    }
    void ChooseStoryBook()
    {
        UIController.isChooseStoryActive = true;
        CameraController.isLookBookCase = true;
        CameraController.isLookBed = false;
    }
    void AutoFalseisNextPlace()
    {
        isNextPlace = false;
    }

    //button
    public void Story_LittleGirl()
    {
        _whichStory = 2;
        switch (StoryGameControl_LittleGirl._chapter)
        {
            case 1:
                UIController.isContentActive = true;
                TextControl.textCount = 2;
                isSleepingContent = true;
                break;

            case 2:
                UIController.isContentActive = true;
                TextControl.textCount = 8;
                isSleepingContent = true;
                break;
        }
        CameraController.isLookBed = true;
        CameraController.isLookBookCase = false;
        UIController.isChooseStoryActive = false;   
    }
    public void Story_Crystal()
    {
        _whichStory = 3;

        UIController.isContentActive = true;
        TextControl.textCount = 13;
        isSleepingContent = true;

        CameraController.isLookBed = true;
        CameraController.isLookBookCase = false;
        UIController.isChooseStoryActive = false;
    }
}
