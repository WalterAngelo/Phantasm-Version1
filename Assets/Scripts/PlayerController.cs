using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform eyeLevelTransform;
    public GameObject interactText;
    public GameObject pickupText;
    public GameObject checkClueText;
    public float maxDistanceReach;
    public GameObject currentHitObject;
    public GameObject inventoryGUI;
    public GameObject notebookModelUI;
    public GameObject instructionPanelUI;
    public GameObject monologueUI;
    public GameObject notebookIcon;
    public InventoryObject inventory;
    public InstructionPanelController instructionPanelController;
    public MonologueUIController monologueUIController;
    public StarterAssets.StarterAssetsInputs inputsController;

    public MonologueObject enemyMonoObj;
    public bool flashlightReady = false;
    public bool inventoryReady = false;

    private float _currentHitDistance;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(eyeLevelTransform.position, eyeLevelTransform.TransformDirection(Vector3.forward), out RaycastHit hitinfoRay, maxDistanceReach))
        {
            currentHitObject = hitinfoRay.transform.gameObject;
            _currentHitDistance = hitinfoRay.distance;
            if (hitinfoRay.collider.tag == "PickableItem")
            {
                if(!currentHitObject.GetComponent<ItemController>().isInteracted)
                {
                    pickupText.SetActive(true);
                }else
                {
                    pickupText.SetActive(false);
                }
            }
            if(hitinfoRay.collider.tag == "InteractableItem")
            {
                if(currentHitObject.GetComponent<InteractableObjectController>().isStillInteractable)
                {
                    interactText.SetActive(true);
                }else
                {
                    interactText.SetActive(false);
                }
            }
            if(hitinfoRay.collider.tag == "Clue")
            {
                if(!currentHitObject.GetComponent<ClueObjectController>().isInteracted)
                {
                    checkClueText.SetActive(true);
                }else
                {
                    checkClueText.SetActive(false);
                }
            }
        }
        else
        {
            pickupText.SetActive(false);
            interactText.SetActive(false);
            checkClueText.SetActive(false);
            currentHitObject = null;
            _currentHitDistance = maxDistanceReach;
        }
    }

    public void ToggleInventory()
    {
        inventoryGUI.SetActive(!inventoryGUI.activeInHierarchy);
        if (inventoryGUI.activeInHierarchy)
        {
            ToggleCursorVisibility(true);
        }
        else
        {
            ToggleCursorVisibility(false);
        }
    }

    public void ToggleNotebook()
    {
        notebookModelUI.SetActive(!notebookModelUI.activeInHierarchy);
        notebookIcon.SetActive(!notebookIcon.activeInHierarchy);
        if (notebookModelUI.activeInHierarchy)
        {
            ToggleCursorVisibility(true);
        }
        else
        {
            ToggleCursorVisibility(false);
        }
    }
    
    public void ToggleCursorVisibility(bool status)
    {
        inputsController.cursorInputForLook = !status;
        inputsController.cursorLocked = !status;
        inputsController.SetCursorState(!status);
        Cursor.visible = status;
    }

    public void PickItem(GameObject pickedItem)
    {
        var item = pickedItem.GetComponent<ItemController>();
        if(item)
        {
            inventory.AddItem(item.item, 1);
            item.isInteracted = true;
        }
    }

    public void OpenInstructionPanel(InstructionObject instObj)
    {
        instructionPanelController.instructionDescription.text = instObj.instructionDescription;
        instructionPanelController.instructionTitle.text = instObj.instructionName;
        instructionPanelUI.SetActive(true);
        ToggleCursorVisibility(true);
        Time.timeScale = 0;
    }
    public void RunMonologue(ClueObjects clueObj = null, MonologueObject monoObj = null)
    {
        monologueUI.SetActive(true);
        StartCoroutine(ShowMonologue(clueObj, monoObj));
    }

    public void RunFirstEnemyMonologue()
    {
        RunMonologue(null, enemyMonoObj);
    }


    IEnumerator ShowMonologue(ClueObjects clueObj = null, MonologueObject monoObj = null)
    {
        if (clueObj != null)
        {
            gameObject.GetComponent<AudioSource>().clip = clueObj.audio;
            gameObject.GetComponent<AudioSource>().Play();
            monologueUIController.monologueTextUI.text = clueObj.clueMonologue;
            yield return new WaitForSeconds(clueObj.monologueSecs);
            monologueUI.SetActive(false);
        }
        else if (monoObj != null)
        {
            gameObject.GetComponent<AudioSource>().clip = monoObj.audio;
            gameObject.GetComponent<AudioSource>().Play();
            monologueUIController.monologueTextUI.text = monoObj.monologueDescription;
            yield return new WaitForSeconds(monoObj.monologoueSecs);
            monologueUI.SetActive(false);
        }
        else
        {
            monologueUI.SetActive(false);
            yield return null;
        }
    }


    //public void OnApplicationQuit()
    //{
    //    inventory.container.Clear();
    //}
}
