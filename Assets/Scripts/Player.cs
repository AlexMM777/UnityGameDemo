using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health, maxHealth;
    public bool dead, onGround, onObject;
    //public GameObject enemy;
    //public GameObject[] enemies;
    //public GameObject inventory, pauseMenu;
    public int x;
    public GameObject playerBody;
    public float timer;
    public float cooldownTime;
    private bool isCoolingDown;
    //public HealthBar healthBar;

    void Start()
    {
        x = 0;
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        dead = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        isCoolingDown = false;
        timer = 0;
        cooldownTime = 1;
    }

    void Update()
    {
        //Debug.Log(health);
        /*if (dead == false)
        {
            if (health <= 0)
            {
                Debug.Log("GAME OVER!");
                dead = true;
            }
        }
        if (dead == false)
        {
            if (!inventory.activeSelf && !pauseMenu.activeSelf)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playerBody.GetComponent<PlayerAnScript>().m_Animator.SetTrigger("punchMid");
                }
            }

            if (timer <= 0)
            {
                isCoolingDown = false;
            }

            if (isCoolingDown)
            {
                timer -= Time.deltaTime;
            }
        }
        healthBar.SetHealth(health);
        */
        
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.gameObject.CompareTag("Enemy"))
        {
            if (inventory.activeSelf == false)
            {
                if (dead == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        //Debug.Log("HURT ENEMY");
                        playerBody.GetComponent<PlayerAnScript>().m_Animator.SetTrigger("punchMid");
                        other.gameObject.GetComponent<EnemyAI>().enemyHealth = other.gameObject.GetComponent<EnemyAI>().enemyHealth - 10;
                        StartCoroutine(attacked());
                        //enemies[x].GetComponent<EnemyAI>().enemyHealth = enemies[x].GetComponent<EnemyAI>().enemyHealth - 10;
                        
                        if (isCoolingDown == false)
                        {
                            attack(other);
                            isCoolingDown = true;
                            timer = cooldownTime;
                        }
                    }
                }
            }
        }*/
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        

    }
        /* IEnumerator attacked()
         {
             //enemyBody.transform.position = new Vector3(0.007689476f, -0.3377469f, -0.06599998f);
             //enemyBody.transform.localEulerAngles = new Vector3(0,0,176.091f);
             yield return new WaitForSeconds(2);
         }*/

        /*public void attack(Collider other)
    {
        if (dead == false)
        {
            if (other.gameObject.GetComponent<EnemyAI>().enemyHealth > 0)
            {
                other.gameObject.GetComponent<EnemyAI>().enemyHealth = other.gameObject.GetComponent<EnemyAI>().enemyHealth - 10;
                other.gameObject.GetComponent<EnemyAI>().GotHurt();
            }
        }
    }*/



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
