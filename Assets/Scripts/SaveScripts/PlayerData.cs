using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] rotation;
    public float[] position;
    public List<string> inventoryItems;
    public List<int> inventoryItemsQuantity;

    public PlayerData(PlayerController player)
    {
        //rotation = new float[3];
        //rotation[0] = player.transform.eulerAngles.x;
        //rotation[1] = player.transform.eulerAngles.y;
        //rotation[2] = player.transform.eulerAngles.z;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        inventoryItems = new List<string>();
        inventoryItemsQuantity = new List<int>();
        for(int i = 0; i < player.inventory.container.Count; i++)
        {
            inventoryItems.Add(player.inventory.container[i].item.itemName);
            inventoryItemsQuantity.Add(player.inventory.container[i].amount);
        }
    }
}
