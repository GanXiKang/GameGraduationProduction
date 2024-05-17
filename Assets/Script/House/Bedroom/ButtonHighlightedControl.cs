using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlightedControl : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    private bool isHighlighted = false;

    public void OnPointEnter(PointerEventData eventData)
    {
        isHighlighted = true;
        print("Yes");
    }

    public void OnPointExit(PointerEventData eventData)
    {
        isHighlighted = false;
        print("no");
    }
}
