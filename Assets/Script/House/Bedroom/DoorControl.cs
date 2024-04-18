using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public int doorNumber;

    void Start()
    {
        switch (GameControl._day)
        {
            case 1:
                if (doorNumber == 1)
                {
                    this.gameObject.SetActive(false);
                }
                break;

            case 2:
                if (doorNumber == 4)
                {
                    if (TaskController._taskNumber <= 2)
                    {
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        this.gameObject.SetActive(true);
                    }
                }
                break;
        }
    }
}
