using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject axe;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject crossbow;
    [SerializeField] GameObject cabinKey;
    [SerializeField] GameObject houseKey;
    [SerializeField] GameObject roomKey;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;

    void Start()
    {
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(1.0f);
        if (SaveScript.haveKnife == true)
        {
            Destroy(knife.gameObject);
        }
        if (SaveScript.haveBat == true)
        {
            Destroy(bat.gameObject);
        }
        if (SaveScript.haveAxe == true)
        {
            Destroy(axe.gameObject);
        }
        if (SaveScript.haveGun == true)
        {
            Destroy(gun.gameObject);
        }
        if (SaveScript.haveCrossbow == true)
        {
            Destroy(crossbow.gameObject);
        }
        if (SaveScript.haveCabinKey == true)
        {
            Destroy(cabinKey.gameObject);
        }
        if (SaveScript.haveHouseKey == true)
        {
            Destroy(houseKey.gameObject);
        }
        if (SaveScript.haveRoomKey == true)
        {
            Destroy(roomKey.gameObject);
        }

        if (SaveScript.enemy1 == 0)
        {
            Destroy(enemy1.gameObject);
        }
        if (SaveScript.enemy2 == 0)
        {
            Destroy(enemy2.gameObject);
        }
        if (SaveScript.enemy3 == 0)
        {
            Destroy(enemy3.gameObject);
        }
    }
}
