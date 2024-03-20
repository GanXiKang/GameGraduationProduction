using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenControl : MonoBehaviour
{
    public Transform insFlowerPoint;
    public GameObject flowerPerfab;

    void Start()
    {
        if (GameControl._day == 2)
        {
            Instantiate(flowerPerfab, insFlowerPoint.position, insFlowerPoint.rotation);
        }
    }
}
