using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spawner")
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Spawner")
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Spawner")
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
