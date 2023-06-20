using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryUI;
    public InventoryObject inventory;
    public GameObject currentSelectedSlot;
    public ItemDescriptionController itemDescriptionController;
    public Sprite normalSlotSprite;
    public Sprite selectedSlotSprite;
    public EquipItemsController equipItemsController;
    public InventoryTextsController inventoryTextsController;

    //public List<GameObject> slots = new List<GameObject> ();
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < inventory.container.Count; i++)
        {
            inventoryUI.GetChild(i).GetComponent<InventorySlotController>().currentItemOnSlot = inventory.container[i].item;
            inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemIcon.enabled = true;
            inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemIcon.sprite = inventory.container[i].item.icon;
            if(inventory.container[i].amount > 1)
            {
                inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemQuantity.enabled = true;
                inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemQuantity.text = inventory.container[i].amount.ToString();
            }
        }
        InventorySelectedUpdate(inventoryUI.GetChild(0).gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        inventoryUI = gameObject.transform;
    }

    public void InventoryUIUpdate()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if(!inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemIcon.enabled)
            {
                inventoryUI.GetChild(i).GetComponent<InventorySlotController>().currentItemOnSlot = inventory.container[i].item;
                inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemIcon.enabled = true;
                inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemIcon.sprite = inventory.container[i].item.icon;
            }

            if (inventory.container[i].amount > 1)
            {
                inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemQuantity.enabled = true;
                inventoryUI.GetChild(i).GetComponent<InventorySlotController>().itemQuantity.text = inventory.container[i].amount.ToString();
            }
        }
    }

    public void InventorySelectedUpdate(GameObject selectedSlotObject)
    {
        if (selectedSlotObject.GetComponent<InventorySlotController>().currentItemOnSlot != null)
        {
            if (currentSelectedSlot != null && currentSelectedSlot != selectedSlotObject)
            {
                currentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite = normalSlotSprite;
            }
            currentSelectedSlot = selectedSlotObject;
            currentSelectedSlot.transform.GetChild(0).GetComponent<Image>().sprite = selectedSlotSprite;
            ItemObject currentItemOnSlotTemp = selectedSlotObject.GetComponent<InventorySlotController>().currentItemOnSlot;
            itemDescriptionController.AddItemInfo(currentItemOnSlotTemp.icon, currentItemOnSlotTemp.itemName, currentItemOnSlotTemp.description);
            if(currentItemOnSlotTemp.type == ItemType.Equipable)
            {
                inventoryTextsController.enableEquipText();
            }else if(currentItemOnSlotTemp.type == ItemType.Unequippable)
            {
                inventoryTextsController.disableEquipText();
            }
        }
    }
}
