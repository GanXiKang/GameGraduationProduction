using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameControl_LittleGirl : MonoBehaviour
{
    [Header("Musia")]
    public AudioClip find;
    public AudioClip fire;
    public AudioClip elf;
    public AudioClip interact;
    AudioSource BGM;

    [Header("GameObject")]
    public GameObject player;
    public GameObject camera;
    public GameObject[] chapter;
    public GameObject[] gameCollider;
    public static int _task = 0;
    public static int _chapter = 0;
    public static bool isStartStoryContent = false;
    bool once;

    //Chapter1
    public static bool isChapter1Finish = false;
    public static bool isGetSweaterAndHatContent = false;
    public static bool isChapter1EndContent = false;
    public static bool isWear = false;

    [Header("Chapter2")]
    public GameObject matchesLight;
    public GameObject useMatchesUI;
    public GameObject fantasyUI;
    public GameObject loadingUI;
    public GameObject pileWood;
    public GameObject fireEffect;
    public Transform pileWoodPoint;
    public static bool isLoading = false;
    public static bool isChapter2Finish = false;
    public static bool isUseMatchesUI = false;
    public static bool isUseMatches = false;
    public static bool isFirstUseMatches = false;
    public static bool isFirstUseMatchesContent = false;
    public static bool isFantasy = false;
    public static bool isSeeFantasy = false;
    public static bool isFantasyEndContent = false;
    public static bool isFindElfContent = false;
    public static bool isInsFireWoodContent = false;
    public static bool isChapter2EndContent = false;
    public static bool isStoryFinish = false;
    public static bool isRestart = false;
    bool isEnough = false;
    bool isPutPileWood = false;
    bool isIgnite = false;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        switch (_chapter)
        {
            case 1:
                gameCollider[4].SetActive(false);
                break;

            case 2:
                gameCollider[1].SetActive(false);
                player.transform.position = new Vector3(36f, 1.43f, 3f);
                camera.transform.position = new Vector3(36f, 3.6f, 0f);
                break;
        }

        if (!isRestart)
        {
            isStartStoryContent = true;
            StoryUIControl_LittleGirl.isContentActive = true;
            if (isChapter1Finish && !isChapter2Finish)
            {
                StoryTextControl_LittleGirl.textCount = 4;
            }
        }
        else
        {
            isRestart = false;
            if (_task >= 2)
            {
                isEnough = true;
                chapter[1].SetActive(false);
                chapter[2].SetActive(true);
                player.transform.position = gameCollider[4].transform.position;
                camera.transform.position = gameCollider[4].transform.position + new Vector3(0f, 2.17f, 0f);
            }
        }    

        once = true;
    }

    void Update()
    {
        if (StoryUIControl_LittleGirl.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StoryUIControl_LittleGirl.isInteractionButtonActive = false;
                switch (StoryObjectColliderControl._nowNumber)
                {
                    case 1:                                                               //clothing&hat
                        BGM.PlayOneShot(find);
                        _task++;
                        break;

                    case 2:                                                               //Elf
                        BGM.PlayOneShot(elf);
                        _task++;
                        StoryElfControl.isAppear = true;
                        break;

                    case 3:                                                               //insfirepoint
                        BGM.PlayOneShot(interact);
                        pileWood.SetActive(true);
                        BagControl_House.isItemSlotAcite[3] = false;
                        gameCollider[3].SetActive(false);
                        isPutPileWood = true;
                        break;

                    case 4:                                                               //GoAlley
                        BGM.PlayOneShot(interact);
                        isLoading = true;
                        loadingUI.SetActive(true);
                        Invoke("CloseLoadingUI", 4f);
                        break;
                }
            }
        }

        switch (_chapter)
        {
            case 1:
                if (!isGetSweaterAndHatContent && _task >= 1 && !isWear)
                {
                    StoryUIControl_LittleGirl.isContentActive = true;
                    isGetSweaterAndHatContent = true;
                    StoryTextControl_LittleGirl.textCount = 2;
                }
                if (!isChapter1EndContent && isWear && !isChapter1Finish)
                {
                    isChapter1EndContent = true;
                    Invoke("Chapter1End", 2.5f);
                }
                if (_chapter == 1 && isChapter1Finish && once)
                {
                    once = false;
                    TaskController._taskNumber = 2;
                    Invoke("GoHouseScene", 0.5f);
                }
                break;

            case 2:
                useMatchesUI.SetActive(isUseMatchesUI);
               
                if (isFantasy)
                {
                    isFantasy = false;
                    isSeeFantasy = true;
                    fantasyUI.SetActive(true);
                    StoryUIControl_LittleGirl.isFantasyAnimation = true;
                    Invoke("FantasyEnd", 3f);
                }

                if (!StoryUIControl_LittleGirl.isContentActive)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (!isUseMatches)
                        {
                            BGM.PlayOneShot(fire);
                            if (!isFirstUseMatches)
                            {
                                isUseMatchesUI = false;
                                isFirstUseMatches = true;
                                StoryUIControl_LittleGirl.isContentActive = true;
                                isFirstUseMatchesContent = true;
                                StoryTextControl_LittleGirl.textCount = 5;
                            }
                            else
                            {
                                if (isPutPileWood && StoryNearPileWood_LittleGirl.isPileWoodNear)
                                {
                                    fireEffect.SetActive(true);
                                    isIgnite = true;
                                    isPutPileWood = false;
                                    StoryNearPileWood_LittleGirl.isPileWoodNear = false;
                                }
                                Invoke("MatchBurned", 3f);
                            }
                            isUseMatches = true;
                            matchesLight.SetActive(true);
                        }
                    }
                }     //useMatch

                if (!isFindElfContent && _task >= 2 && !isEnough)
                {
                    isEnough = true;
                    isFindElfContent = true;
                    gameCollider[3].SetActive(true);
                    StoryUIControl_LittleGirl.isContentActive = true;
                    StoryTextControl_LittleGirl.textCount = 7;
                    TaskController._taskNumber = 8;
                }
                if (!isInsFireWoodContent && isIgnite)
                {
                    isIgnite = false;
                    StoryUIControl_LittleGirl.isContentActive = true;
                    isInsFireWoodContent = true;
                    StoryTextControl_LittleGirl.textCount = 8;
                }
                if (!isChapter2EndContent && isStoryFinish && !isChapter2Finish)
                {
                    StoryUIControl_LittleGirl.isContentActive = true;
                    isChapter2EndContent = true;
                    StoryTextControl_LittleGirl.textCount = 9;
                }
                if (_chapter == 2 && isChapter2Finish && once)
                {
                    once = false;
                    TaskController._taskNumber = 9;
                    Invoke("GoHouseScene", 0.5f);
                }
                break;
        }

        RestartScene();
    }

    void Chapter1End()
    {
        StoryUIControl_LittleGirl.isContentActive = true;
        StoryTextControl_LittleGirl.textCount = 3;
    }
    void MatchBurned()
    {
        isUseMatches = false;
        matchesLight.SetActive(false);
    }
    void FantasyEnd()
    {  
        isUseMatches = false;
        isSeeFantasy = false;
        fantasyUI.SetActive(false);
        matchesLight.SetActive(false);
        StoryUIControl_LittleGirl.isContentActive = true;
        isFantasyEndContent = true;
        StoryTextControl_LittleGirl.textCount = 6;
        TaskController._taskNumber = 7;
    }
    void CloseLoadingUI()
    {
        isLoading = false;
        loadingUI.SetActive(false);
        chapter[1].SetActive(false);
        chapter[2].SetActive(true);  
    }
    void GoHouseScene()
    {
        SceneManager.LoadScene(1);
        GameControl_House._day += 1;
        BedControl_Bedroom.isNight = false;
        switch (_chapter)
        {
            case 2:
                CaseControl_Bedroom.isStoryBookLittleGirlFinish = true;
                break;
        }
    }

    void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            isRestart = true;
            SceneManager.LoadScene(2);
        }
    }
}
