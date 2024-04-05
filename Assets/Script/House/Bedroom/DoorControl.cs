using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    void Start()
    {
        if (GameControl._day == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
