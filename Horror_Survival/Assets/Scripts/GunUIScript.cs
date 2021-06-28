using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIScript : MonoBehaviour
{
    [SerializeField] Text bulletAmount;

    private void Start()
    {
        bulletAmount.text = SaveScript.bullets + "";
    }

    private void Update()
    {
        bulletAmount.text = SaveScript.bullets + "";
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (SaveScript.inventoryOpen == false && SaveScript.optionsOpen == false)
            {
                if (SaveScript.bullets > 0)
                {
                    SaveScript.bullets--;
                }
            }
        }
    }
}
