using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingAt : MonoBehaviour
{
    public GameObject interactableObj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //interactableObj = other.gameObject;
        if (other.gameObject.CompareTag("Interactable"))
        {
            interactableObj = other.gameObject;
            Debug.Log("LOOKED");
            interactableObj.GetComponent<InteractableScript>().isLooking = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            interactableObj.GetComponent<InteractableScript>().isLooking = false;
        }
    }
}
