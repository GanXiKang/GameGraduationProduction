using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    public GameObject settingUI;
    public Image bookUI;
    public Sprite[] turnPage;

    void Start()
    {
        //StartCoroutine(TurnPageRight());
    }

    
    void Update()
    {
        
    }

    public void LabelGreen_Button()             //ÔO¶¨
    {
        
    }
    public void LabelBlue_Button()              //²Ù×÷
    {

    }
    public void LabelRed_Button()               //êPé]
    {

    }

    IEnumerator TurnPageLeft()
    {
        bookUI.sprite = turnPage[1];
        yield return new WaitForSeconds(0.3f);
        bookUI.sprite = turnPage[2];
        yield return new WaitForSeconds(0.3f);
        bookUI.sprite = turnPage[0];
    }
    IEnumerator TurnPageRight()
    {
        bookUI.sprite = turnPage[3];
        yield return new WaitForSeconds(0.3f);
        bookUI.sprite = turnPage[4];
        yield return new WaitForSeconds(0.3f);
        bookUI.sprite = turnPage[0];
    }
}
