using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIController : MonoBehaviour
{
    public PlayerController playerController;
    public NotebookModelController notebookModelController;
    public MainController mainController;
    public GameObject savedText;
    public TMP_Text cluesFoundText;
    public TMP_Text cluesFoundNumber;
    public List<TMP_Text> clueLists = new List<TMP_Text>();
    public List<ClueObjects> clues = new List<ClueObjects>();
    public List<GameObject> barriers = new List<GameObject>();
    public int currentFloorNumber;

    public int _cluesFound = 0;
    public int _totalClueCount = 0;

    public void AddClues()
    {
        for(int i = 0; i < clues.Count; i++)
        {
            if ((int)clues[i].floor == currentFloorNumber)
            {
                clueLists[_totalClueCount].text = clues[i].shortDesc;
                if (clues[i].found)
                {
                    clueLists[_totalClueCount].enabled = true;
                    if (clues[i].used)
                    {
                        clueLists[_totalClueCount].fontStyle = FontStyles.Strikethrough;
                    }
                    _cluesFound++;
                }
                else
                {
                    clueLists[_totalClueCount].enabled = false;
                }
                _totalClueCount++;
            }
        }
        cluesFoundNumber.text = _cluesFound.ToString() + "/" + _totalClueCount.ToString();
        RemoveBarriers();
    }

    public void FinishedQuest(ClueObjects clueObj)
    {
        mainController.SaveFile();
        foreach(TMP_Text clueText in clueLists)
        {
            if(clueText.text == clueObj.shortDesc)
            {
                clueText.fontStyle = FontStyles.Strikethrough;
            }
        }
    }

    public void DiscoveredQuest(ClueObjects clueObj, GameObject clueSceneObj)
    {
        foreach(TMP_Text clueText in clueLists)
        {
            if(clueText.text == clueObj.shortDesc)
            {
                clueText.enabled = true;
                clueObj.found = true;
                notebookModelController.UpdateClues(clueObj);
                _cluesFound++;
                playerController.RunMonologue(clueObj, null);
                if (clueSceneObj != null)
                {
                    clueSceneObj.GetComponent<ClueObjectController>().isInteracted = true;
                    if (clueSceneObj.GetComponent<NotebookInstructionsController>() != null)
                    {
                        clueSceneObj.GetComponent<NotebookInstructionsController>().playerController = playerController;
                        clueSceneObj.GetComponent<NotebookInstructionsController>().StartInstruction(clueObj);
                    }
                }
            }
        }
        cluesFoundNumber.text = (_cluesFound).ToString() + "/" + _totalClueCount.ToString();
        RemoveBarriers();
    }

    public void RemoveBarriers()
    {
        if (_cluesFound == _totalClueCount)
        {
            if (currentFloorNumber == 1)
            {
                barriers[0].SetActive(false);
            }
            else if (currentFloorNumber == 2)
            {
                barriers[1].SetActive(false);
                barriers[2].SetActive(false);
            }
        }
    }
}
