using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBagControl : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject[] itemSlot;

    bool isBagActive;

    void Start()
    {
        isBagActive = false;
    }

    void Update()
    {
        bagUI.SetActive(isBagActive);
        ItemSlotActive();

        if (Input.GetKeyDown(KeyCode.B))
        {
            isBagActive = !isBagActive;
        }
    }

    void ItemSlotActive()
    {
        for (int k = 1; k < itemSlot.Length; k++)
        {
            itemSlot[k].SetActive(BagController.isItemSlotAcite[k]);
        }
    }
}
