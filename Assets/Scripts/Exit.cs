using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject aI;
    public GameObject invAI;
    public GameObject keyNeeded;
    public string sceneToLoad;
    public GameObject playerNearDoor;
    public bool nearThisDoor;
    public bool isUnlocked;

    void Start()
    {
        aI.GetComponent<AIScript>().interact.SetActive(false);
        nearThisDoor = false;
    }

    void Update()
    {
        if (nearThisDoor == true)
        {

            if (playerNearDoor.GetComponent<ifNearDoor>().inFront)
            {
                aI.GetComponent<AIScript>().interact.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    if (isUnlocked)
                    {
                        //Debug.Log("OPENED!!!");
                        SceneManager.LoadScene(sceneToLoad);
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
