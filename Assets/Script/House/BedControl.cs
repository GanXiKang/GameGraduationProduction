using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedControl : MonoBehaviour
{
    public Transform sleepPoint;
    public GameObject player;
    public static bool isSleep;

    void Start()
    {
        isSleep = false;
    }

    void Update()
    {
        if (isSleep)
        {
            player.transform.position = sleepPoint.position;
            player.transform.rotation = Quaternion.Euler(-90f, 90f, -270f);
        }
    }
}
