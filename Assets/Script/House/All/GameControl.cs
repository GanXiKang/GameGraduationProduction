using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int _day = 1;
    public static bool isGotoStroy;
    public static bool isChooseStoryBook;
    int _whichStory;
    bool isFullScreen;

    [Header("Musia")]
    public AudioClip ClimbIntoBed;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    public AudioClip pickFlower;
    public AudioClip interact;
    public AudioClip pickUp;
    public AudioClip useWorkbench;
    AudioSource BGM;

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

    public static bool isBedContent;
    public static bool isLittleGirlStoryFinish = false;
    public static bool isCheckStoryBookContent;
    public static bool isFindStoryBookContent;

    bool isFindCrystalStoryBook;

    void Start()
    {
        DayStart();
        BGM = GetComponent<AudioSource>();
        isGotoStroy = false;
        isChooseStoryBook = false;
        _whichStory = 0;
    }

    void Update()
    {
        InteractionButton();

        if (isGotoStroy)
        {
            SceneManager.LoadScene(_whichStory);
            isGotoStroy = false;
        }
        if (isChooseStoryBook)
        {
            isChooseStoryBook = false;
            CameraController.isLookBed = false;
            CameraController.isLookBookCase = true;
            Invoke("ChooseStoryAcitce", 2.2f);
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
                        BGM.PlayOneShot(ClimbIntoBed);
                        CameraController.isFollow = false;
                        CameraController.isLookBed = true;
                        BedControl.isSleep = true;
                        switch (_day)
                        {
                            case 1:
                                Story_LittleGirl();
                                break;

                            case 2:
                                UIController.isContentActive = true;
                                isBedContent = true;
                                TextControl.textCount = 12;
                                break;

                            case 3:
                                UIController.isContentActive = true;
                                isBedContent = true;
                                TextControl.textCount = 12;
                                break;
                        }
                        break;

                    case 2:                                                     //workbench
                        BGM.PlayOneShot(useWorkbench);
                        CameraController.isFollow = false;
                        CameraController.isLookWorkbench = true;
                        if (_day == 2 && isFirstOpenWorkbench)
                        {
                            UIController.isTeachOpenTask = true;
                            UIController.isContentActive = true;
                            TextControl.textCount = 6;
                            isFirstOpenWorkbench = false;
                            isOpenWorkbenchContent = true;
                            TaskController._taskNumber = 4;
                        }
                        break;

                    case 3:                                                     //case
                        BGM.PlayOneShot(interact);
                        switch (_day)
                        {
                            case 3:
                                if (!isLittleGirlStoryFinish)
                                {
                                    isLittleGirlStoryFinish = true;
                                    isCheckStoryBookContent = true;
                                    UIController.isContentActive = true;
                                    TextControl.textCount = 10;
                                }
                                if (isFindCrystalStoryBook)
                                {
                                    isFindCrystalStoryBook = false;
                                    BagController.isItemSlotAcite[29] = false;
                                    CaseControl.isStoryBookCrystal = true;
                                    TaskController._taskNumber = 11;
                                }
                                break;
                        }
                        break;

                    case 4:                                                     //storybook_crystal
                        BGM.PlayOneShot(pickUp);
                        isFindStoryBookContent = true;
                        UIController.isContentActive = true;
                        TextControl.textCount = 11;
                        Destroy(colliderObject[1]);
                        BagController.isItemSlotAcite[29] = true;
                        isFindCrystalStoryBook = true;
                        BedControl.isNight = true;
                        TaskController._taskNumber = 10;
                        break;

                    case 5:                                                     //gotoLivingroom
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl.isLivingRoom = true;
                        DoorControl.isBedroom = false;
                        player.position = doorPoint[2].position;                
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 6:                                                     //gotoBedroom
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl.isBedroom = true;
                        DoorControl.isLivingRoom = false;
                        player.position = doorPoint[1].position;                
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 7:                                                     //gotoLivingroom
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl.isOutDoor = false;
                        player.position = doorPoint[4].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 8:                                                     //gotoOutdoor
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl.isOutDoor = true;
                        player.position = doorPoint[3].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 9:                                                     //GradenA
                        BGM.PlayOneShot(pickFlower);
                        GardenControl.isGardenA = false;
                        FlowerControl.isDestory = true;
                        if (_day == 2)
                        {
                            BagController.isItemSlotAcite[33] = true;
                            TaskController._taskNumber = 5;
                        }
                        break;

                    case 10:                                                    //GradenB
                        BGM.PlayOneShot(pickFlower);
                        GardenControl.isGardenB = false;
                        FlowerControl.isDestory = true;
                        break;
                }
            }
        }
    }
    void ChooseStoryAcitce()
    {
        UIController.isChooseStoryActive = true;
    }
    void AutoFalseisNextPlace()
    {
        BGM.PlayOneShot(doorClose);
        isNextPlace = false;
    }
    void ListenStory_LitteGirl()
    {
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
    }

    //button
    public void Story_LittleGirl()
    {
        _whichStory = 2;
        StoryGameControl_LittleGirl._chapter++;
        UIController.isChooseStoryActive = false;
        Invoke("ListenStory_LitteGirl", 8f);
    }
    public void Story_Crystal()
    {
        _whichStory = 3;

        UIController.isContentActive = true;
        TextControl.textCount = 13;
        isSleepingContent = true;

        UIController.isChooseStoryActive = false;
    }
}
