using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("InteractionButton")]
    public GameObject interactionButton;
    public static Text interactionButton_text;
    public static bool isActive;

    void Start()
    {
        isActive = true;
    }

    void Update()
    {
        if (isActive)
        {
            interactionButton.SetActive(true);
        }
    }
}
