using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControl : MonoBehaviour
{
    [Header("UIComponents")]
    public Text textLabel;

    [Header("TextFile")]
    public TextAsset textFile;
    public int index;
    public float textSpend = 0.1f;

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
        if (GameControl.isOpening)
        {
            StartCoroutine(SetTextLabelIndexUI());
            if (index == textList.Count)
            {
                index = 0;
                GameControl.isOpening = false;
                UIController.isAutoCloseContent = true;
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
        textLabel.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpend);
        }
        index++;
    }
}
