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
        StartCoroutine(TurnPageLeft());
    }

    
    void Update()
    {
        
    }

    IEnumerator TurnPageLeft()
    {
        bookUI.sprite = turnPage[1];
        yield return new WaitForSeconds(0.5f);
        bookUI.sprite = turnPage[2];
        yield return new WaitForSeconds(0.5f);
        bookUI.sprite = turnPage[0];
    }
    IEnumerator TurnPageRight()
    {
        bookUI.sprite = turnPage[3];
        yield return new WaitForSeconds(0.5f);
        bookUI.sprite = turnPage[4];
        yield return new WaitForSeconds(0.5f);
        bookUI.sprite = turnPage[0];
    }
}
