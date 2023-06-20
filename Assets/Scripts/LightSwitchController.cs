using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    public GameObject hallwayLights;
    public GameObject invisibleCollider;
    public GameObject enterNoLightsRaycast;
    public GameObject lightSwitchText;
    public MonologueObject monoObj;
    public PlayerController playerController;

    public void StartLights()
    {
        StartCoroutine(LightIt());
    }


    IEnumerator LightIt()
    {
        enterNoLightsRaycast.SetActive(false);
        lightSwitchText.SetActive(false);
        hallwayLights.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        hallwayLights.SetActive(false);
        yield return new WaitForSeconds(1f);
        hallwayLights.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hallwayLights.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        hallwayLights.SetActive(true);
        invisibleCollider.SetActive(false);
        playerController.RunMonologue(null, monoObj);
    }


}
