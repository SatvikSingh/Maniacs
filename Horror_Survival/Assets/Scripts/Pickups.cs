using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] float distance = 4.0f;
    [SerializeField] GameObject pickupMessage;
    [SerializeField] GameObject playerArms;
    [SerializeField] GameObject doorMessage;
    [SerializeField] Text doorText;
    private AudioSource myPlayer;

    private float rayDistance;

    private bool canSeePickup = false;
    private bool canSeeDoor = false;

    private void Start()
    {
        pickupMessage.gameObject.SetActive(false);
        playerArms.gameObject.SetActive(false);
        doorMessage.gameObject.SetActive(false);
        rayDistance = distance;
        myPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            if (hit.transform.tag == "Apple")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Apples < 6)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.applesLeft--;
                        SaveScript.Apples++;
                        myPlayer.Play();
                    }
                }
            }
            else
            {
                canSeePickup = false;
            }

            if (hit.transform.tag == "Battery")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.Batteries < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.batteryLeft--;
                        SaveScript.Batteries++;
                        myPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Knife")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveKnife == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.haveKnife = true;
                        myPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Gun")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveGun == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.haveGun = true;
                        myPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Baseball Bat")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveBat == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.haveBat = true;
                        myPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Crossbow")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveCrossbow == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.haveCrossbow = true;
                        myPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Axe")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveAxe == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.haveAxe = true;
                        myPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Gun Ammo")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.gunAmmo < 4)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.ammoLeft--;
                        SaveScript.gunAmmo++;
                        myPlayer.Play();
                    }
                }
            }
            else if (hit.transform.tag == "Crossbow Ammo")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveCrossbowAmmo == false)
                    {
                        Destroy(hit.transform.gameObject);
                        SaveScript.arrowLeft--;
                        myPlayer.Play();
                        SaveScript.haveCrossbowAmmo = true;
                    }
                }
            }
            else if (hit.transform.tag == "Cabin Key")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveCabinKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        myPlayer.Play();
                        SaveScript.haveCabinKey = true;
                    }
                }
            }
            else if (hit.transform.tag == "House Key")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveHouseKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        myPlayer.Play();
                        SaveScript.haveHouseKey = true;
                    }
                }
            }
            else if (hit.transform.tag == "Room Key")
            {
                canSeePickup = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (SaveScript.haveRoomKey == false)
                    {
                        Destroy(hit.transform.gameObject);
                        myPlayer.Play();
                        SaveScript.haveRoomKey = true;
                    }
                }
            }
            else if (hit.transform.tag == "Door")
            {
                canSeeDoor = true;
                if (hit.transform.gameObject.GetComponent<DoorScript>().locked == false)
                {
                    if (hit.transform.gameObject.GetComponent<DoorScript>().isOpen == false)
                    {
                        doorText.text = "Press 'E' to Open";
                    }
                    if (hit.transform.gameObject.GetComponent<DoorScript>().isOpen == true)
                    {
                        doorText.text = "Press 'E' to Close";
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.transform.gameObject.SendMessage("DoorOpen");
                    }
                }
                else if (hit.transform.gameObject.GetComponent<DoorScript>().locked == true)
                {
                    doorText.text = "You need the " + hit.transform.gameObject.GetComponent<DoorScript>().doorType + " key";
                }
            }
            else
            {
                canSeePickup = false;
                canSeeDoor = false;
            }
        }

        if (canSeePickup == true)
        {
            pickupMessage.gameObject.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeePickup == false)
        {
            pickupMessage.gameObject.SetActive(false);
            rayDistance = distance;
        }
        if (canSeeDoor == true)
        {
            doorMessage.gameObject.SetActive(true);
            rayDistance = 1000f;
        }
        if (canSeeDoor == false)
        {
            doorMessage.gameObject.SetActive(false);
            rayDistance = distance;
        }
    }
}
