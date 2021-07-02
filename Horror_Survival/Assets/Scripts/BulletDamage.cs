using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveScript.PlayerHealth -= 40;
            SaveScript.healthChanged = true;
            Destroy(gameObject);
        }
    }
}
