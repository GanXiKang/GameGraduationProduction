using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("InteractionButton")]
    public GameObject interactionButton;
    public Text interactionButton_text;
    public static bool isActive;
    public static int _conveyColliderNumber;

    void Start()
    {
        isActive = false;
    }

    void Update()
    {
        interactionButton.SetActive(isActive);
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
