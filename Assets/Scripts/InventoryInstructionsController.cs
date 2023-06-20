using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInstructionsController : MonoBehaviour
{
    public PlayerController playerController;
    public InstructionObject instObj;
    

    public void ShowInventoryInstructions()
    {
        playerController.OpenInstructionPanel(instObj);
        playerController.inventoryReady = true;
    }
}
