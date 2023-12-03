using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public GameObject aI;
    public GameObject invAI;
    public GameObject keyNeeded;
    //private  message, interact;

    public GameObject playerNearDoor;
    private Animator m_Animator;
    public bool nearThisDoor;
    public bool isUnlocked;

    void Start()
    {
        m_Animator = this.GetComponent<Animator>();
        m_Animator.SetBool("isOpen", false);
        aI.GetComponent<AIScript>().interact.SetActive(false);
        nearThisDoor = false;
    }

    void Update()
    {
        if (nearThisDoor == true)
        {
            
            if (playerNearDoor.GetComponent<ifNearDoor>().inFront || playerNearDoor.GetComponent<ifNearDoor>().inBack)
            {
                //Debug.Log("PLAYER NEAR DOOR");
                aI.GetComponent<AIScript>().interact.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    if (isUnlocked)
                    {
                        if (m_Animator.GetBool("isOpen") == true)
                        {
                            m_Animator.SetBool("isOpen", false);
                        }
                        else
                        {
                            if (playerNearDoor.GetComponent<ifNearDoor>().inFront)
                            {
                                m_Animator.SetTrigger("front");
                            }
                            if (playerNearDoor.GetComponent<ifNearDoor>().inBack)
                            {
                                m_Animator.SetTrigger("back");
                            }
                            m_Animator.SetBool("isOpen", true);
                        }
                    }
                    else
                    {
                        if (invAI.GetComponent<InventoryScript>().equipped == keyNeeded)
                        {
                            //Debug.Log(invAI.GetComponent<InventoryScript>().invObjects.IndexOf(keyNeeded.transform.parent.gameObject));
                            keyNeeded.GetComponent<InvEnableMesh>().meshForItem.SetActive(false);
                            keyNeeded.transform.parent.gameObject.SetActive(false);
                            invAI.GetComponent<InventoryScript>().invObjects.RemoveAt(invAI.GetComponent<InventoryScript>().invObjects.IndexOf(keyNeeded.transform.parent.gameObject));
                            isUnlocked = true;
                        }
                        else
                        {
                            aI.GetComponent<AIScript>().message.text = "It seems to be locked...";
                            StartCoroutine(wait());
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerNear"))
        {
            nearThisDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerNear"))
        {
            nearThisDoor = false;
            aI.GetComponent<AIScript>().message.text = "";
            aI.GetComponent<AIScript>().interact.SetActive(false);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5);
        aI.GetComponent<AIScript>().message.text = "";
    }
}
