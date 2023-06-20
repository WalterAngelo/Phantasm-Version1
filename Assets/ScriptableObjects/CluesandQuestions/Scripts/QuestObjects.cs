using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestType
{
    Clue,
    Question
}

public enum QuestFloor
{
    Floor1 = 1,
    Floor2 = 2,
    Floor3 = 3
}

public class QuestObjects : ScriptableObject
{
    public QuestType type;
    public QuestFloor floor;
    [TextArea(15, 20)]
    public string info;
}
