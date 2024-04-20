using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    public GameObject taskUI;
    public Text taskText;

    public static bool isTaskActive;
    public static int _taskNumber = 1;

    void Start()
    {
        isTaskActive = false;
    }

    void Update()
    {
        taskUI.SetActive(isTaskActive);
        TaskTextControl();

        if (!UIController.isContentActive && !BagController.isBagActive && GameControl._day != 1)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                isTaskActive = !isTaskActive;
            }
        }
    }

    void TaskTextControl()
    {
        switch (_taskNumber)
        {
            case 1:
                taskText.text = "�z�鱳��";
                break;

            case 2:
                taskText.text = "�鿴�����_";
                break;

            case 3:
                taskText.text = "�����@��ȡ���";
                break;
        }
    }
}
