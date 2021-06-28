using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Transform theTarget;
    private float distanceFromTarget;
    private int targetNum = 1;
    private bool hasStopped = false;
    private bool randomizer = true;
    private int nextTargetNum;
    private bool canPatrol = false;
    [SerializeField] int maxTargets = 10;
    [SerializeField] float waitTime = 2.0f;

    // Targets
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;
    [SerializeField] Transform target3;
    [SerializeField] Transform target4;
    [SerializeField] Transform target5;
    [SerializeField] Transform target6;
    [SerializeField] Transform target7;
    [SerializeField] Transform target8;
    [SerializeField] Transform target9;
    [SerializeField] Transform target10;

    [SerializeField] float stopDistance = 2.0f;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        StartCoroutine(StartElements());
    }

    private void Update()
    {
        if (canPatrol == true)
        {
            distanceFromTarget = Vector3.Distance(theTarget.position, transform.position);
            if (distanceFromTarget > stopDistance)
            {
                nav.SetDestination(theTarget.position);
                anim.SetInteger("State", 0);
                nav.isStopped = false;
                nextTargetNum = targetNum;
                nav.speed = 1.6f;
            }
            if (distanceFromTarget < stopDistance)
            {
                nav.isStopped = true;
                anim.SetInteger("State", 1);
                StartCoroutine(LookAround());
            }
        }
    }

    void SetTarget()
    {
        if (targetNum == 1)
        {
            theTarget = target1;
        }
        if (targetNum == 2)
        {
            theTarget = target2;
        }
        if (targetNum == 3)
        {
            theTarget = target3;
        }
        if (targetNum == 4)
        {
            theTarget = target4;
        }
        if (targetNum == 5)
        {
            theTarget = target5;
        }
        if (targetNum == 6)
        {
            theTarget = target6;
        }
        if (targetNum == 7)
        {
            theTarget = target7;
        }
        if (targetNum == 8)
        {
            theTarget = target8;
        }
        if (targetNum == 9)
        {
            theTarget = target9;
        }
        if (targetNum == 10)
        {
            theTarget = target10;
        }
    }

    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(waitTime);
        if (hasStopped == false)
        {
            hasStopped = true;
            if (randomizer == true)
            {
                randomizer = false;
                targetNum = Random.Range(1, maxTargets);
                if (targetNum == nextTargetNum)
                {
                    targetNum++;
                    if (targetNum >= maxTargets)
                    {
                        targetNum = 1;
                    }
                }              
            }
            SetTarget();
            yield return new WaitForSeconds(waitTime);
            hasStopped = false;
            randomizer = true;
        }         
    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        target1 = SaveScript.target1;
        target2 = SaveScript.target2;
        target3 = SaveScript.target3;
        target4 = SaveScript.target4;
        target5 = SaveScript.target5;
        target6 = SaveScript.target6;
        target7 = SaveScript.target7;
        target8 = SaveScript.target8;
        target9 = SaveScript.target9;
        target10 = SaveScript.target10;
        theTarget = target1;
        nav.avoidancePriority = Random.Range(5, 65);
        canPatrol = true;
    }
}
