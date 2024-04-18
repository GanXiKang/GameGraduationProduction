using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject[] door;

    void Start()
    {
        switch (GameControl._day)
        {
            case 1:
                door[1].SetActive(false);
                break;

            case 2:
                if (TaskController._taskNumber >= 3)
                {
                    door[4].SetActive(true);
                }
                else
                {
                    door[4].SetActive(false);
                }
                break;
        }
    }
}
