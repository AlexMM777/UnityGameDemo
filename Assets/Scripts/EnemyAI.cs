using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent enemyNavMesh;
    public Transform playerTransform;
    public Transform[] waypoints;
    public  bool sawPlayer;
    public int x, xPrev;
    public GameObject player, enemy;
    public GameObject enemyBody;
    public bool hurt, stillThere;
    public float timer;
    public float cooldownTime;
    private bool isCoolingDown;
    public int hideTimer, randomSound;
    public bool outOfRange;
    public int enemyHealth, enemyDamage;
    public bool isDead;
    public bool changeX;
    //public AudioClip[] sounds;
    public AudioSource[] sounds;
    public AudioSource diedSound;

    void Start()
    {
        x = Random.Range(0, 4);
        xPrev = x;
        outOfRange = false;
        isCoolingDown = false;
        timer = 0;
        cooldownTime = 2;
        hideTimer = 0;
        isDead = false;
        //GetComponent<LookAtTarget>().enabled = false;
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            isDead = true;
            enemyBody.GetComponent<EnemyAnScript>().m_Animator.SetBool("isDead", true);
            enemy.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            StartCoroutine(died());
        }

        if (isDead == false)
        {
            if (changeX == true)
            {
                while (x == xPrev)
                {
                    x = Random.Range(0, 4);
                }
                xPrev = x;
                changeX = false;
            }

            if (timer <= 0)
            {
                isCoolingDown = false;
            }

            if (isCoolingDown)
            {
                timer -= Time.deltaTime;
            }

            if (sawPlayer == true)
            {
                enemyNavMesh.SetDestination(playerTransform.position);
                //GetComponent<LookAtTarget>().enabled = true;
            }

            if (sawPlayer == false)
            {
                //GetComponent<LookAtTarget>().enabled = false;
                outOfRange = true;
                enemyNavMesh.SetDestination(waypoints[x].position);
            }

            RaycastHit hit;
            if (Physics.Linecast(player.transform.position, enemy.transform.position, out hit))
            {
                if (hit.collider.CompareTag("Hide"))
                {
                    if (sawPlayer)
                    {
                        hideTimer++;
                    }
                }
            }
            if (hideTimer >= 250)
            {
                sawPlayer = false;
            }

            if (outOfRange == true)
            {
                hideTimer++;
                enemyBody.GetComponent<EnemyAnScript>().m_walk = true;
            }

            if (hurt == true)
            {
                player.GetComponent<Player>().health = player.GetComponent<Player>().health - enemyDamage;
                hurt = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead == false)
        {
            if (player.GetComponent<Player>().dead == false)
            {
                if (sawPlayer == false)
                {
                    if (other.gameObject.CompareTag("Waypoint"))
                    {
                        StartCoroutine(changeXCoroutine());
                    }
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    if (sawPlayer == true)
                    {
                        hideTimer = 0;
                        outOfRange = false;
                        enemyBody.GetComponent<EnemyAnScript>().m_walk = false;
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isDead == false)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (sawPlayer == true)
                {
                    if (player.GetComponent<Player>().dead == false)
                    {
                        if (isCoolingDown == false)
                        {
                            attack();
                            stillThere = true;
                            isCoolingDown = true;
                            timer = cooldownTime;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isDead == false)
        {
            if (player.GetComponent<Player>().dead == false)
            {
                if (sawPlayer == true)
                {
                    if (other.gameObject.CompareTag("Player"))
                    {
                        stillThere = false;
                        hurt = false;
                        outOfRange = true;
                        enemyBody.GetComponent<EnemyAnScript>().m_walk = true;
                    }
                }
            }
        }
    }
    public void attack()
    {
        if (isDead == false)
        {
            enemyBody.GetComponent<EnemyAnScript>().activateAttackAnimation();
            if (stillThere == true)
            {
                hurt = true;
            }
        }
    }

    IEnumerator changeXCoroutine()
    {
        if (isDead == false)
        {
            enemyBody.GetComponent<EnemyAnScript>().m_walk = false;
            yield return new WaitForSeconds(Random.Range(7, 17));
            enemyBody.GetComponent<EnemyAnScript>().m_walk = true;
            changeX = true;
        }
    }

    IEnumerator died()
    {
        sounds[randomSound].Stop();
        enemyBody.GetComponent<EnemyAnScript>().m_walk = false;
        //GetComponent<LookAtTarget>().enabled = false;
        diedSound.Play();
        yield return new WaitForSeconds(7);
        Destroy(enemy);
    }

    public void GotHurt()
    {
        //GetComponent<AudioSource>().clip = sounds[0];
        sounds[randomSound].Stop();
        randomSound = Random.Range(0, sounds.Length - 1);
        sounds[randomSound].Play();
    }
}






