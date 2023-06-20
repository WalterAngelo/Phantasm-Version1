using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class MainSaveSystem
{
    public static void SaveAllSceneData(PlayerController player,
                                        List<GameObject> pickableItems,
                                        List<GameObject> interactableItems,
                                        Flashlight flashlight,
                                        List<RaycastMonologue> raycastMonologue,
                                        List<ClueObjects> clueObjects,
                                        int saveNumber = 1)
    {
        SavePlayerData(player, saveNumber);
        SaveItemData(pickableItems, interactableItems, saveNumber);
        SaveFlashlightData(flashlight, saveNumber);
        SaveRaycastData(raycastMonologue, saveNumber);
        SaveClueObjectData(clueObjects, saveNumber);
    }

    public static void SavePlayerData(PlayerController player, int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData" + saveNumber.ToString() + ".sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData playerDataVar = new PlayerData(player);

        formatter.Serialize(stream, playerDataVar);
        stream.Close();
    }

    public static void SaveItemData(List<GameObject> pickableItems,
                                    List<GameObject> interactableItems,
                                    int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/itemData" + saveNumber.ToString() + ".sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        ItemData itemsDataVar = new ItemData(pickableItems, interactableItems);

        formatter.Serialize(stream, itemsDataVar);
        stream.Close();
    }

    public static void SaveFlashlightData(Flashlight flashlight,
                                          int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/flashlightData" + saveNumber.ToString() + ".sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        FlashlightData flashlightDataVar = new FlashlightData(flashlight);

        formatter.Serialize(stream, flashlightDataVar);
        stream.Close();
    }

    public static void SaveRaycastData(List<RaycastMonologue> raycastMonologue,
                                        int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/raycastData" + saveNumber.ToString() + ".sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        RaycastData raycastsDataVar = new RaycastData(raycastMonologue);

        formatter.Serialize(stream, raycastsDataVar);
        stream.Close();
    }

    public static void SaveClueObjectData(List<ClueObjects> clueObjects,
                                        int saveNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/clueObjectsData" + saveNumber.ToString() + ".sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        ClueObjectsData clueObjectsDataVar = new ClueObjectsData(clueObjects);

        formatter.Serialize(stream, clueObjectsDataVar);
        stream.Close();
    }

    public static PlayerData LoadPlayer(int saveNumber)
    {
        string path = Application.persistentDataPath + "/playerData" + saveNumber.ToString() + ".sav";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static ItemData LoadItems(int saveNumber)
    {
        string path = Application.persistentDataPath + "/itemData" + saveNumber.ToString() + ".sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ItemData data = formatter.Deserialize(stream) as ItemData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static EnemyData LoadEnemies(int saveNumber)
    {
        string path = Application.persistentDataPath + "/enemyData" + saveNumber.ToString() + ".sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            EnemyData data = formatter.Deserialize(stream) as EnemyData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
