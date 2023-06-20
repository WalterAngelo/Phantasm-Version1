using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public List<bool> enemyStatus;

    public EnemyData(List<EnemyController> enemies)
    {
        enemyStatus = new List<bool>();
        foreach (EnemyController enemy in enemies)
        {
            enemyStatus.Add(enemy.isDead);
        }
    }
}
