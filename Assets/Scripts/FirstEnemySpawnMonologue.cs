using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemySpawnMonologue : MonoBehaviour
{
    public FirstEnemySpawnController firstEnemySpawnController;

    public void StartSpawnController() 
    { 
        firstEnemySpawnController.canSpawn = true;
    }
}
