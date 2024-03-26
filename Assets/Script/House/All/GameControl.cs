using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static int _day = 1;
    public static bool isOpening;


    void Start()
    {
        if (_day == 1)
        {
            isOpening = true;
            Invoke("OpeningText", 1f);
        }
        else
        {
            isOpening = false;
        }
    }

    void Update()
    {
        InteractionButton();
    }

    void OpeningText()
    {
        if (isOpening)
        {
            UIController.isContentActive = true;
        }
    }
    void InteractionButton()
    {
        if (UIController.isInteractionButtonActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UIController.isInteractionButtonActive = false;
                switch (PlayerColliderControl._nowNumber)
                {
                    case 1:                                                     //bed
                        CameraController.isFollow = false;
                        CameraController.isLookBed = true;
                        UIController.isChooseStoryActive = true;
                        BedControl.isSleep = true;
                        break;

                    case 2:                                                     //workbench
                        CameraController.isFollow = false;
                        CameraController.isLookWorkbench = true;
                        break;

                    case 3:                                                     //cabinet
                        UIController.isContentActive = true;
                        UIController._conveyContentTextNumber = 1;
                        break;

                    case 4:                                                     //flower
                        FlowerControl.isDestory = true;
                        BagController.isItemSlotAcite[3] = true;
                        BagController.quantity = 1;
                        break;
                }
            }
        }
    }

    //button
    public void Story_LittleGirl()
    {
        SceneManager.LoadScene(2);
        CameraController.isFollow = true;
        CameraController.isLookBed = false;
        UIController.isChooseStoryActive = false;
        BedControl.isSleep = false;
    }
}
