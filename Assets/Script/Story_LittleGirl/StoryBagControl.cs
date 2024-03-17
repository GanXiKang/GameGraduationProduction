using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBagControl : MonoBehaviour
{
    public GameObject[] itemSlot;
    public GameObject bagUI;

    public static bool[] isItemSlotAcite;

    bool isBagActive;

    void Start()
    {
        isBagActive = false;
        print(itemSlot.Length);
        isItemSlotAcite = new bool[itemSlot.Length]; 
        for (int i = 0; i < itemSlot.Length; i++)
        {
            isItemSlotAcite[i] = false;
            print("ok");
        }
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
            itemSlot[k].SetActive(isItemSlotAcite[k]);
        }
    }
}
