using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] int weaponDamage = 1;
    [SerializeField] Animator hurtAnim;
    [SerializeField] AudioSource myPlayer;
    [SerializeField] GameObject FPSArms;

    private bool hitActive = false;

    private void Start()
    {
        StartCoroutine(StartElements());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == false)
            {
                hitActive = true;
                hurtAnim.SetTrigger("Hurt");
                SaveScript.PlayerHealth -= weaponDamage;
                SaveScript.healthChanged = true;
                myPlayer.Play();
                FPSArms.GetComponent<PlayerAttacks>().attackStamina -= 0.2f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hitActive == true)
            {
                hitActive = false;
            }
        }
    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        hurtAnim = SaveScript.hurt;
        myPlayer = SaveScript.audioPlayer;
        FPSArms = SaveScript.arms;
    }
}
