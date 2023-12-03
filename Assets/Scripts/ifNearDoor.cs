using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifNearDoor : MonoBehaviour
{
    public bool inBack, inFront;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Back"))
        {
            inBack = true;
            inFront = false;
        }
        if (other.gameObject.CompareTag("Front"))
        {
            inBack = false;
            inFront = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Back") || other.gameObject.CompareTag("Front"))
        {
            inBack = false;
            inFront = false;
        }
    }
}
