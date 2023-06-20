using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public List<GameObject> poolOfEnemies = new List<GameObject>();
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject player;
    public bool canSpawnEnemies = false;
    public float spawnTime;
    public float spawnDelay;
    
    public GameObject _currentSpawner;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (canSpawnEnemies)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime >= spawnDelay)
            {
                GameObject _currentSpawnedEnemy = GetPooledEnemyObject();
                _currentSpawner = GetRandomSpawner();
                if (_currentSpawnedEnemy != null)
                {
                    _currentSpawnedEnemy.transform.position = _currentSpawner.transform.position;
                    _currentSpawnedEnemy.GetComponent<EnemyController>().player = player;
                    _currentSpawnedEnemy.GetComponent<EnemyController>().isDead = false;
                    _currentSpawnedEnemy.SetActive(true);
                }
                spawnTime = 0;
            }
        }
    }

    public void ChangeSpawnDelay(int currentFloorNumber)
    {
        if (currentFloorNumber == 1)
        {
            spawnDelay = 5f;
        }
        else if (currentFloorNumber == 2)
        {
            spawnDelay = 3f;
        }
    }

    public GameObject GetPooledEnemyObject()
    {
        for (int i = 0; i < poolOfEnemies.Count; i++)
        {
            if (!poolOfEnemies[i].activeInHierarchy)
            {
                return poolOfEnemies[i];
            }
        }
        return null;
    }

    public GameObject GetRandomSpawner()
    {
        GameObject tempObj = spawners[Random.Range(0, spawners.Count)];
        while (!tempObj.activeInHierarchy)
        {
            tempObj = spawners[Random.Range(0, spawners.Count)];
        }
        return tempObj;
    }
}
