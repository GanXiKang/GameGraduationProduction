using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTextControl : MonoBehaviour
{
    [Header("UIComponents")]
    public Transform player;
    public Transform target;
    public GameObject systemContent;
    public GameObject characterContent;
    public Text systemTextLabel;
    public Text characterTextLabel;

    [Header("TextFile")]
    public TextAsset[] textFile;
    public int index;
    public float textSpend;
    public static int textCount = 1;
    bool isPlayerTalk;
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
        if (StoryGameControl_LittleGirl.isStartStoryContent || StoryGameControl_LittleGirl.isGetSweaterAndHatContent || 
            StoryGameControl_LittleGirl.isChapter1EndContent || StoryGameControl_LittleGirl.isFirstUseMatchesContent ||
            StoryGameControl_LittleGirl.isFantasyEndContent || StoryGameControl_LittleGirl.isFindElfContent || 
            StoryGameControl_LittleGirl.isInsFireWoodContent || StoryGameControl_LittleGirl.isChapter2EndContent)
        {
            TextController();
        }

        //Œ¦Ô’¿òÔÚî^ÉÏ
        Vector3 offset = new Vector3(0f, 80f, 0f);
        if (isPlayerTalk)
        {
            Vector3 p = Camera.main.WorldToScreenPoint(player.position);
            characterContent.transform.position = p + offset;
        }
        else 
        {
            Vector3 p = Camera.main.WorldToScreenPoint(target.position);
            characterContent.transform.position = p + offset;
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
                    StoryUIControl_LittleGirl.isContentActive = false;
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
        if (StoryGameControl_LittleGirl.isStartStoryContent)
        {
            StoryGameControl_LittleGirl.isStartStoryContent = false;
            if (StoryGameControl_LittleGirl._chapter == 2)
            {
                StoryGameControl_LittleGirl.isUseMatchesUI = true;
            }
        }
        else if (StoryGameControl_LittleGirl.isGetSweaterAndHatContent)
        {
            StoryGameControl_LittleGirl.isWear = true;
            StoryGameControl_LittleGirl.isGetSweaterAndHatContent = false;
            BagController.isItemSlotAcite[2] = true;
            GetItemUIControl.isGetItemActice = true;
            GetItemUIControl._howMuchToGet = 1;
            GetItemUIControl._getItemNumber[1] = 2;
        }
        else if (StoryGameControl_LittleGirl.isChapter1EndContent)
        {
            StoryGameControl_LittleGirl.isChapter1EndContent = false;
            StoryGameControl_LittleGirl.isChapter1Finish = true;
        }
        else if (StoryGameControl_LittleGirl.isFirstUseMatchesContent)
        {
            StoryGameControl_LittleGirl.isFantasy = true;
            StoryGameControl_LittleGirl.isFirstUseMatchesContent = false;
        }
        else if (StoryGameControl_LittleGirl.isFantasyEndContent)
        {
            StoryGameControl_LittleGirl.isFantasyEndContent = false;
        }
        else if (StoryGameControl_LittleGirl.isFindElfContent)
        {
            StoryGameControl_LittleGirl.isFindElfContent = false;
            StoryElfControl.isFlyLeave = true;
            BagController._itemQuantity++;
            BagController.isItemSlotAcite[1] = true;
            BagController.isItemSlotAcite[3] = true;
            GetItemUIControl.isGetItemActice = true;
            GetItemUIControl._howMuchToGet = 2;
            GetItemUIControl._getItemNumber[1] = 1;
            GetItemUIControl._getItemNumber[2] = 3;

        }
        else if (StoryGameControl_LittleGirl.isInsFireWoodContent)
        {
            StoryGameControl_LittleGirl.isInsFireWoodContent = false;
            StoryGameControl_LittleGirl.isStoryFinish = true;
        }
        else if (StoryGameControl_LittleGirl.isChapter2EndContent)
        {
            StoryGameControl_LittleGirl.isChapter2EndContent = false;
            StoryGameControl_LittleGirl.isChapter2Finish = true;
        }
    }

    IEnumerator SetTextLabelIndexUI()
    {
        textFinish = false;
        characterTextLabel.text = "";
        systemTextLabel.text = "";
        switch (textList[index].Trim())
        {
            case "Ç§ºÉ":
                isPlayerTalk = true;
                systemContent.SetActive(false);
                characterContent.SetActive(true);
                index++;
                whoContent = 2;
                break;

            case "¾«ì`":
                isPlayerTalk = false;
                systemContent.SetActive(false);
                characterContent.SetActive(true);
                index++;
                whoContent = 2;
                break;

            case "ÄÌÄÌ":
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
