using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLittleGirlUIControl : MonoBehaviour
{
    [Header("InteractionButton")]
    public GameObject interactionButton;
    public Text interactionButton_text;
    public static bool isInteractionButtonActive;
    public static int _conveyColliderNumber;

    [Header("Content")]
    public GameObject content;
    public static bool isContentActive;

    void Start()
    {
        isInteractionButtonActive = false;
        isContentActive = false;
    }

    void Update()
    {
        interactionButton.SetActive(isInteractionButtonActive);
        content.SetActive(isContentActive);

        ColliderObjectName();
        ContentActiveControl();
    }

    void ColliderObjectName()
    {
        switch (_conveyColliderNumber)
        {
            case 1:
                interactionButton_text.text = "ÆÆÅfµÄÃ«ÒÂ";
                break;

            case 2:
                interactionButton_text.text = "ÆÆÅfµÄÃ«Ã±";
                break;

            case 3:
            case 4:
                interactionButton_text.text = "Ä¾²Ä";
                break;

            case 5:
                interactionButton_text.text = "ÉÏ»ð";
                break;
        }
    }
    void ContentActiveControl()
    {
        if (StoryGameControl_LittleGirl.isStartStoryContent)
        {
            isContentActive = true;
        }
        else 
        {
            isContentActive = false;
        }
    }
}
