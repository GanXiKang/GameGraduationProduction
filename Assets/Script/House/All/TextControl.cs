using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [Header("UIComponents")]
    public Text textLabel;
    public Image faceImage;

    [Header("TextFile")]
    public TextAsset textFile;
    public int index;
    public float textSpend;
    bool textFinish;

    [Header("Avatar")]
    public Sprite littleGirl;
    public Sprite grandmother;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    void OnEnable()
    {
        StartCoroutine(SetTextLabelIndexUI());
    }

    void Update()
    {
        if (GameControl.isOpening && textFinish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(SetTextLabelIndexUI());

                if (index == textList.Count)
                {
                    index = 0;
                    GameControl.isOpening = false;
                    UIController.isContentActive = false;
                }
            }
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

    IEnumerator SetTextLabelIndexUI()
    {
        textFinish = false;
        textLabel.text = "";
        print(textList[index]);
        switch (textList[index].Trim())
        {
            case "A":
                faceImage.sprite = littleGirl;
                index++;
                break;

            case "B":
                faceImage.sprite = grandmother;
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
