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

    List<string> textList = new List<string>();

    void Start()
    {
        GetTextFormFile(textFile);
        index = 0;
    }

    void Update()
    {
        if (GameControl.isOpening)
        {
            textLabel.text = textList[index];
            index++;
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
}
