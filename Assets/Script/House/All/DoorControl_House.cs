using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl_House : MonoBehaviour
{
    MeshRenderer mr_Wall;
    MeshRenderer mr_FrontDoor;
    MeshRenderer mr_Glass;

    public GameObject[] door;
    public GameObject wall;
    public GameObject frontDoor;
    public GameObject glass;
    public GameObject bedroom_G;
    public GameObject livingRoom_G;

    public static bool isOutDoor = false;
    public static bool isBedroom = true;
    public static bool isLivingRoom = false;

    void Start()
    {
        mr_Wall = wall.GetComponent<MeshRenderer>();
        mr_FrontDoor = frontDoor.GetComponent<MeshRenderer>();
        mr_Glass = glass.GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        switch (GameControl_House._day)
        {
            case 1:
                door[1].SetActive(false);
                break;

            case 2:
                if (GameControl_House.isFirstOpenBag)
                {
                    door[1].SetActive(false);
                }
                else
                {
                    door[1].SetActive(true);
                }
                if (GameControl_House.isFirstOpenWorkbench)
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
        mr_Glass.enabled = isOutDoor;

        bedroom_G.SetActive(isLivingRoom);
        livingRoom_G.SetActive(isBedroom);
    }
}
