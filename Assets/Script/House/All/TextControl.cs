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
    bool textFinish;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile[1]);
    }

    void OnEnable()
    {
        StartCoroutine(SetTextLabelIndexUI());
    }

    void Update()
    {
        if (GameControl.isOpening)
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
                    GameControl.isOpening = false;
                    UIController.isContentActive = false;
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
