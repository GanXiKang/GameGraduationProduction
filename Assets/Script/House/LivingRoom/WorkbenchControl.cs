using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchControl : MonoBehaviour
{
    public GameObject storyBook, materialWindow;
    int _whatDate;

    void Update()
    {
        if (CameraController.isLookWorkbench)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CameraController.isLookWorkbench = false;
                CameraController.isFollow = true;
            }
        }
    }

    public void Vacancy_Button(int date)
    {
        _whatDate = date;
        storyBook.SetActive(false);
        materialWindow.SetActive(true);
    }
}
