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

    void Awake()
    {
        GetTextFormFile(textFile);
    }

    void OnEnable()
    {
        textLabel.text = textList[index];
        index++;
    }

    void Update()
    {
        if (GameControl.isOpening)
        {
            textLabel.text = textList[index];
            StartCoroutine(TextLabelIndex());
            if (index == textList.Count)
            {
                index = 0;
                GameControl.isOpening = false;
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

    IEnumerator TextLabelIndex()
    {
        for (int i = 1; i < textList.Count; i++)
        {
            yield return new WaitForSeconds(2f);
            index++;
        }
    }
}
