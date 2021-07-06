using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{
    [SerializeField] GameObject enemyDetectionZone;
    // Start is called before the first frame update
    void Start()
    {
        enemyDetectionZone.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyDetectionZone.gameObject.SetActive(true);
        }
    }
}
