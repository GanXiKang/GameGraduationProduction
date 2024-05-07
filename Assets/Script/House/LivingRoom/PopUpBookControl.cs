using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBookControl : MonoBehaviour
{
    Animator anim;

    public static bool isOpenBook;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isOpenBook)
        {
            anim.SetInteger("isChapter", StoryGameControl_LittleGirl._chapter);
        }
    }
}
