using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class WritingController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public NotebookModelController notebookModelController;
    public QuestUIController questUIController;
    public ClueObjects clueInfo;
    public Texture2D cursorTexture;
    public bool isFinished = false;
    public Vector2 _hotSpot;

    private CursorMode _cursorMode = CursorMode.Auto;
    private Coroutine _writeClueCoroutine;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isFinished)
        {
            Cursor.SetCursor(cursorTexture, _hotSpot, _cursorMode);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, _hotSpot, _cursorMode);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isFinished)
        {
            _writeClueCoroutine = StartCoroutine(notebookModelController.WriteClues(clueInfo, gameObject.GetComponent<TextMeshProUGUI>()));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(_writeClueCoroutine != null)
        {
            StopCoroutine(_writeClueCoroutine);
        }else
        {
            isFinished = true;
            questUIController.FinishedQuest(clueInfo);
            Cursor.SetCursor(null, _hotSpot, _cursorMode);
        }
    }
}
