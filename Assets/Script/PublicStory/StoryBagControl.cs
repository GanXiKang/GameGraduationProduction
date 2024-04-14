using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBagControl : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject[] itemSlot;
    public Text[] quantity_Text;

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
        for (int q = 1; q < quantity_Text.Length; q++)
        {
            quantity_Text[q].text = BagController._itemQuantity[q].ToString();
        }
    }
}