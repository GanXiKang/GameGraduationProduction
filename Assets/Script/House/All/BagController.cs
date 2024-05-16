using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour
{
    [Header("Musia")]
    public AudioClip open;
    AudioSource bgm;

    [Header("UI")]
    public GameObject bagUI;
    public GameObject[] itemSlot;
    public Text quantity_Text;
    public static bool isBagActive;
    public static bool[] isItemSlotAcite;
    public static int _itemQuantity = 0;

    void Start()
    {
        bgm.GetComponent<AudioSource>();

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
                Bag_Button();
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
        bgm.PlayOneShot(open);
        isBagActive = !isBagActive;
        if (GameControl._day == 2 && GameControl.isFirstOpenBag)
        {
            PlayerController.isNoMove = false;
            UIController.isPanelActive = false;
            UIController.isTeachOpenBag = false;
            UIController.isContentActive = true;
            TextControl.textCount = 4;
            GameControl.isFirstOpenBag = false;
            GameControl.isOpenBagContent = true;
            TaskController._taskNumber = 3;
        }
    }
}
