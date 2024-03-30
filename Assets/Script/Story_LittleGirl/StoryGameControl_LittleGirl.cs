using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryGameControl_LittleGirl : MonoBehaviour
{
    public GameObject player;
    public GameObject cameraTrans;
    public GameObject chapter2PlayerPoint;
    public GameObject[] colliderObject;

    public static int _task = 0;
    public static int _chapter = 1;

    bool isOnce;

    void Start()
    {
        isOnce = true;

        StartingSettings();
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
                }
            }
        }

        if (_task >= 2)
        {
            if (isOnce)
            {
                isOnce = false;
                Invoke("GoHouseScene", 1f);
            }
        }
    }

    void GoHouseScene()
    {
        SceneManager.LoadScene(1);
        GameControl._day++;
        _chapter++;
        _task = 0;
    }

    void StartingSettings()
    {
        switch (_chapter)
        {
            case 2:
                player.transform.position = chapter2PlayerPoint.transform.position;
                cameraTrans.transform.position = chapter2PlayerPoint.transform.position;
                colliderObject[1].SetActive(false);
                colliderObject[2].SetActive(false);
                break;
        }
    }
}
