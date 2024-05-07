using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseControl : MonoBehaviour
{
    public GameObject caseCollider;

    [Header("StoryBookLitteGirl")]
    public GameObject storyBookLitteGirl;
    public GameObject storyLittleGirl_Button;
    public static bool isStoryBookLittleGirl = true;
    public static bool isStoryBookLittleGirlFinish = false;

    [Header("StoryBookCrystal")]
    public GameObject storyBookCrystal;
    public GameObject storyCrystal_Button;
    public static bool isStoryBookCrystal = false;
    public static bool isStoryBookCrystalFinish = false;

    [Header("StoryBookMomotaro")]
    public GameObject storyBookMomotaro;
    public GameObject storyMomotaro_Button;
    public static bool isStoryBookMomotaro = false;
    public static bool isStoryBookMomotaroFinish = false;

    [Header("StoryBookBeanstalk")]
    public GameObject storyBookBeanstalk;
    public GameObject storyBeanstalk_Button;
    public static bool isStoryBookBeanstalk = false;
    public static bool isStoryBookBeanstalkFinish = false;

    [Header("StoryBookCinderella")]
    public GameObject storyBookCinderella;
    public GameObject storyCinderella_Button;
    public static bool isStoryBookCinderella = false;
    public static bool isStoryBookCinderellaFinish = false;

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
