using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clue", menuName = "Quests/Clue")]
public class ClueObjects : QuestObjects
{
    public int visibleCharacters;
    public int maxCharacters;
    public bool found = false;
    public bool used = false;
    public string shortDesc;
    public AudioClip audio;
    public float monologueSecs;
    [TextArea(15, 20)]
    public string clueMonologue;
    private void Awake()
    {
        type = QuestType.Clue;
    }
}
