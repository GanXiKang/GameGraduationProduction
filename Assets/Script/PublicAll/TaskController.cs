using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    [Header("Musia")]
    public AudioClip open;
    AudioSource BGM;

    [Header("UI")]
    public GameObject taskUI;
    public GameObject imageUI;
    public Text taskText;
    public TextAsset taskFile;

    public static bool isTaskActive;
    public static int _taskNumber = 1;                    //在text裏的第1行 = C#的第0行

    List<string> taskList = new List<string>();

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        isTaskActive = false;
        GetTextFormFile(taskFile);
    }

    void Update()
    {
        taskUI.SetActive(isTaskActive);
        taskText.text = taskList[_taskNumber - 1];       //配合notepad的行數
        if (CameraController.isFollow && !UIController.isContentActive && !BagController.isBagActive && !SettingControl.isSettingActive && !GetItemUIControl.isGetItemActice &&
            !StoryLittleGirlUIControl.isContentActive && !StoryGameControl_LittleGirl.isSeeFantasy && !StoryGameControl_LittleGirl.isUseMatchesUI && !StoryBagControl.isBagActive)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Task_Button();
            }
        }

        switch (_taskNumber)
        {
            case 7:
                imageUI.SetActive(true);
                break;

            default:
                imageUI.SetActive(false);
                break;
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

    public void Task_Button()
    {
        BGM.PlayOneShot(open);
        isTaskActive = !isTaskActive;
        if (GameControl._day == 2)
        {
            PlayerController.isNoMove = false;
            UIController.isTeachOpenTask = false;
        }
    }
}
