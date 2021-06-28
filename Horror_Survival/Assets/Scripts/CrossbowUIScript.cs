using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossbowUIScript : MonoBehaviour
{
    [SerializeField] Text arrowAmount;

    private void Start()
    {
        arrowAmount.text = SaveScript.arrows + "";
    }

    private void Update()
    {
        arrowAmount.text = SaveScript.arrows + "";
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (SaveScript.inventoryOpen == false && SaveScript.optionsOpen == false)
            {
                if (SaveScript.arrows > 0)
                {
                    SaveScript.arrows--;
                }
            }
        }
    }
}
