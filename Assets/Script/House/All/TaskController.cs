using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public GameObject taskUI;

    bool isTaskActive;

    void Start()
    {
        isTaskActive = false;
    }

    void Update()
    {
        taskUI.SetActive(isTaskActive);

        if (!UIController.isContentActive || GameControl._day != 1)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                isTaskActive = !isTaskActive;
            }
        }
    }
}
