using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedControl : MonoBehaviour
{
    GameObject player;
    public GameObject bedCollider;
    public GameObject bedNoSleep;
    public GameObject bedSleep;
    public static bool isSleep;
    public static bool isNight = true;

    void Start()
    {
        player = GameObject.Find("Player");
        isSleep = false;
    }

    void Update()
    {
        player.SetActive(!isSleep);
        bedCollider.SetActive(isNight);
        bedNoSleep.SetActive(!isSleep);
        bedSleep.SetActive(isSleep);

        if (isSleep)
        {
            SoundControl.isWalk = false;
        }
    }
}
