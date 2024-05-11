using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    public Image bookUI;
    public GameObject[] settingUI;
    public Button[] labelColor;
    public Sprite[] turnPage;

    public static int _page = 1;

    bool isUIInteractable;

    void Start()
    {
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
                 settingUI[_page].SetActive(false);
            }
        }    
    }

    //Button
    public void LabelGreen_Button()             //�O��
    {
        _page = 1;
        StartCoroutine(TurnPageRight()); 
    }
    public void LabelBlue_Button()              //����
    {
        _page = 2;
        StartCoroutine(TurnPageLeft());
    }
    public void LabelRed_Button()               //�P�]
    {
        settingUI[0].SetActive(false);
    }

    //�����Ӯ�
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
