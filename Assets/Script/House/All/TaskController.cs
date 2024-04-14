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

        if (Input.GetKeyDown(KeyCode.T))
        {
            isTaskActive = !isTaskActive;
        }
    }
}