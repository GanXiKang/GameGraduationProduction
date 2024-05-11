using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingControl : MonoBehaviour
{
    public static Sprite[] turnPage;

    void Start()
    {
        StartCoroutine(TurnPageLeft());
    }

    
    void Update()
    {
        
    }

    IEnumerator TurnPageLeft()
    {

        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator TurnPageRight()
    {

        yield return new WaitForSeconds(0.5f);

        yield return new WaitForSeconds(0.5f);
    }
}
