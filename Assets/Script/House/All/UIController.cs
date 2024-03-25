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
    public Sprite[] itemImage;
    public Button makeButton;
    public static int _whatDate;
    int needMaterialQuantity;

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
        MaterialWindowInformation();
        JudgmentMakeButtonInteractable();
    }

    void ColliderObjectName()
    {
        switch (_conveyColliderNumber)
        {
            case 1:
                interactionButton_text.text = "Ë¯´²";
                break;

            case 2:
                interactionButton_text.text = "Ñu×÷Ì¨";
                break;

            case 3:
                interactionButton_text.text = "™™×Ó";
                break;

            case 4:
                interactionButton_text.text = "»¨¶ä";
                break;
        }
    }

    void PlayerContentText()
    {
        switch (_conveyContentTextNumber)
        {
            case 1:
                content_text.text = "ÓÐºÜ¶à•ø";
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

    void MaterialWindowInformation()
    {
        switch (_whatDate)
        {
            case 1:                               //Ã«ÒÂÃ«Ã±
                needMaterialQuantity = 3;
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
                materialNeeded[3].GetComponent<Image>().sprite = itemImage[3];
                break;
        }
    }

    void JudgmentMakeButtonInteractable()
    {
        switch (_whatDate)
        {
            case 1:                               //Ã«ÒÂÃ«Ã±
                if (BagController.isItemSlotAcite[1] && BagController.isItemSlotAcite[2] && BagController.isItemSlotAcite[3])
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

    //Button
    public void Vacancy_Button(int date)
    {
        _whatDate = date;
        storyBook.SetActive(false);
        materialWindow.SetActive(true);
    }
    public void Make_Button()
    {
        WorkbenchControl.isDrawing = true;
        storyBook.SetActive(false);
        materialWindow.SetActive(false);
    }
    public void Back_Button()
    {
        storyBook.SetActive(true);
        materialWindow.SetActive(false);
    }
}
