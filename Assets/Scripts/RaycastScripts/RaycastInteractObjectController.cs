using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractObjectController : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject lightSwitchTextUI;
    public InstructionObject instObj;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<RaycastMonologue>().playerController;
    }

    public void StartInstruction(MonologueObject monoObj)
    {
        StartCoroutine(ShowInstruction(monoObj));
    }


    IEnumerator ShowInstruction(MonologueObject monoObj)
    {
        yield return new WaitForSeconds(monoObj.monologoueSecs);
        lightSwitchTextUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerController.OpenInstructionPanel(instObj);
        gameObject.SetActive(false);
    }
}
