using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack : MonoBehaviour
{
    private NavMeshAgent nav;
    private float distanceFromPlayer;
    private AnimatorStateInfo bossInfo;

    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] GameObject enemy;
    [SerializeField] float attackRotateSpeed = 2.0f;
    [SerializeField] GameObject chaseMusic;
    [SerializeField] GameObject hurtUI;
    [SerializeField] GameObject enemyDamageZone;
    [SerializeField] Transform shootScript;

    void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        bossInfo = anim.GetCurrentAnimatorStateInfo(0);
        distanceFromPlayer = Vector3.Distance(player.position, enemy.transform.position);
        if (bossInfo.IsTag("Chase"))
        {
            if (enemyDamageZone.GetComponent<EnemyDamage>().hasDied == false)
            {
                chaseMusic.gameObject.SetActive(true);
                nav.isStopped = false;
                nav.acceleration = 25;
                nav.SetDestination(player.position);
                hurtUI.gameObject.SetActive(false);
            }
        }
        if (bossInfo.IsTag("Shoot"))
        {
            if (enemyDamageZone.GetComponent<EnemyDamage>().hasDied == false)
            {
                nav.isStopped = true;
                nav.acceleration = 180;
                hurtUI.gameObject.SetActive(true);
                Vector3 pos = (player.position - enemy.transform.position).normalized;
                Quaternion posRotation = Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z));
                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, posRotation, Time.deltaTime * attackRotateSpeed);
            }
        }

        if (bossInfo.IsTag("Hurt"))
        {
            shootScript.GetComponent<SimpleShoot1>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PKnife"))
        {
            anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PAxe"))
        {
            anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PBat"))
        {
            anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PCrossbow"))
        {
            anim.SetTrigger("BigReact");
        }
    }
}
