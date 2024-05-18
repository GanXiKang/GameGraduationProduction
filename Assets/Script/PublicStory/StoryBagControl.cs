using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBagControl : MonoBehaviour
{
    [Header("Musia")]
    public AudioClip open;
    AudioSource BGM;

    [Header("UI")]
    public GameObject bagUI;
    public GameObject zipper;
    public GameObject itemUI;
    public GameObject[] itemSlot;
    public Image bagOpen;
    public Sprite[] bagOpenAnim;
    public Text quantity_Text;
    public static bool isBagActive;

    void Start()
    {
        BGM = GetComponent<AudioSource>();

        isBagActive = false;
    }

    void Update()
    {
        ItemSlotActive();

        if (!StoryLittleGirlUIControl.isContentActive && !TaskController.isTaskActive && GameControl._day != 1)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Zipper_Button();
            }
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
        BGM.PlayOneShot(open);
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
        StoryLittleGirlUIControl.isInteractionUIActive = false;
        bagUI.SetActive(isBagActive);
        yield return new WaitForSeconds(0.5f);
        bagOpen.sprite = bagOpenAnim[2];
        yield return new WaitForSeconds(0.5f);
        bagOpen.sprite = bagOpenAnim[3];
        zipper.SetActive(true);
        itemUI.SetActive(true);
    }
    IEnumerator CloseBagAnimation()
    {
        yield return new WaitForSeconds(0.8f);
        bagOpen.sprite = bagOpenAnim[2];
        zipper.SetActive(false);
        itemUI.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        bagOpen.sprite = bagOpenAnim[1];
        bagUI.SetActive(isBagActive);
        StoryLittleGirlUIControl.isInteractionUIActive = true;
    }
}
