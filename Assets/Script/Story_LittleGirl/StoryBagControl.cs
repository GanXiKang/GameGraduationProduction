using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBagControl : MonoBehaviour
{
    public GameObject bagUI;

    bool isBagActive;

    void Start()
    {
        isBagActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isBagActive = !isBagActive;
            bagUI.SetActive(isBagActive);
        }
    }
}
