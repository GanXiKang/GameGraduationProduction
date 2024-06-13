using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseControl_Bedroom : MonoBehaviour
{
    public GameObject caseCollider;
    bool isMoveOnce;
    Vector3 distance;

    [Header("StoryBookLitteGirl")]
    public GameObject storyBookLitteGirl;
    public GameObject storyLittleGirl_Button;
    public static bool isStoryBookLittleGirl = true;
    public static bool isStoryBookLittleGirlFinish = false;
    Vector3 originalLocation_LittleGirl;
    Vector3 highlightLocation_LittleGirl;

    [Header("StoryBookCrystal")]
    public GameObject storyBookCrystal;
    public GameObject storyCrystal_Button;
    public static bool isStoryBookCrystal = false;
    public static bool isStoryBookCrystalFinish = false;
    Vector3 originalLocation_Crystal;
    Vector3 highlightLocation_Crystal;

    [Header("StoryBookMomotaro")]
    public GameObject storyBookMomotaro;
    public GameObject storyMomotaro_Button;
    public static bool isStoryBookMomotaro = false;
    public static bool isStoryBookMomotaroFinish = false;
    Vector3 originalLocation_Momotaro;
    Vector3 highlightLocation_Momotaro;

    [Header("StoryBookBeanstalk")]
    public GameObject storyBookBeanstalk;
    public GameObject storyBeanstalk_Button;
    public static bool isStoryBookBeanstalk = false;
    public static bool isStoryBookBeanstalkFinish = false;
    Vector3 originalLocation_Beanstalk;
    Vector3 highlightLocation_Beanstalk;

    [Header("StoryBookCinderella")]
    public GameObject storyBookCinderella;
    public GameObject storyCinderella_Button;
    public static bool isStoryBookCinderella = false;
    public static bool isStoryBookCinderellaFinish = false;
    Vector3 originalLocation_Cinderella;
    Vector3 highlightLocation_Cinderella;

    void Start()
    {
        switch (GameControl._day)
        {
            case 1:
            case 2:
                caseCollider.SetActive(false);
                break;
        }
        StoryBookLocationRecord();
    }

    void Update()
    {
        StoryBookFinish();
        ChooseStoryBookButtonisHighlighter();
    }

    void StoryBookLocationRecord()
    {
        distance = new Vector3(0.1f, 0f, 0f);

        originalLocation_LittleGirl = storyBookLitteGirl.transform.position;
        highlightLocation_LittleGirl = originalLocation_LittleGirl - distance;

        originalLocation_Crystal = storyBookCrystal.transform.position;
        highlightLocation_Crystal = originalLocation_Crystal - distance;

        originalLocation_Momotaro = storyBookMomotaro.transform.position;
        highlightLocation_Momotaro = originalLocation_Momotaro - distance;

        originalLocation_Beanstalk = storyBookBeanstalk.transform.position;
        highlightLocation_Beanstalk = originalLocation_Beanstalk - distance;

        originalLocation_Cinderella = storyBookCinderella.transform.position;
        highlightLocation_Cinderella = originalLocation_Cinderella - distance;
    }
    void StoryBookFinish()
    {
        if (isStoryBookLittleGirlFinish)
        {
            storyLittleGirl_Button.SetActive(false);
        }
        else
        {
            storyBookLitteGirl.SetActive(isStoryBookLittleGirl);
            storyLittleGirl_Button.SetActive(isStoryBookLittleGirl);
        }
        if (isStoryBookCrystalFinish)
        {
            storyCrystal_Button.SetActive(false);
        }
        else
        {
            storyBookCrystal.SetActive(isStoryBookCrystal);
            storyCrystal_Button.SetActive(isStoryBookCrystal);
        }
        if (isStoryBookMomotaroFinish)
        {
            storyMomotaro_Button.SetActive(false);
        }
        else
        {
            storyBookMomotaro.SetActive(isStoryBookMomotaro);
            storyMomotaro_Button.SetActive(isStoryBookMomotaro);
        }
        if (isStoryBookBeanstalkFinish)
        {
            storyBeanstalk_Button.SetActive(false);
        }
        else
        {
            storyBookBeanstalk.SetActive(isStoryBookBeanstalk);
            storyBeanstalk_Button.SetActive(isStoryBookBeanstalk);
        }
        if (isStoryBookCinderellaFinish)
        {
            storyCinderella_Button.SetActive(false);
        }
        else
        {
            storyBookCinderella.SetActive(isStoryBookCinderella);
            storyCinderella_Button.SetActive(isStoryBookCinderella);
        }
    }
    void ChooseStoryBookButtonisHighlighter()
    {
        if (ButtonHighlightedControl_Bedroom.isProtrudeStoryBook)
        {
            if (isMoveOnce)
            {
                switch (ButtonHighlightedControl_Bedroom._whichStoryBook)
                {
                    case 1:
                        storyBookLitteGirl.transform.position = highlightLocation_LittleGirl;
                        break;

                    case 2:
                        storyBookCrystal.transform.position = highlightLocation_Crystal;
                        break;

                    case 3:
                        storyBookMomotaro.transform.position = highlightLocation_Momotaro;
                        break;

                    case 4:
                        storyBookBeanstalk.transform.position = highlightLocation_Beanstalk;
                        break;

                    case 5:
                        storyBookCinderella.transform.position = highlightLocation_Cinderella;
                        break;
                }
                isMoveOnce = false;
            }
        }
        else
        {
            switch (ButtonHighlightedControl_Bedroom._whichStoryBook)
            {
                case 1:
                    storyBookLitteGirl.transform.position = originalLocation_LittleGirl;
                    break;

                case 2:
                    storyBookCrystal.transform.position = originalLocation_Crystal;
                    break;

                case 3:
                    storyBookMomotaro.transform.position = originalLocation_Momotaro;
                    break;

                case 4:
                    storyBookBeanstalk.transform.position = originalLocation_Beanstalk;
                    break;

                case 5:
                    storyBookCinderella.transform.position = originalLocation_Cinderella;
                    break;
            }
            ButtonHighlightedControl_Bedroom._whichStoryBook = 0;
            isMoveOnce = true;
        }
    }
}
