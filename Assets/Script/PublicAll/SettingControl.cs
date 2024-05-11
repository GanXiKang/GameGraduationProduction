using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    AudioSource BGM;

    public Image bookUI;
    public Slider sliderBGM;
    public Toggle fullScreen;
    public GameObject[] settingUI;
    public Button[] labelColor;
    public Sprite[] turnPage;

    public static float volumeBGM = 0.7f;
    public static bool isFullS;
    public static int _page = 1;

    bool isUIInteractable;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        sliderBGM.value = volumeBGM;
        fullScreen.isOn = Screen.fullScreen;
        isUIInteractable = true;
    }

    
    void Update()
    {
        ButtonInteractable();
    }

    void ButtonInteractable()
    {
        if (isUIInteractable)
        {
            for (int i = 1; i < settingUI.Length; i++)
            {
                if (i == _page)
                {
                    settingUI[i].SetActive(true);
                    labelColor[i].interactable = false;
                }
                else
                {
                    settingUI[i].SetActive(false);
                    labelColor[i].interactable = true;
                }
            }
        }
        else 
        {
            for (int i = 1; i < settingUI.Length; i++)
            {
                 settingUI[i].SetActive(false);
            }
        }    
    }

    //Button
    public void LabelGreen_Button()             //ÔO¶¨
    {
        _page = 1;
        StartCoroutine(TurnPageRight()); 
    }
    public void LabelBlue_Button()              //²Ù×÷
    {
        _page = 2;
        StartCoroutine(TurnPageLeft());
    }
    public void LabelRed_Button()               //êPé]
    {
        settingUI[0].SetActive(false);
    }
    public void Volume_BGM()
    {
        volumeBGM = sliderBGM.value;
        BGM.volume = volumeBGM;
    }
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        isFullS = isFullScreen;
    }

    //·­•ø„Ó®‹
    IEnumerator TurnPageLeft()
    {
        isUIInteractable = false;
        bookUI.sprite = turnPage[1];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[2];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[4];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[3];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[0];
        isUIInteractable = true;
    }
    IEnumerator TurnPageRight()
    {
        isUIInteractable = false;
        bookUI.sprite = turnPage[3];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[4];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[2];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[1];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[0];
        isUIInteractable = true;
    }
}
