using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryLittleGirlUIControl : MonoBehaviour
{
    [Header("Interaction")]
    public GameObject interactionUI;
    public GameObject bagButton;
    public GameObject taskButton;

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

        InteractableUI();
        ColliderObjectName();

        if (isFantasyAnimation)
        {
            StartCoroutine(FantasyAnimation());
        }
    }

    void InteractableUI()
    {
        if (GameControl._day != 1 && !isContentActive && !StoryBagControl.isBagActive && !TaskController.isTaskActive)
        {
            interactionUI.SetActive(true);
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
        yield return new WaitForSeconds(0.3f);
        fantasy.sprite = fantasyPicture[2];
        yield return new WaitForSeconds(0.5f);
        fantasy.sprite = fantasyPicture[3];
        yield return new WaitForSeconds(0.5f);
        fantasy.sprite = fantasyPicture[4];
        yield return new WaitForSeconds(0.5f);
        fantasy.sprite = fantasyPicture[3];
        yield return new WaitForSeconds(0.5f);
        fantasy.sprite = fantasyPicture[4];
        yield return new WaitForSeconds(0.4f);
        fantasy.sprite = fantasyPicture[5];
        yield return new WaitForSeconds(0.3f);
        fantasy.sprite = fantasyPicture[6];
    }
}
