using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenControl : MonoBehaviour
{
    public Transform[] insFlowerPoint;
    public GameObject flowerPerfab;
    public GameObject gardenA_Collider;
    public GameObject gardenB_Collider;

    public static bool isGardenA = false;
    public static bool isGardenB = false;

    void Start()
    {
        if (GameControl._day == 2)
        {
            for (int i = 1; i < 4; i++)
            {
                isGardenA = true;
                Instantiate(flowerPerfab, insFlowerPoint[i].position, insFlowerPoint[i].rotation);
            }
        }
    }

    void Update()
    {
        gardenA_Collider.SetActive(isGardenA);
        gardenB_Collider.SetActive(isGardenB);
    }
}
