using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    public GameObject taskUI;
    public Text taskText;
    public TextAsset taskFile;

    public static bool isTaskActive;
    public static int _taskNumber = 1;

    List<string> taskList = new List<string>();

    void Start()
    {
        isTaskActive = false;
        GetTextFormFile(taskFile);
    }

    void Update()
    {
        taskUI.SetActive(isTaskActive);
        taskText.text = taskList[_taskNumber];

        if (!UIController.isContentActive && !BagController.isBagActive && GameControl._day != 1)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                isTaskActive = !isTaskActive;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        var lineDate = file.text.Split("\n");

        foreach (var line in lineDate)
        {
            taskList.Add(line);
        }
    }
}
