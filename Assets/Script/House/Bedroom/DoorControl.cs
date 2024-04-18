using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject[] door;

    void FixedUpdate()
    {
        switch (GameControl._day)
        {
            case 1:
                door[1].SetActive(false);
                break;

            case 2:
                switch (TaskController._taskNumber)
                {
                    case 1:
                        door[1].SetActive(false);
                        break;

                    case 2:
                        door[1].SetActive(true);
                        door[4].SetActive(false);
                        break;

                    case 3:
                        door[4].SetActive(true);
                        break;
                }
                break;
        }
    }
}
