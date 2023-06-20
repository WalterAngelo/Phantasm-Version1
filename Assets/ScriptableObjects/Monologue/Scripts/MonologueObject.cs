using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monologue Object", menuName = "Monologue")]
public class MonologueObject : ScriptableObject
{
    public string monologueName;
    public AudioClip audio;
    public float monologoueSecs;
    [TextArea (15,20)]
    public string monologueDescription;
}
