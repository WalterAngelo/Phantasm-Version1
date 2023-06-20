using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public List<bool> pItemsStatus;
    public List<bool> iItemsStatus;
    
    public ItemData(List<GameObject> pickableItems, List<GameObject> interactableItems)
    {
        pItemsStatus = new List<bool>();
        foreach(GameObject pItem in pickableItems)
        {
            pItemsStatus.Add(pItem.GetComponent<ItemController>().isInteracted);
        }

        iItemsStatus = new List<bool>();
        foreach(GameObject iItem in interactableItems)
        {
            iItemsStatus.Add(iItem.GetComponent<InteractableObjectController>().isStillInteractable);
        }
        
    }
}
