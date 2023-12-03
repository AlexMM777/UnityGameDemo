using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(enemy.GetComponent<EnemyAI>().sawPlayer == false)
            {
                //Debug.Log("Saw Player");
                enemy.GetComponent<EnemyAI>().sawPlayer = true;
            }
        }
    }
}
