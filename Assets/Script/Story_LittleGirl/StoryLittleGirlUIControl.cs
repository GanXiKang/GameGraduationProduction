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
    public static bool isInteractionUIActive;

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
        isInteractionUIActive = true;
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
        if (isInteractionUIActive && GameControl._day != 1 && !isContentActive && !TaskController.isTaskActive && !SettingControl.isSettingActive  && !StoryGameControl_LittleGirl.isSeeFantasy && !StoryGameControl_LittleGirl.isLoading && !StoryGameControl_LittleGirl.isUseMatchesUI)
        {
            interactionUI.SetActive(true);
        }
        else
        {
            interactionUI.SetActive(false);
        }
    }
    void ColliderObjectName()
    {
        switch (_conveyColliderNumber)
        {
            case 1:
                interactionButton_text.text = "À¬»øÍ°";
                break;

            case 2:
                interactionButton_text.text = "???";
                break;

            case 3:
                interactionButton_text.text = "”[·Å";
                break;

            case 4:
                interactionButton_text.text = "Ð¡Ïï";
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
