using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBagControl : MonoBehaviour
{
    public GameObject[] itemSlot;
    public GameObject bagUI;

    bool isBagActive;

    void Start()
    {
        isBagActive = false;
    }

    void Update()
    {
        bagUI.SetActive(isBagActive);

        if (Input.GetKeyDown(KeyCode.B))
        {
            isBagActive = !isBagActive; 
        }

    }

    void ItemSlotActive()
    {

    }
}
