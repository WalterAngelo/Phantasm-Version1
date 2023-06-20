using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ClueObjectsData
{
    public List<bool> clueFoundStatus;
    public List<bool> clueUsedStatus;
    public List<int> clueVisibleCharacters;

    public ClueObjectsData(List<ClueObjects> clueObjects)
    {
        clueFoundStatus = new List<bool>();
        clueUsedStatus = new List<bool>();
        clueVisibleCharacters = new List<int>();

        foreach (ClueObjects clueObject in clueObjects)
        {
            clueFoundStatus.Add(clueObject.found);
            clueUsedStatus.Add(clueObject.used);
            clueVisibleCharacters.Add(clueObject.visibleCharacters);
        }
    }
}
