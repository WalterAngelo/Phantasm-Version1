using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotebookModelController : MonoBehaviour
{
    public TMP_Text floorTitle;
    public List<QuestionObjects> questions = new List<QuestionObjects>();
    public List<TextMeshProUGUI> cluePlaceholders = new List<TextMeshProUGUI>();
    public int currentFloorNumber;

    public void AddQuestions()
    {
        for (int i = 0; i < questions.Count; i++)
        {
            if ((int)questions[i].floor == currentFloorNumber)
            {
                floorTitle.text = questions[i].info;
                for(int j=0; j < questions[i].cluesPerFloor.Count; j++)
                {
                    ClueObjects tiedClueTemp = questions[i].cluesPerFloor[j];
                    WritingController writingControllerTemp = cluePlaceholders[j].gameObject.GetComponent<WritingController>();
                    writingControllerTemp.clueInfo = tiedClueTemp;
                    cluePlaceholders[j].text = tiedClueTemp.info;
                    cluePlaceholders[j].ForceMeshUpdate(true);
                    tiedClueTemp.maxCharacters = cluePlaceholders[j].textInfo.characterCount;
                    if (tiedClueTemp.found)
                    {
                        if (tiedClueTemp.used)
                        {
                            writingControllerTemp.isFinished = true;
                            tiedClueTemp.visibleCharacters = cluePlaceholders[j].textInfo.characterCount;
                            cluePlaceholders[j].maxVisibleCharacters = cluePlaceholders[j].textInfo.characterCount;
                        }
                        else
                        {
                            cluePlaceholders[j].maxVisibleCharacters = tiedClueTemp.visibleCharacters;
                        }
                        cluePlaceholders[j].enabled = true;
                    }
                    else
                    {
                        cluePlaceholders[j].enabled = false;
                    }
                }
            }
        }
    }

    public void UpdateClues(ClueObjects clueObj)
    {
        foreach(TextMeshProUGUI cluePlaceholder in cluePlaceholders)
        {
            if (cluePlaceholder.text == clueObj.info)
            {
                cluePlaceholder.maxVisibleCharacters = clueObj.visibleCharacters;
                cluePlaceholder.enabled = true;
            }
        }
    }

    public IEnumerator WriteClues(ClueObjects clue, TextMeshProUGUI cluePlaceholder)
    {
        while(cluePlaceholder.maxVisibleCharacters < clue.maxCharacters)
        {
            cluePlaceholder.maxVisibleCharacters = clue.visibleCharacters + 1;
            clue.visibleCharacters = cluePlaceholder.maxVisibleCharacters;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
