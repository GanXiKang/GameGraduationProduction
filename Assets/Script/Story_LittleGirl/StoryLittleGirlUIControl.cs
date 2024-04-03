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
    public GameObject systemContent;
    public GameObject characterContent;
    public static bool isContentActive;

    void Start()
    {
        isInteractionButtonActive = false;
    }

    void Update()
    {
        interactionButton.SetActive(isInteractionButtonActive);

        //Œ¦Ô’¿òÔÚî^ÉÏ
        //Vector3 offset = new Vector3(0f, 300f, 0f);
        //Vector3 p = Camera.main.WorldToScreenPoint(target.position);
        //content.transform.position = p + offset;

        ColliderObjectName();
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
        }
    }
}
