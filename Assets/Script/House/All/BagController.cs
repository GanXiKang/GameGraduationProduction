using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject[] itemSlot;
    public Text[] quantity_Text;

    public static bool[] isItemSlotAcite;
    public static int[] _itemQuantity;

    public static bool isBagActive;

    void Start()
    {
        isBagActive = false;
       
        if (MenuGameControl.isNewGameModel)
        {
            MenuGameControl.isNewGameModel = false;

            isItemSlotAcite = new bool[itemSlot.Length];

            for (int i = 0; i < itemSlot.Length; i++)
            {
                isItemSlotAcite[i] = false;
            }
            for (int t = 1; t < quantity_Text.Length; t++)
            {
                _itemQuantity[t] = 0;
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
        if (isBagActive)
        {
            for (int k = 1; k < itemSlot.Length; k++)
            {
                itemSlot[k].SetActive(isItemSlotAcite[k]);
            }
            //for (int q = 1; q < quantity_Text.Length; q++)
            //{
                quantity_Text[1].text = _itemQuantity[1].ToString();
            //}
        }
    }
}
