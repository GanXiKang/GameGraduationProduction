using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSystem/Item")]
public class ItemController : ScriptableObject
{
    public int ItemID;
    public string ItemName;
    public Sprite ItemSprite;

    public void Use()
    {
        //Method to use item
    }
}
