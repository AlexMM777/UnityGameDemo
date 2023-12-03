using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnScript : MonoBehaviour
{
    public Animator m_Animator;
    public bool m_walk;

    void Start()
    {
        m_walk = true;
    }

    void Update()
    {
        m_Animator.SetBool("isWalking", m_walk);
    }

    public void activateAttackAnimation()
    {
        m_Animator.SetTrigger("isAttacking");
    }
}
