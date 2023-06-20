using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RaycastType
{
    Monologue = 1,
    Instructions = 2,
    Clue = 3,
    WallBarriers = 4,
    UpdateNewClues = 5,
    EnemyLightsStart = 6
}

public class RaycastMonologue : MonoBehaviour
{
    public RaycastType raycastType;
    public bool interacted = false;
    public GameObject currentHitObject;
    public PlayerController playerController;
    public QuestUIController questUIController;
    public EnemyLightsController enemyLightsController;
    public Flashlight flashlightController;
    public InstructionObject instObj;
    public MonologueObject monoObj;
    public ClueObjects clueObj;

    private int _layerMask = 1 << 7;

    // Start is called before the first frame update
    void Start()
    {
        _layerMask = ~_layerMask;
        if(interacted)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!interacted)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 20f, _layerMask))
            {
                currentHitObject = hitinfo.transform.parent.gameObject;
                if(currentHitObject.tag == "Player")
                {
                    if((int)raycastType == 1)
                    {
                        playerController.RunMonologue(null, monoObj);
                        if(monoObj.monologueName == "EnterNoLight")
                        {
                            RaycastInteractObjectController raycastInteractObjectController = GetComponent<RaycastInteractObjectController>();
                            raycastInteractObjectController.StartInstruction(monoObj);
                        }else if((monoObj.monologueName == "FirstSFXPlayed"))
                        {
                            RaycastSFXPlayed raycastSFXPlayed = GetComponent<RaycastSFXPlayed>();
                            raycastSFXPlayed.PlayAudio();
                            gameObject.SetActive(false);
                        }
                    }
                    else if((int)raycastType == 2)
                    {
                        playerController.OpenInstructionPanel(instObj);
                        if(instObj.instructionName == "Flashlight")
                        {
                            RaycastFlashlightController raycastFlashlightController = GetComponent<RaycastFlashlightController>();
                            raycastFlashlightController.enableFlashlight();
                        }
                    }else if((int)raycastType == 3)
                    {
                        questUIController.DiscoveredQuest(clueObj, null);
                        gameObject.SetActive(false);
                    }else if((int)raycastType == 4)
                    {
                        RaycastBarrier raycastBarrier = GetComponent<RaycastBarrier>();
                        raycastBarrier.StartShowText();
                    }else if((int)raycastType == 5)
                    {
                        RaycastNewClues raycastNewClues = GetComponent<RaycastNewClues>();
                        raycastNewClues.UpdateNewClues();
                    }else if((int)raycastType == 6)
                    {
                        enemyLightsController.StartEnemyLights();
                    }
                    interacted = true;
                }
            }
        }
    }
}
