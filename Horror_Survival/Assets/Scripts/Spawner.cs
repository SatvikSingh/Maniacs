using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemySpawn1;
    [SerializeField] GameObject enemySpawn2;
    [SerializeField] GameObject enemySpawn3;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;
    [SerializeField] Transform spawnPoint3;
    //[SerializeField] bool retriggerable = false;

    private bool canSpawn = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SaveScript.enemiesCurrent < SaveScript.maxEnemiesInGame)
            {
                if (SaveScript.enemiesOnScreen < SaveScript.maxEnemiesOnScreen)
                {
                    if (canSpawn == true)
                    {
                        canSpawn = false;
                        Instantiate(enemySpawn1, spawnPoint1.position, spawnPoint1.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;
                        Instantiate(enemySpawn2, spawnPoint2.position, spawnPoint2.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;
                        Instantiate(enemySpawn3, spawnPoint3.position, spawnPoint3.rotation);
                        SaveScript.enemiesOnScreen++;
                        SaveScript.enemiesCurrent++;             
                    }
                }
            }
        }
    }
}
