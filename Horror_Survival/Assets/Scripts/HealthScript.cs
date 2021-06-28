using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] Text HealthText;
    [SerializeField] GameObject deathPanel;

    // Start is called before the first frame update
    void Start()
    {
        deathPanel.gameObject.SetActive(false);
        HealthText.text = SaveScript.PlayerHealth + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.healthChanged == true)
        {
            SaveScript.healthChanged = false;
            HealthText.text = SaveScript.PlayerHealth + "%";
        }
        if (SaveScript.PlayerHealth <= 0)
        {
            SaveScript.PlayerHealth = 0;
            deathPanel.gameObject.SetActive(true);
        }
    }
}
