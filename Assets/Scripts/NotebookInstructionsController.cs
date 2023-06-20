using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookInstructionsController : MonoBehaviour
{
    public InstructionObject instObj;
    public PlayerController playerController;

    public void StartInstruction(ClueObjects clue)
    {
        StartCoroutine(ShowInstruction(clue));
    }

    IEnumerator ShowInstruction(ClueObjects clue)
    {
        yield return new WaitForSeconds(clue.monologueSecs);
        playerController.OpenInstructionPanel(instObj);
    }
}
