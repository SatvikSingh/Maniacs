using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickup : MonoBehaviour
{
    [SerializeField] int arrowNumber;

    void Start()
    {
        StartCoroutine(CheckArrow());
    }

    IEnumerator CheckArrow()
    {
        yield return new WaitForSeconds(1.0f);
        if (arrowNumber > SaveScript.arrowLeft)
        {
            Destroy(gameObject);
        }
    }
}
