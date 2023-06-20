using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool canSpawn = false;

    // Update is called once per frame
    void Update()
    {
        if(canSpawn)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation, transform.parent);
            canSpawn = false;
        }
    }
}
