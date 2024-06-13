using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHighlightedControl_Bedroom : MonoBehaviour
{
    public int _storyNumber;
    public static int _whichStoryBook;
    public static bool isProtrudeStoryBook;

    public void OnPointEnter()
    {
        isProtrudeStoryBook = true;
        _whichStoryBook = _storyNumber;
    }

    public void OnPointExit()
    {
        isProtrudeStoryBook = false;
    }
}
