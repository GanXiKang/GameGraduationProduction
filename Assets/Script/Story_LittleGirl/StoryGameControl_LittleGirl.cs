using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameControl_LittleGirl : MonoBehaviour
{
    public GameObject[] colliderObject;
    public GameObject[] chapter;
    public static int _task = 0;
    public static int _chapter = 1;
    public static bool isStartStoryContent = false;

    //Chapter1
    public static bool isChapter1Finish = false;
    public static bool isGetSweaterAndHatContent = false;
    public static bool isChapter1EndContent = false;
    public static bool isWear = false;

    //Chatper2
    public GameObject fireWood;
    public Transform fireWoodPoint;
    public static bool isChapter2Finish = false;
    public static bool isEnoughWoodContent = false;
    public static bool isInsFireWoodContent = false;
    public static bool isChapter2EndContent = false;

    void Start()
    {
        chapter[_chapter].SetActive(true);
        isStartStoryContent = true;
        if (isChapter1Finish && !isChapter2Finish)
        {
            StoryTextControl.textCount = 4;
        }
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
                    case 1:                                                               //clothing
                        _task++;
                        BagController.isItemSlotAcite[4] = true;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;

                    case 2:                                                                    //hat
                        _task++;
                        BagController.isItemSlotAcite[5] = true;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;

                    case 3:                                                                    //wood
                    case 4:
                        BagController.isItemSlotAcite[1] = true;
                        BagController._itemQuantity[1] += 5;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;

                    case 5:                                                                    //insfirepoint
                        Instantiate(fireWood, fireWoodPoint.position, fireWoodPoint.rotation);
                        BagController._itemQuantity[1] -= 8;
                        isChapter2Finish = true;
                        break;
                        
                }
            }
        }

        switch (_chapter)
        {
            case 1:
                if (!isGetSweaterAndHatContent && _task >= 2 && !isWear)
                {
                    isGetSweaterAndHatContent = true;
                    StoryTextControl.textCount = 2;
                }
                if (!isChapter1EndContent && isWear && !isChapter1Finish)
                {
                    isChapter1EndContent = true;
                    StoryTextControl.textCount = 3;
                }
                if (_chapter == 1 && isChapter1Finish)
                {
                    Invoke("GoHouseScene", 1f);
                }
                break;

            case 2:
                if (_chapter == 2 && isChapter2Finish)
                {
                    Invoke("GoHouseScene", 1f);
                }
                break;
        }
    }

    void GoHouseScene()
    {
        SceneManager.LoadScene(1);
        GameControl._day++;
        _chapter++;
    }
}
