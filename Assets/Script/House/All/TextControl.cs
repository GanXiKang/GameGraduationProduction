using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [Header("UIComponents")]
    public Text textName;
    public Text textLabel;

    [Header("TextFile")]
    public TextAsset[] textFile;
    public int index;
    public float textSpend;
    public static int textCount = 1;
    bool textFinish;

    List<string> textList = new List<string>();

    void OnEnable()
    {
        GetTextFormFile(textFile[textCount]);
        StartCoroutine(SetTextLabelIndexUI());
    }

    void Update()
    {
        if (GameControl.isOpeningContent || GameControl.isSleepingContent || 
            GameControl.isOpenBagContent || GameControl.isOpenWorkbenchContent || 
            GameControl.isFinishSweaterContent || GameControl.isBedContent ||
            GameControl.isCheckStoryBookContent || GameControl.isFindStoryBookContent)
        {
            TextController();
        }
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
        if (GameControl.isOpeningContent)
        {
            GameControl.isOpeningContent = false;
            if (GameControl._day == 2)
            {
                UIController.isTeachOpenBag = true;
            }
        }
        else if (GameControl.isSleepingContent)
        {
            GameControl.isSleepingContent = false;
            GameControl.isGotoStroy = true;
        }
        else if (GameControl.isOpenBagContent)
        {
            GameControl.isOpenBagContent = false;
        }
        else if (GameControl.isOpenWorkbenchContent)
        {
            GameControl.isOpenWorkbenchContent = false;
        }
        else if (GameControl.isFinishSweaterContent)
        {
            GameControl.isFinishSweaterContent = false;
        }
        else if (GameControl.isBedContent)
        {
            GameControl.isBedContent = false;
            GameControl.isChooseStoryBook = true;
        }
        else if (GameControl.isCheckStoryBookContent)
        {
            GameControl.isCheckStoryBookContent = false;
        }
        else if (GameControl.isFindStoryBookContent)
        {
            GameControl.isFindStoryBookContent = false;
            BagController.isItemSlotAcite[29] = true;
            GetItemUIControl.isGetItemActice = true;
            GetItemUIControl._howMuchToGet = 1;
            GetItemUIControl._getItemNumber = 29;
        }
    }

    IEnumerator SetTextLabelIndexUI()
    {
        textFinish = false;
        textLabel.text = "";
        switch (textList[index].Trim())
        {
            case "認塞":
                textName.text = "認塞";
                index++;
                break;

            case "通通":
                textName.text = "通通";
                index++;
                break;
        }
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            
            yield return new WaitForSeconds(textSpend);
        }
        textFinish = true;
        index++;
    }
}
