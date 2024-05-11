using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    public GameObject settingUI;
    public Image bookUI;
    public Button[] labelColor;
    public Sprite[] turnPage;

    public static int _page = 1;

    void Start()
    {
        
    }

    
    void Update()
    {
     
    }

    void ButtonInteractable()
    {
        for (int i = 1; i < labelColor.Length; i++)
        {
            if (i == _page)
            {
                labelColor[i].interactable = false;
            }
            else
            {
                labelColor[i].interactable = true;
            }
        }
    }

    //Button
    public void LabelGreen_Button()             //ÔO¶¨
    {  
        StartCoroutine(TurnPageRight());
        _page = 1;
        ButtonInteractable();
    }
    public void LabelBlue_Button()              //²Ù×÷
    {
        if (_page == 1)
        {
            StartCoroutine(TurnPageLeft());
        } 
        else
        {
            StartCoroutine(TurnPageRight());
        }
        _page = 2;
        ButtonInteractable();
    }
    public void LabelRed_Button()               //êPé]
    {
        StartCoroutine(TurnPageLeft());
        _page = 3;
        ButtonInteractable();
    }

    //·­•ø„Ó®‹
    IEnumerator TurnPageLeft()
    {
        bookUI.sprite = turnPage[1];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[2];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[4];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[3];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[0];
    }
    IEnumerator TurnPageRight()
    {
        bookUI.sprite = turnPage[3];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[4];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[2];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[1];
        yield return new WaitForSeconds(0.2f);
        bookUI.sprite = turnPage[0];
    }
}
