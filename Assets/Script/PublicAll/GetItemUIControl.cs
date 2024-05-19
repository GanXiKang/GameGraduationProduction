using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemUIControl : MonoBehaviour
{
    public GameObject getItemUI;
    public GameObject panel;
    public GameObject theme;

    public GridLayoutGroup group;
    public GameObject[] item;
    public Sprite[] itemImage;

    public static bool isGetItemActice = false;
    public static int _howMuchToGet = 2;
    public static int _getItemNumber;

    void Update()
    {
        GridLayoutGroupControl();

        //item[1].GetComponent<Image>().sprite = itemImage[1];
    }

    void GridLayoutGroupControl()
    {
        switch (_howMuchToGet)
        {
            case 1:
                group.padding.right = 0;
                break;

            case 2:
                group.padding.right = 300;
                break;

            case 3:
                group.padding.right = 600;
                break;
        }
    }
}
