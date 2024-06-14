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
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
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
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                textSpend = 0f;
            }
        }
    }
    void JudgmentAfterTheTextEnds()
    {
        if (GameControl_House.isOpeningContent)
        {
            GameControl_House.isOpeningContent = false;
            if (GameControl_House._day == 2)
            {
                UIController.isTeachOpenBag = true;
            }
        }
        else if (GameControl_House.isSleepingContent)
        {
            GameControl_House.isSleepingContent = false;
            GameControl_House.isGotoStroy = true;
        }
        else if (GameControl_House.isOpenBagContent)
        {
            GameControl_House.isOpenBagContent = false;
        }
        else if (GameControl_House.isOpenWorkbenchContent)
        {
            GameControl_House.isOpenWorkbenchContent = false;
        }
        else if (GameControl_House.isFinishSweaterContent)
        {
            GameControl_House.isFinishSweaterContent = false;
        }
        else if (GameControl_House.isBedContent)
        {
            GameControl_House.isBedContent = false;
            GameControl_House.isChooseStoryBook = true;
        }
        else if (GameControl_House.isCheckStoryBookContent)
        {
            GameControl_House.isCheckStoryBookContent = false;
        }
        else if (GameControl_House.isFindStoryBookContent)
        {
            GameControl_House.isFindStoryBookContent = false;
            BagControl_House.isItemSlotAcite[29] = true;
            GetItemUIControl.isGetItemActice = true;
            GetItemUIControl._howMuchToGet = 1;
            GetItemUIControl._getItemNumber[1] = 29;
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
