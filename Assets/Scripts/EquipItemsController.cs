using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemsController : MonoBehaviour
{
    public InventoryUI inventoryUIController;
    public ItemObject currentequippedItem;
    public Image equippedItemSlotObject;
    public PlayerController playerController;
    
    public void EquipItem(ItemObject item)
    {
        equippedItemSlotObject.enabled = true;
        equippedItemSlotObject.sprite = item.icon;
    }

    public void ClickedEquipItemButton()
    {
        currentequippedItem = inventoryUIController.currentSelectedSlot.GetComponent<InventorySlotController>().currentItemOnSlot;
        EquipItem(currentequippedItem);
    }

    public void ClickedBackButton()
    {
        playerController.ToggleInventory();
    }
}
