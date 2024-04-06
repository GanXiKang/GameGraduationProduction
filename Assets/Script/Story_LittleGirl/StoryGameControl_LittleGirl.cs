using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameControl_LittleGirl : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraTrans;
    public GameObject[] colliderObject;
    public GameObject[] chapter;

    public static int _task = 0;
    public static int _chapter = 2;
    public static bool isChapter1Finish = false;
    public static bool isChapter2Finish = false;
    public static bool isStartStoryContent = false;

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
                        BagController.isItemSlotAcite[StoryObjectColliderControl._nowNumber] = true;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;

                    case 2:                                                                    //hat
                        _task++;
                        BagController.isItemSlotAcite[StoryObjectColliderControl._nowNumber] = true;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;

                    case 3:                                                                    //wood
                        BagController.isItemSlotAcite[StoryObjectColliderControl._nowNumber] = true;
                        Destroy(colliderObject[StoryObjectColliderControl._nowNumber]);
                        break;
                }
            }
        }

        if (_task >= 2 && !isChapter1Finish)
        {
            isChapter1Finish = true;
            Invoke("GoHouseScene", 1f);
        }
    }

    void GoHouseScene()
    {
        SceneManager.LoadScene(1);
        GameControl._day++;
        _chapter++;
    }
}
