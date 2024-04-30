using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    MeshRenderer mr_Wall;
    MeshRenderer mr_FrontDoor;

    public GameObject[] door;
    public GameObject wall;
    public GameObject frontDoor;

    public static bool isOutDoor = false;

    void Start()
    {
        mr_Wall = wall.GetComponent<MeshRenderer>();
        mr_FrontDoor = frontDoor.GetComponent<MeshRenderer>();
    }

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

    void Update()
    {
        mr_Wall.enabled = isOutDoor;
        mr_FrontDoor.enabled = isOutDoor;
    }
}
