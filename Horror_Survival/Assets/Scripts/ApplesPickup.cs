using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplesPickup : MonoBehaviour
{
    [SerializeField] int appleNumber;

    void Start()
    {
        StartCoroutine(CheckApples());
    }

    IEnumerator CheckApples()
    {
        yield return new WaitForSeconds(1.0f);
        if (appleNumber > SaveScript.applesLeft)
        {
            Destroy(gameObject);
        }
    }
}
