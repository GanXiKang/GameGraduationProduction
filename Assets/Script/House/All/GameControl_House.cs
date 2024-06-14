using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl_House : MonoBehaviour
{
    public static int _day = 1;
    public static bool isGotoStroy;
    public static bool isChooseStoryBook;
    int _whichStoryScene;
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
    public Transform[] doorPoint;
    public static bool isNextPlace = false;
    GameObject player;

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
        _whichStoryScene = 0;

        player = GameObject.Find("Player");
    }

    void Update()
    {
        InteractionButton();

        if (isGotoStroy)
        {
            SceneManager.LoadScene(_whichStoryScene);
            CaseStoryBook();
            isGotoStroy = false;
        }
        if (isChooseStoryBook)
        {
            isChooseStoryBook = false;
            CameraControl_House.isLookBed = false;
            CameraControl_House.isLookBookCase = true;
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
                TextControl_House.textCount = 3;
                break;

            case 3:
                Invoke("OpeningText", 1f);
                TextControl_House.textCount = 9;
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
                switch (ColliderControl_House._nowNumber)
                {
                    case 1:                                                     //bed
                        BGM.PlayOneShot(ClimbIntoBed);
                        CameraControl_House.isFollow = false;
                        CameraControl_House.isLookBed = true;
                        BedControl_Bedroom.isSleep = true;
                        switch (_day)
                        {
                            case 1:
                                Story_LittleGirl();
                                break;

                            case 2:
                                UIController.isContentActive = true;
                                isBedContent = true;
                                TextControl_House.textCount = 12;
                                break;

                            case 3:
                                UIController.isContentActive = true;
                                isBedContent = true;
                                TextControl_House.textCount = 12;
                                break;
                        }
                        break;

                    case 2:                                                     //workbench
                        BGM.PlayOneShot(useWorkbench);
                        CameraControl_House.isFollow = false;
                        CameraControl_House.isLookWorkbench = true;
                        UIController.isWorkbenchUIActive = true;
                        if (_day == 2 && isFirstOpenWorkbench)
                        {
                            UIController.isTeachOpenTask = true;
                            UIController.isContentActive = true;
                            TextControl_House.textCount = 6;
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
                                    colliderObject[1].SetActive(true);
                                    isLittleGirlStoryFinish = true;
                                    isCheckStoryBookContent = true;
                                    UIController.isContentActive = true;
                                    TextControl_House.textCount = 10;
                                    BagControl_House.isItemSlotAcite[4] = true;
                                    GetItemUIControl.isGetItemActice = true;
                                    GetItemUIControl._howMuchToGet = 1;
                                    GetItemUIControl._getItemNumber[1] = 4;
                                    TaskController._taskNumber = 10;

                                }
                                if (isFindCrystalStoryBook)
                                {
                                    BedControl_Bedroom.isNight = true;
                                    isFindCrystalStoryBook = false;
                                    BagControl_House.isItemSlotAcite[29] = false;
                                    CaseControl_Bedroom.isStoryBookCrystal = true;
                                    TaskController._taskNumber = 12;
                                }
                                break;
                        }
                        break;

                    case 4:                                                     //storybook_crystal
                        BGM.PlayOneShot(pickUp);
                        isFindStoryBookContent = true;
                        UIController.isContentActive = true;
                        TextControl_House.textCount = 11;
                        Destroy(colliderObject[1]);
                        isFindCrystalStoryBook = true;
                        TaskController._taskNumber = 11;
                        break;

                    case 5:                                                     //gotoLivingroom
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl_House.isLivingRoom = true;
                        DoorControl_House.isBedroom = false;
                        player.transform.position = doorPoint[2].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 6:                                                     //gotoBedroom
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl_House.isBedroom = true;
                        DoorControl_House.isLivingRoom = false;
                        player.transform.position = doorPoint[1].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 7:                                                     //gotoLivingroom
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl_House.isOutDoor = false;
                        player.transform.position = doorPoint[4].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 8:                                                     //gotoOutdoor
                        BGM.PlayOneShot(doorOpen);
                        isNextPlace = true;
                        DoorControl_House.isOutDoor = true;
                        player.transform.position = doorPoint[3].position;
                        Invoke("AutoFalseisNextPlace", 0.5f);
                        break;

                    case 9:                                                     //GradenA
                        BGM.PlayOneShot(pickFlower);
                        PlantControl_Garden.isGardenA = false;
                        FlowerControl_Garden.isDestory = true;
                        if (_day == 2)
                        {
                            TaskController._taskNumber = 5;
                            BagControl_House.isItemSlotAcite[33] = true;
                            GetItemUIControl.isGetItemActice = true;
                            GetItemUIControl._howMuchToGet = 1;
                            GetItemUIControl._getItemNumber[1] = 33;
                        }
                        break;

                    case 10:                                                    //GradenB
                        BGM.PlayOneShot(pickFlower);
                        PlantControl_Garden.isGardenB = false;
                        FlowerControl_Garden.isDestory = true;
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
    void CaseStoryBook()
    {
        switch (_whichStoryScene)
        {
            case 2:
                CaseControl_Bedroom.isStoryBookLittleGirl = true;
                break;

            case 3:
                CaseControl_Bedroom.isStoryBookCrystal = true;
                break;
        }
    }
    void ListenStory_LitteGirl()
    {
        TextControl_House.textCount = 8;
        UIController.isContentActive = true;
        isSleepingContent = true;
    }
    void ListenStory_Crystal()
    {
        TextControl_House.textCount = 13;
        UIController.isContentActive = true;
        isSleepingContent = true;
    }

    //button
    public void Story_LittleGirl()
    {
        _whichStoryScene = 2;
        StoryGameControl_LittleGirl._chapter++;
        UIController.isChooseStoryActive = false;
        switch (StoryGameControl_LittleGirl._chapter)
        {
            case 1:
                UIController.isContentActive = true;
                TextControl_House.textCount = 2;
                isSleepingContent = true;
                break;

            case 2:
                CameraControl_House.isLookStoryWorld = true;
                BookCaseControl_Bedroom._chooseWhichStoryWorld = 1;
                BookCaseControl_Bedroom.isChooseWhichStoryBook = true;
                Invoke("ListenStory_LitteGirl", 5f);
                break;
        }
    }
    public void Story_Crystal()
    {
        _whichStoryScene = 3;
        UIController.isChooseStoryActive = false;
        CameraControl_House.isLookStoryWorld = true;
        BookCaseControl_Bedroom._chooseWhichStoryWorld = 2;
        BookCaseControl_Bedroom.isChooseWhichStoryBook = true;
        Invoke("ListenStory_Crystal", 5f);
    }
}
