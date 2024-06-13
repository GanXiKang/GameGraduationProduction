using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCaseControl_Bedroom : MonoBehaviour
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
                        CaseControl_Bedroom.isStoryBookLittleGirl = false;
                    }
                    break;

                case 2:
                    if (_storyNumber == _chooseWhichStoryWorld)
                    {
                        anim.SetBool("isChooseStoryBook", true);
                        CaseControl_Bedroom.isStoryBookCrystal = false;
                    }
                    break;
            }
            Invoke("AutoFalseOfisChooseWhichStoryBook", 0.5f);
        }
    }

    void AutoFalseOfisChooseWhichStoryBook()
    {
        isChooseWhichStoryBook = false;
    }
}
