using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOnOff : MonoBehaviour
{
    [SerializeField] GameObject bloodOff;

    private void Start()
    {
        StartCoroutine(SwitchOff());
    }

    private void Update()
    {
        StartCoroutine(SwitchOff());
    }

    IEnumerator SwitchOff()
    {
        yield return new WaitForSeconds(0.2f);
        bloodOff.gameObject.SetActive(false);
    }
}
