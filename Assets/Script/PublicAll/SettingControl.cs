using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    public GameObject settingUI;
    public Image bookUI;
    public Sprite[] turnPage;

    public static int _page = 1;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void LabelGreen_Button()             //ÔO¶¨
    {  
        StartCoroutine(TurnPageRight());
        _page = 1;
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
    }
    public void LabelRed_Button()               //êPé]
    {
        StartCoroutine(TurnPageLeft());
        _page = 3;
    }

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
