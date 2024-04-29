using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedControl : MonoBehaviour
{
    public Transform sleepPoint;
    public GameObject player;
    public GameObject bedCollider;
    public static bool isSleep;
    public static bool isNight;

    void Start()
    {
        isSleep = false;
        isNight = false;
        bedCollider.SetActive(isNight);
    }

    void Update()
    {
        bedCollider.SetActive(isNight);
        if (isSleep)
        {
            player.transform.position = sleepPoint.position;
            player.transform.rotation = Quaternion.Euler(-90f, 90f, -270f);
        }
    }
}
