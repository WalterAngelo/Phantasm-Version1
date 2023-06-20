using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unequiptable Object", menuName = "Inventory System/Items/Unequiptable")]
public class UnequippableObejcts : ItemObject
{
    public void Awake()
    {
        type = ItemType.Unequippable;
    }
}
