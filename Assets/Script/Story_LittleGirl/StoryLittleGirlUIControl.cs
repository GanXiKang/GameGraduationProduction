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

    void Start()
    {
        isInteractionButtonActive = false;
    }

    void Update()
    {
        interactionButton.SetActive(isInteractionButtonActive);

        ColliderObjectName();
    }

    void ColliderObjectName()
    {
        switch (_conveyColliderNumber)
        {
            case 1:
                interactionButton_text.text = "ÆÆÅfµÄÃ«ÒÂ";
                break;
        }
    }
}
