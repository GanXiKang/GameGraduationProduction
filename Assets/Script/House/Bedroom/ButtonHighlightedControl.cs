using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHighlightedControl : MonoBehaviour
{
    public int _storyNumber;
    public static int _whichStoryBook;
    public static bool isProtrudeStoryBook;

    public void OnPointEnter()
    {
        isProtrudeStoryBook = true;
        _whichStoryBook = _storyNumber;
        print("true");
    }

    public void OnPointExit()
    {
        isProtrudeStoryBook = false;
        print("false");
    }
}
