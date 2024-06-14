using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Interaction")]
    public GameObject interactionUI;
    public GameObject panelA, panelB;
    public GameObject bagButton;
    public GameObject taskButton;
    public static bool isTeachOpenBag = false;
    public static bool isTeachOpenTask = false;

    [Header("Button")]
    public GameObject interactionButton;
    public Text interactionButton_text;
    public static bool isInteractionButtonActive;
    public static int _conveyColliderNumber;

    [Header("Story")]
    public GameObject chooseStory;
    public static bool isChooseStoryActive;

    [Header("Content")]
    public GameObject content;
    public Text content_text;
    public static bool isContentActive;
    public static bool isAutoCloseContent;
    public static int _conveyContentTextNumber;

    [Header("Workbench")]
    public GameObject workbench;
    public GameObject backTip;
    public GameObject storyQuiz;
    public GameObject storyBook;
    public GameObject materialWindow;
    public GameObject[] materialNeeded;
    public Sprite[] itemImage;
    public Button makeButton;
    public static int _whatDate;
    public static bool isFinish;
    public static bool isWorkbenchUIActive;
    int needMaterialQuantity;
    bool isWaitOpenBook;

    void Start()
    {
        isInteractionButtonActive = false;
        isChooseStoryActive = false;
        isContentActive = false;
        isAutoCloseContent = false;
        isWaitOpenBook = true; 
    }

    void Update()
    {
        interactionButton.SetActive(isInteractionButtonActive);
        chooseStory.SetActive(isChooseStoryActive);
        content.SetActive(isContentActive);
        storyBook.SetActive(CameraController.isLookWorkbench);

        if (isAutoCloseContent)
        {
            Invoke("CloseContent", 1f);
        }
            
        InteractableUI();
        ColliderObjectName();
        WorkbenchUI();
        MaterialWindowInformation();
        JudgmentMakeButtonInteractable();
        JudgmentFinish();
    }

    void FixedUpdate()
    {
        if (!CameraController.isLookWorkbench && !CameraController.isLookMake)   //不斷的檢查
        {
            materialWindow.SetActive(false);
            storyQuiz.SetActive(false);
            isWaitOpenBook = true;
        }
    }

    void InteractableUI()
    {
        if (GameControl._day != 1 && CameraController.isFollow && !isContentActive && !BagControl_House.isBagActive && !TaskController.isTaskActive && !GameControl.isOpeningStopMove && !SettingControl.isSettingActive && !GetItemUIControl.isGetItemActice)
        {
            interactionUI.SetActive(true);

            if (GameControl._day == 2)
            {
                if (isTeachOpenBag)
                {
                    PlayerController.isNoMove = true;
                    panelA.SetActive(true);
                    bagButton.SetActive(true);
                    taskButton.SetActive(false);
                }
                else
                {
                    panelA.SetActive(false);
                }
                if (isTeachOpenTask)
                {
                    PlayerController.isNoMove = true;
                    panelB.SetActive(true);
                    taskButton.SetActive(true);
                }
                else
                {
                    panelB.SetActive(false);
                }
            }
        }
        else
        {
            interactionUI.SetActive(false);
        }
    }
    void ColliderObjectName()
    {
        switch (_conveyColliderNumber)
        {
            case 1:
                interactionButton_text.text = "睡床";
                break;

            case 2:
                interactionButton_text.text = "工作台";
                break;

            case 3:
                interactionButton_text.text = "櫃子";
                break;

            case 4:
                interactionButton_text.text = "故事書";
                break;

            case 5:
                interactionButton_text.text = "客廳";
                break;

            case 6:
                interactionButton_text.text = "房間";
                break;

            case 7:
                interactionButton_text.text = "客廳";
                break;

            case 8:
                interactionButton_text.text = "花園";
                break;

            case 9:
            case 10:
                interactionButton_text.text = "採集";
                break;
        }
    }
    void CloseContent()
    {
        isContentActive = false;
        isAutoCloseContent = false;
    }
    void WorkbenchUI()
    {
        if (isWorkbenchUIActive)
        {
            workbench.SetActive(!isFinish);
            BookWorkbenchControl_LivingRoom.isOpenBook = true;
            backTip.SetActive(CameraController.isLookWorkbench);
            if (isWaitOpenBook)
            {
                isWaitOpenBook = false;
                Invoke("StoryQuizWaitOpenBook", 3f);
            }
            if (CameraController.isLookWorkbench)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    LeaveWorkbench_Button();
                }
            }
        }
    }
    void StoryQuizWaitOpenBook()
    {
        storyQuiz.SetActive(true);
    }
    void MaterialWindowInformation()
    {
        switch (_whatDate)
        {
            case 1:                               //毛衣
                needMaterialQuantity = 2;
                for (int i = 1; i < materialNeeded.Length; i++)
                {
                    if (i <= needMaterialQuantity)
                    {
                        materialNeeded[i].SetActive(true);
                    }
                    else
                    {
                        materialNeeded[i].SetActive(false);
                    }
                }
                materialNeeded[1].GetComponent<Image>().sprite = itemImage[1];
                materialNeeded[2].GetComponent<Image>().sprite = itemImage[2];
                break;
        }
    }
    void JudgmentMakeButtonInteractable()
    {
        switch (_whatDate)
        {
            case 1:                               //毛衣&藍色顏料
                if (BagController.isItemSlotAcite[2] && BagController.isItemSlotAcite[33])
                {
                    makeButton.interactable = true;
                }
                else
                {
                    makeButton.interactable = false;
                }
                break;
        }
    }
    void JudgmentFinish()
    {
        switch (_whatDate)
        {
            case 1:                               //毛衣
                if (isFinish)
                {
                    BookWorkbenchControl_LivingRoom.isFinishQuiz = true;
                    DeleteUsedMaterial();
                }
                break;
        }
    }
    void DeleteUsedMaterial()
    {
        switch (_whatDate)
        {
            case 1:                              
                if (isFinish)
                {
                    BagController.isItemSlotAcite[2] = false;
                    BagController.isItemSlotAcite[33] = false;
                }
                break;
        }
    }
    void LeaveWorkbench()
    {
        CameraController.isLookWorkbench = false;
        CameraController.isFollow = true;
        materialWindow.SetActive(false);
        storyQuiz.SetActive(false);
        isWaitOpenBook = true;
    }

    //Button
    public void Vacancy_Button(int date)
    {
        _whatDate = date;
        storyQuiz.SetActive(false);
        materialWindow.SetActive(true);
    }
    public void Make_Button()
    {
        isFinish = false;
        WorkbenchControl_LivingRoom.isDrawing = true;
        CameraController.isLookMake = true;
        CameraController.isLookWorkbench = false;
        materialWindow.SetActive(false);
    }
    public void Back_Button()
    {
        storyQuiz.SetActive(true);
        materialWindow.SetActive(false);
    }
    public void LeaveWorkbench_Button()
    {
        isWorkbenchUIActive = false;
        backTip.SetActive(false);
        workbench.SetActive(false);
        BookWorkbenchControl_LivingRoom.isCloseBook = true;
        Invoke("LeaveWorkbench", 1.8f);
    }
}
