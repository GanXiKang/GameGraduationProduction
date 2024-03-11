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

    [Header("InteractionButton")]
    public GameObject chooseStory;
    public static bool isChooseStoryActive;

    void Start()
    {
        isInteractionButtonActive = false;
        isChooseStoryActive = false;
    }

    void Update()
    {
        interactionButton.SetActive(isInteractionButtonActive);
        chooseStory.SetActive(isChooseStoryActive);
        ColliderObjectName();
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
        }
    }
}
