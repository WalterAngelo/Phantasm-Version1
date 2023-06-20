using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionController : MonoBehaviour
{
    public Image itemImage;
    public Text itemTitle;
    public Text itemInfo;

    public void AddItemInfo(Sprite itemSprite, string itemName, string itemDescription)
    {
        itemImage.enabled = true;
        itemImage.sprite = itemSprite;
        itemTitle.enabled = true;
        itemTitle.text = itemName;
        itemInfo.enabled = true;
        itemInfo.text = itemDescription;
    }
}
