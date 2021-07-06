using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int PlayerHealth = 100;
    public static bool healthChanged = false;
    public static float batteryPower = 1.0f;
    public static bool batteryRefill = false;
    public static bool flashlightOn = false;
    public static bool NVlightOn = false;
    public static int Apples = 0;
    public static int Batteries = 0;
    public static bool haveKnife = false;
    public static bool haveAxe = false;
    public static bool haveBat = false;
    public static bool haveGun = false;
    public static bool haveCrossbow = false;
    public static bool haveGunAmmo = false;
    public static bool haveCrossbowAmmo = false;
    public static bool haveCabinKey = false;
    public static bool haveHouseKey = false;
    public static bool haveRoomKey = false;
    public static int gunAmmo = 0;
    public static bool havingKnife = false;
    public static bool havingBat = false;
    public static bool havingAxe = false;
    public static bool havingGun = false;
    public static bool havingCrossbow = false;
    public static int bullets = 12;
    public static int arrows = 8;
    public static bool newGame = false;
    public static bool savedGame = false;
    public static Transform playerChar;
    public static GameObject chase;
    public static GameObject hurtScreen;
    public static AudioSource stabSound;
    public static GameObject splatKnife;
    public static GameObject splatBat;
    public static GameObject splatAxe;
    public static Animator hurt;
    public static AudioSource audioPlayer;
    public static GameObject arms;
    public static int maxEnemiesOnScreen = 15;
    public static int enemiesOnScreen = 0;
    public static int maxEnemiesInGame = 300;
    public static int enemiesCurrent = 0;
    public static int applesLeft = 10;
    public static int ammoLeft = 4;
    public static int batteryLeft = 4;
    public static int arrowLeft = 3;
    public static int enemy1 = 1;
    public static int enemy2 = 1;
    public static int enemy3 = 1;
    public static bool inventoryOpen = false;
    public static bool optionsOpen = false;

    [SerializeField] Transform playerPrefab;
    [SerializeField] GameObject chaseMusic;
    [SerializeField] GameObject hurtUI;
    [SerializeField] AudioSource stabPlayer;
    [SerializeField] GameObject bloodSplatKnife;
    [SerializeField] GameObject bloodSplatBat;
    [SerializeField] GameObject bloodSplatAxe;
    [SerializeField] Animator hurtAnim;
    [SerializeField] AudioSource myPlayer;
    [SerializeField] GameObject FPSArms;

    // Targets
    public static Transform target1;
    public static Transform target2;
    public static Transform target3;
    public static Transform target4;
    public static Transform target5;
    public static Transform target6;
    public static Transform target7;
    public static Transform target8;
    public static Transform target9;
    public static Transform target10;
    [SerializeField] Transform _target1;
    [SerializeField] Transform _target2;
    [SerializeField] Transform _target3;
    [SerializeField] Transform _target4;
    [SerializeField] Transform _target5;
    [SerializeField] Transform _target6;
    [SerializeField] Transform _target7;
    [SerializeField] Transform _target8;
    [SerializeField] Transform _target9;
    [SerializeField] Transform _target10;

    private void Start()
    {
        target1 = _target1;
        target2 = _target2;
        target3 = _target3;
        target4 = _target4;
        target5 = _target5;
        target6 = _target6;
        target7 = _target7;
        target8 = _target8;
        target9 = _target9;
        target10 = _target10;
        playerChar = playerPrefab;
        chase = chaseMusic;
        hurtScreen = hurtUI;
        stabSound = stabPlayer;
        splatKnife = bloodSplatKnife;
        splatBat = bloodSplatBat;
        splatAxe = bloodSplatAxe;
        hurt = hurtAnim;
        audioPlayer = myPlayer;
        arms = FPSArms;

        if (newGame == true)
        {
            PlayerHealth = 100;
            healthChanged = true;
            batteryPower = 1.0f;
            batteryRefill = false;
            flashlightOn = false;
            NVlightOn = false;
            Apples = 0;
            Batteries = 0;
            haveKnife = false;
            haveAxe = false;
            haveBat = false;
            haveGun = false;
            haveCrossbow = false;
            haveGunAmmo = false;
            haveCrossbowAmmo = false;
            haveCabinKey = false;
            haveHouseKey = false;
            haveRoomKey = false;
            gunAmmo = 0;
            havingKnife = false;
            havingBat = false;
            havingAxe = false;
            havingGun = false;
            havingCrossbow = false;
            bullets = 12;
            arrows = 8;
            newGame = false;
            applesLeft = 10;
            ammoLeft = 4;
            batteryLeft = 4;
            arrowLeft = 2;
            enemy1 = 1;
            enemy2 = 1;
            enemy3 = 1;
            inventoryOpen = false;
            optionsOpen = false;
        }

        if (savedGame == true)
        {
            PlayerHealth = PlayerPrefs.GetInt("PlayersHealth");
            healthChanged = true;
            batteryPower = PlayerPrefs.GetFloat("BatteriesPower");
            Apples = PlayerPrefs.GetInt("AppleCount");
            Batteries = PlayerPrefs.GetInt("BatteryCount");
            bullets = PlayerPrefs.GetInt("BulletCount");
            arrows = PlayerPrefs.GetInt("ArrowCount");
            gunAmmo = PlayerPrefs.GetInt("GunClips");
            maxEnemiesOnScreen = PlayerPrefs.GetInt("MaxEScreen");
            maxEnemiesInGame = PlayerPrefs.GetInt("MaxEGame");
            applesLeft = PlayerPrefs.GetInt("ApplesL");
            ammoLeft = PlayerPrefs.GetInt("AmmoL");
            batteryLeft = PlayerPrefs.GetInt("BatteryL");
            arrowLeft = PlayerPrefs.GetInt("ArrowL");
            enemy1 = PlayerPrefs.GetInt("Enemy1Alive");
            enemy2 = PlayerPrefs.GetInt("Enemy2Alive");
            enemy3 = PlayerPrefs.GetInt("Enemy3Alive");

            if (PlayerPrefs.GetInt("KnifeInv") == 1)
            {
                haveKnife = true;
            }
            if (PlayerPrefs.GetInt("BatInv") == 1)
            {
                haveBat = true;
            }
            if (PlayerPrefs.GetInt("AxeInv") == 1)
            {
                haveAxe = true;
            }
            if (PlayerPrefs.GetInt("GunInv") == 1)
            {
                haveGun = true;
            }
            if (PlayerPrefs.GetInt("CrossbowInv") == 1)
            {
                haveCrossbow = true;
            }
            if (PlayerPrefs.GetInt("CabinKeyInv") == 1)
            {
                haveCabinKey = true;
            }
            if (PlayerPrefs.GetInt("HouseKeyInv") == 1)
            {
                haveHouseKey = true;
            }
            if (PlayerPrefs.GetInt("RoomKeyInv") == 1)
            {
                haveRoomKey = true;
            }
            savedGame = false;
            inventoryOpen = false;
            optionsOpen = false;
        }
    }
}
