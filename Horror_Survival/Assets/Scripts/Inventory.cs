using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool InventoryisActive = false;
    public GameObject Inventory_Overlay;
    private AudioSource myPlayer;
    private bool optionsActive;
    [SerializeField] GameObject playerArms;
    [SerializeField] Animator anim;

    [SerializeField] GameObject GunUI;
    [SerializeField] GameObject bulletAmount;
    [SerializeField] GameObject crossbowUI;
    [SerializeField] GameObject arrowAmount;

    // Audio Clips
    [SerializeField] AudioClip appleBite;
    [SerializeField] AudioClip batteryChange;
    [SerializeField] AudioClip weaponChange;
    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip arrowShot;

    // Weapons
    [SerializeField] GameObject knife;
    [SerializeField] GameObject Bat;
    [SerializeField] GameObject Axe;
    [SerializeField] GameObject Gun;
    [SerializeField] GameObject Crossbow;

    // Apples
    [SerializeField] GameObject appleImage001;
    [SerializeField] GameObject appleButton001;
    [SerializeField] GameObject appleImage002;
    [SerializeField] GameObject appleButton002;
    [SerializeField] GameObject appleImage003;
    [SerializeField] GameObject appleButton003;
    [SerializeField] GameObject appleImage004;
    [SerializeField] GameObject appleButton004;
    [SerializeField] GameObject appleImage005;
    [SerializeField] GameObject appleButton005;
    [SerializeField] GameObject appleImage006;
    [SerializeField] GameObject appleButton006;

    // Batteries
    [SerializeField] GameObject batteryImage001;
    [SerializeField] GameObject batteryButton001;
    [SerializeField] GameObject batteryImage002;
    [SerializeField] GameObject batteryButton002;
    [SerializeField] GameObject batteryImage003;
    [SerializeField] GameObject batteryButton003;
    [SerializeField] GameObject batteryImage004;
    [SerializeField] GameObject batteryButton004;

    // Weapons
    [SerializeField] GameObject knifeImage;
    [SerializeField] GameObject knifeButton;
    [SerializeField] GameObject axeImage;
    [SerializeField] GameObject axeButton;
    [SerializeField] GameObject batImage;
    [SerializeField] GameObject batButton;
    [SerializeField] GameObject gunImage;
    [SerializeField] GameObject gunButton;
    [SerializeField] GameObject crossbowImage;
    [SerializeField] GameObject crossbowButton;

    // Ammo
    [SerializeField] GameObject gunAmmoImage001;
    [SerializeField] GameObject gunAmmoButton001;
    [SerializeField] GameObject gunAmmoImage002;
    [SerializeField] GameObject gunAmmoButton002;
    [SerializeField] GameObject gunAmmoImage003;
    [SerializeField] GameObject gunAmmoButton003;
    [SerializeField] GameObject gunAmmoImage004;
    [SerializeField] GameObject gunAmmoButton004;
    [SerializeField] GameObject crossbowAmmoImage;
    [SerializeField] GameObject crossbowAmmoButton;

    // Keys
    [SerializeField] GameObject cabinKeyImage;
    [SerializeField] GameObject houseKeyImage;
    [SerializeField] GameObject roomKeyImage;

    [SerializeField] GameObject optionsMenu;

    private void Start()
    {
        Inventory_Overlay.SetActive(false);
        InventoryisActive = false;
        Cursor.visible = false;
        Time.timeScale = 1;
        myPlayer = GetComponent<AudioSource>();
        GunUI.gameObject.SetActive(false);
        bulletAmount.gameObject.SetActive(false);
        crossbowUI.gameObject.SetActive(false);
        arrowAmount.gameObject.SetActive(false);
        optionsMenu.gameObject.SetActive(false);

        // Apples
        appleImage001.SetActive(false);
        appleButton001.SetActive(false);
        appleImage002.SetActive(false);
        appleButton002.SetActive(false);
        appleImage003.SetActive(false);
        appleButton003.SetActive(false);
        appleImage004.SetActive(false);
        appleButton004.SetActive(false);
        appleImage005.SetActive(false);
        appleButton005.SetActive(false);
        appleImage006.SetActive(false);
        appleButton006.SetActive(false);

        // Batteries
        batteryButton001.SetActive(false);
        batteryImage001.SetActive(false);
        batteryButton002.SetActive(false);
        batteryImage002.SetActive(false);
        batteryButton003.SetActive(false);
        batteryImage003.SetActive(false);
        batteryButton004.SetActive(false);
        batteryImage004.SetActive(false);

        // Weapons
        knifeImage.SetActive(false);
        knifeButton.SetActive(false);
        axeImage.SetActive(false);
        axeButton.SetActive(false);
        batImage.SetActive(false);
        batButton.SetActive(false);
        gunImage.SetActive(false);
        gunButton.SetActive(false);
        crossbowImage.SetActive(false);
        crossbowButton.SetActive(false);

        // Ammo 
        gunAmmoImage001.SetActive(false);
        gunAmmoButton001.SetActive(false);
        gunAmmoImage002.SetActive(false);
        gunAmmoButton002.SetActive(false);
        gunAmmoImage003.SetActive(false);
        gunAmmoButton003.SetActive(false);
        gunAmmoImage004.SetActive(false);
        gunAmmoButton004.SetActive(false);
        crossbowAmmoImage.SetActive(false);
        crossbowAmmoButton.SetActive(false);

        // Keys
        cabinKeyImage.SetActive(false);
        houseKeyImage.SetActive(false);
        roomKeyImage.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (optionsActive == false)
            {
                optionsMenu.gameObject.SetActive(true);
                SaveScript.optionsOpen = true;
                optionsActive = true;
            }
            else if (optionsActive == true)
            {
                optionsMenu.gameObject.SetActive(false);
                SaveScript.optionsOpen = false;
                optionsActive = false;
                Time.timeScale = 1;
                Cursor.visible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryisActive == false)
            {
                InventoryisActive = true;
                Inventory_Overlay.SetActive(true);
                SaveScript.inventoryOpen = true;
                Time.timeScale = 0f;
                Cursor.visible = true;
            }
            else
            {
                InventoryisActive = false;
                Inventory_Overlay.SetActive(false);
                SaveScript.inventoryOpen = false;
                Time.timeScale = 1f;
                Cursor.visible = false;
            }
        }
        CheckInventory();
        CheckWeapons();
        CheckGunAmmo();
        CheckCrossbowAmmo();
        CheckKeys();
    }

    void CheckInventory()
    {
        // Apples
        if (SaveScript.Apples == 0)
        {
            appleButton001.gameObject.SetActive(false);
            appleImage001.gameObject.SetActive(false);
            appleButton002.gameObject.SetActive(false);
            appleImage002.gameObject.SetActive(false);
            appleButton003.gameObject.SetActive(false);
            appleImage003.gameObject.SetActive(false);
            appleButton004.gameObject.SetActive(false);
            appleImage004.gameObject.SetActive(false);
            appleButton005.gameObject.SetActive(false);
            appleImage005.gameObject.SetActive(false);
            appleButton006.gameObject.SetActive(false);
            appleImage006.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 1)
        {
            appleButton001.gameObject.SetActive(true);
            appleImage001.gameObject.SetActive(true);
            appleButton002.gameObject.SetActive(false);
            appleImage002.gameObject.SetActive(false);
            appleButton003.gameObject.SetActive(false);
            appleImage003.gameObject.SetActive(false);
            appleButton004.gameObject.SetActive(false);
            appleImage004.gameObject.SetActive(false);
            appleButton005.gameObject.SetActive(false);
            appleImage005.gameObject.SetActive(false);
            appleButton006.gameObject.SetActive(false);
            appleImage006.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 2)
        {
            appleButton001.gameObject.SetActive(true);
            appleImage001.gameObject.SetActive(true);
            appleButton002.gameObject.SetActive(true);
            appleImage002.gameObject.SetActive(true);
            appleButton003.gameObject.SetActive(false);
            appleImage003.gameObject.SetActive(false);
            appleButton004.gameObject.SetActive(false);
            appleImage004.gameObject.SetActive(false);
            appleButton005.gameObject.SetActive(false);
            appleImage005.gameObject.SetActive(false);
            appleButton006.gameObject.SetActive(false);
            appleImage006.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 3)
        {
            appleButton001.gameObject.SetActive(true);
            appleImage001.gameObject.SetActive(true);
            appleButton002.gameObject.SetActive(true);
            appleImage002.gameObject.SetActive(true);
            appleButton003.gameObject.SetActive(true);
            appleImage003.gameObject.SetActive(true);
            appleButton004.gameObject.SetActive(false);
            appleImage004.gameObject.SetActive(false);
            appleButton005.gameObject.SetActive(false);
            appleImage005.gameObject.SetActive(false);
            appleButton006.gameObject.SetActive(false);
            appleImage006.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 4)
        {
            appleButton001.gameObject.SetActive(true);
            appleImage001.gameObject.SetActive(true);
            appleButton002.gameObject.SetActive(true);
            appleImage002.gameObject.SetActive(true);
            appleButton003.gameObject.SetActive(true);
            appleImage003.gameObject.SetActive(true);
            appleButton004.gameObject.SetActive(true);
            appleImage004.gameObject.SetActive(true);
            appleButton005.gameObject.SetActive(false);
            appleImage005.gameObject.SetActive(false);
            appleButton006.gameObject.SetActive(false);
            appleImage006.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 5)
        {
            appleButton001.gameObject.SetActive(true);
            appleImage001.gameObject.SetActive(true);
            appleButton002.gameObject.SetActive(true);
            appleImage002.gameObject.SetActive(true);
            appleButton003.gameObject.SetActive(true);
            appleImage003.gameObject.SetActive(true);
            appleButton004.gameObject.SetActive(true);
            appleImage004.gameObject.SetActive(true);
            appleButton005.gameObject.SetActive(true);
            appleImage005.gameObject.SetActive(true);
            appleButton006.gameObject.SetActive(false);
            appleImage006.gameObject.SetActive(false);
        }
        if (SaveScript.Apples == 6)
        {
            appleButton001.gameObject.SetActive(true);
            appleImage001.gameObject.SetActive(true);
            appleButton002.gameObject.SetActive(true);
            appleImage002.gameObject.SetActive(true);
            appleButton003.gameObject.SetActive(true);
            appleImage003.gameObject.SetActive(true);
            appleButton004.gameObject.SetActive(true);
            appleImage004.gameObject.SetActive(true);
            appleButton005.gameObject.SetActive(true);
            appleImage005.gameObject.SetActive(true);
            appleButton006.gameObject.SetActive(true);
            appleImage006.gameObject.SetActive(true);
        }

        // Batteries
        if (SaveScript.Batteries == 0)
        {
            batteryImage001.gameObject.SetActive(false);
            batteryButton001.gameObject.SetActive(false);
            batteryImage002.gameObject.SetActive(false);
            batteryButton002.gameObject.SetActive(false);
            batteryImage003.gameObject.SetActive(false);
            batteryButton003.gameObject.SetActive(false);
            batteryImage004.gameObject.SetActive(false);
            batteryButton004.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 1)
        {
            batteryImage001.gameObject.SetActive(true);
            batteryButton001.gameObject.SetActive(true);
            batteryImage002.gameObject.SetActive(false);
            batteryButton002.gameObject.SetActive(false);
            batteryImage003.gameObject.SetActive(false);
            batteryButton003.gameObject.SetActive(false);
            batteryImage004.gameObject.SetActive(false);
            batteryButton004.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 2)
        {
            batteryImage001.gameObject.SetActive(true);
            batteryButton001.gameObject.SetActive(true);
            batteryImage002.gameObject.SetActive(true);
            batteryButton002.gameObject.SetActive(true);
            batteryImage003.gameObject.SetActive(false);
            batteryButton003.gameObject.SetActive(false);
            batteryImage004.gameObject.SetActive(false);
            batteryButton004.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 3)
        {
            batteryImage001.gameObject.SetActive(true);
            batteryButton001.gameObject.SetActive(true);
            batteryImage002.gameObject.SetActive(true);
            batteryButton002.gameObject.SetActive(true);
            batteryImage003.gameObject.SetActive(true);
            batteryButton003.gameObject.SetActive(true);
            batteryImage004.gameObject.SetActive(false);
            batteryButton004.gameObject.SetActive(false);
        }
        if (SaveScript.Batteries == 4)
        {
            batteryImage001.gameObject.SetActive(true);
            batteryButton001.gameObject.SetActive(true);
            batteryImage002.gameObject.SetActive(true);
            batteryButton002.gameObject.SetActive(true);
            batteryImage003.gameObject.SetActive(true);
            batteryButton003.gameObject.SetActive(true);
            batteryImage004.gameObject.SetActive(true);
            batteryButton004.gameObject.SetActive(true);
        }
    }

    void CheckWeapons()
    {
        if (SaveScript.haveKnife == true)
        {
            knifeImage.SetActive(true);
            knifeButton.SetActive(true);
        }
        if (SaveScript.haveBat == true)
        {
            batImage.SetActive(true);
            batButton.SetActive(true);
        }
        if (SaveScript.haveAxe == true)
        {
            axeImage.SetActive(true);
            axeButton.SetActive(true);
        }
        if (SaveScript.haveGun == true)
        {
            gunImage.SetActive(true);
            gunButton.SetActive(true);
        }
        if (SaveScript.haveCrossbow == true)
        {
            crossbowImage.SetActive(true);
            crossbowButton.SetActive(true);
        }
    }

    void CheckGunAmmo()
    {
        if (SaveScript.gunAmmo == 0)
        {
            gunAmmoImage001.SetActive(false);
            gunAmmoButton001.SetActive(false);
            gunAmmoImage002.SetActive(false);
            gunAmmoButton002.SetActive(false);
            gunAmmoImage003.SetActive(false);
            gunAmmoButton003.SetActive(false);
            gunAmmoImage004.SetActive(false);
            gunAmmoButton004.SetActive(false);
        }
        if (SaveScript.gunAmmo == 1)
        {
            gunAmmoImage001.SetActive(true);
            gunAmmoButton001.SetActive(true);
            gunAmmoImage002.SetActive(false);
            gunAmmoButton002.SetActive(false);
            gunAmmoImage003.SetActive(false);
            gunAmmoButton003.SetActive(false);
            gunAmmoImage004.SetActive(false);
            gunAmmoButton004.SetActive(false);
        }
        if (SaveScript.gunAmmo == 2)
        {
            gunAmmoImage001.SetActive(true);
            gunAmmoButton001.SetActive(true);
            gunAmmoImage002.SetActive(true);
            gunAmmoButton002.SetActive(true);
            gunAmmoImage003.SetActive(false);
            gunAmmoButton003.SetActive(false);
            gunAmmoImage004.SetActive(false);
            gunAmmoButton004.SetActive(false);
        }
        if (SaveScript.gunAmmo == 3)
        {
            gunAmmoImage001.SetActive(true);
            gunAmmoButton001.SetActive(true);
            gunAmmoImage002.SetActive(true);
            gunAmmoButton002.SetActive(true);
            gunAmmoImage003.SetActive(true);
            gunAmmoButton003.SetActive(true);
            gunAmmoImage004.SetActive(false);
            gunAmmoButton004.SetActive(false);
        }
        if (SaveScript.gunAmmo == 4)
        {
            gunAmmoImage001.SetActive(true);
            gunAmmoButton001.SetActive(true);
            gunAmmoImage002.SetActive(true);
            gunAmmoButton002.SetActive(true);
            gunAmmoImage003.SetActive(true);
            gunAmmoButton003.SetActive(true);
            gunAmmoImage004.SetActive(true);
            gunAmmoButton004.SetActive(true);
        }
    }

    void CheckCrossbowAmmo()
    {
        if (SaveScript.haveCrossbowAmmo == true)
        {
            crossbowAmmoImage.SetActive(true);
            crossbowAmmoButton.SetActive(true);
        }
    }

    void CheckKeys()
    {
        if (SaveScript.haveCabinKey == true)
        {
            cabinKeyImage.SetActive(true);
        }
        if (SaveScript.haveHouseKey == true)
        {
            houseKeyImage.SetActive(true);
        }
        if (SaveScript.haveRoomKey == true)
        {
            roomKeyImage.SetActive(true);
        }
    }

    public void HealthUpdate()
    {
        if (SaveScript.PlayerHealth < 100)
        {
            SaveScript.PlayerHealth += 10;
            SaveScript.healthChanged = true;
            SaveScript.Apples--;
            myPlayer.clip = appleBite;
            myPlayer.Play();

            if (SaveScript.PlayerHealth > 100)
            {
                SaveScript.PlayerHealth = 100;
            }
        }
    }

    public void BatteryUpdate()
    {
        SaveScript.batteryRefill = true;
        SaveScript.Batteries--;
        myPlayer.clip = batteryChange;
        myPlayer.Play();
    }

    public void GunAmmoUpdate()
    {
        SaveScript.gunAmmo--;
        SaveScript.bullets = 12;
        myPlayer.Play();
    }

    public void CrossbowAmmoUpdate()
    {
        SaveScript.haveCrossbowAmmo = false;
        SaveScript.arrows = 8;
        myPlayer.Play();
    }

    public void WieldKnife()
    {
        playerArms.gameObject.SetActive(true);
        knife.gameObject.SetActive(true);
        Axe.gameObject.SetActive(false);
        Bat.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
        myPlayer.clip = weaponChange;
        myPlayer.Play();
        SaveScript.havingKnife = true;
        SaveScript.havingBat = false;
        SaveScript.havingAxe = false;
        SaveScript.havingGun = false;
        SaveScript.havingCrossbow = false;
        anim.SetBool("Melee", true);
        GunUI.gameObject.SetActive(false);
        bulletAmount.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
        crossbowUI.gameObject.SetActive(false);
    }

    public void WieldBat()
    {
        playerArms.gameObject.SetActive(true);
        Bat.gameObject.SetActive(true);
        knife.gameObject.SetActive(false);
        Axe.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
        myPlayer.clip = weaponChange;
        myPlayer.Play();
        SaveScript.havingKnife = false;
        SaveScript.havingBat = true;
        SaveScript.havingAxe = false;
        SaveScript.havingGun = false;
        SaveScript.havingCrossbow = false;
        anim.SetBool("Melee", true);
        GunUI.gameObject.SetActive(false);
        bulletAmount.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
        crossbowUI.gameObject.SetActive(false);
    }

    public void WieldAxe()
    {
        playerArms.gameObject.SetActive(true);
        Axe.gameObject.SetActive(true);
        knife.gameObject.SetActive(false);
        Bat.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
        myPlayer.clip = weaponChange;
        myPlayer.Play();
        SaveScript.havingKnife = false;
        SaveScript.havingBat = false;
        SaveScript.havingAxe = true;
        SaveScript.havingGun = false;
        SaveScript.havingCrossbow = false;
        anim.SetBool("Melee", true);
        GunUI.gameObject.SetActive(false);
        bulletAmount.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(false);
        crossbowUI.gameObject.SetActive(false);
    }

    public void WieldGun()
    {
        playerArms.gameObject.SetActive(true);
        Axe.gameObject.SetActive(false);
        knife.gameObject.SetActive(false);
        Bat.gameObject.SetActive(false);
        Gun.gameObject.SetActive(true);
        Crossbow.gameObject.SetActive(false);
        GunUI.gameObject.SetActive(true);
        bulletAmount.gameObject.SetActive(true);
        myPlayer.clip = gunShot;
        myPlayer.Play();
        SaveScript.havingKnife = false;
        SaveScript.havingBat = false;
        SaveScript.havingAxe = false;
        SaveScript.havingGun = true;
        SaveScript.havingCrossbow = false;
        anim.SetBool("Melee", false);
        Crossbow.gameObject.SetActive(false);
        crossbowUI.gameObject.SetActive(false);
    }

    public void WieldCrossbow()
    {
        playerArms.gameObject.SetActive(true);
        Axe.gameObject.SetActive(false);
        knife.gameObject.SetActive(false);
        Bat.gameObject.SetActive(false);
        Gun.gameObject.SetActive(false);
        Crossbow.gameObject.SetActive(true);
        crossbowUI.gameObject.SetActive(true);
        arrowAmount.gameObject.SetActive(true);
        myPlayer.clip = arrowShot;
        myPlayer.Play();
        SaveScript.havingKnife = false;
        SaveScript.havingBat = false;
        SaveScript.havingAxe = false;
        SaveScript.havingGun = false;
        SaveScript.havingCrossbow = true;
        anim.SetBool("Melee", false);
        GunUI.gameObject.SetActive(false);
        bulletAmount.gameObject.SetActive(false);
    }
}

