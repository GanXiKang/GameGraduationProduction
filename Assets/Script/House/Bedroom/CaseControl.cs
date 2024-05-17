using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseControl : MonoBehaviour
{
    public GameObject caseCollider;
    bool isMoveOnce;

    [Header("StoryBookLitteGirl")]
    public GameObject storyBookLitteGirl;
    public GameObject storyLittleGirl_Button;
    public static bool isStoryBookLittleGirl = true;
    public static bool isStoryBookLittleGirlFinish = false;
    Transform originalLocation_LittleGirl;
    Transform highlightLocation_LittleGirl;

    [Header("StoryBookCrystal")]
    public GameObject storyBookCrystal;
    public GameObject storyCrystal_Button;
    public static bool isStoryBookCrystal = false;
    public static bool isStoryBookCrystalFinish = false;
    Transform originalLocation_Crystal;
    Transform highlightLocation_Crystal;

    [Header("StoryBookMomotaro")]
    public GameObject storyBookMomotaro;
    public GameObject storyMomotaro_Button;
    public static bool isStoryBookMomotaro = false;
    public static bool isStoryBookMomotaroFinish = false;
    Transform originalLocation_Momotaro;
    Transform highlightLocation_Momotaro;

    [Header("StoryBookBeanstalk")]
    public GameObject storyBookBeanstalk;
    public GameObject storyBeanstalk_Button;
    public static bool isStoryBookBeanstalk = false;
    public static bool isStoryBookBeanstalkFinish = false;
    Transform originalLocation_Beanstalk;
    Transform highlightLocation_Beanstalk;

    [Header("StoryBookCinderella")]
    public GameObject storyBookCinderella;
    public GameObject storyCinderella_Button;
    public static bool isStoryBookCinderella = false;
    public static bool isStoryBookCinderellaFinish = false;
    Transform originalLocation_Cinderella;
    Transform highlightLocation_Cinderella;

    void Start()
    {
        switch (GameControl._day)
        {
            case 1:
            case 2:
                caseCollider.SetActive(false);
                break;
        }

        originalLocation_LittleGirl.position = storyBookLitteGirl.transform.position;
        highlightLocation_LittleGirl.position = storyBookLitteGirl.transform.position + new Vector3(0f, 0.2f, 0f);
        originalLocation_Crystal.position = storyBookCrystal.transform.position;
        highlightLocation_Crystal.position = storyBookCrystal.transform.position + new Vector3(0f, 0.2f, 0f);
        originalLocation_Momotaro.position = storyBookMomotaro.transform.position;
        highlightLocation_Momotaro.position = storyBookMomotaro.transform.position + new Vector3(0f, 0.2f, 0f);
        originalLocation_Beanstalk.position = storyBookBeanstalk.transform.position;
        highlightLocation_Beanstalk.position = storyBookBeanstalk.transform.position + new Vector3(0f, 0.2f, 0f);
        originalLocation_Cinderella.position = storyBookCinderella.transform.position;
        highlightLocation_Cinderella.position = storyBookCinderella.transform.position + new Vector3(0f, 0.2f, 0f);
    }

    void Update()
    {
        //StoryBookFinish();
        ChooseStoryBookButtonisHighlighter();
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
        if (ButtonHighlightedControl.isProtrudeStoryBook)
        {
            if (isMoveOnce)
            {
                switch (ButtonHighlightedControl._whichStoryBook)
                {
                    case 1:
                        storyBookLitteGirl.transform.position = highlightLocation_LittleGirl.position;
                        break;

                    case 2:
                        storyBookCrystal.transform.position = highlightLocation_Crystal.position;
                        break;

                    case 3:
                        storyBookMomotaro.transform.position = highlightLocation_Momotaro.position;
                        break;

                    case 4:
                        storyBookBeanstalk.transform.position = highlightLocation_Beanstalk.position;
                        break;

                    case 5:
                        storyBookCinderella.transform.position = highlightLocation_Cinderella.position;
                        break;
                }
                isMoveOnce = false;
            }
        }
        else
        {
            print("OK");
            switch (ButtonHighlightedControl._whichStoryBook)
            {
                case 1:
                    storyBookLitteGirl.transform.position = originalLocation_LittleGirl.position;
                    break;

                case 2:
                    storyBookCrystal.transform.position = originalLocation_Crystal.position;
                    break;

                case 3:
                    storyBookMomotaro.transform.position = originalLocation_Momotaro.position;
                    break;

                case 4:
                    storyBookBeanstalk.transform.position = originalLocation_Beanstalk.position;
                    break;

                case 5:
                    storyBookCinderella.transform.position = originalLocation_Cinderella.position;
                    break;
            }
            ButtonHighlightedControl._whichStoryBook = 0;
            isMoveOnce = true;
        }
    }
}
