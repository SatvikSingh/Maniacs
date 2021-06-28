using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerLightSettings : MonoBehaviour
{
    [SerializeField] PostProcessVolume MyVolume;
    [SerializeField] PostProcessProfile Standard;
    [SerializeField] PostProcessProfile NightVision;

    private bool CamisActive = false;
    private bool FlashisActive = false;
    public GameObject NightVision_Overlay;
    public GameObject FlashLight;
    public GameObject enemyFlashlight;

    private void Start()
    {
        NightVision_Overlay.gameObject.SetActive(false);
        FlashLight.gameObject.SetActive(false);
        enemyFlashlight.gameObject.SetActive(false);
    }

    void Update()
    {
        if (SaveScript.batteryPower > 0.0f)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                if (CamisActive == false)
                {
                    MyVolume.profile = NightVision;
                    CamisActive = true;
                    NightVision_Overlay.SetActive(true);
                    SaveScript.NVlightOn = true;
                }
                else
                {
                    MyVolume.profile = Standard;
                    CamisActive = false;
                    NightVision_Overlay.SetActive(false);
                    SaveScript.NVlightOn = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                if (FlashisActive == false)
                {
                    FlashLight.SetActive(true);
                    enemyFlashlight.gameObject.SetActive(true);
                    FlashisActive = true;
                    SaveScript.flashlightOn = true;
                }
                else
                {
                    FlashLight.SetActive(false);
                    enemyFlashlight.gameObject.SetActive(false);
                    FlashisActive = false;
                    SaveScript.flashlightOn = false;
                }

            }
        }

        if (SaveScript.batteryPower <= 0.0f)
        {
            MyVolume.profile = Standard;
            CamisActive = false;
            NightVision_Overlay.SetActive(false);
            SaveScript.NVlightOn = false;
            FlashLight.SetActive(false);
            enemyFlashlight.gameObject.SetActive(false);
            FlashisActive = false;
            SaveScript.flashlightOn = false;
        }
    }
}
