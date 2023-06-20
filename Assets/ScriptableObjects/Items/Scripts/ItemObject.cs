using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Equipable,
    Unequippable
}

public abstract class ItemObject : ScriptableObject
{
    public Sprite icon;
    public ItemType type;
    public string itemName;
    [TextArea(15, 20)]
    public string description;
}
