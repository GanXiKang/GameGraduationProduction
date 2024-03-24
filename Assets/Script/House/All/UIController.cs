using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("InteractionButton")]
    public GameObject interactionButton;
    public Text interactionButton_text;
    public static bool isInteractionButtonActive;
    public static int _conveyColliderNumber;

    [Header("Story")]
    public GameObject chooseStory;
    public static bool isChooseStoryActive;

    [Header("Content")]
    public GameObject content;
    public Transform target;
    public Text content_text;
    public static bool isContentActive;
    public static int _conveyContentTextNumber;

    [Header("Workbench")]
    public GameObject workbench;
    public GameObject storyBook;
    public GameObject materialWindow;
    public GameObject[] materialNeeded;
    public static int _whatDate;

    void Start()
    {
        isInteractionButtonActive = false;
        isChooseStoryActive = false;
        isContentActive = false;
    }

    void Update()
    {
        interactionButton.SetActive(isInteractionButtonActive);
        chooseStory.SetActive(isChooseStoryActive);
        content.SetActive(isContentActive);

        if (isContentActive)
        {
            Invoke("CloseContent", 1f);
        }
        if (CameraController.isLookWorkbench)
        {
            Invoke("WorkbenchUI", 2f);
        }
        else
        {
            WorkbenchUI();
        }

        Vector3 offset = new Vector3(0f, 300f, 0f);
        Vector3 p = Camera.main.WorldToScreenPoint(target.position);
        content.transform.position = p + offset;

        ColliderObjectName();
        PlayerContentText();
    }

    void ColliderObjectName()
    {
        switch (_conveyColliderNumber)
        {
            case 1:
                interactionButton_text.text = "˯��";
                break;

            case 2:
                interactionButton_text.text = "�u��̨";
                break;

            case 3:
                interactionButton_text.text = "����";
                break;

            case 4:
                interactionButton_text.text = "����";
                break;
        }
    }

    void PlayerContentText()
    {
        switch (_conveyContentTextNumber)
        {
            case 1:
                content_text.text = "�кܶ���";
                break;
        }
    }

    void CloseContent()
    {
        isContentActive = false;
    }

    void WorkbenchUI()
    {
        workbench.SetActive(CameraController.isLookWorkbench);
    }

    //Button
    public void Vacancy_Button(int date)
    {
        _whatDate = date;
        storyBook.SetActive(false);
        materialWindow.SetActive(true);
    }
    public void Make_Button()
    {
        
    }
    public void Back_Button()
    {
        materialWindow.SetActive(false);
        storyBook.SetActive(true);  
    }
}
