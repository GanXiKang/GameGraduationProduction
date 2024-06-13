using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerControl_Garden : MonoBehaviour
{
    public static bool isDestory;

    void Start()
    {
        isDestory = false;
    }

    void Update()
    {
        if (isDestory)
        {
            Destroy(this.gameObject);
        }
    }
}
