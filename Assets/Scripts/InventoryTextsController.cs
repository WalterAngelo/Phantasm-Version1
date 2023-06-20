using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTextsController : MonoBehaviour
{
    public Button equipTextButtonUI;
    public Button backTextButtonUI;
    
    public void disableEquipText()
    {
        equipTextButtonUI.interactable = false;
    }

    public void enableEquipText()
    {
        equipTextButtonUI.interactable = true;
    }
}
