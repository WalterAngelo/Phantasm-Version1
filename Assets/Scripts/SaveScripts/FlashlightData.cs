using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FlashlightData
{
    public bool flashlightStatus;

    public FlashlightData(Flashlight flashlight)
    {
        flashlightStatus = flashlight.gameObject.activeInHierarchy;
    }
}
