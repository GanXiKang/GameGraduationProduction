using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBagControl : MonoBehaviour
{
    public GameObject bagUI;
    public GameObject zipper;
    public GameObject[] itemSlot;
    public Image bagOpen;
    public Sprite[] bagOpenAnim;
    public Text quantity_Text;
    public static bool isBagActive;

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
            Zipper_Button();
        }
    }

    void ItemSlotActive()
    {
        for (int k = 1; k < itemSlot.Length; k++)
        {
            itemSlot[k].SetActive(BagController.isItemSlotAcite[k]);
        }

        quantity_Text.text = BagController._itemQuantity.ToString();
    }

    public void Zipper_Button()
    {
        isBagActive = !isBagActive;
        if (isBagActive)
        {
            StartCoroutine(OpenBagAnimation());
        }
        else
        {
            StartCoroutine(CloseBagAnimation());
        }
    }

    IEnumerator OpenBagAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        bagOpen.sprite = bagOpenAnim[2];
        yield return new WaitForSeconds(0.5f);
        bagOpen.sprite = bagOpenAnim[3];
        zipper.SetActive(true);
    }
    IEnumerator CloseBagAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        bagOpen.sprite = bagOpenAnim[2];
        zipper.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        bagOpen.sprite = bagOpenAnim[1]; 
    }
}
