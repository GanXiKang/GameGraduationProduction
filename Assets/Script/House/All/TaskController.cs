using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    public GameObject taskUI;
    public Text taskText;

    public static bool isTaskActive;
    public static int _taskNumber;

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
                break;

            case 2:
                break;

            case 3:
                break;
        }
    }
}
