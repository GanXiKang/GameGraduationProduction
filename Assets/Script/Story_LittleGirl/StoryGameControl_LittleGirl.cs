using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameControl_LittleGirl : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public GameObject[] chapter;
    public GameObject[] gameCollider;
    public static int _task = 0;
    public static int _chapter = 1;
    public static bool isStartStoryContent = false;
    bool once;

    //Chapter1
    public static bool isChapter1Finish = false;
    public static bool isGetSweaterAndHatContent = false;
    public static bool isChapter1EndContent = false;
    public static bool isWear = false;

    //Chatper2
    public GameObject pileWood;
    public Transform pileWoodPoint;
    public static bool isChapter2Finish = false;
    public static bool isUseMatches = false;
    public static bool isFirstUseMatchesContent = false;
    public static bool isFindElfContent = false;
    public static bool isInsFireWoodContent = false;
    public static bool isChapter2EndContent = false;
    public static bool isStoryFinish = false;
    public static bool isDestoryGameControl = false;
    bool isEnough = false;
    bool isIgnite = false;

    void Start()
    {
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
        isStartStoryContent = true;
        if (isChapter1Finish && !isChapter2Finish)
        {
            StoryTextControl.textCount = 4;
        }
        once = true;
    }

    void Update()
    {
        if (StoryLittleGirlUIControl.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StoryLittleGirlUIControl.isInteractionButtonActive = false;
                switch (StoryObjectColliderControl._nowNumber)
                {
                    case 1:                                                               //clothing&hat
                        _task++;
                        BagController.isItemSlotAcite[4] = true;
                        BagController.isItemSlotAcite[5] = true;
                        break;

                    case 2:                                                               //Elf
                        _task++;
                        //µÃµ½¼ˆˆºÍÄ¾²Ä
                        break;

                    case 3:                                                               //insfirepoint
                        Instantiate(pileWood, pileWoodPoint.position, pileWoodPoint.rotation);
                        BagController._itemQuantity[1] -= 8;
                        isIgnite = true;
                        break;

                    case 4:                                                               //GoAlley
                        chapter[1].SetActive(false);
                        chapter[2].SetActive(true);
                        break;
                }
            }
        }

        switch (_chapter)
        {
            case 1:
                if (!isGetSweaterAndHatContent && _task >= 1 && !isWear)
                {
                    isGetSweaterAndHatContent = true;
                    StoryTextControl.textCount = 2;
                }
                if (!isChapter1EndContent && isWear && !isChapter1Finish)
                {
                    isChapter1EndContent = true;
                    StoryTextControl.textCount = 3;
                }
                if (_chapter == 1 && isChapter1Finish && once)
                {
                    once = false;
                    TaskController._taskNumber = 2;
                    Invoke("GoHouseScene", 0.5f);
                }
                break;

            case 2:
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!isUseMatches)
                    {
                        if (!isFirstUseMatchesContent)
                        {
                            isFirstUseMatchesContent = true;
                            StoryTextControl.textCount = 5;
                        }
                        else
                        {
                            Invoke("MatchBurned", 2f);
                        }
                        isUseMatches = true;                        
                    }
                }

                if (!isFindElfContent && _task >= 2 && !isEnough)
                {
                    isEnough = true;
                    isFindElfContent = true;
                    gameCollider[3].SetActive(true);
                    StoryTextControl.textCount = 7;
                    TaskController._taskNumber = 9;
                }
                if (!isInsFireWoodContent && isIgnite)
                {
                    isIgnite = false;
                    isInsFireWoodContent = true;
                    StoryTextControl.textCount = 8;
                }
                if (!isChapter2EndContent && isStoryFinish && !isChapter2Finish)
                {
                    isChapter2EndContent = true;
                    StoryTextControl.textCount = 9;
                }
                if (_chapter == 2 && isChapter2Finish && once)
                {
                    once = false;
                    TaskController._taskNumber = 10;
                    Invoke("GoHouseScene", 0.5f);
                }
                break;
        }
    }

    void MatchBurned()
    {
        isUseMatches = false;
    }
    void GoHouseScene()
    {
        SceneManager.LoadScene(1);
        GameControl._day += 1;
        switch (_chapter)
        {
            case 1:
                _chapter++;
                break;

            case 2:
                isDestoryGameControl = true;
                break;

        }
    }
}
