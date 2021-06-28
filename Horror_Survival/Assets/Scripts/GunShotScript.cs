using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotScript : MonoBehaviour
{
    RaycastHit hit;

    void Update()
    {
        if (SaveScript.havingGun == true)
        {
            if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (SaveScript.bullets > 0)
                {
                    if (Physics.Raycast(transform.position, transform.forward, out hit, 3000))
                    {
                        if (hit.transform.Find("Body"))
                        {
                            hit.transform.gameObject.GetComponentInChildren<EnemyDamage>().enemyHealth -= Random.Range(30, 101);
                            hit.transform.gameObject.GetComponent<Animator>().SetTrigger("BigReact");
                        }
                    }
                }
            }
        }
    }
}
