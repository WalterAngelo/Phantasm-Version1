using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemObject item;
    public bool isInteracted = false;

    private void Update()
    {
        if(isInteracted)
        {
            CheckComponent();
            gameObject.SetActive(false);
        }
    }

    public void CheckComponent()
    {
        InventoryInstructionsController inventoryInstructionsController = GetComponent<InventoryInstructionsController>();
        FirstEnemySpawnMonologue firstEnemySpawnMonologue = GetComponent<FirstEnemySpawnMonologue>();
        if(inventoryInstructionsController != null)
        {
            inventoryInstructionsController.ShowInventoryInstructions();
        }else if(firstEnemySpawnMonologue != null)
        {
            firstEnemySpawnMonologue.StartSpawnController();
        }
    }
}
