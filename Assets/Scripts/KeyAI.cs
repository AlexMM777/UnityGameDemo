using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAI : MonoBehaviour
{
    public GameObject playerNear;
    public bool nearThisKey;
    public GameObject invAI, keyInv, aI, thisKey;
    //public GameObject doorThatCanOpen;

    void Start()
    {
        nearThisKey = false;
    }

    void Update()
    {
        if (nearThisKey)
        {
            aI.GetComponent<AIScript>().interact.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                invAI.GetComponent<InventoryScript>().invObjects.Add(keyInv);
                //invAI.GetComponent<InventoryScript>().itemAssigned.Add(keyInv);
                aI.GetComponent<AIScript>().interact.SetActive(false);
                thisKey.SetActive(false);
                Destroy(this);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerNear"))
        {
            nearThisKey = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerNear"))
        {
            nearThisKey = false;
            aI.GetComponent<AIScript>().message.text = "";
            aI.GetComponent<AIScript>().interact.SetActive(false);
        }
    }
}
