using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InteractableObjectType
{
    Door = 1,
    Lightswitch = 2,
    MainDoor = 3,
}


public class InteractableObjectController : MonoBehaviour
{
    public int key;
    public PlayerController playerController;
    public GameObject isLockedUI;
    public GameObject wrongItemUI;
    public InteractableObjectType interactableObjectType;
    public bool isStillInteractable = true;

    private Animator _anim;
    private Collider _collider;
    private LightSwitchController _lightSwitchController;
    private const string _animBoolName = "isOpen_Obj_";

    public void Awake()
    {
        _anim = GetComponent<Animator>();
        if(_anim != null)
        {
            _anim.enabled = false;
        }
        _collider = GetComponent<Collider>();
        _lightSwitchController = GetComponent<LightSwitchController>();
    }

    public void InteractOnObject(EquipableObjects equippedItem)
    {
        if((int)interactableObjectType == 1)
        {
            if (_anim != null)
            {
                MoveableObject moveableObject = null;
                //is the object of the collider player is looking at the same as me?
                if (!isEqualToParent(_collider, out moveableObject))
                {   //it's not so return;
                    return;
                }

                if (moveableObject != null)     //hit object must have MoveableDraw script attached
                {
                    string animBoolNameNum = _animBoolName + moveableObject.objectNumber.ToString();

                    bool isOpen = _anim.GetBool(animBoolNameNum);    //need current state for message.

                    if (equippedItem == null)
                    {
                        if (key == 0)
                        {
                            _anim.enabled = true;
                            _anim.SetBool(animBoolNameNum, !isOpen);
                        }
                        else
                        {
                            StartCoroutine(SetActiveTimer(wrongItemUI));
                        }
                    }
                    else
                    {
                        if (key == 0 || key == (int)equippedItem.key)
                        {
                            _anim.enabled = true;
                            _anim.SetBool(animBoolNameNum, !isOpen);
                        }
                        else
                        {
                            StartCoroutine(SetActiveTimer(wrongItemUI));
                        }
                    }
                }
            }
            else
            {
                StartCoroutine(SetActiveTimer(isLockedUI));
            }
        }else if((int)interactableObjectType == 2) {
            if(_lightSwitchController != null)
            {
                isStillInteractable = false;
                _lightSwitchController.StartLights();
            }
        }else if((int)interactableObjectType == 3)
        {
            if(gameObject.GetComponent<MainDoorMonologueController>() != null)
            {
                StartCoroutine(SetActiveTimer(isLockedUI));
                gameObject.GetComponent<MainDoorMonologueController>().playerController = playerController;
                gameObject.GetComponent<MainDoorMonologueController>().StartMonologue();
            }
        }
    }

    private bool isEqualToParent(Collider other, out MoveableObject draw)
    {
        draw = null;
        bool rtnVal = false;
        try
        {
            int maxWalk = 6;
            draw = other.GetComponent<MoveableObject>();

            GameObject currentGO = other.gameObject;
            for (int i = 0; i < maxWalk; i++)
            {
                if (currentGO.Equals(this.gameObject))
                {
                    rtnVal = true;
                    if (draw == null)
                    {
                        draw = currentGO.GetComponentInParent<MoveableObject>();
                    }
                    break;          //exit loop early.
                }

                //not equal to if reached this far in loop. move to parent if exists.
                if (currentGO.transform.parent != null)     //is there a parent
                {
                    currentGO = currentGO.transform.parent.gameObject;
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

        return rtnVal;

    }

    IEnumerator SetActiveTimer(GameObject obj)
    {
        isStillInteractable = false;
        obj.SetActive(true);
        yield return new WaitForSeconds(1f);
        isStillInteractable = true;
        obj.SetActive(false);
    }
}
