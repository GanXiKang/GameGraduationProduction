using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseControl : MonoBehaviour
{
    public GameObject caseCollider;
    Vector3 highlightedMovingDistance;

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

        highlightedMovingDistance = new Vector3(0.145f, 0f, 0f);
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
            switch (ButtonHighlightedControl._whichStoryBook)
            {
                case 1:
                    storyBookLitteGirl.transform.position -= highlightedMovingDistance;
                    break;

                case 2:
                    storyBookCrystal.transform.position -= highlightedMovingDistance;
                    break;

                case 3:
                    storyBookMomotaro.transform.position -= highlightedMovingDistance;
                    break;

                case 4:
                    storyBookBeanstalk.transform.position -= highlightedMovingDistance;
                    break;

                case 5:
                    storyBookCinderella.transform.position -= highlightedMovingDistance;
                    break;
            }
        }
        else
        {
            switch (ButtonHighlightedControl._whichStoryBook)
            {
                case 1:
                    storyBookLitteGirl.transform.position += highlightedMovingDistance;
                    break;

                case 2:
                    storyBookCrystal.transform.position += highlightedMovingDistance;
                    break;

                case 3:
                    storyBookMomotaro.transform.position += highlightedMovingDistance;
                    break;

                case 4:
                    storyBookBeanstalk.transform.position += highlightedMovingDistance;
                    break;

                case 5:
                    storyBookCinderella.transform.position += highlightedMovingDistance;
                    break;
            }
        }
    }
}
