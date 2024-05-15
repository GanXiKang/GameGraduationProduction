using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject[] itemSlot;
    public Text quantity_Text;

    public static bool[] isItemSlotAcite;
    public static int _itemQuantity = 0;

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
        }
    }

    void Update()
    {
        bagUI.SetActive(isBagActive);
        ItemSlotActive();

        if (!UIController.isContentActive && !TaskController.isTaskActive && GameControl._day != 1)
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
                    TaskController._taskNumber = 3;
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
            
            quantity_Text.text = _itemQuantity.ToString();
        }
    }

    public void Bag_Button()
    {
        isBagActive = !isBagActive;
    }
}
