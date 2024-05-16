using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameControl : MonoBehaviour
{
    [Header("Musia")]
    public AudioClip onClick;
    AudioSource BGM;

    [Header("UI")]
    public GameObject interactiveUI;

    public static bool isNewGameModel = true; //•º•rµÄ

    void Update()
    {
        BGM = GetComponent<AudioSource>();

        interactiveUI.SetActive(!SettingControl.isSettingActive);
    }

    public void Start_Button()
    {
        BGM.PlayOneShot(onClick);
        isNewGameModel = true;
        SceneManager.LoadScene(1);
    }
    public void Setting_Button()
    {
        BGM.PlayOneShot(onClick);
        SettingControl.isSettingActive = true;
    }
}
