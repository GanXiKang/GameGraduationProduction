using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextControl : MonoBehaviour
{
    [Header("UIComponents")]
    public GameObject systemContent;
    public GameObject characterContent;
    public Text systemTextLabel;
    public Text characterTextLabel;

    [Header("TextFile")]
    public TextAsset[] textFile;
    public int index;
    public float textSpend;
    public static int textCount = 1;
    bool textFinish;
    int whoContent;

    List<string> textList = new List<string>();

    void OnEnable()
    {
        GetTextFormFile(textFile[textCount]);
        StartCoroutine(SetTextLabelIndexUI());
    }

    void Update()
    {
        //if (GameControl.isOpeningContent || GameControl.isSleepingContent)
        //{
        //    TextController();
        //}
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split("\n");

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    void TextController()
    {
        if (textFinish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                textSpend = 0.1f;
                StartCoroutine(SetTextLabelIndexUI());

                if (index == textList.Count)
                {
                    index = 0;
                    textCount++;
                    UIController.isContentActive = false;
                    JudgmentAfterTheTextEnds();
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                textSpend = 0f;
            }
        }
    }

    void JudgmentAfterTheTextEnds()
    {
        //if (GameControl.isOpeningContent)
        //{
        //    GameControl.isOpeningContent = false;
        //}
        //if (GameControl.isSleepingContent)
        //{
        //    GameControl.isSleepingContent = false;
        //}
    }

    IEnumerator SetTextLabelIndexUI()
    {
        textFinish = false;
        switch (textList[index].Trim())
        {
            case "Ç§ºÉ":
                characterTextLabel.text = "";
                systemContent.SetActive(false);
                characterContent.SetActive(true);
                index++;
                whoContent = 2;
                break;

            case "ÄÌÄÌ":
                systemTextLabel.text = "";
                systemContent.SetActive(true);
                characterContent.SetActive(false);
                index++;
                whoContent = 1;
                break;
        }
        for (int i = 0; i < textList[index].Length; i++)
        {
            if (whoContent == 1)
            {
                systemTextLabel.text += textList[index][i];
            }
            else
            {
                characterTextLabel.text += textList[index][i];
            }
            yield return new WaitForSeconds(textSpend);
        }
        textFinish = true;
        index++;
    }
}
