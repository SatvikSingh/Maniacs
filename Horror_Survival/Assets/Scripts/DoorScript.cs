using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator anim;
    public bool isOpen = false;
    private AudioSource myPlayer;
    [SerializeField] bool cabin;
    [SerializeField] bool room;
    [SerializeField] bool house;
    public bool locked;
    public string doorType;

    // Audio Clips
    [SerializeField] AudioClip cabinSound;
    [SerializeField] AudioClip roomSound;
    [SerializeField] AudioClip houseSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        myPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (cabin == true)
        {
            doorType = "Cabin";
            if (SaveScript.haveCabinKey == true)
            {
                locked = false;
            }
        }
        if (room == true)
        {
            doorType = "Room";
            if (SaveScript.haveRoomKey == true)
            {
                locked = false;
            }
        }
        if (house == true)
        {
            doorType = "House";
            if (SaveScript.haveHouseKey == true)
            {
                locked = false;
            }
        }
    }

    public void DoorOpen()
    {
        if (isOpen == false)
        {
            anim.SetTrigger("Open");
            isOpen = true;
            if (cabin == true)
            {
                myPlayer.clip = cabinSound;
                myPlayer.Play();
            }
            if (room == true)
            {
                myPlayer.clip = roomSound;
                myPlayer.Play();
            }
            if (house == true)
            {
                myPlayer.clip = houseSound;
                myPlayer.Play();
            }
        }
        else if (isOpen == true)
        {
            anim.SetTrigger("Close");
            isOpen = false;
            if (cabin == true)
            {
                myPlayer.clip = cabinSound;
                myPlayer.Play();
            }
            if (room == true)
            {
                myPlayer.clip = roomSound;
                myPlayer.Play();
            }
            if (house == true)
            {
                myPlayer.clip = houseSound;
                myPlayer.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (locked == false)
            {
                if (isOpen == false)
                {
                    anim.SetTrigger("Open");
                    isOpen = true;
                }
            }
        }
    }
}
