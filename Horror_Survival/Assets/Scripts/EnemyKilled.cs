using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilled : MonoBehaviour
{
    [SerializeField] int enemyNumber;

    void Start()
    {
        if (enemyNumber == 1)
        {
            SaveScript.enemy1 = 0;
        }
        if (enemyNumber == 2)
        {
            SaveScript.enemy2 = 0;
        }
        if (enemyNumber == 3)
        {
            SaveScript.enemy3 = 0;
        }
    }
}
