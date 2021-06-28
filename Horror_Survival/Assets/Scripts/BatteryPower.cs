using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
    [SerializeField] Image BatteryUI;
    [SerializeField] float drainTime = 180.0f;
    [SerializeField] float power;

    void Update()
    {
        if (SaveScript.batteryRefill == true)
        {
            SaveScript.batteryRefill = false;
            BatteryUI.fillAmount = 1.0f;
        }

        if (SaveScript.flashlightOn == true || SaveScript.NVlightOn == true)
        {
            BatteryUI.fillAmount -= 1.0f / drainTime * Time.deltaTime;
            power = BatteryUI.fillAmount;
            SaveScript.batteryPower = power;
        }
    }
}
