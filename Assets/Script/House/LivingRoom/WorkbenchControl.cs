using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchControl : MonoBehaviour
{
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
}
