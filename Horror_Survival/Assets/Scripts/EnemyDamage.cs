using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] public int enemyHealth = 100;
    public int knifeDamage = 20;
    public int batDamage = 25;
    public int axeDamage = 35;
    public int arrowDamage = 100;

    [SerializeField] AudioSource stabPlayer;
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject bloodSplatKnife;
    [SerializeField] GameObject bloodSplatBat;
    [SerializeField] GameObject bloodSplatAxe;
    [SerializeField] bool isBoss = false;

    private AudioSource myPlayer;
    public bool hasDied = false;
    private Animator anim;
    private bool damageOn = false;

    void Start()
    {
        myPlayer = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
        StartCoroutine(StartElements());
    }

    private void Update()
    {
        if (damageOn == true)
        {
            if (enemyHealth <= 0)
            {
                if (hasDied == false)
                {
                    anim.SetTrigger("Death");
                    anim.SetBool("IsDead", true);
                    hasDied = true;
                    SaveScript.enemiesOnScreen--;

                    Destroy(this.transform.parent.gameObject, 25f);
                }
            }

            if (isBoss == true)
            {
                if (enemyHealth <= 0)
                {
                    if (hasDied == false)
                    {
                        anim.SetTrigger("BossDead");
                        hasDied = true;
                        StartCoroutine(LoadFinalScene());
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PKnife"))
        {
            enemyHealth -= knifeDamage;
            myPlayer.Play();
            stabPlayer.Play();
            bloodSplatKnife.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("PBat"))
        {
            enemyHealth -= batDamage;
            myPlayer.Play();
            stabPlayer.Play();
            bloodSplatBat.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("PAxe"))
        {
            enemyHealth -= axeDamage;
            myPlayer.Play();
            stabPlayer.Play();
            bloodSplatAxe.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("PCrossbow"))
        {
            enemyHealth -= arrowDamage;
            Destroy(other.gameObject, 0.05f);
        }
    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);
        stabPlayer = SaveScript.stabSound;
        bloodSplatKnife = SaveScript.splatKnife;
        bloodSplatAxe = SaveScript.splatAxe;
        bloodSplatBat = SaveScript.splatBat;
        bloodSplatKnife.gameObject.SetActive(false);
        bloodSplatBat.gameObject.SetActive(false);
        bloodSplatAxe.gameObject.SetActive(false);
        damageOn = true;
    }

    IEnumerator LoadFinalScene()
    {
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene(4);
    }
}
