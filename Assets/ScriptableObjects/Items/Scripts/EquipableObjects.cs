using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equippable Object", menuName = "Inventory System/Items/Equippable")]
public class EquipableObjects : ItemObject
{
    public enum KeyObjects
    {
        KitchenKey = 1,
        DiningRoomKey = 2,
        WineRoomKey = 3,
        StorageKey = 4,
        MastersBedroomKey = 5,
        MastersBathroomKey = 6,
        WineRoom2 = 7,
    }

    public KeyObjects key;
    private void Awake()
    {
        type = ItemType.Equipable;
    }
}
