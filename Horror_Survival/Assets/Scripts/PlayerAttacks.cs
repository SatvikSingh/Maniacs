using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private Animator anim;

    public float attackStamina;
    [SerializeField] float attackDrain = 2;
    [SerializeField] float attackRefill = 1;
    [SerializeField] float maxAttackStamina = 10;
    [SerializeField] GameObject pointer;
    [SerializeField] AudioClip gunShotSound;
    [SerializeField] AudioClip arrowShotSound;
    private AudioSource myPlayer;
    [SerializeField] Camera FPSCamera;

    private void Start()
    {
        anim = GetComponent<Animator>();
        attackStamina = maxAttackStamina;
        pointer.gameObject.SetActive(true);
        myPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (attackStamina < maxAttackStamina)
        {
            attackStamina += attackRefill * Time.deltaTime;
        }
        if (attackStamina <= 0.1)
        {
            attackStamina = 0.1f;
        }

        if (attackStamina > 3.0f)
        {
            if (SaveScript.inventoryOpen == false && SaveScript.optionsOpen == false)
            {
                if (SaveScript.havingKnife == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        anim.SetTrigger("KnifeLMB");
                        attackStamina -= attackDrain;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("KnifeRMB");
                        attackStamina -= attackDrain;
                    }
                }
                if (SaveScript.havingBat == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        anim.SetTrigger("BatLMB");
                        attackStamina -= attackDrain;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("BatRMB");
                        attackStamina -= attackDrain;
                    }
                }
                if (SaveScript.havingAxe == true)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        anim.SetTrigger("AxeLMB");
                        attackStamina -= attackDrain;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse1))
                    {
                        anim.SetTrigger("AxeRMB");
                        attackStamina -= attackDrain;
                    }
                }
                if (SaveScript.havingGun == true)
                {
                    if (Input.GetKey(KeyCode.Mouse1))
                    {
                        anim.SetBool("AimGun", true);
                        pointer.gameObject.SetActive(false);
                        FPSCamera.fieldOfView = 50.0f;
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse1))
                    {
                        anim.SetBool("AimGun", false);
                        pointer.gameObject.SetActive(true);
                        FPSCamera.fieldOfView = 75.0f;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (SaveScript.bullets > 0)
                        {
                            myPlayer.clip = gunShotSound;
                            myPlayer.Play();
                        }
                    }
                }
                if (SaveScript.havingCrossbow == true)
                {
                    if (Input.GetKey(KeyCode.Mouse1))
                    {
                        anim.SetBool("AimCrossbow", true);
                        pointer.gameObject.SetActive(false);
                        FPSCamera.fieldOfView = 50.0f;
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse1))
                    {
                        anim.SetBool("AimCrossbow", false);
                        pointer.gameObject.SetActive(true);
                        FPSCamera.fieldOfView = 75.0f;
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (SaveScript.arrows > 0)
                        {
                            myPlayer.clip = arrowShotSound;
                            myPlayer.Play();
                        }
                    }
                }
            }
        }
    }
}
