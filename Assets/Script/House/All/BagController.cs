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
            _itemQuantity = new int[quantity_Text.Length];

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

        if (!UIController.isContentActive && GameControl._day != 1)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                isBagActive = !isBagActive;
                if (GameControl._day == 2 && GameControl.isFirstOpenBag)
                {
                    UIController.isContentActive = true;
                    TextControl.textCount = 4;
                    GameControl.isFirstOpenBag = false;
                    GameControl.isOpenBagContent = true;
                }
            }
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
            for (int q = 1; q < quantity_Text.Length; q++)
            {
                quantity_Text[1].text = _itemQuantity[1].ToString();
            }
        }
    }
}
