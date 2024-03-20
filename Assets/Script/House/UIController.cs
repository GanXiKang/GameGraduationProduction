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
                interactionButton_text.text = "睡床";
                break;

            case 2:
                interactionButton_text.text = "製作台";
                break;

            case 3:
                interactionButton_text.text = "櫃子";
                break;
        }
    }

    void PlayerContentText()
    {
        switch (_conveyContentTextNumber)
        {
            case 1:
                content_text.text = "有很多書";
                break;
        }
    }

    void CloseContent()
    {
        isContentActive = false;
    }
}
