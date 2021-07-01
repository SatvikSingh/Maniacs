using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent nav;
    private NavMeshHit hit;
    private bool isBlocked = false;
    private bool runToPlayer = false;
    private float distanceFromPlayer;
    private bool isChecking = true;
    private int failedChecks = 0;
    private bool canRun = false;

    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] GameObject enemy;
    [SerializeField] float maxRange = 35.0f;
    [SerializeField] int maxChecks = 3;
    [SerializeField] float chaseSpeed = 8.5f;
    [SerializeField] float walkSpeed = 1.6f;
    [SerializeField] float attackDistance = 2.3f;
    [SerializeField] float attackRotateSpeed = 2.0f;
    [SerializeField] float checkTime = 3.0f;
    [SerializeField] GameObject chaseMusic;
    [SerializeField] GameObject hurtUI;
    [SerializeField] GameObject enemyDamageZone;
    [SerializeField] bool iHaveKnife;
    [SerializeField] bool iHaveBat;
    [SerializeField] bool iHaveAxe;

    private void Start()
    {
        nav = GetComponentInParent<NavMeshAgent>();
        StartCoroutine(StartElements());
        StartCoroutine(StartWalking());
    }

    private void Update()
    {
        if (canRun == true)
        {
            if (enemyDamageZone.GetComponent<EnemyDamage>().hasDied == true)
            {
                chaseMusic.gameObject.SetActive(false);
            }

            distanceFromPlayer = Vector3.Distance(player.position, enemy.transform.position);

            if (distanceFromPlayer < maxRange)
            {
                if (isChecking == true)
                {
                    isChecking = false;
                    isBlocked = NavMesh.Raycast(transform.position, player.position, out hit, NavMesh.AllAreas);

                    if (isBlocked == false)
                    {
                        Debug.Log("I can see the Player");
                        runToPlayer = true;
                        failedChecks = 0;
                    }
                    if (isBlocked == true)
                    {
                        Debug.Log("I can't see the Player");
                        runToPlayer = false;
                        anim.SetInteger("State", 1);
                        failedChecks++;
                    }
                    StartCoroutine(TimedCheck());
                }
            }
            if (runToPlayer == true)
            {
                enemy.GetComponent<EnemyMove>().enabled = false;
                if (enemyDamageZone.GetComponent<EnemyDamage>().hasDied == false)
                {
                    chaseMusic.gameObject.SetActive(true);
                }
                if (distanceFromPlayer > attackDistance)
                {
                    nav.isStopped = false;
                    anim.SetInteger("State", 2);
                    nav.acceleration = 25;
                    nav.SetDestination(player.position);
                    nav.speed = chaseSpeed;
                    hurtUI.gameObject.SetActive(false);
                }
                if (distanceFromPlayer < attackDistance - 0.5f)
                {
                    nav.isStopped = true;
                    if (iHaveAxe == true)
                    {
                        anim.SetInteger("State", 3);
                    }
                    if (iHaveBat == true)
                    {
                        anim.SetInteger("State", 4);
                    }
                    if (iHaveKnife == true)
                    {
                        anim.SetInteger("State", 5);
                    }
                    nav.acceleration = 180;
                    hurtUI.gameObject.SetActive(true);

                    Vector3 pos = (player.position - enemy.transform.position).normalized;
                    Quaternion posRotation = Quaternion.LookRotation(new Vector3(pos.x, 0, pos.z));
                    enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, posRotation, Time.deltaTime * attackRotateSpeed);
                }
            }
            else if (runToPlayer == false)
            {
                nav.isStopped = true;
            }
        }
    }

    IEnumerator StartWalking()
    {
        yield return new WaitForSeconds(1.0f);
        runToPlayer = true;
        yield return new WaitForSeconds(0.1f);
        runToPlayer = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            runToPlayer = true;
        }

        if (other.gameObject.CompareTag("PKnife"))
        {
            anim.SetTrigger("SmallReact");
        }
        if (other.gameObject.CompareTag("PAxe"))
        {
            anim.SetTrigger("BigReact");
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

    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(checkTime);
        isChecking = true;

        if (failedChecks > maxChecks)
        {
            enemy.GetComponent<EnemyMove>().enabled = true;
            nav.isStopped = false;
            nav.speed = walkSpeed;
            failedChecks = 0;
            chaseMusic.gameObject.SetActive(false);
        }
    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        player = SaveScript.playerChar;
        chaseMusic = SaveScript.chase;
        hurtUI = SaveScript.hurtScreen;
        chaseMusic.gameObject.SetActive(false);
        canRun = true;
        checkTime = Random.Range(3, 15);
    }
}
