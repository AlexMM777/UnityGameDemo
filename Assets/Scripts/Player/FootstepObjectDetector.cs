using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepObjectDetector : MonoBehaviour
{
    public GameObject playerBody;
    public bool currentlyOnObj;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (playerBody.GetComponent<FootSteps>().isOnGround)
        {
            if (other.gameObject.tag == "Stone")
            {
                playerBody.GetComponent<FootSteps>().isOnObj = true;
                //Debug.Log("Stone");
                playerBody.GetComponent<FootSteps>().chosenSounds = playerBody.GetComponent<FootSteps>().stoneSteps;
                playerBody.GetComponent<FootSteps>().ChooseRandom();
                currentlyOnObj = true;
            }

            if (other.gameObject.tag == "Wood")
            {
                playerBody.GetComponent<FootSteps>().isOnObj = true;
                //Debug.Log("Wood");
                playerBody.GetComponent<FootSteps>().chosenSounds = playerBody.GetComponent<FootSteps>().woodSteps;
                playerBody.GetComponent<FootSteps>().ChooseRandom();
                currentlyOnObj = true;
            }
            if (other.gameObject.tag == "Carpet")
            {
                playerBody.GetComponent<FootSteps>().isOnObj = true;
                //Debug.Log("Carpet");
                playerBody.GetComponent<FootSteps>().chosenSounds = playerBody.GetComponent<FootSteps>().carpetSteps;
                playerBody.GetComponent<FootSteps>().ChooseRandom();
                currentlyOnObj = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Stone")||(other.gameObject.tag == "Wood") || (other.gameObject.tag == "Carpet"))
        {
            currentlyOnObj = false;
            StartCoroutine(CheckIfOnObjStill());
        }
    }

    IEnumerator CheckIfOnObjStill()
    {
        yield return new WaitForSecondsRealtime(1);
        if (!currentlyOnObj)
        {
            playerBody.GetComponent<FootSteps>().isOnObj = false;
        }
    }
}
