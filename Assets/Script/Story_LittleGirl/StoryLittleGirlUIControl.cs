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

    [Header("Fantasy")]
    public Image fantasy;
    public Sprite[] fantasyPicture;
    public static bool isFantasyAnimation;

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

        if (isFantasyAnimation)
        {
            StartCoroutine(FantasyAnimation());
        }
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
        }
    }

    IEnumerator FantasyAnimation()
    {
        isFantasyAnimation = false;
        yield return new WaitForSeconds(1f);
    }
}
