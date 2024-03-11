using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public void Story_LittleGirl()
    {
        SceneManager.LoadScene(1);
        CameraController.isFollow = true;
        CameraController.isLookBed = false;
        UIController.isChooseStoryActive = false;
        BedControl.isSleep = false;
    }
}
