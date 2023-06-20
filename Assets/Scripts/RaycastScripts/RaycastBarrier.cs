using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBarrier : MonoBehaviour
{
    public GameObject findCluesTextUI;

    public void StartShowText()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        findCluesTextUI.SetActive(true);
        yield return new WaitForSeconds(2f);
        findCluesTextUI.SetActive(false);
        gameObject.SetActive(false);
    }
}
