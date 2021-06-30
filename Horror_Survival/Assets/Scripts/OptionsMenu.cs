using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] GameObject visualsPanel;
    [SerializeField] GameObject soundsPanel;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject difficultyPanel;
    [SerializeField] GameObject savePanel;
    [SerializeField] GameObject backtoMenuPanel;
    [SerializeField] PostProcessLayer myLayer;
    [SerializeField] GameObject fogStorm;

    public Slider lightSlider;
    public Toggle fogToggle;
    public Toggle antiOff;
    public Toggle antiFXAA;
    public Toggle antiSMAA;
    public Toggle antiTAA;
    public Slider ambienceLevel;
    public Slider sfxLevel;
    public AudioMixer ambienceMixer;
    public AudioMixer sfxMixer;

    private bool fogOn = true;
    private int antiState = 4;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
        visualsPanel.gameObject.SetActive(true);
        soundsPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(false);
        difficultyPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        backtoMenuPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void LightValue()
    {
        RenderSettings.ambientIntensity = lightSlider.value;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void AmbienceVolume()
    {
        ambienceMixer.SetFloat("Volume", ambienceLevel.value);
    }

    public void SFXVolume()
    {
        sfxMixer.SetFloat("Volume", sfxLevel.value);
    }

    public void Easy()
    {
        SaveScript.maxEnemiesOnScreen = 6;
        SaveScript.maxEnemiesInGame = 100;
    }

    public void Medium()
    {
        SaveScript.maxEnemiesOnScreen = 15;
        SaveScript.maxEnemiesInGame = 300;
    }

    public void Hard()
    {
        SaveScript.maxEnemiesOnScreen = 30;
        SaveScript.maxEnemiesInGame = 600;
    }

    public void AntiAliasingOff()
    {
        if (antiState != 1)
        {
            if (antiOff.isOn == true)
            {
                myLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
                antiFXAA.isOn = false;
                antiSMAA.isOn = false;
                antiTAA.isOn = false;
                antiState = 1;
            }
        }
    }

    public void AntiAliasingFXAA()
    {
        if (antiState != 2)
        {
            if (antiFXAA.isOn == true)
            {
                myLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                antiOff.isOn = false;
                antiSMAA.isOn = false;
                antiTAA.isOn = false;
                antiState = 2;
            }
        }
    }

    public void AntiAliasingSMAA()
    {
        if (antiState != 3)
        {
            if (antiSMAA.isOn == true)
            {
                myLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                antiOff.isOn = false;
                antiFXAA.isOn = false;
                antiTAA.isOn = false;
                antiState = 3;
            }
        }
    }

    public void AntiAliasingTAA()
    {
        if (antiState != 4)
        {
            if (antiTAA.isOn == true)
            {
                myLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                antiOff.isOn = false;
                antiFXAA.isOn = false;
                antiSMAA.isOn = false;
                antiState = 4;
            }
        }
    }

    public void FogState()
    {
        if (fogToggle.isOn == true)
        {
            if (fogOn == true)
            {
                myLayer.fog.enabled = false;
                fogStorm.gameObject.SetActive(false);
                fogOn = false;
            }
            else if (fogOn == false)
            {
                myLayer.fog.enabled = true;
                fogStorm.gameObject.SetActive(true);
                fogOn = true;
            }
        }
        if (fogToggle.isOn == false)
        {
            if (fogOn == true)
            {
                myLayer.fog.enabled = false;
                fogStorm.gameObject.SetActive(false);
                fogOn = false;
            }
            else if (fogOn == false)
            {
                myLayer.fog.enabled = true;
                fogStorm.gameObject.SetActive(true);
                fogOn = true;
            }
        }
    }

    public void Visuals()
    {
        visualsPanel.gameObject.SetActive(true);
        soundsPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(false);
        difficultyPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        backtoMenuPanel.gameObject.SetActive(false);
    }

    public void Sounds()
    {
        visualsPanel.gameObject.SetActive(false);
        soundsPanel.gameObject.SetActive(true);
        controlsPanel.gameObject.SetActive(false);
        difficultyPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        backtoMenuPanel.gameObject.SetActive(false);
    }

    public void Controls()
    {
        visualsPanel.gameObject.SetActive(false);
        soundsPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(true);
        difficultyPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        backtoMenuPanel.gameObject.SetActive(false);
    }

    public void Difficulty()
    {
        visualsPanel.gameObject.SetActive(false);
        soundsPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(false);
        difficultyPanel.gameObject.SetActive(true);
        savePanel.gameObject.SetActive(false);
        backtoMenuPanel.gameObject.SetActive(false);
    }

    public void Save()
    {
        visualsPanel.gameObject.SetActive(false);
        soundsPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(false);
        difficultyPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(true);
        backtoMenuPanel.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        visualsPanel.gameObject.SetActive(false);
        soundsPanel.gameObject.SetActive(false);
        controlsPanel.gameObject.SetActive(false);
        difficultyPanel.gameObject.SetActive(false);
        savePanel.gameObject.SetActive(false);
        backtoMenuPanel.gameObject.SetActive(true);
    }
}
