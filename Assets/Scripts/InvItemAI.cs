using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvItemAI : MonoBehaviour
{
    public GameObject playerNear;
    public bool nearThis;
    public GameObject invAI, itemInvImage, aI, thisItem;
    //public GameObject doorThatCanOpen;

    void Start()
    {
        nearThis = false;
    }

    void Update()
    {
        if (nearThis)
        {
            aI.GetComponent<AIScript>().interact.SetActive(true);
            if (Input.GetKeyDown("e"))
            {
                invAI.GetComponent<InventoryScript>().invObjects.Add(itemInvImage);
                //invAI.GetComponent<InventoryScript>().itemAssigned.Add(keyInv);
                aI.GetComponent<AIScript>().interact.SetActive(false);
                thisItem.SetActive(false);
                Destroy(this);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerNear"))
        {
            nearThis = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerNear"))
        {
            nearThis = false;
            aI.GetComponent<AIScript>().message.text = "";
            aI.GetComponent<AIScript>().interact.SetActive(false);
        }
    }
}
