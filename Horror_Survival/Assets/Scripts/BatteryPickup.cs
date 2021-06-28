using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] int batteryNumber;

    void Start()
    {
        StartCoroutine(CheckBattery());
    }

    IEnumerator CheckBattery()
    {
        yield return new WaitForSeconds(1.0f);
        if (batteryNumber > SaveScript.batteryLeft)
        {
            Destroy(gameObject);
        }
    }
}
