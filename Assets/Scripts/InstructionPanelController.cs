using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InstructionPanelController : MonoBehaviour
{
    public PlayerController playerController;
    public TMP_Text instructionTitle;
    public TMP_Text instructionDescription;
    public Button closeButtonX;
    public Button closeButton;
    
    public void ClosePanel()
    {
        playerController.ToggleCursorVisibility(false);
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
