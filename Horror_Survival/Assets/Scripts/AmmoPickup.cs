using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] int ammoNumber;

    void Start()
    {
        StartCoroutine(CheckAmmo());
    }

    IEnumerator CheckAmmo()
    {
        yield return new WaitForSeconds(1.0f);
        if (ammoNumber > SaveScript.ammoLeft)
        {
            Destroy(gameObject);
        }
    }
}
