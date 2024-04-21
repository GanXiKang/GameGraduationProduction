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
                if (GameControl.isFirstOpenBag)
                {
                    door[1].SetActive(false);
                }
                else 
                {
                    door[1].SetActive(true);
                }
                if (GameControl.isFirstOpenWorkbench)
                {
                    door[4].SetActive(false);
                }
                else
                {
                    door[4].SetActive(true);
                }
                break;
        }
    }
}
