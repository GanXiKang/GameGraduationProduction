using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryGrandmotherTalkControl : MonoBehaviour
{
    public Image grandmother;
    public Sprite[] image;

    bool isNewStartAnimator;

    void Start()
    {
        isNewStartAnimator = true;
    }

    void Update()
    {
        if (isNewStartAnimator)
        {
            StartCoroutine(GrandmotherTalk());
        }
    }

    IEnumerator GrandmotherTalk()
    {
        isNewStartAnimator = false;
        yield return new WaitForSeconds(1f);
        grandmother.sprite = image[1];
        yield return new WaitForSeconds(1f);
        grandmother.sprite = image[0];
        yield return new WaitForSeconds(1f);
        grandmother.sprite = image[2];
        yield return new WaitForSeconds(1f);
        grandmother.sprite = image[0];
        isNewStartAnimator = true;
    }
}
