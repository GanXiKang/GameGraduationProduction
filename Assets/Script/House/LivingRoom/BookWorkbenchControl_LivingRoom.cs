using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookWorkbenchControl_LivingRoom : MonoBehaviour
{
    Animator anim;

    public GameObject[] quizImage;
    public static bool isOpenBook;
    public static bool isCloseBook;
    public static bool isFinishQuiz = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("isChapter", StoryGameControl_LittleGirl._chapter);
        anim.SetBool("isOpenBook", isOpenBook);
        anim.SetBool("isCloseBook", isCloseBook);

        if (isOpenBook)
        {
            Invoke("FalseOfOpenBook", 0.2f);
        }
        if (isCloseBook)
        {
            Invoke("FalseOfCloseBook", 0.2f);
        }

        quizImage[0].SetActive(!isFinishQuiz);
        quizImage[1].SetActive(isFinishQuiz);
        quizImage[2].SetActive(isFinishQuiz);
    }

    void FalseOfOpenBook()
    {
        isOpenBook = false;
    }
    void FalseOfCloseBook()
    {
        isCloseBook = false;
    }
}
