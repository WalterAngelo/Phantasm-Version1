using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RaycastData
{
    public List<bool> raycastMonologueStatus;

    public RaycastData(List<RaycastMonologue> raycastMonologues)
    {
        raycastMonologueStatus = new List<bool>();
        foreach (RaycastMonologue raycastMonologue in raycastMonologues)
        {
            raycastMonologueStatus.Add(raycastMonologue.interacted);
        }
    }
}