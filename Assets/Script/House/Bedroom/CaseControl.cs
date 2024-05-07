using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseControl : MonoBehaviour
{
    public GameObject caseCollider;

    [Header("StoryBook")]
    public GameObject storyBookLitteGirl;
    public GameObject storyLittleGirl_Button;
    public static bool isStoryBookLittleGirl;

    public GameObject storyBookCrystal;
    public GameObject storyCrystal_Button;
    public static bool isStoryBookCrystal;

    public GameObject storyBookMomotaro;
    public GameObject storyMomotaro_Button;
    public static bool isStoryBookMomotaro;

    public GameObject storyBookBeanstalk;
    public GameObject storyBeanstalk_Button;
    public static bool isStoryBookBeanstalk;

    public GameObject storyBookCinderella;
    public GameObject storyCinderella_Button;
    public static bool isStoryBookCinderella;

    void Start()
    {
        switch (GameControl._day)
        {
            case 1:
            case 2:
                caseCollider.SetActive(false);
                break;
        }
    }
}
