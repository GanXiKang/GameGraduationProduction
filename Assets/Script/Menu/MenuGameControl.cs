using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameControl : MonoBehaviour
{
    public GameObject interactiveUI;

    public static bool isNewGameModel = true; //•º•rµÄ

    void Update()
    {
        interactiveUI.SetActive(!SettingControl.isSettingActive);
    }

    public void Start_Button()
    {
        isNewGameModel = true;
        SceneManager.LoadScene(1);
    }
    public void Setting_Button()
    {
        SettingControl.isSettingActive = true;
    }
}
