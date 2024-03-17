using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBagControl : MonoBehaviour
{
    GameObject[] itemSlot;
    public GameObject bagUI;

    bool isBagActive;

    void Start()
    {
        isBagActive = false;
        itemSlot = GameObject.FindGameObjectsWithTag("Item");
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
