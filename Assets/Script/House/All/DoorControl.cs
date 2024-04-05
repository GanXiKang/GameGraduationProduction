using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Transform playerPoint;
    public Transform NextPlacePoint;
    public int _doorNumber;
    public static int _whoDoor;
    public static bool isNextPlace = false;

    void Update()
    {
        if (isNextPlace)
        {
            playerPoint.position = NextPlacePoint.position;
            isNextPlace = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameControl._day != 1)
        {
            if (other.tag == "Player")
            {
                _whoDoor = _doorNumber;
            }
        }
    }
}
