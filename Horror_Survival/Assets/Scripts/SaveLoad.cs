using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public int dataExists = 10;
    [SerializeField] GameObject loadButton;

    void Start()
    {
        if (loadButton != null)
        {
            loadButton.gameObject.SetActive(false);
            dataExists = PlayerPrefs.GetInt("PlayersHealth", 0);
            if (dataExists > 0)
            {
                loadButton.gameObject.SetActive(true);
            }
        }
    }

    public void LoadGameData()
    {
        SaveScript.savedGame = true;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("PlayersHealth", SaveScript.PlayerHealth);
        PlayerPrefs.SetFloat("BatteriesPower", SaveScript.batteryPower);
        PlayerPrefs.SetInt("AppleCount", SaveScript.Apples);
        PlayerPrefs.SetInt("BatteryCount", SaveScript.Batteries);
        PlayerPrefs.SetInt("BulletCount", SaveScript.bullets);
        PlayerPrefs.SetInt("ArrowCount", SaveScript.arrows);
        PlayerPrefs.SetInt("GunClips", SaveScript.gunAmmo);
        PlayerPrefs.SetInt("MaxEScreen", SaveScript.maxEnemiesOnScreen);
        PlayerPrefs.SetInt("MaxEGame", SaveScript.maxEnemiesInGame);
        PlayerPrefs.SetInt("ApplesL", SaveScript.applesLeft);
        PlayerPrefs.SetInt("AmmoL", SaveScript.ammoLeft);
        PlayerPrefs.SetInt("BatteryL", SaveScript.batteryLeft);
        PlayerPrefs.SetInt("ArrowL", SaveScript.arrowLeft);
        PlayerPrefs.SetInt("Enemy1Alive", SaveScript.enemy1);
        PlayerPrefs.SetInt("Enemy2Alive", SaveScript.enemy2);
        PlayerPrefs.SetInt("Enemy3Alive", SaveScript.enemy3);

        if (SaveScript.haveKnife == true)
        {
            PlayerPrefs.SetInt("KnifeInv", 1);
        }
        if (SaveScript.haveBat == true)
        {
            PlayerPrefs.SetInt("BatInv", 1);
        }
        if (SaveScript.haveAxe == true)
        {
            PlayerPrefs.SetInt("AxeInv", 1);
        }
        if (SaveScript.haveGun == true)
        {
            PlayerPrefs.SetInt("GunInv", 1);
        }
        if (SaveScript.haveCrossbow == true)
        {
            PlayerPrefs.SetInt("CrossbowInv", 1);
        }
        if (SaveScript.haveCabinKey == true)
        {
            PlayerPrefs.SetInt("CabinKeyInv", 1);
        }
        if (SaveScript.haveHouseKey == true)
        {
            PlayerPrefs.SetInt("HouseKeyInv", 1);
        }
        if (SaveScript.haveRoomKey == true)
        {
            PlayerPrefs.SetInt("RoomKeyInv", 1);
        }
    }
}
