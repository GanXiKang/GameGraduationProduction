using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenControl : MonoBehaviour
{
    public Transform[] insFlowerPoint;
    public GameObject flowerPerfab;
    public GameObject gardenA_Collider;
    public GameObject gardenB_Collider;

    void Start()
    {
        if (GameControl._day == 2)
        {
            for (int i = 1; i < 4; i++)
            {
                Instantiate(flowerPerfab, insFlowerPoint[i].position, insFlowerPoint[i].rotation);
            }
        }
    }

    void Update()
    {
        
    }
}
