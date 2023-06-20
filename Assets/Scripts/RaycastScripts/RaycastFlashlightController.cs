using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFlashlightController : MonoBehaviour
{
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<RaycastMonologue>().playerController;
    }

    public void enableFlashlight()
    {
        playerController.flashlightReady = true;
        gameObject.SetActive(false);
    }
}
