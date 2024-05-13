using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBookControl : MonoBehaviour
{
    Animator anim;

    public GameObject quizImage;
    public static bool isOpenBook;
    public static bool isCloseBook;
    public static bool isFinishQuiz = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isOpenBook)
        {
            anim.SetInteger("isChapter", StoryGameControl_LittleGirl._chapter);
            quizImage.SetActive(isFinishQuiz);
        }
    }
}
