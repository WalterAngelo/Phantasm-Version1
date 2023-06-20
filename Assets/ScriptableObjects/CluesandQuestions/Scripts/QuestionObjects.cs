using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Question")]
public class QuestionObjects : QuestObjects
{
    public List<ClueObjects> cluesPerFloor = new List<ClueObjects>();
    private void Awake()
    {
        type = QuestType.Question;
    }
}
