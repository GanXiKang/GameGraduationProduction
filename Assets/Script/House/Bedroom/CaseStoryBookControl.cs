using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseStoryBookControl : MonoBehaviour
{
    Animator anim;

    public int storyNumber;
    public static bool isChooseWhichStoryBook;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isChooseWhichStoryBook)
        {
            switch (storyNumber)
            {
                case 1:
                    anim.SetBool("isChooseStoryBook", true);
                    CaseControl.isStoryBookLittleGirl = false;
                    break;

                case 2:
                    anim.SetBool("isChooseStoryBook", true);
                    CaseControl.isStoryBookCrystal = false;
                    break;
            }
            isChooseWhichStoryBook = false;
        }
    }
}
