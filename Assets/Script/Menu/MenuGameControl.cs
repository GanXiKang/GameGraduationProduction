using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameControl : MonoBehaviour
{
    public GameObject settingUI;
    public GameObject interactiveUI;

    public static bool isNewGameModel = true; //•º•rµÄ
    public static bool isSettingUI = false;

    void Update()
    {
        settingUI.SetActive(isSettingUI);
        interactiveUI.SetActive(!isSettingUI);
    }

    public void Start_Button()
    {
        isNewGameModel = true;
        SceneManager.LoadScene(1);
    }
    public void Setting_Button()
    {
        isSettingUI = true;
    }
}
