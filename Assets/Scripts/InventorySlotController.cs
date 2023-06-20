using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public Image itemIcon;
    public Text itemQuantity;
    public ItemObject currentItemOnSlot;
    public InventoryUI inventoryUIController;

    private void Update()
    {

    }

    public void ClickSlot()
    {
        inventoryUIController.InventorySelectedUpdate(gameObject);
    }
}
