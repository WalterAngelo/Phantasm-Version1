using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLightsController : MonoBehaviour
{
    public List<GameObject> lights = new List<GameObject>();
    public SpawnerController spawnerController;

    public void StartEnemyLights()
    {
        StartCoroutine(OpenEnemyLights());
    }

    IEnumerator OpenEnemyLights()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);
            foreach (GameObject light in lights)
            {
                light.SetActive(!light.activeInHierarchy);
            }
            spawnerController.canSpawnEnemies = !spawnerController.canSpawnEnemies;
        }
    }
}
