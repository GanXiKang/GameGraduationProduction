using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedControl : MonoBehaviour
{
    GameObject player;
    public GameObject bedCollider;
    public Transform sleepPoint;
    public static bool isSleep;
    public static bool isNight = true;

    void Start()
    {
        player = GameObject.Find("Player");
        isSleep = false;
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
