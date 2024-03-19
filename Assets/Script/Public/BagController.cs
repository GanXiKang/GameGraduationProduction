using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject[] itemSlot;

    public static bool[] isItemSlotAcite;

    bool isBagActive;

    void Start()
    {
        isBagActive = false;

        isItemSlotAcite = new bool[itemSlot.Length];

        if (MenuGameControl.isNewGameModel)
        {
            print("1");
            MenuGameControl.isNewGameModel = false;
            for (int i = 0; i < itemSlot.Length; i++)
            {
                isItemSlotAcite[i] = false;
            }
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
        print("2");
        for (int k = 1; k < itemSlot.Length; k++)
        {
            itemSlot[k].SetActive(isItemSlotAcite[k]);
        }
    }
}
