using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastNewClues : MonoBehaviour
{
    public QuestUIController questUIController;
    public MainController mainController;
    public NotebookModelController notebookModelController;

    public void UpdateNewClues()
    {
        mainController.currentFloorNumber += 1;
        questUIController.currentFloorNumber = mainController.currentFloorNumber;
        questUIController._cluesFound = 0;
        questUIController._totalClueCount = 0;
        questUIController.AddClues();
        notebookModelController.currentFloorNumber = mainController.currentFloorNumber;
        notebookModelController.AddQuestions();
        gameObject.SetActive(false);
    }
}
