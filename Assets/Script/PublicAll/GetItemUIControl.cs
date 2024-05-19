using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemUIControl : MonoBehaviour
{
    [Header("Musia")]
    public AudioClip get;
    public AudioSource BGM;

    [Header("UI")]
    public GameObject getItemUI;
    public GameObject panel;
    public GameObject theme;

    public GridLayoutGroup group;
    public GameObject[] item;
    public Sprite[] itemImage;

    public static bool isGetItemActice = false;
    public static int _howMuchToGet;
    public static int[] _getItemNumber = new int[4];
    bool isAnim;

    void Start()
    {
        isAnim = false;
    }

    void Update()
    {
        getItemUI.SetActive(isGetItemActice);
        if (isGetItemActice && !isAnim)
        {
            BGM.PlayOneShot(get);
            isAnim = true;
            GridLayoutGroupControl();
            StartCoroutine(GetItemAnimation());
        }
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
        for (int i = 1; i < item.Length; i++)
        {
            if (i <= _howMuchToGet)
            {
                item[i].SetActive(true);
                item[i].GetComponent<Image>().sprite = itemImage[_getItemNumber[i]];
            }
            else
            {
                item[i].SetActive(false);
            }
        }
    }

    IEnumerator GetItemAnimation()
    {
        for (int v = 0; v <= 5; v++)
        {
            panel.GetComponent<RectTransform>().localScale = new Vector3(20f, v, 1f);
            yield return new WaitForSeconds(0.04f);
        }
        theme.SetActive(true);
        item[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        theme.SetActive(false);
        item[0].SetActive(false);
        for (int v = 5; v >= 0; v--)
        {
            panel.GetComponent<RectTransform>().localScale = new Vector3(20f, v, 1f);
            yield return new WaitForSeconds(0.04f);
        }
        isGetItemActice = false;
        isAnim = false;
    }
}
