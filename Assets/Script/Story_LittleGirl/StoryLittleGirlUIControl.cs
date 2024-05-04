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
                interactionButton_text.text = "����Ͱ";
                break;

            case 2:
                interactionButton_text.text = "???";
                break;

            case 3:
                interactionButton_text.text = "����";
                break;

            case 4:
                interactionButton_text.text = "С��";
                break;

            case 5:
                interactionButton_text.text = "·��";
                break;
        }
    }
    void ContentActiveControl()
    {
        if (StoryGameControl_LittleGirl.isStartStoryContent || StoryGameControl_LittleGirl.isGetSweaterAndHatContent || StoryGameControl_LittleGirl.isChapter1EndContent
            || StoryGameControl_LittleGirl.isFirstUseMatchesContent || StoryGameControl_LittleGirl.isFindElfContent || StoryGameControl_LittleGirl.isInsFireWoodContent || StoryGameControl_LittleGirl.isChapter2EndContent)
        {
            isContentActive = true;
        }
        else 
        {
            isContentActive = false;
        }
    }
}
