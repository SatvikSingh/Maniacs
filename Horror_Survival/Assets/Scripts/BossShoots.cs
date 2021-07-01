using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoots : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform shootScript;

    private bool canShoot = false;


    void Start()
    {
        shootScript.GetComponent<SimpleShoot1>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canShoot = true;
            anim.SetTrigger("AimShoot");
            StartCoroutine(ShootPlayer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canShoot = false;
            StartCoroutine(ShootPlayer());
        }
    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(1.0f);
        if (canShoot == true)
        {
            shootScript.GetComponent<SimpleShoot1>().enabled = true;
        }
        if (canShoot == false)
        {
            shootScript.GetComponent<SimpleShoot1>().enabled = false;
        }
    }
}
