using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseStoryBookControl : MonoBehaviour
{
    Animator anim;

    public int _storyNumber;
    public static int _chooseWhichStoryWorld;
    public static bool isChooseWhichStoryBook;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isChooseWhichStoryBook)
        {
            switch (_storyNumber)
            {
                case 1:
                    if (_storyNumber == _chooseWhichStoryWorld)
                    {
                        anim.SetBool("isChooseStoryBook", true);
                        CaseControl.isStoryBookLittleGirl = false;
                    }
                    break;

                case 2:
                    if (_storyNumber == _chooseWhichStoryWorld)
                    {
                        anim.SetBool("isChooseStoryBook", true);
                        CaseControl.isStoryBookCrystal = false;
                    }
                    break;
            }
            isChooseWhichStoryBook = false;
        }
    }
}
