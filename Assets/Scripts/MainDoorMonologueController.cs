using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorMonologueController : MonoBehaviour
{
    public MonologueObject monoObj;
    public PlayerController playerController;
    public bool interacted = false;


    public void StartMonologue()
    {
        if(!interacted)
        {
            interacted = true;
            StartCoroutine(ShowMonologue(monoObj));
        }
    }

    IEnumerator ShowMonologue(MonologueObject monoObj)
    {
        yield return new WaitForSeconds(0.5f);
        playerController.RunMonologue(null, monoObj);
    }
}
